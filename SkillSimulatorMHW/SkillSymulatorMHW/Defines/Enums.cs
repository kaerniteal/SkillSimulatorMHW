using System;

namespace SkillSimulatorMHW.Defines
{
    /// <summary>
    /// ランク.
    /// </summary>
    public enum Rank
    {
        Non = 0,
        Low = 1,
        High = 2,
        G = 3,
    }

    /// <summary>
    /// 部位.
    /// </summary>
    public enum Part
    {
        Non = 0,
        Wepon = 1,
        Head = 11,
        Body = 12,
        Arm = 13,
        Waist = 14,
        Leg = 15,
        Amulet = 20,
        Accessory = 30,
    }

    /// <summary>
    /// 部位状態.
    /// </summary>
    public enum PartState
    {
        Unuse,      // 不使用.
        Unsettled,  // 未確定.
        Determined, // 確定.
        NotExist,   // 候補なし.
    }

    /// <summary>
    /// 検索条件種別.
    /// </summary>
    public enum TermsType
    {
        Unused,     // 使用しない.
        All,        // 全てを対象にする.
        Ignore,     // 除外リストを使用する.
        Possession, // 所持リストを使用する.
        Fixed,      // 特定の装備を指定する.
    }

    /// <summary>
    /// 検索の状態.
    /// </summary>
    public enum SearchState
    {
        ShortageSkill,  // スキル不足.
        ShortageSlot,   // スロット不足.
        Complete,       // 条件達成完了.
        Terminate,      // 条件未達終了.
    }

    /// <summary>
    /// 解析実行タイプ.
    /// </summary>
    public enum AnalyzeType
    {
        Non,            // 解析しない.
        NotExist,       // 条件を満たすセットが存在しない場合は実行する.
        Always,         // 常に実行する.
    }

    /// <summary>
    /// Enum拡張メソッドを定義します。
    /// </summary>
    public static class Enums
    {
        /// <summary>
        /// 数値をEnumへ変換する.
        /// </summary>
        /// <typeparam name="TEnum">変換先のEnum型</typeparam>
        /// <param name="self">変換元値</param>
        /// <returns></returns>
        public static TEnum ToEnum<TEnum>(this int self)
        {
            // TEnum列挙体のメンバの値として存在するか調べる
            if (!Enum.IsDefined(typeof(TEnum), self))
            {
                throw new FormatException("値[" + self + "]をEnum[" + typeof(TEnum) + "]に変換できません");
            }

            //DayOfWeek列挙体に変換する
            return (TEnum)Enum.ToObject(typeof(TEnum), self);
        }
    }
}
