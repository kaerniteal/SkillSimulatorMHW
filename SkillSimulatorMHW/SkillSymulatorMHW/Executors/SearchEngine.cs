using System.Collections.Generic;
using System.Linq;
using SkillSimulatorMHW.Interface;
using SkillSimulatorMHW.Requirements;
using SkillSimulatorMHW.Result;

namespace SkillSimulatorMHW.Executors
{
    /// <summary>
    /// 検索実行基底クラス.
    /// </summary>
    public abstract class SearchEngine : ProgressExecutorBase
    {
        /// <summary>
        /// 検索処理リスト.
        /// </summary>
        public static readonly List<SearchEngine> SearchEngines = new List<SearchEngine>
        {
            new SearchEngineLatest(),
            new SearchEngineStable(),
        };

        /// <summary>
        /// 検索処理を取得する.
        /// </summary>
        /// <returns></returns>
        public static SearchEngine GetSearchEngine()
        {
            var confId = Ssm.Config.SearchEngineId;
            return SearchEngines
                .FirstOrDefault(engine => engine.GetId() == confId);
        }

        /// <summary>
        /// 検索処理IDを返す.
        /// </summary>
        /// <returns>ID</returns>
        public abstract string GetId();

        /// <summary>
        /// パラメータセット.
        /// </summary>
        /// <param name="requirements">検索条件</param>
        /// <param name="mainForm">結果反映先</param>
        /// <param name="analyzeFactors">解析実施要否</param>
        public abstract void SetParam(Requirement requirements, IMainForm mainForm, bool analyzeFactors);

        /// <summary>
        /// 検索処理.
        /// </summary>
        public abstract ResultData Search();
    }
}
