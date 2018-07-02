using System;
using System.Collections.Generic;
using SkillSimulatorMHW.Extensions;

namespace SkillSimulatorMHW.Masters
{
    /// <summary>
    /// スキルマスタデータ.
    /// </summary>
    public class MasterSkillData : MasterDataBase, IEquatable<MasterSkillData>
    {
        /// <summary>
        /// コンストラクタ.
        /// </summary>
        public MasterSkillData()
        {
            this.Index = 0;
            this.Name = "なし";
            this.Kana = string.Empty;
            this.SeriesId = 0;
            this.Need = 0;
            this.MaxLv = 0;
            this.Remarks = string.Empty;
            this.CacheMasterSeriesData = null;
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
        /// シリーズスキルId
        /// </summary>
        public int SeriesId { get; set; }

        /// <summary>
        /// 必要数.
        /// </summary>
        public int Need { get; set; }

        /// <summary>
        /// 最大Lv
        /// </summary>
        public int MaxLv { get; set; }

        /// <summary>
        /// 備考.
        /// </summary>
        public string Remarks { get; set; }

        /// <summary>
        /// シリーズスキル(キャッシュを保持)
        /// </summary>
        private MasterSeriesData CacheMasterSeriesData { get; set; }

        /// <summary>
        /// シリーズスキル
        /// </summary>
        public MasterSeriesData GetSeries()
        {
            if (null == this.CacheMasterSeriesData && this.IsSeries())
            {
                this.CacheMasterSeriesData = Ssm.Master.MasterSeries.GetRecord(this.SeriesId);
            }

            return this.CacheMasterSeriesData;
        }

        /// <summary>
        /// シリーズスキルかどうか.
        /// </summary>
        /// <returns></returns>
        public bool IsSeries()
        {
            return 0 != this.SeriesId;
        }

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
            this.Name =  row[1];
            this.Kana =  row[2];
            this.SeriesId = row[3].CsvToIntNotNull();
            this.Need =     row[4].CsvToIntNotNull();
            this.MaxLv =    row[5].CsvToIntNotNull();
            this.Remarks = row[6];
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
                this.SeriesId.ToString(),
                this.Need.ToString(),
                this.MaxLv.ToString(),
                this.Remarks,
            });
        }

        /// <summary>
        /// 文字列化のオーバーライド.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            var series = this.GetSeries();
            return null == series
                ? this.Name
                : "{0} 【{1}：{2}】".Fmt(this.Name, series.Name, this.Need);
        }

        /// <summary>
        /// 一致を確認.
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(MasterSkillData other)
        {
            if (0 == this.Index || null == other || 0 == other.Index)
            {
                return false;
            }

            return this.Index == other.Index;
        }
    }
}
