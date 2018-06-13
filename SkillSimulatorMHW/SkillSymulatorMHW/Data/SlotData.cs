using System;
using System.Collections.Generic;
using System.Linq;

namespace SkillSimulatorMHW.Data
{
    /// <summary>
    /// スロットデータ.
    /// </summary>
    public class SlotData : IEquatable<SlotData>
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public SlotData(List<int> slotList)
        {
            this.SlotList = slotList
                .Where(lv => 0 != lv)
                .OrderByDescending(lv => lv)
                .ToList();
        }

        /// <summary>
        /// スロットリスト.
        /// </summary>
        public List<int> SlotList { get; set; }

        /// <summary>
        /// スロットLvを取得
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public int GetSlotLv(int index)
        {
            if (index < this.SlotList.Count)
            {
                return this.SlotList[index];
            }

            return 0;
        }

        /// <summary>
        /// ユニークなIndexを取得する.
        /// </summary>
        /// <returns>Index</returns>
        public int GetIndex()
        {
            var index = 0;

            foreach (var lv in this.SlotList)
            {
                if (0 != lv)
                {
                    index *= 10;
                    index += lv;
                }
            }

            return index;
        }

        /// <summary>
        /// スロットLvの文字列化
        /// </summary>
        /// <returns></returns>
        public static string IntToStr(int slotLv)
        {
            switch (slotLv)
            {
                case 1: return "①";
                case 2: return "②";
                case 3: return "③";
                case 4: return "④";
                case 5: return "⑤";
            }

            return "??";
        }

        /// <summary>
        /// 文字列化(オーバライド)
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            var strList = this.SlotList
                .Where(lv => 0 != lv)
                .Select(IntToStr)
                .ToList();

            return string.Join(string.Empty, strList);
        }

        /// <summary>
        /// IEquatableの実装.
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return this.GetIndex().GetHashCode();
        }

        /// <summary>
        /// IEquatableの実装.
        /// </summary>
        /// <returns></returns>
        bool IEquatable<SlotData>.Equals(SlotData dst)
        {
            return this.Equals(dst);
        }

        /// <summary>
        /// 一致を調査.
        /// </summary>
        /// <param name="dst"></param>
        /// <returns></returns>
        public bool Equals(SlotData dst)
        {
            if (dst == null)
            {
                return false;
            }

            return this.GetIndex() == dst.GetIndex();
        }
    }
}
