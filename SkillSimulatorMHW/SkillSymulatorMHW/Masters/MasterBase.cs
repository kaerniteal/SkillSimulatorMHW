using System;
using System.Collections.Generic;
using System.Linq;
using SkillSimulatorMHW.Extensions;

namespace SkillSimulatorMHW.Masters
{
    /// <summary>
    /// マスタ基底.
    /// </summary>
    public class MasterBase<TData>
        where TData : MasterDataBase, new()
    {
        /// <summary>
        /// コンストラクタ.
        /// </summary>
        protected MasterBase(string dataSrc)
        {
            this.DataSrc = dataSrc;
            this.Records = new Dictionary<int, TData>();
        }

        /// <summary>
        /// データソース.
        /// </summary>
        protected string DataSrc { get; set; }

        /// <summary>
        /// レコード.
        /// </summary>
        protected Dictionary<int, TData> Records { get; set; }

        /// <summary>
        /// レコードリストを取得
        /// </summary>
        /// <returns>レコードリスト</returns>
        public List<TData> GetRecordList()
        {
            return this.Records.Values
                .OrderBy(row => row.GetIndex())
                .ToList();
        }

        /// <summary>
        /// レコードを取得.
        /// </summary>
        /// <param name="index">インデックス</param>
        /// <returns>レコード</returns>
        public TData GetRecord(int index)
        {
            return this.Records.ContainsKey(index)
                ? this.Records[index]
                : null;
        }

        /// <summary>
        /// マスタデータ型のリストで取得.
        /// </summary>
        /// <returns></returns>
        public List<MasterDataBase> GetMasterDataList()
        {
            // IMasterData型に変換.
            return GetRecordList()
                .Select(rec => rec as MasterDataBase)
                .Where(rec => null != rec)
                .ToList();
        }

        /// <summary>
        /// マスタ初期化.
        /// </summary>
        public virtual bool Init()
        {
            var result = false;

            try
            {
                if (!this.DataSrc.IsEmpty())
                {
                    var csv = new CsvIo();
                    csv.Read(this.DataSrc);
                    foreach (var csvRow in csv.AllRows())
                    {
                        var row = new TData();
                        try
                        {
                            row.SetFromCsv(csvRow);
                            this.Records.Add(row.GetIndex(), row);
                        }
                        catch (Exception e)
                        {
                            Log.Write("マスタの変換に失敗しました ファイル[" + DataSrc + "] 行[" + csvRow + "] 例外["+ e.Message +"]");
                        }
                    }

                    result = true;
                }
            }
            catch(Exception)
            {
                // Do nothing.
            }

            if (!result)
            {
                Log.Write("マスタの読み込みに失敗しました ファイル[" + this.DataSrc + "]");
            }

            return result;
        }
    }
}
