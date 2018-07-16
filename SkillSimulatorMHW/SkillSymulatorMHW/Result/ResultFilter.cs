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
            this.NeedSkill1 = new SkillBase();
            this.NeedSkill2 = new SkillBase();
            this.NeedSkill3 = new SkillBase();
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
        public SkillBase NeedSkill1 { get; set; }

        /// <summary>
        /// 必要スキル2
        /// </summary>
        public SkillBase NeedSkill2 { get; set; }

        /// <summary>
        /// 必要スキル3
        /// </summary>
        public SkillBase NeedSkill3 { get; set; }

        /// <summary>
        /// フィルタ処理.
        /// </summary>
        /// <param name="resultSet"></param>
        /// <returns></returns>
        public bool Filter(ResultSet resultSet)
        {
            // 空きスロット条件をチェック.
            if (!this.FilterBlankSlot(resultSet))
            {
                return false;
            }

            // 追加スキル条件をチェック.
            if (!this.FilterAddSkill(resultSet))
            {
                return false;
            }

            // すべて満たしている場合
            return true;
        }

        /// <summary>
        /// フィルタ処理(空きスロット).
        /// </summary>
        /// <param name="resultSet"></param>
        /// <returns></returns>
        public bool FilterBlankSlot(ResultSet resultSet)
        {
            // 空きスロットをLv毎にグループ化.
            var groupedSlotList = resultSet.GetBlankSlot()
                .GroupBy(slot => slot)
                .ToList();

            // スロットLv毎の必要数をリスト化.
            var needBlankSlotList = new List<Tuple<int, int>>
            {
                Tuple.Create(1, this.NeedBlankSlotLv1),
                Tuple.Create(2, this.NeedBlankSlotLv2),
                Tuple.Create(3, this.NeedBlankSlotLv3),
            };

            // 必要スロットの条件を満たしているかどうか,
            foreach (var needSlot in needBlankSlotList)
            {
                // 空きスロットフィルタが設定されていない場合.
                if (0 == needSlot.Item2)
                {
                    continue;
                }

                // Lv毎の空きスロットを取得.
                var blank = groupedSlotList
                    .FirstOrDefault(grp => grp.Key == needSlot.Item1);

                // 1個も無い、もしくは必要数に足りない場合.
                if (null == blank || blank.Count() < needSlot.Item2)
                {
                    return false;
                }
            }

            // 空きスロット条件を満たしている場合.
            return true;
        }

        /// <summary>
        /// フィルタ処理(追加スキル).
        /// </summary>
        /// <param name="resultSet"></param>
        /// <returns></returns>
        public bool FilterAddSkill(ResultSet resultSet)
        {
            // 所持スキルリストを取得.
            var skillList = resultSet.GetAllSkillList();

            // 追加スキルをリスト化.
            var needAddSkill = new List<SkillBase>
            {
                this.NeedSkill1,
                this.NeedSkill2,
                this.NeedSkill3,
            };

            // 追加スキルの条件を満たしているかどうか,
            foreach (var needSkill in needAddSkill)
            {
                // 追加スキルフィルタが設定されていない場合.
                if (0 == needSkill.Index || needSkill.Lv <= 0)
                {
                    continue;
                }

                // 追加スキルのLvを取得.
                var target = skillList
                    .FirstOrDefault(skill => skill.Skill.Index == needSkill.Index);
                
                // スキルを所持していない、もしくは必要Lvに足りない場合.
                if (null == target || target.Lv < needSkill.Lv)
                {
                    return false;
                }
            }

            // 追加スキル条件を満たしている場合.
            return true;
        }
    }
}
