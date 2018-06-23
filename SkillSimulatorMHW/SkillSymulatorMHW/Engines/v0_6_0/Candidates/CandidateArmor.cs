using System.Collections.Generic;
using System.Linq;
using SkillSimulatorMHW.Data;
using SkillSimulatorMHW.Defines;
using SkillSimulatorMHW.Extensions;
using SkillSimulatorMHW.Masters;
using SkillSimulatorMHW.Requirements;

namespace SkillSimulatorMHW.Engines.v0_6_0.Candidates
{
    /// <summary>
    /// 検索候補データ防具
    /// </summary>
    public class CandidateArmor : CandidatePartBase
    {
        /// <summary>
        /// 静的コンストラクタ.
        /// </summary>
        static CandidateArmor()
        {
            TermsList = new List<TermsTypeData>
            {
                new TermsTypeData(TermsType.All),
                //new TermsTypeData(TermsType.Ignore),      TODO:nakamura 可能なら対応.
                //new TermsTypeData(TermsType.Possession),  TODO:nakamura 可能なら対応.
                new TermsTypeData(TermsType.Fixed),
            };
        }

        /// <summary>
        /// コンストラクタ(ファクトリ用インスタンス生成)
        /// </summary>
        /// <param name="part">部位</param>
        public CandidateArmor(Part part)
            : base(part, new List<CandidateData>())
        {
        }

        /// <summary>
        /// コンストラクタ(検索用データ生成.)
        /// </summary>
        /// <param name="part">部位</param>
        /// <param name="candidateList">候補リスト</param>
        protected CandidateArmor(Part part, List<CandidateData> candidateList)
            : base(part, candidateList)
        {
        }

        /// <summary>
        /// 防具コンボボックスアイテムリスト.
        /// </summary>
        public static List<TermsTypeData> TermsList { get; private set; }

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

            // 検索対象スキルのIndexリストを生成.
            var requirementAllSkillIdList = requirements.RequirementSkillList.GetAllIndexList();

            // 対象のマスタリストを生成する.
            var masterList = new List<MasterArmorData>();
            switch (requirementData.TermsType)
            {

                // 全リストの場合.
                case TermsType.All:
                    // 対象部位の全防具をリスト化
                    masterList = Ssm.Master.MasterArmor.GetPartList(this.Part)
                        .ToList();
                    break;

                // 除外リストの場合.
                case TermsType.Ignore:
                    // TODO:nakamura 除外リストを使用して、リストを生成して返す
                    Log.Write("【ERROR】防具の検索条件[{0}]は未実装です".Fmt(requirementData.TermsType));
                    masterList = new List<MasterArmorData>();
                    break;

                // 所持リストの場合.
                case TermsType.Possession:
                    // TODO:nakamura 所持リストを使用して、リストを生成して返す
                    Log.Write("【ERROR】防具の検索条件[{0}]は未実装です".Fmt(requirementData.TermsType));
                    masterList = new List<MasterArmorData>();
                    break;

                // 固定の場合.
                case TermsType.Fixed:
                    // 検索対象リストは不要.
                    break;

                // 上記以外のパターン.
                default:
                    Log.Write("【ERROR】防具の検索条件[{0}]は未実装です".Fmt(requirementData.TermsType));
                    break;
            }

            // マスタリストから条件を満たす防具をリスト化して返す.
            // ・該当レア度に収まる.
            // ・検索対象スキルを持つ
            var candidateList = masterList
                .Where(armor => requirements.RequirementRareData.Lower <= armor.Rare && armor.Rare <= requirements.RequirementRareData.Upper)
                .Where(armor => armor.HaveSkill(requirementAllSkillIdList))
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
                    var armor = candidate as PartDataArmor;
                    if (null == armor)
                    {
                        return false;
                    }

                    // シリーズスキルのリストも取得して加える
                    var allSkillList = armor.GetSeriesList();
                    allSkillList.AddRange(armor.GetSkillList());

                    // 通常防具の場合、要求を満たしていないスキルを持つ防具以外は除外する.
                    return allSkillList
                        .Any(skill =>
                        {
                            return searchReport.UnsatisfyList
                                .Contains(skill.Index);
                        });
                })
                .Select(candidate => new CandidateData(true, candidate))
                .ToList();

            // 1件目に未確定を挿入.
            filteredList.Insert(0, new CandidateData(true, new PartDataArmor(this.Part)));

            // 検索に使用するリストを格納して返す.
            return new CandidateArmor(this.Part, filteredList);
        }
    }
}
