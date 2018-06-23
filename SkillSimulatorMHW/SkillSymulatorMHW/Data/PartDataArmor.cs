using System.Collections.Generic;
using System.Linq;
using SkillSimulatorMHW.Defines;
using SkillSimulatorMHW.Masters;

namespace SkillSimulatorMHW.Data
{
    /// <summary>
    /// 部位データ防具
    /// </summary>
    public class PartDataArmor : PartDataBase
    {
        /// <summary>
        /// コンストラクタ(未確定)
        /// </summary>
        public PartDataArmor(Part part)
            : base(part)
        {
            this.State = PartState.Unsettled;
            this.Master = null;
        }

        /// <summary>
        /// コンストラクタ(確定済み)
        /// </summary>
        public PartDataArmor(MasterArmorData master)
            : base(master.Part)
        {
            this.State = PartState.Determined;
            this.Master = master;
        }

        /// <summary>
        /// コンストラクタ(ステータス指定)
        /// </summary>
        public PartDataArmor(Part part, PartState state)
            : base(part)
        {
            this.State = state;
            this.Master = null;
        }

        /// <summary>
        /// マスタ.
        /// </summary>
        public MasterArmorData Master { get; set; }

        /// <summary>
        /// 所持シリーズスキルの一覧を取得.
        /// </summary>
        /// <returns></returns>
        public List<SkillData> GetSeriesList()
        {
            if (PartState.Determined == this.State && null != this.Master)
            {
                return this.Master.GetSeriesList();
            }

            return new List<SkillData>();
        }

        /// <summary>
        /// 指定したシリーズスキルを持っているかどうかを返す.
        /// </summary>
        /// <returns></returns>
        public bool HaveSeries(int index)
        {
            if (PartState.Determined == this.State && null != this.Master)
            {
                return this.Master.GetSeriesList()
                    .Any(skill => skill.Index == index);
            }

            return false;
        }

        /// <summary>
        /// 抽象化防具かどうか.
        /// </summary>
        /// <returns></returns>
        public bool IsAbstract()
        {
            if (PartState.Determined == this.State && null != this.Master)
            {
                return this.Master.IsAbstract();
            }

            return false;
        }

        /// <summary>
        /// 固定装備セット.
        /// </summary>
        /// <param name="masterIndex"></param>
        public override void SetFixed(int masterIndex)
        {
            this.State = PartState.Determined;
            this.Master = Ssm.Master.MasterArmor.GetRecord(masterIndex);
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
            // 確定している場合はマスタに確認..
            if (PartState.Determined == this.State && null != this.Master)
            {
                var slotData = this.Master.GetSlotData();
                equippedSlot.AddRange(slotData.SlotList); 
            }
        }
    }
}
