namespace SkillSimulatorMHW.Data
{
    /// <summary>
    /// コンボボックスアイテムデータ.
    /// </summary>
    public class CmbItem<T>
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public CmbItem(string title, T value)
        {
            this.Title = title;
            this.Value = value;
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public CmbItem(T value)
        {
            this.Title = value.ToString();
            this.Value = value;
        }

        /// <summary>
        /// 見出し.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 値.
        /// </summary>
        public T Value { get; set; }

        /// <summary>
        /// 比較
        /// </summary>
        /// <returns></returns>
        public bool Equals(T dst)
        {
            return null != this.Value && this.Value.Equals(dst);
        }

        /// <summary>
        /// 文字列化(オーバライド)
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.Title;
        }
    }
}
