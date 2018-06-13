using System.Collections.Generic;
using SkillSimulatorMHW.Defines;

namespace SkillSimulatorMHW.Data
{
    /// <summary>
    /// 部位データ基底
    /// </summary>
    public abstract class PartDataBase
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        protected PartDataBase(Part part)
        {
            this.Part = part;
            this.State = PartState.Unsettled;
        }

        /// <summary>
        /// 部位.
        /// </summary>
        public Part Part { get; set; }

        /// <summary>
        /// 検索状態.
        /// </summary>
        public PartState State { get; set; }

        /// <summary>
        /// 固定装備セット.
        /// </summary>
        /// <param name="masterIndex"></param>
        public abstract void SetFixed(int masterIndex);

        /// <summary>
        /// 確定装備のIndexリストを取得.
        /// </summary>
        /// <returns></returns>
        public abstract List<int> GetIndexList();

        /// <summary>
        /// 確定装備の文字列表現を取得.
        /// </summary>
        /// <returns></returns>
        public abstract string GetText();

        /// <summary>
        /// 所持スキルの一覧を取得.
        /// </summary>
        /// <returns></returns>
        public abstract List<SkillData> GetSkillList();

        /// <summary>
        /// 対象スキルのスキルLvを取得.
        /// </summary>
        /// <returns></returns>
        public abstract int GetSkillLv(int index);

        /// <summary>
        /// 所持スロットの一覧を取得.
        /// </summary>
        /// <returns></returns>
        public abstract void GetEquippedSlot(List<int> equippedSlot);
    }
}
