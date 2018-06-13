using System.Collections.Generic;
using System.Linq;
using SkillSimulatorMHW.Extensions;
using SkillSimulatorMHW.Result;

namespace SkillSimulatorMHW.Data
{
    /// <summary>
    /// 要因解析データ(スキル不足).
    /// </summary>
    public class AnalyzeResultShortageSkill : AnalyzeResultBase
    {
        /// <summary>
        /// コンストラクタ.
        /// </summary>
        public AnalyzeResultShortageSkill(string key, List<ResultSet> resultSetList)
            : base(key, resultSetList)
        {
            this.SkillList = key.Split('.')
                .Select(SkillBase.CreateFromText)
                .ToList();

            var count = this.SkillList.Count;
            if (1 == count)
            {
                // 不足スキルが一個だけの場合.
                this.Factor = this.GetFactorText(this.SkillList[0]);
                this.Details = string.Empty;
            }
            else
            {
                // 不足スキルが複数の場合.
                var factorList = this.SkillList
                    .Select(this.GetFactorText)
                    .ToList();

                this.Factor = "{0}個のスキルが不足しています。".Fmt(count);
                this.Details = string.Join("\n", factorList);
            }
        }

        /// <summary>
        /// スキルデータを格納.
        /// </summary>
        private List<SkillBase> SkillList { get; set; }

        /// <summary>
        /// 要因文字列.
        /// </summary>
        private string Factor { get; set; }

        /// <summary>
        /// 詳細文字列.
        /// </summary>
        private string Details { get; set; }

        /// <summary>
        /// 解析結果タイプを返す.
        /// </summary>
        /// <returns></returns>
        public override AnalyzeResultType GetAnalyzeResultType()
        {
            return AnalyzeResultType.ShortageSkill;
        }

        /// <summary>
        /// 要因を説明する文字列を取得.
        /// </summary>
        /// <returns></returns>
        public override string GetFactor()
        {
            return this.Factor;
        }

        /// <summary>
        /// 詳細を説明する文字列を取得.
        /// </summary>
        /// <returns></returns>
        public override string GetDetails()
        {
            return this.Details;
        }

        /// <summary>
        /// 発令までに惜しいかどうか
        /// </summary>
        /// <returns></returns>
        public override bool IsNearly()
        {
            return 1 == this.SkillList.Count && 1 == this.SkillList[0].Lv;
        }

        /// <summary>
        /// 要因文字列を取得する.
        /// </summary>
        /// <param name="skillBase"></param>
        /// <returns></returns>
        private string GetFactorText(SkillBase skillBase)
        {
            var skill = Ssm.Master.MasterSkill.GetRecord(skillBase.Index);
            if (skill.IsSeries())
            {
                var series = skill.GetSeries();
                return "[{0}]を持つ装備が[{1}]個不足しています。".Fmt(series.Name, skillBase.Lv);
            }

            return "[{0}]スキルのLvが[{1}]不足しています。".Fmt(skill.Name, skillBase.Lv);
        }
    }
}
