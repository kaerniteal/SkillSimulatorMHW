using System.Linq;
using SkillSimulatorMHW.Defines;
using SkillSimulatorMHW.Extensions;

namespace SkillSimulatorMHW.Masters
{
    /// <summary>
    /// 抽象化武器データ.
    /// </summary>
    public class MasterWeponAbstract : MasterWeponData
    {
        /// <summary>
        /// コンストラクタ.
        /// </summary>
        public MasterWeponAbstract(int slot1, int slot2, int slot3, int slot4)
        {
            this.Part = Defines.Part.Wepon;
            this.Slot1 = slot1;
            this.Slot2 = slot2;
            this.Slot3 = slot3;
            this.Slot4 = slot4;
        }

        /// <summary>
        /// ユニークなIndexを取得する.
        /// </summary>
        /// <returns>Index</returns>
        public override int GetIndex()
        {
            var slotData = this.GetSlotData();
            return slotData.GetIndex() * -1;
        }

        /// <summary>
        /// フィルタ対象文字列を取得する.
        /// </summary>
        /// <returns></returns>
        public override string GetFilterText()
        {
            var slotData = this.GetSlotData();
            var txtList = slotData.SlotList
                .Select(lv => lv.ToString())
                .ToList();
            return "{0}ぶきすろっと{1}".Fmt(this.ToString(), string.Join(string.Empty, txtList));
        }

        /// <summary>
        /// 文字列化のオーバーライド.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            var slotData = this.GetSlotData();
            return "武器 スロット{0}".Fmt(slotData);
        }
    }
}
