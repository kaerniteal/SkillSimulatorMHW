using System;
using System.Collections.Generic;
using System.Linq;
using SkillSimulatorMHW.Data;
using SkillSimulatorMHW.Defines;
using SkillSimulatorMHW.Masters;
using SkillSimulatorMHW.Requirements;
using SkillSimulatorMHW.Extensions;

namespace SkillSimulatorMHW.Candidates
{
    /// <summary>
    /// 検索候補データ護石
    /// </summary>
    public class CandidateAmulet : CandidatePartBase
    {
        /// <summary>
        /// 静的コンストラクタ.
        /// </summary>
        static CandidateAmulet()
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
        public CandidateAmulet()
            : base(Defines.Part.Amulet, new List<CandidateData>())
        {
        }

        /// <summary>
        /// コンストラクタ(検索用データ生成.)
        /// </summary>
        /// <param name="candidateList">候補リスト</param>
        protected CandidateAmulet(List<CandidateData> candidateList)
            : base(Defines.Part.Amulet, candidateList)
        {
        }

        /// <summary>
        /// 護石コンボボックスアイテムリスト.
        /// </summary>
        public static List<TermsTypeData> TermsList { get; private set; }

        /// <summary>
        /// オリジナル検索候補リストを生成
        /// </summary>
        /// <param name="requirements">検索条件</param>
        /// <remarks>検索処理実施前のオリジナル候補装備リスト</remarks>
        public override List<PartDataBase> CreateOrgList(Requirement requirements)
        {
            var requirementData = requirements.RequirementDataList.Get(Defines.Part.Amulet);

            // 使用しない場合は空リストを返す.
            if (TermsType.Unused == requirementData.TermsType)
            {
                return new List<PartDataBase>();
            }

            // 検索対象スキルのIndexリストを生成.
            var requirementSkillIdList = requirements.RequirementSkillList.SkillList
                .Select(skill => skill.Index)
                .ToList();

            // 対象のマスタリストを生成する.
            var masterList = new List<MasterAmuletData>();
            switch (requirementData.TermsType)
            {
                // 全リストの場合.
                case TermsType.All:
                    // 検索対象スキルを持つ全護石をリスト化.
                    masterList = Ssm.Master.MasterAmulet.GetRecordList()
                        .ToList();
                    break;

                // 除外リストの場合.
                case TermsType.Ignore:
                    // TODO:nakamura 除外リストを使用して、リストを生成して返す
                    Log.Write("【ERROR】護石の検索条件[{0}]は未実装です".Fmt(requirementData.TermsType));
                    masterList = new List<MasterAmuletData>();
                    break;

                // 所持リストの場合.
                case TermsType.Possession:
                    // TODO:nakamura 所持リストを使用して、リストを生成して返す
                    Log.Write("【ERROR】護石の検索条件[{0}]は未実装です".Fmt(requirementData.TermsType));
                    masterList = new List<MasterAmuletData>();
                    break;

                // 固定の場合.
                case TermsType.Fixed:
                    // 検索対象リストは不要.
                    break;

                // 上記以外のパターン.
                default:
                    Log.Write("【ERROR】護石の検索条件[{0}]は未実装です".Fmt(requirementData.TermsType));
                    masterList = new List<MasterAmuletData>();
                    break;
            }

            // 検索条件(要件)に指定されているスキルを持たない護石、 要求以上のスキルLvを持つ護石は除外する
            var candidateList = masterList
                .Where(amulet =>
                {
                    // スキルを持たない護石は除外.
                    if (!amulet.HaveSkill(requirementSkillIdList))
                    {
                        return false;
                    }

                    // マスタを取得できない護石は除外.
                    var master = Ssm.Master.MasterAmulet.GetRecord(amulet.Index);
                    if (null == master)
                    {
                        return false;
                    }

                    // 護石の所持スキルIndexリストを取得.
                    var skillIndexList = master.GetAllMemberSkillIndexList();

                    // 護石の対象スキルの要求レベルの中から最大を取得.
                    var maxRequirementLv = requirements.RequirementSkillList.SkillList
                        .Where(skill => skillIndexList.Contains(skill.Index))
                        .Max(skill => skill.Lv);

                    // 護石Lvの方が高い場合は除外.
                    return master.AmulteLv <= maxRequirementLv;
                })
                .Select(amulet => (PartDataBase)new PartDataAmulet(amulet))
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
            // 条件を満たしていないスキルを持つ防具に絞る.
            var filteredList = orgList
                .Where(candidate =>
                {
                    return candidate.GetSkillList()
                        .Any(skill => searchReport.UnsatisfyList.Contains(skill.Index));
                })
                .Select(candidate => new CandidateData(true, candidate))
                .ToList();

            // 検索に使用するリストを格納して返す.
            return new CandidateAmulet(filteredList);
        }

        /// <summary>
        /// 上方互換候補の除外処理.
        /// </summary>
        /// <param name="done">条件を満たすセットが見つかった装備</param>
        /// <param name="searchReport">現状の検索状況</param>
        public override void RemoveUpwardCompatibility(PartDataBase done, SearchReport searchReport)
        {
            // この処理が呼ばれている時点で、引数に渡された護石で実現可能セットが見つかっている為
            // 同じ護石のより上位の護石で対象スキルがオーバーする場合、その護石をリストから除く.
            // 例）
            // 引数が攻撃の護石Ⅰで、現状のセットで攻撃スキルが1だけ不足している場合
            // 攻撃の護石Ⅱ以上の検索は不要.

            // 上記が前提だが、実際には検索順序で護石は最下位にしてあるので、
            // ※ SearchSetのGetUnsettledPartListの順序で最も後方になっているはず.
            // 護石を検索する時点で護石以外の候補は残っておらず、
            // 引数の護石で条件を満たすセットが見つかったのであれば、
            // 同じIDのより上位の護石は無条件で無効にしても問題ないはず.

            var doneAmulet = done as PartDataAmulet;
            for(var i = 0; i < this.GetCount(); i++)
            {
                var candidate = this.GetAt(i);
                var candidateAmulet = candidate.PartData as PartDataAmulet;
                
                // 同じシリーズでよりLvが高い護石があれば.
                if (null != doneAmulet && 
                    null != candidateAmulet &&
                    null != doneAmulet.Master &&
                    null != candidateAmulet.Master &&
                    doneAmulet.Master.AmulteId == candidateAmulet.Master.AmulteId &&
                    doneAmulet.Master.AmulteLv < candidateAmulet.Master.AmulteLv)
                {
                    candidate.Enable = false;
                }
            }
        }
    }
}
