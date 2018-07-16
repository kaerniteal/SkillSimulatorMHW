using System;
using System.Collections.Generic;
using SkillSimulatorMHW.Masters;

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
        /// 空きスロットデータを仮想装飾品リストに変換して返す
        /// </summary>
        /// <returns></returns>
        public List<MasterAccessoryData> GetBlankSlotList()
        {
            var blankSlotList = new List<Tuple<int, int>>
            {
                Tuple.Create(1, this.Lv1),
                Tuple.Create(2, this.Lv2),
                Tuple.Create(3, this.Lv3),
            };

            var blankSlotLvList = new List<MasterAccessoryData>();
            foreach (var lv in blankSlotList)
            {
                for (var i = 0; i < lv.Item2; i++)
                {
                    blankSlotLvList.Add(new MasterAccessoryAbstract(lv.Item1));
                }
            }

            return blankSlotLvList;
        }
    }
}
