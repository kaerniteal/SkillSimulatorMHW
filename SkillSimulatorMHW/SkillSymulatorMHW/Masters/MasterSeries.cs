namespace SkillSimulatorMHW.Masters
{
    /// <summary>
    /// シリーズマスタ.
    /// </summary>
    public class MasterSeries : MasterBase<MasterSeriesData>
    {
        /// <summary>
        /// コンストラクタ.
        /// </summary>
        public MasterSeries()
            : base(@"Csv/Series.csv")
        {
        }
    }
}
