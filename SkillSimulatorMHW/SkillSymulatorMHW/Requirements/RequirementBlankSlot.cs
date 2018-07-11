using System;
using System.Collections.Generic;
using SkillSimulatorMHW.Defines;

namespace SkillSimulatorMHW.Requirements
{
    /// <summary>
    /// 検索条件(空きスロット).
    /// </summary>
    public class RequirementBlankSlot
    {
        /// <summary>
        /// コンストラクタ.
        /// </summary>
        public RequirementBlankSlot()
        {
            this.Lv3 = 0;
            this.Lv2 = 0;
            this.Lv1 = 0;
        }

        /// <summary>
        /// Lv3.
        /// </summary>
        public int Lv3 { get; set; }

        /// <summary>
        /// Lv2.
        /// </summary>
        public int Lv2 { get; set; }

        /// <summary>
        /// LV1.
        /// </summary>
        public int Lv1 { get; set; }

        /// <summary>
        /// 空きスロットデータを辞書型にして返す
        /// </summary>
        /// <returns></returns>
        public List<Tuple<int, int>> GetBlankSlotList()
        {
            return new List<Tuple<int, int>>
            {
                Tuple.Create(1, this.Lv1),
                Tuple.Create(2, this.Lv2),
                Tuple.Create(3, this.Lv3),
            };
        }
    }
}
