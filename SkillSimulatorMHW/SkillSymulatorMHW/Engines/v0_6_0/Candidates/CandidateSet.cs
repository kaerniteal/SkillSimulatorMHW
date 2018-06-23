using System;
using System.Collections.Generic;
using System.Linq;
using SkillSimulatorMHW.Data;
using SkillSimulatorMHW.Defines;
using SkillSimulatorMHW.Requirements;

namespace SkillSimulatorMHW.Engines.v0_6_0.Candidates
{
    /// <summary>
    /// 候補データセット.
    /// </summary>
    public class CandidateSet
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="requirements">検索条件</param>
        public CandidateSet(Requirement requirements)
        {
            // 検索処理の実施前に各装備の候補リスト最低限絞り込んだオリジナルリストを生成してデータ化しておく
            // 検索処理中ではオリジナルリストをさらにその検索中の状態に合わせて絞り込んだデータに複製して利用する.

            // 候補装備リスト辞書を生成.
            this.OrgCandidateListDic = new Dictionary<Part, CandidateCreator>
            {
                { Part.Wepon,      new CandidateCreator(new CandidateWepon(),           requirements ) },
                { Part.Head,       new CandidateCreator(new CandidateArmor(Part.Head),  requirements ) },
                { Part.Body,       new CandidateCreator(new CandidateArmor(Part.Body),  requirements ) },
                { Part.Arm,        new CandidateCreator(new CandidateArmor(Part.Arm),   requirements ) },
                { Part.Waist,      new CandidateCreator(new CandidateArmor(Part.Waist), requirements ) },
                { Part.Leg,        new CandidateCreator(new CandidateArmor(Part.Leg),   requirements ) },
                { Part.Amulet,     new CandidateCreator(new CandidateAmulet(),          requirements ) },
                { Part.Accessory,  new CandidateCreator(new CandidateAccessory(),       requirements ) },
            };


            // 抽象化防具もあらかじめリスト辞書を生成しておく.
            this.OrgAbstractListDic = new Dictionary<Part, CandidateCreator>
            {
                { Part.Head,       new CandidateCreator(new CandidateArmorAbstract(Part.Head),  requirements ) },
                { Part.Body,       new CandidateCreator(new CandidateArmorAbstract(Part.Body),  requirements ) },
                { Part.Arm,        new CandidateCreator(new CandidateArmorAbstract(Part.Arm),   requirements ) },
                { Part.Waist,      new CandidateCreator(new CandidateArmorAbstract(Part.Waist), requirements ) },
                { Part.Leg,        new CandidateCreator(new CandidateArmorAbstract(Part.Leg),   requirements ) },
            };
        }

        /// <summary>
        /// オリジナル候補装備リストデータ辞書
        /// </summary>
        private Dictionary<Part, CandidateCreator> OrgCandidateListDic { get; set; }

        /// <summary>
        /// 抽象化防具リストデータ辞書
        /// </summary>
        private Dictionary<Part, CandidateCreator> OrgAbstractListDic { get; set; }

        /// <summary>
        /// 検索候補データを取得.
        /// </summary>
        /// <param name="part">部位</param>
        /// <param name="searchReport">検索中の状態レポート</param>
        /// <returns>検索候補データ</returns>
        public CandidatePartBase GetCandidate(Part part, SearchReport searchReport)
        {
            if (!this.OrgCandidateListDic.ContainsKey(part))
            {
                throw new ArgumentOutOfRangeException("part", part, null);
            }

            // オリジナルリストからさらに検索中の状態に合わせて絞り込んだリストを格納して返す.
            return this.OrgCandidateListDic[part].Create(searchReport);
        }

        /// <summary>
        /// 抽象化防具データを取得.
        /// </summary>
        /// <param name="part">部位</param>
        /// <param name="searchReport">検索中の状態レポート</param>
        /// <returns>検索候補データ</returns>
        public CandidatePartBase GetArmorAbstract(Part part, SearchReport searchReport)
        {
            if (!this.OrgAbstractListDic.ContainsKey(part))
            {
                throw new ArgumentOutOfRangeException("part", part, null);
            }

            // 抽象化防具リストからさらに検索中の状態に合わせて絞り込んだリストを格納して返す.
            return this.OrgAbstractListDic[part].Create(searchReport);
        }

        /// <summary>
        /// 組み合わせ総数を取得する.
        /// </summary>
        /// <returns></returns>
        public long GetTotalCcombination()
        {
            // 候補が0件でも1ケースとみなすので、全ての候補数に1加算してリスト化する.
            // 単純にこの値に0が含まれると、いかなる場合も総数が0となるので0は不可.
            var countList = this.OrgCandidateListDic
                .Select(candidate => candidate.Value.OrgList.Count + 1)
                .ToList();

            // 候補毎のケース数を全て乗算して総組み合わせ数を算出.
            long result = 1;

            foreach (var count in countList)
            {
                result *= count;
            }

            return result;
        }

        /// <summary>
        /// 候補リストを複製する為のインナークラス.
        /// </summary>
        private class CandidateCreator
        {
            /// <summary>
            /// コンストラクタ.
            /// </summary>
            public CandidateCreator(CandidatePartBase creator, Requirement requirements)
            {
                this.Creator = creator;
                this.OrgList = creator.CreateOrgList(requirements);
            }

            /// <summary>
            /// 複製生成用のインスタンス.
            /// </summary>
            public CandidatePartBase Creator { get; set; }

            /// <summary>
            /// オジリナル検索候補装備リスト.
            /// </summary>
            public List<PartDataBase> OrgList { get; set; }

            /// <summary>
            /// 候補リストを生成.
            /// </summary>
            /// <returns></returns>
            public CandidatePartBase Create(SearchReport searchReport)
            {
                return this.Creator.CreateCandidate(this.OrgList, searchReport);
            }
        }
    }
}
