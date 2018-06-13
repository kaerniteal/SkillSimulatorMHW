using System.Collections.Generic;

namespace SkillSimulatorMHW.Defines
{
    /// <summary>
    /// 静的定義.
    /// </summary>
    public static class Define
    {
        /// <summary>
        /// 静的コンストラクタ.
        /// </summary>
        static Define()
        {
            // 防具部位リストを生成.
            ArmorList = new List<Part>
            {
                Part.Head,
                Part.Body,
                Part.Arm,
                Part.Waist,
                Part.Leg,
            };
        }


        /// <summary>
        /// コンボボックスのアイテム無し
        /// </summary>
        public const string StrItemNon = @"なし";

        /// <summary>
        /// 防具部位リスト.
        /// </summary>
        public static List<Part> ArmorList { get; private set; }
    }
}
