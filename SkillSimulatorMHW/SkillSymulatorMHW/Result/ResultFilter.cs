using System;
using System.Collections.Generic;
using System.Linq;
using SkillSimulatorMHW.Data;

namespace SkillSimulatorMHW.Result
{
    /// <summary>
    /// 結果フィルタ.
    /// </summary>
    public class ResultFilter
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public ResultFilter()
        {
            // デフォルトはここで与える.
            this.SetDefault();
        }

        /// <summary>
        /// デフォルトをセット.
        /// </summary>
        private void SetDefault()
        {
            this.NeedBlankSlotLv1 = 0;
            this.NeedBlankSlotLv2 = 0;
            this.NeedBlankSlotLv3 = 0;
            this.NeedSkill1 = null;
            this.NeedSkill2 = null;
            this.NeedSkill3 = null;
        }

        /// <summary>
        /// 必要空きLv1スロ
        /// </summary>
        public int NeedBlankSlotLv1 { get; set; }

        /// <summary>
        /// 必要空きLv2スロ
        /// </summary>
        public int NeedBlankSlotLv2 { get; set; }

        /// <summary>
        /// 必要空きLv3スロ
        /// </summary>
        public int NeedBlankSlotLv3 { get; set; }

        /// <summary>
        /// 必要スキル1
        /// </summary>
        public SkillData NeedSkill1 { get; set; }

        /// <summary>
        /// 必要スキル2
        /// </summary>
        public SkillData NeedSkill2 { get; set; }

        /// <summary>
        /// 必要スキル3
        /// </summary>
        public SkillData NeedSkill3 { get; set; }

        /// <summary>
        /// フィルタ処理.
        /// </summary>
        /// <param name="resultSet"></param>
        /// <returns></returns>
        public bool Filter(ResultSet resultSet)
        {
            // 空きスロットを取得.
            var blankSlotList = new List<int>();
            resultSet.GetBlankSlot(blankSlotList);

            // 空きスロットをLv毎にグループ化.
            var groupedSlotList = blankSlotList
                .GroupBy(slot => slot)
                .ToList();

            // 必要スロットの条件を満たしているかどうか,
            foreach (var needSlot in this.NeedBlankSlot())
            {
                // 空きスロットフィルタが設定されていない場合.
                if (0 == needSlot.Item2)
                {
                    continue;
                }

                // Lv毎の空きスロットを取得.
                var blank = groupedSlotList
                    .FirstOrDefault(grp => grp.Key == needSlot.Item1);

                // 1個も無い場合.
                if (null == blank)
                {
                    return false;
                }

                // 必要数に足りない場合.
                if (blank.Count() < needSlot.Item2)
                {
                    return false;
                }
            }

            // すべて満たしている場合
            return true;
        }

        /// <summary>
        /// スロットLv毎の必要数を取得.
        /// </summary>
        /// <param name="lv"></param>
        /// <returns></returns>
        private List<Tuple<int, int>> NeedBlankSlot()
        {
            return new List<Tuple<int, int>>
            {
                Tuple.Create(1, this.NeedBlankSlotLv1),
                Tuple.Create(2, this.NeedBlankSlotLv2),
                Tuple.Create(3, this.NeedBlankSlotLv3),
            };
        }
    }
}
