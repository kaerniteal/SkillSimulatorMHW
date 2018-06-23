namespace SkillSimulatorMHW.Data
{
    /// <summary>
    /// 検索候補データ
    /// </summary>
    public class CandidateData
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="enable">有効/無効</param>
        /// <param name="partData">検索候補装備</param>
        public CandidateData(bool enable, PartDataBase partData)
        {
            this.Enable = enable;
            this.PartData = partData;
        }

        /// <summary>
        /// 有効/無効.
        /// </summary>
        public bool Enable { get; set; }

        /// <summary>
        /// 検索候補装備.
        /// </summary>
        public PartDataBase PartData { get; set; }

     }
}
