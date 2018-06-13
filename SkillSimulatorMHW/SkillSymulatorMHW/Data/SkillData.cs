using SkillSimulatorMHW.Masters;
using SkillSimulatorMHW.Extensions;

namespace SkillSimulatorMHW.Data
{
    /// <summary>
    /// スキルデータ.
    /// </summary>
    public class SkillData : SkillBase
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public SkillData()
            : base(0, 1)
        {
            this.Skill = new MasterSkillData();
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public SkillData(MasterSkillData masterSkillData, int lv = 1)
            : base(masterSkillData.Index, lv)
        {
            this.Skill = masterSkillData;
        }

        /// <summary>
        /// スキル
        /// </summary>
        public MasterSkillData Skill { get; set; }

        /// <summary>
        /// シリーズスキルかどうか.
        /// </summary>
        /// <returns></returns>
        public bool IsSeries()
        {
            return this.Skill.IsSeries();
        }

        /// <summary>
        /// このスキルの文字列表現.
        /// </summary>
        /// <returns></returns>
        public override string GetText()
        {
            return this.IsSeries()
                ? "★{0}".Fmt(Skill.Name)
                : "Lv{0} {1}".Fmt(Lv, Skill.Name);
        }
    }
}
