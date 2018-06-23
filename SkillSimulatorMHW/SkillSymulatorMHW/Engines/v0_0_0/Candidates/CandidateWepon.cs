using System.Collections.Generic;
using System.Linq;
using SkillSimulatorMHW.Data;
using SkillSimulatorMHW.Defines;
using SkillSimulatorMHW.Requirements;

namespace SkillSimulatorMHW.Engines.v0_0_0.Candidates
{
    /// <summary>
    /// 検索候補データ武器
    /// </summary>
    public class CandidateWepon : CandidatePartBase
    {
        /// <summary>
        /// 静的コンストラクタ.
        /// </summary>
        static CandidateWepon()
        {
            TermsList = new List<TermsTypeData>
            {
                new TermsTypeData(TermsType.Fixed),
            };
        }

        /// <summary>
        /// コンストラクタ(ファクトリ用インスタンス生成)
        /// </summary>
        public CandidateWepon()
            : base(Part.Wepon, new List<CandidateData>())
        {
        }

        /// <summary>
        /// コンストラクタ(検索用データ生成.)
        /// </summary>
        /// <param name="candidateList">候補リスト</param>
        protected CandidateWepon(List<CandidateData> candidateList)
            : base(Part.Wepon, candidateList)
        {
        }

        /// <summary>
        /// 武器コンボボックスアイテムリスト.
        /// </summary>
        public static List<TermsTypeData> TermsList { get; private set; }

        /// <summary>
        /// オリジナル検索候補リストを生成
        /// </summary>
        /// <param name="requirements">検索条件</param>
        /// <remarks>検索処理実施前のオリジナル候補装備リスト</remarks>
        public override List<PartDataBase> CreateOrgList(Requirement requirements)
        {
            // 武器は[使用しない OR 固定]なので、
            // 検索対象リストは不要.
            return new List<PartDataBase>();
        }

        /// <summary>
        /// 候補装備データのファクトリ.
        /// </summary>
        /// <param name="orgList">オリジナル検索候補リスト</param>
        /// <param name="searchReport">検索中の状態レポート</param>
        /// <returns></returns>
        public override CandidatePartBase CreateCandidate(List<PartDataBase> orgList, SearchReport searchReport)
        {
            // フィルタリング処理不要.
            var filteredList = orgList
                .Select(candidate => new CandidateData(true, candidate))
                .ToList();

            // フィルタリング処理不要(複製だけしておく).
            return new CandidateWepon(filteredList);
        }
    }
}
