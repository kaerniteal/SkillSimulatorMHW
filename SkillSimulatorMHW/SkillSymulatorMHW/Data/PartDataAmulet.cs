using System.Collections.Generic;
using SkillSimulatorMHW.Defines;
using SkillSimulatorMHW.Masters;

namespace SkillSimulatorMHW.Data
{
    /// <summary>
    /// 部位データ護石
    /// </summary>
    public class PartDataAmulet : PartDataBase
    {
        /// <summary>
        /// コンストラクタ(未確定)
        /// </summary>
        public PartDataAmulet()
            : base(Part.Amulet)
        {
            this.State = PartState.Unsettled;
            this.Master = null;
        }

        /// <summary>
        /// コンストラクタ(確定済み)
        /// </summary>
        public PartDataAmulet(MasterAmuletData master)
            : base(Part.Amulet)
        {
            this.State = PartState.Determined;
            this.Master = master;
        }

        /// <summary>
        /// マスタ.
        /// </summary>
        public MasterAmuletData Master { get; set; }

        /// <summary>
        /// 固定装備セット.
        /// </summary>
        /// <param name="masterIndex"></param>
        public override void SetFixed(int masterIndex)
        {
            this.State = PartState.Determined;
            this.Master = Ssm.Master.MasterAmulet.GetRecord(masterIndex);
        }

        /// <summary>
        /// 確定装備のIndexリストを取得.
        /// </summary>
        /// <returns></returns>
        public override List<int> GetIndexList()
        {
            // 確定している場合は装備のIndexを返す.
            if (PartState.Determined == this.State && null != this.Master)
            {
                return new List<int> { this.Master.GetIndex() };
            }

            // 未確定の場合.
            return new List<int> { 0 };
        }

        /// <summary>
        /// 確定装備の文字列表現を取得.
        /// </summary>
        /// <returns></returns>
        public override string GetText()
        {
            // 確定している場合は装備の名称を返す.
            if (PartState.Determined == this.State && null != this.Master)
            {
                return this.Master.Name;
            }

            // 未確定の場合.
            return "－";
        }

        /// <summary>
        /// 所持スキルの一覧を取得.
        /// </summary>
        /// <returns></returns>
        public override List<SkillData> GetSkillList()
        {
            if (PartState.Determined == this.State && null != this.Master)
            {
                return this.Master.GetSkillDataList();
            }

            return new List<SkillData>();
        }

        /// <summary>
        /// 対象スキルのスキルLvを取得.
        /// </summary>
        /// <returns></returns>
        public override int GetSkillLv(int index)
        {
            if (PartState.Determined == this.State && null != this.Master)
            {
                return this.Master.GetSkillLv(index);
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
