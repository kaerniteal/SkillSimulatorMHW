using System.Collections.Generic;
using SkillSimulatorMHW.Defines;
using SkillSimulatorMHW.Masters;

namespace SkillSimulatorMHW.Data
{
    /// <summary>
    /// 部位データ武器
    /// </summary>
    public class PartDataWepon : PartDataBase
    {
        /// <summary>
        /// コンストラクタ(未確定)
        /// </summary>
        public PartDataWepon()
            : base(Part.Wepon)
        {
            this.State = PartState.Unsettled;
        }

        /// <summary>
        /// コンストラクタ(確定済み)
        /// </summary>
        public PartDataWepon(MasterWeponData master)
            : base(Part.Wepon)
        {
            this.State = PartState.Determined;
            this.Master = master;
        }

        /// <summary>
        /// 武器マスタ.
        /// </summary>
        public MasterWeponData Master { get; set; }

        /// <summary>
        /// 固定装備セット.
        /// </summary>
        /// <param name="masterIndex"></param>
        public override void SetFixed(int masterIndex)
        {
            this.State = PartState.Determined;
            this.Master = Ssm.Master.MasterWepon.GetRecord(masterIndex);
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
                return new List<int> { this.Master.Index };
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
                return this.Master.ToString();
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
            // スキルは持たない.
            return new List<SkillData>();
        }

        /// <summary>
        /// 対象スキルのスキルLvを取得.
        /// </summary>
        /// <returns></returns>
        public override int GetSkillLv(int index)
        {
            // スキルは持たない.
            return 0;
        }

        /// <summary>
        /// 所持スロットの一覧を取得.
        /// </summary>
        /// <returns></returns>
        public override void GetEquippedSlot(List<int> equippedSlot)
        {
            // 確定している場合はマスタに確認..
            if (PartState.Determined == this.State && null != this.Master)
            {
                var slotData = this.Master.GetSlotData();
                equippedSlot.AddRange(slotData.SlotList); 
            }
        }
    }
}
