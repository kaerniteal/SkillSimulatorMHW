using SkillSimulatorMHW.Masters;

namespace SkillSimulatorMHW.Data
{
    /// <summary>
    /// 装飾品データ.
    /// </summary>
    public class AccessoryData
    {
        /// <summary>
        /// コンストラクタ.
        /// </summary>
        public AccessoryData(MasterAccessoryData master, int possession)
        {
            this.Index = master.Index;
            this.Master = master;
            this.Possession = possession;
        }

        /// <summary>
        /// Index
        /// </summary>
        public int Index { get; set; }

        /// <summary>
        /// マスタデータ.
        /// </summary>
        public MasterAccessoryData Master { get; set; }

        /// <summary>
        /// 所持数
        /// </summary>
        public int Possession { get; set; }
    }
}
