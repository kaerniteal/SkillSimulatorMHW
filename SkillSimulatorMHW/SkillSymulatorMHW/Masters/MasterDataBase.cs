namespace SkillSimulatorMHW.Masters
{
    /// <summary>
    /// マスタデータ基底.
    /// </summary>
    public abstract class MasterDataBase
    {
        /// <summary>
        /// ユニークなIndexを取得する.
        /// </summary>
        /// <returns>Index</returns>
        public abstract int GetIndex();

        /// <summary>
        /// フィルタ対象文字列を取得する.
        /// </summary>
        /// <returns></returns>
        public abstract string GetFilterText();

        /// <summary>
        /// CSV行データをセットする.
        /// </summary>
        /// <param name="row"></param>
        public abstract void SetFromCsv(CsvIo.CsvRow row);

        /// <summary>
        /// CSV行データを取得する
        /// </summary>
        /// <returns></returns>
        public abstract CsvIo.CsvRow GetCsvRow();
    }
}
