namespace SkillSimulatorMHW.Masters
{
    /// <summary>
    /// スキルマスタ.
    /// </summary>
    public class MasterSkill : MasterBase<MasterSkillData>
    {
        /// <summary>
        /// コンストラクタ.
        /// </summary>
        public MasterSkill()
            : base(@"Csv/Skill.csv")
        {
        }
    }
}
