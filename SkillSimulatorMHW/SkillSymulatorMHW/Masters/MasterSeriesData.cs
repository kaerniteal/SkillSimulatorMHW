using System.Collections.Generic;
using SkillSimulatorMHW.Defines;
using SkillSimulatorMHW.Extensions;

namespace SkillSimulatorMHW.Masters
{
    /// <summary>
    /// シリーズマスタデータ.
    /// </summary>
    public class MasterSeriesData : MasterDataBase
    {
        /// <summary>
        /// コンストラクタ.
        /// </summary>
        public MasterSeriesData()
        {
            this.Rank = Rank.Non;
        }

        /// <summary>
        /// Index
        /// </summary>
        public int Index { get; set; }

        /// <summary>
        /// 名称.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 読み
        /// </summary>
        public string Kana { get; set; }

        /// <summary>
        /// ランク
        /// </summary>
        public Rank Rank { get; set; }

        /// <summary>
        /// 備考.
        /// </summary>
        public string Remarks { get; set; }

        /// <summary>
        /// ユニークなIndexを取得する.
        /// </summary>
        /// <returns>Index</returns>
        public override int GetIndex()
        {
            return this.Index;
        }

        /// <summary>
        /// フィルタ対象文字列を取得する.
        /// </summary>
        /// <returns></returns>
        public override string GetFilterText()
        {
            return this.Name + this.Kana;
        }

        /// <summary>
        /// CSV行データをセットする.
        /// </summary>
        /// <param name="row"></param>
        public override void SetFromCsv(CsvIo.CsvRow row)
        {
            this.Index = row[0].CsvToIntNotNull();
            this.Name = row[1];
            this.Kana = row[2];
            this.Rank = row[3].CsvToEnum<Rank>();
            this.Remarks = row[4];
        }

        /// <summary>
        /// CSV行データを取得する
        /// </summary>
        /// <returns></returns>
        public override CsvIo.CsvRow GetCsvRow()
        {
            return new CsvIo.CsvRow(new List<string>
            {
                this.Index.ToString(),
                this.Name,
                this.Kana,
                ((int) this.Rank).ToString(),
                this.Remarks,
            });
        }
    }
}
