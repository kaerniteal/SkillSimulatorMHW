namespace SkillSimulatorMHW.Masters
{
    /// <summary>
    /// 装飾品マスタデータ.
    /// </summary>
    public class MasterAccessoryAbstract : MasterAccessoryData
    {
        /// <summary>
        /// コンストラクタ.
        /// </summary>
        public MasterAccessoryAbstract(int slotLv)
        {
            this.Index = -1 * slotLv;
            this.SlotLv = slotLv;
        }

        /// <summary>
        /// 抽象化防具かどうか.
        /// </summary>
        /// <returns></returns>
        public override bool IsAbstract()
        {
            return true;
        }
    }
}
