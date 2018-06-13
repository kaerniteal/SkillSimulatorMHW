using System.Collections.Generic;
using System.Linq;
using SkillSimulatorMHW.Data;

namespace SkillSimulatorMHW.Result
{
    /// <summary>
    /// 結果データセット.
    /// </summary>
    public class ResultData
    {
        /// <summary>
        /// コンストラクタ.
        /// </summary>
        public ResultData()
        {
            this.SatisfiedList = new List<ResultSet>();
            this.ShortageSkillDic = new Dictionary<string, List<ResultSet>>();
            this.ShortageSlotDic = new Dictionary<string, List<ResultSet>>();
        }

        /// <summary>
        /// 条件未達解析を実施したかどうか.
        /// </summary>
        public bool AnalyzeFactors { get; set; }

        /// <summary>
        /// 条件を満たしたセットリスト.
        /// </summary>
        private List<ResultSet> SatisfiedList { get; set; }

        /// <summary>
        /// スキル不足セット辞書.
        /// </summary>
        private Dictionary<string, List<ResultSet>> ShortageSkillDic { get; set; }

        /// <summary>
        /// スロット不足セット辞書.
        /// </summary>
        private Dictionary<string, List<ResultSet>> ShortageSlotDic { get; set; }

        /// <summary>
        /// 条件を満たしたセットを追加する.
        /// </summary>
        public void AddSatisfiedSet(ResultSet resultSet)
        {
            this.SatisfiedList.Add(resultSet);
        }

        /// <summary>
        /// スキル不足セットを追加する.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="resultSet"></param>
        public void AddShortageSkill(string key, ResultSet resultSet)
        {
            if (this.ShortageSkillDic.ContainsKey(key))
            {
                this.ShortageSkillDic[key].Add(resultSet);
            }
            else
            {
                this.ShortageSkillDic.Add(key, new List<ResultSet> { resultSet });
            }
        }

        /// <summary>
        /// スロット不足セットを追加する.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="resultSet"></param>
        public void AddShortageSlot(string key, ResultSet resultSet)
        {
            if (this.ShortageSlotDic.ContainsKey(key))
            {
                this.ShortageSlotDic[key].Add(resultSet);
            }
            else
            {
                this.ShortageSlotDic.Add(key, new List<ResultSet> { resultSet });
            }
        }

        /// <summary>
        /// 条件を満たしたセットを取得する.
        /// </summary>
        /// <returns></returns>
        public List<ResultSet> GetSatisfiedList()
        {
            return this.SatisfiedList;
        }

        /// <summary>
        /// スキル不足セットを取得する.
        /// </summary>
        /// <returns></returns>
        public List<ResultSet> GetShortageSkillList(string key)
        {
            return this.ShortageSkillDic.ContainsKey(key)
                ? this.ShortageSkillDic[key]
                : new List<ResultSet>();
        }

        /// <summary>
        /// スロット不足セットを取得する.
        /// </summary>
        /// <returns></returns>
        public List<ResultSet> GetShortageSlotList(string key)
        {
            return this.ShortageSlotDic.ContainsKey(key)
                ? this.ShortageSlotDic[key]
                : new List<ResultSet>();
        }

        /// <summary>
        /// 条件を満たしたセットの数を取得する.
        /// </summary>
        /// <returns></returns>
        public int GetSatisfiedCount()
        {
            return this.SatisfiedList.Count;
        }

        /// <summary>
        /// 解析結果一覧を取得する.
        /// </summary>
        /// <returns></returns>
        public List<AnalyzeResultBase> GetAnalyzeResultList()
        {
            var resultList = new List<AnalyzeResultBase>();

            // スキル不足を追加.
            resultList.AddRange(this.ShortageSkillDic
                .Keys
                .OrderBy(key => key)
                .Select(key => new AnalyzeResultShortageSkill(key, this.ShortageSkillDic[key]))
                .ToList());

            // スロット不足を追加.
            resultList.AddRange(this.ShortageSlotDic
                .Keys
                .OrderBy(key => key)
                .Select(key => new AnalyzeResultShortageSlot(key, this.ShortageSlotDic[key]))
                .ToList());

            // リストを返す.
            return resultList;
        }
    }
}
