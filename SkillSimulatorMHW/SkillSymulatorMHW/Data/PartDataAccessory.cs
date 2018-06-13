using System.Collections.Generic;
using System.Linq;
using SkillSimulatorMHW.Defines;
using SkillSimulatorMHW.Masters;
using SkillSimulatorMHW.Extensions;

namespace SkillSimulatorMHW.Data
{
    /// <summary>
    /// 部位データ装飾品
    /// </summary>
    public class PartDataAccessory : PartDataBase
    {
        /// <summary>
        /// コンストラクタ(未確定)
        /// </summary>
        public PartDataAccessory()
            : base(Defines.Part.Accessory)
        {
            this.State = PartState.Unsettled;
            this.MasterList = null;
            this.CacheNeedSlotList = new List<int>();
            this.CacheSkillLvDic = new Dictionary<int, int>();
        }

        /// <summary>
        /// コンストラクタ(確定済み)
        /// </summary>
        public PartDataAccessory(List<MasterAccessoryData> masterList)
            : base(Defines.Part.Accessory)
        {
            this.State = PartState.Determined;
            this.MasterList = masterList;
            this.CacheNeedSlotList = null;
            this.CacheSkillLvDic = new Dictionary<int, int>();
        }

        /// <summary>
        /// マスタリスト.
        /// </summary>
        public List<MasterAccessoryData> MasterList { get; set; }

        /// <summary>
        /// 必要スロットリスト(パフォーマンス改善の為、キャッシュする).
        /// </summary>
        private List<int> CacheNeedSlotList { get; set; }

        /// <summary>
        /// スキルLv合計(パフォーマンス改善の為、キャッシュする)
        /// </summary>
        private Dictionary<int, int> CacheSkillLvDic { get; set; }

        /// <summary>
        /// 固定装備セット.
        /// </summary>
        /// <param name="masterIndex"></param>
        public override void SetFixed(int masterIndex)
        {
            // 装飾品は固定装備に未対応.
            Log.Write("【Error】装飾品は固定装備に未対応");
        }

        /// <summary>
        /// 確定装備のIndexリストを取得.
        /// </summary>
        /// <returns></returns>
        public override List<int> GetIndexList()
        {
            // 確定している場合は装備のIndexを返す.
            if (PartState.Determined == this.State && null != this.MasterList && 0 < MasterList.Count)
            {
                // 装飾品のIDリストを返す.
                return this.MasterList
                    .Select(master => master.Index)
                    .ToList();
            }

            // 未確定の場合.
            return new List<int> { 0 };
        }

        /// <summary>
        /// 確定装備の文字列表現リストを取得.
        /// </summary>
        /// <returns></returns>
        public List<string> GetTextList()
        {
            // 確定している場合は装備の名称を返す.
            if (PartState.Determined == this.State && null != this.MasterList && 0 < MasterList.Count)
            {
                // 装飾品の個数も含めた名称リストを返す.
                // Indexでグループ化して、グループ毎に文字列化.
                return this.MasterList
                    .GroupBy(master => master.Index)
                    .Select(group => "{0}*{1}".Fmt(group.First().Name, group.Count()))
                    .ToList();
            }

            // 未確定の場合.
            return new List<string>();
        }

        /// <summary>
        /// 必要スロットリストを取得.
        /// </summary>
        /// <returns></returns>
        public List<int> GetNeedSlot()
        {
            if (null == this.CacheNeedSlotList)
            {
                this.CacheNeedSlotList = this.MasterList
                    .Select(master => master.SlotLv)
                    .OrderBy(lv => lv)
                    .ToList();
            }

            return this.CacheNeedSlotList;
        }

        /// <summary>
        /// 確定装備の文字列表現を取得.
        /// </summary>
        /// <returns></returns>
        public override string GetText()
        {
            // 文字列リストを取得.
            var strList = this.GetTextList();

            // 存在する場合は.
            return strList.Any()
                ? string.Join(" ", strList)
                : "－";

            // 未確定の場合.
        }

        /// <summary>
        /// 所持スキルの一覧を取得.
        /// </summary>
        /// <returns></returns>
        public override List<SkillData> GetSkillList()
        {
            if (PartState.Determined == this.State && null != this.MasterList && 0 < MasterList.Count)
            {
                var skillList = new List<SkillData>();
                foreach (var master in this.MasterList)
                {
                    skillList.AddRange(master.GetSkillDataList());
                }

                return skillList;
            }

            return new List<SkillData>();
        }

        /// <summary>
        /// 対象スキルのスキルLvを取得.
        /// </summary>
        /// <returns></returns>
        public override int GetSkillLv(int index)
        {
            if (PartState.Determined == this.State && null != this.MasterList && 0 < MasterList.Count)
            {
                // 一度も登録されていない場合.
                if (!this.CacheSkillLvDic.ContainsKey(index))
                {
                    var lv = 0;
                    foreach (var master in this.MasterList)
                    {
                        lv += master.GetSkillLv(index);
                    }

                    this.CacheSkillLvDic.Add(index, lv);
                }

                // キャッシュされたLvを返す.
                return this.CacheSkillLvDic[index];
            }

            return 0;
        }

        /// <summary>
        /// 所持スロットの一覧を取得.
        /// </summary>
        /// <returns></returns>
        public override void GetEquippedSlot(List<int> equippedSlot)
        {
            // スロットは持たない.
        }
    }
}
