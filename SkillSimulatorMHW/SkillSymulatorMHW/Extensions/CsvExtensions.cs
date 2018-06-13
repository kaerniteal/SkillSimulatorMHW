using System;
using SkillSimulatorMHW.Defines;

namespace SkillSimulatorMHW.Extensions
{
    /// <summary>
    /// CSV拡張メソッドを定義します。
    /// </summary>
    public static class CsvExtensions
    {
        /// <summary>
        /// 数値文字列を数値へ変換する(変換不能な場合は0にする).
        /// </summary>
        /// <param name="self">変換元数値文字列</param>
        /// <returns>変換後の数値</returns>
        public static int CsvToInt(this string self)
        {
            var value = 0;
            if (!int.TryParse(self, out value))
            {
                return 0;
            }

            return value;
        }

        /// <summary>
        /// 数値文字列を数値へ変換する(変換不能な場合は例外とする).
        /// </summary>
        /// <param name="self">変換元数値文字列</param>
        /// <returns>変換後の数値</returns>
        public static int CsvToIntNotNull(this string self)
        {
            var value = 0;
            if (!int.TryParse(self, out value))
            {
                return 0;
            }

            return value;
        }

        /// <summary>
        /// 数値文字列をEnumへ変換する.
        /// </summary>
        /// <typeparam name="TEnum">変換先のEnum型</typeparam>
        /// <param name="self">変換元数値文字列</param>
        /// <returns>変換後のEnum値</returns>
        public static TEnum CsvToEnum<TEnum>(this string self)
        {
            var value = 0;
            if (!int.TryParse(self, out value))
            {
                throw new FormatException("値[" + self + "]をEnum[" + typeof(TEnum) + "]に変換できません");
            }

            return value.ToEnum<TEnum>();
        }
    }
}