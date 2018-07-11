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
    /// 検索候補データ装飾品
    /// </summary>
    public class CandidateAccessory : CandidatePartBase
    {
        /// <summary>
        /// 静的コンストラクタ.
        /// </summary>
        static CandidateAccessory()
        {
            TermsList = new List<TermsTypeData>
            {
                new TermsTypeData(TermsType.Possession),
            };
        }

        /// <summary>
        /// コンストラクタ(ファクトリ用インスタンス生成)
        /// </summary>
        public CandidateAccessory()
            : base(Defines.Part.Accessory, new List<CandidateData>())
        {
        }

        /// <summary>
        /// コンストラクタ(検索用データ生成.)
        /// </summary>
        /// <param name="candidateList">候補リスト</param>
        protected CandidateAccessory(List<CandidateData> candidateList)
            : base(Defines.Part.Accessory, candidateList)
        {
        }

        /// <summary>
        /// 装飾品コンボボックスアイテムリスト.
        /// </summary>
        public static List<TermsTypeData> TermsList { get; private set; }

        /// <summary>
        /// オリジナル検索候補リストを生成
        /// </summary>
        /// <param name="requirements">検索条件</param>
        /// <remarks>検索処理実施前のオリジナル候補装備リスト</remarks>
        public override List<PartDataBase> CreateOrgList(Requirement requirements)
        {
            var requirementData = requirements.RequirementDataList.Get(Defines.Part.Accessory);

            // 装飾品リストだけは再起呼び出しの外側で処理されるため、
            // 装飾品ゼロ個の組み合わせが常に必要になる.
            // よって使用しない場合は0件の装飾品リストを持った候補1件のリストを返す.
            if (TermsType.Unused == requirementData.TermsType)
            {
                return new List<PartDataBase>
                {
                    // 0件の装飾品のリストを持った候補データ.
                    new PartDataAccessory(new List<MasterAccessoryData>())
                };
            }

            // 所持リストを使用のみ有効.

            // 検索対象スキルのIndexリストを生成.
            var requirementSkillIdList = requirements.RequirementSkillList.SkillList
                .Select(skill => skill.Index)
                .ToList();

            // 所持装飾品indexをグルーピングして、検索対象スキルを持っている物で絞る.
            // List<IGrouping<int, int>>
            //  key   :装飾品ID
            //  要素数:所持個数
            var groupList = requirementData.PossessionList
                .GroupBy(index => index)
                .Where(group =>
                {
                    // 対象の装飾品マスタを取得.
                    var master = Ssm.Master.MasterAccessory.GetRecord(group.Key);
                    if (null == master)
                    {
                        return false;
                    }

                    // 対象装飾品が検索対象スキルを所持する場合はリストに乗せる.
                    return master.GetAllMemberSkillIndexList()
                        .Any(index => requirementSkillIdList.Contains(index));
                })
                .ToList();

            // 所持装飾品の組み合わせ対象をマスタに変換してListのListのListへ変換.
            // List<List<List<MasterAccessoryData>>>
            // 外：装飾品毎
            //  中：0個、1個、2個。。。の組み合わせリスト
            //   内：装飾品マスタのリスト
            var allCombinationList = groupList
                .Select(group =>
                {
                    // 格納先リスト.
                    var listList = new List<List<MasterAccessoryData>>();

                    // 装飾品マスタを取得.
                    var master = Ssm.Master.MasterAccessory.GetRecord(group.Key);
                    if (null != master)
                    {
                        // 装飾品の所持スキルIndexリストを取得.
                        var skillIndexList = master.GetAllMemberSkillIndexList();

                        // 装飾品の対象スキルの要求レベルの中から最大を取得.
                        var maxRequirementLv = requirements.RequirementSkillList.SkillList
                            .Where(skill => skillIndexList.Contains(skill.Index))
                            .Max(skill => skill.Lv);

                        // 所持数と要求レベルの小さいほうを最大数とする.
                        var max = maxRequirementLv < group.Count()
                            ? maxRequirementLv
                            : group.Count();

                        // 0個、1個、2個。。。の組み合わせ分、リストのリストを作成.
                        for (var ko = 0; ko <= max; ko++)
                        {
                            // マスタのレコードそのもののリストを生成 0個から作る.
                            var list = new List<MasterAccessoryData>();
                            for (var i = 0; i < ko; i++)
                            {
                                list.Add(master);
                            }

                            listList.Add(list);
                        }
                    }

                    return listList;
                })
                .ToList();

            // 必要空きスロットを仮想装飾品リストに置き換えて処理に渡す.
            var blankSlotList = new List<MasterAccessoryData>();
            foreach (var Lv in requirements.RequirementBlankSlot.GetBlankSlotList())
            {
                for(var i = 0; i < Lv.Item2; i++)
                {
                    blankSlotList.Add(new MasterAccessoryAbstract(Lv.Item1));
                }
            }

            // 対象スキルを持つ全ての装飾品の組み合わせリストを生成し、
            // 検索データ装飾品に変換してリスト化する.
            // 装飾品リストだけは再起呼び出しの外側で処理されるため、
            // 装飾品ゼロ個の組み合わせが常に必要になるが、
            // GetAllCombinationsListは全ての組み合わせを抽出する為、
            // 0個の組み合わせも含まれるので、それをそのまま使用する.
            var candidateList = allCombinationList.GetAllCombinationsList()
                .Select(combList =>
                {
                    var openedList = combList
                        .SelectMany(list => list)
                        .ToList();
                    
                    // 全ての組み合わせに、仮想防具リストを加える.
                    if (blankSlotList.Any())
                    {
                        openedList.AddRange(blankSlotList);
                    }

                    return (PartDataBase)new PartDataAccessory(openedList);
                })
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
            // 既に条件を満たしたスキルを持った装飾品が含まれた組み合わせはリストから除外する.
            var filteredList = orgList
                .Where(candidate =>
                {
                    return !candidate.GetSkillList()
                        .Select(skill => skill.Index)
                        .Any(searchReport.SatisfyList.Contains);
                })
                .Select(candidate => new CandidateData(true, candidate))
                .ToList();

            // 検索に使用するリストを格納して返す.
            return new CandidateAccessory(filteredList);
        }
    }
}
