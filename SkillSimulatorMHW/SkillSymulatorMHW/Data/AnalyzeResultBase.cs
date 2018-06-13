using System.Collections.Generic;
using SkillSimulatorMHW.Result;

namespace SkillSimulatorMHW.Data
{
    /// <summary>
    /// 要因解析データ基底.
    /// </summary>
    public abstract class AnalyzeResultBase
    {
        /// <summary>
        /// 解析結果タイプ.
        /// </summary>
        public enum AnalyzeResultType
        {
            Satisfied,
            ShortageSkill,
            ShortageSlot,
        }

        /// <summary>
        /// コンストラクタ.
        /// </summary>
        public AnalyzeResultBase(string key, List<ResultSet> resultSetList)
        {
            this.Key = key;
            this.ResultSetList = resultSetList;
        }

        /// <summary>
        /// KEY文字列.
        /// </summary>
        protected string Key { get; set; }

        /// <summary>
        /// 結果セットリスト.
        /// </summary>
        public List<ResultSet> ResultSetList { get; set; }

        /// <summary>
        /// 解析結果タイプを返す.
        /// </summary>
        /// <returns></returns>
        public abstract AnalyzeResultType GetAnalyzeResultType();

        /// <summary>
        /// 要因を説明する文字列を取得.
        /// </summary>
        /// <returns></returns>
        public abstract string GetFactor();

        /// <summary>
        /// 詳細を説明する文字列を取得.
        /// </summary>
        /// <returns></returns>
        public abstract string GetDetails();

        /// <summary>
        /// 発令までに惜しいかどうか
        /// </summary>
        /// <returns></returns>
        public abstract bool IsNearly();
    }
}
