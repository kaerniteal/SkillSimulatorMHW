using System.Collections.Generic;
using System.Linq;
using SkillSimulatorMHW.Masters;
using SkillSimulatorMHW.Interface;

namespace SkillSimulatorMHW.Extensions
{
    /// <summary>
    /// マスタ拡張メソッドを定義します。
    /// </summary>
    public static class MasterExtensions
    {
        /// <summary>
        /// 文字列フィルタリング後のレコードリストを取得.
        /// </summary>
        /// <returns></returns>
        public static List<MasterDataBase> GetRecordListWithStringFilter(this List<MasterDataBase> self, string filter)
        {
            if (filter.IsEmpty())
            {
                // フィルタ無しの場合は全て.
                return self;
            }

            // 文字の入力がある場合、絞込みワードを抽出(半角スペースで複数取得).
            var wards = filter.Split(' ')
                .Where(ward => !ward.IsEmpty());

            // 絞込みワードのいずれかを含むレコードのみ抽出.
            return self
                .Where(rec => wards.Any(ward => rec.GetFilterText().Contains(ward)))
                .ToList();
        }
    }
}