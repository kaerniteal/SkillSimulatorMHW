namespace SkillSimulatorMHW.Masters
{
    /// <summary>
    /// 護石マスタ.
    /// </summary>
    public class MasterAmulet : MasterBase<MasterAmuletData>
    {
        /// <summary>
        /// コンストラクタ.
        /// </summary>
        public MasterAmulet()
            : base(@"Csv/Amulet.csv")
        {
        }
    }
}
