using System.Collections.Generic;
using System.Linq;
using SkillSimulatorMHW.Data;
using SkillSimulatorMHW.Defines;
using SkillSimulatorMHW.Masters;
using SkillSimulatorMHW.Requirements;

namespace SkillSimulatorMHW.Engines.v0_6_0.Candidates
{
    /// <summary>
    /// 検索候補データ抽象化防具
    /// </summary>
    public class CandidateArmorAbstract : CandidatePartBase
    {
        /// <summary>
        /// コンストラクタ(ファクトリ用インスタンス生成)
        /// </summary>
        /// <param name="part">部位</param>
        public CandidateArmorAbstract(Part part)
            : base(part, new List<CandidateData>())
        {
        }

        /// <summary>
        /// コンストラクタ(検索用データ生成.)
        /// </summary>
        /// <param name="part">部位</param>
        /// <param name="candidateList">候補リスト</param>
        protected CandidateArmorAbstract(Part part, List<CandidateData> candidateList)
            : base(part, candidateList)
        {
        }

        /// <summary>
        /// オリジナル検索候補リストを生成
        /// </summary>
        /// <param name="requirements">検索条件</param>
        /// <remarks>検索処理実施前のオリジナル候補装備リスト</remarks>
        public override List<PartDataBase> CreateOrgList(Requirement requirements)
        {
            var requirementData = requirements.RequirementDataList.Get(this.Part);

            // 使用しない場合は空リストを格納したデータを返す.
            if (TermsType.Unused == requirementData.TermsType)
            {
                return new List<PartDataBase>();
            }

            // 対象の抽象化防具マスタリストを生成する.
            var masterList = MasterArmorAbstract.GetAbstractArmorList(this.Part);

            // マスタリストから条件を満たす防具をリスト化して返す.
            // ・該当レア度に収まる.
            var candidateList = masterList
                .Where(armor => requirements.RequirementRareData.Lower <= armor.Rare && armor.Rare <= requirements.RequirementRareData.Upper)
                .Select(armor => (PartDataBase)new PartDataArmor(armor))
                .ToList();

            // オリジナルリストを格納したデータを返す.
            return candidateList;
        }

        /// <summary>
        /// 候補装備データのファクトリ.
        /// </summary>
        /// <param name="orgList">オリジナル検索候補リスト</param>
        /// <param name="searchReport">検索中の状態レポート</param>
        /// <returns></returns>
        public override CandidatePartBase CreateCandidate(List<PartDataBase> orgList, SearchReport searchReport)
        {
            // オリジナル候補リストをさらに絞り込んでリスト化.
            var filteredList = orgList
                .Where(candidate =>
                {
                    // 不足スロットを越えるスロットを持つ防具は除外する.
                    var equippedSlot = new List<int>();
                    candidate.GetEquippedSlot(equippedSlot);

                    // スロット数が超える場合は助長.
                    if (searchReport.LackSlotList.Count < equippedSlot.Count)
                    {
                        return false;
                    }

                    // 不足スロットよりLvの高いスロットを持つ防具も助長
                    for (var i = 0; i < equippedSlot.Count; i++)
                    {
                        if (searchReport.LackSlotList[i] < equippedSlot[i])
                        {
                            return false;
                        }
                    }

                    return true;
                })
                .Select(candidate => new CandidateData(true, candidate))
                .ToList();

            // 1件目に候補なしを挿入しておく.
            filteredList.Insert(0, new CandidateData(true, new PartDataArmor(this.Part, PartState.NotExist)));

            // 検索に使用するリストを格納して返す.
            return new CandidateArmorAbstract(this.Part, filteredList);
        }
    }
}
