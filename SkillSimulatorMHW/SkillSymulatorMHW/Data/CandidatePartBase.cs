using System.Collections.Generic;
using SkillSimulatorMHW.Defines;
using SkillSimulatorMHW.Requirements;

namespace SkillSimulatorMHW.Data
{
    /// <summary>
    /// 検索候補データ基底
    /// </summary>
    public abstract class CandidatePartBase
    {
        /// <summary>
        /// コンストラクタ(検索用データ生成.)
        /// </summary>
        /// <param name="part">部位</param>
        /// <param name="candidateList">候補リスト</param>
        protected CandidatePartBase(Part part, List<CandidateData> candidateList)
        {
            this.Part = part;
            this.CandidateList = candidateList;
        }

        /// <summary>
        /// 部位.
        /// </summary>
        public Part Part { get; set; }

        /// <summary>
        /// 検索候補装備リスト.
        /// </summary>
        private List<CandidateData> CandidateList { get; set; }

        /// <summary>
        /// 検索候補リスト数を取得する.
        /// </summary>
        /// <returns></returns>
        public int GetCount()
        {
            return null != this.CandidateList
                ? this.CandidateList.Count
                : 0;
        }

        /// <summary>
        /// 検索候補装備を取得する.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public CandidateData GetAt(int index)
        {
            return index < CandidateList.Count
                ? CandidateList[index]
                : new CandidateData(false, null);
        }

        /// <summary>
        /// オリジナル検索候補リストを生成
        /// </summary>
        /// <param name="requirements">検索条件</param>
        /// <remarks>検索処理実施前のオリジナル候補装備リスト</remarks>
        public abstract List<PartDataBase> CreateOrgList(Requirement requirements);

            /// <summary>
        /// 候補装備データのファクトリ.
        /// </summary>
        /// <param name="orgList">オリジナル検索候補リスト</param>
        /// <param name="searchReport">検索中の状態レポート</param>
        /// <returns></returns>
        public abstract CandidatePartBase CreateCandidate(List<PartDataBase> orgList, SearchReport searchReport);

        /// <summary>
        /// 上方互換候補の除外処理.
        /// </summary>
        /// <param name="done">条件を満たすセットが見つかった装備</param>
        /// <param name="searchReport">現状の検索状況</param>
        public virtual void RemoveUpwardCompatibility(PartDataBase done, SearchReport searchReport)
        {
            // 処置不要.
        }
    }
}
