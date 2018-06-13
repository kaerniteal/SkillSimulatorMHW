using System.Collections.Generic;
using System.Linq;

namespace SkillSimulatorMHW.Extensions
{
    /// <summary>
    /// ユーティリティ拡張メソッドを定義します。
    /// </summary>
    public static class UtilExtensions
    {
        /// <summary>
        /// string.Formatを行います。
        /// </summary>
        /// <param name="self">自分自身</param>
        /// <param name="args">引数</param>
        /// <returns>整形済み文字列</returns>
        public static string Fmt(this string self, params object[] args)
        {
            return string.Format(self, args);
        }

        /// <summary>
        /// Nullか空文字かどうかを判定します。
        /// </summary>
        /// <param name="self">自分自身</param>
        /// <returns>Nullまたは空文字の場合はTrue, それ以外はFalse</returns>
        public static bool IsEmpty(this string self)
        {
            return string.IsNullOrEmpty(self);
        }

        /// <summary>
        /// 対象のリストの全ての組み合わせリストを生成する
        /// </summary>
        public static List<List<T>> GetAllCombinationsList<T>(this List<List<T>> self)
        {
            var resultList = new List<List<T>>();
            var stack = new Stack<T>();

            // 再帰処理(本体)を呼び出す.
            GetCombinationsCore(stack, resultList, self);

            return resultList;
        }

        /// <summary>
        /// 【再帰処理】対象のリストの全ての組み合わせリストを生成する
        /// </summary>
        private static void GetCombinationsCore<T>(Stack<T> stack, List<List<T>> resultList, List<List<T>> sourceList)
        {
            int dimension = stack.Count;
            if (sourceList.Count <= dimension)
            {
                var list = stack.ToList();
                resultList.Add(list);
                return;
            }
            else
            {
                foreach (var item in sourceList[dimension])
                {
                    stack.Push(item);
                    GetCombinationsCore<T>(stack, resultList, sourceList);
                    stack.Pop();
                }
            }
        }
    }
}