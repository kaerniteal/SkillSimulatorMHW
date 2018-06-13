namespace SkillSimulatorMHW.Masters
{
    /// <summary>
    /// 装飾品マスタ.
    /// </summary>
    public class MasterAccessory : MasterBase<MasterAccessoryData>
    {
        /// <summary>
        /// コンストラクタ.
        /// </summary>
        public MasterAccessory()
            : base(@"Csv/Accessory.csv")
        {
        }
    }
}
