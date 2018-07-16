using System.Collections.Generic;

namespace SkillSimulatorMHW.Data
{
    /// <summary>
    /// 検索中の状態レポート.
    /// </summary>
    public class SearchReport
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public SearchReport()
        {
            this.SatisfyList = new List<int>();
            this.UnsatisfyList = new List<int>();
            this.UnsatisfyBaseList = new List<SkillBase>();
            this.BlankSlotList = new List<int>();
            this.LackSlotList = new List<int>();
        }

        /// <summary>
        /// 要求を満たしているスキルIndexのリスト.
        /// </summary>
        public List<int> SatisfyList { get; set; }

        /// <summary>
        /// 要求を満たしていないスキルIndexのリスト.
        /// </summary>
        public List<int> UnsatisfyList { get; set; }

        /// <summary>
        /// 要求を満たしていないスキルデータのリスト.
        /// </summary>
        public List<SkillBase> UnsatisfyBaseList { get; set; }

        /// <summary>
        /// 空きスロットリスト.
        /// </summary>
        private List<int> BlankSlotList { get; set; }

        /// <summary>
        /// 不足スロットリスト
        /// </summary>
        public List<int> LackSlotList { get; set; }

        /// <summary>
        /// 不足スキルを表すKEY文字列を取得.
        /// </summary>
        /// <returns></returns>
        public string GetUnsatisfyKey()
        {
            var resultText = string.Empty;
            for (var i = 0; i < this.UnsatisfyList.Count; i++)
            {
                if (0 == i)
                {
                    resultText = this.UnsatisfyBaseList[i].GetText();
                }
                else
                {
                    resultText += "." + this.UnsatisfyBaseList[i].GetText();
                }
            }

            return resultText;
        }

        /// <summary>
        /// 不足スロットを表すKEY文字列を取得.
        /// </summary>
        /// <returns></returns>
        public string GetLackSlotKey()
        {
            return string.Join(".", this.LackSlotList);
        }
    }
}
