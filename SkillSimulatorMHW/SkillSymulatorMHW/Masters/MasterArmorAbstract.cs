using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using SkillSimulatorMHW.Data;
using SkillSimulatorMHW.Defines;
using SkillSimulatorMHW.Extensions;

namespace SkillSimulatorMHW.Masters
{
    /// <summary>
    /// 抽象化防具データ.
    /// </summary>
    public class MasterArmorAbstract : MasterArmorData
    {
        /// <summary>
        /// 静的コンストラクタ.
        /// </summary>
        static MasterArmorAbstract()
        {
            AbstractMasterDic = new Dictionary<Part, List<MasterArmorData>>();
        }

        /// <summary>
        /// コンストラクタ.
        /// </summary>
        public MasterArmorAbstract(Part part, SlotData slotData, int rare)
        {
            this.Part = part;
            this.Rare = rare;
            this.Slot1 = slotData.GetSlotLv(0);
            this.Slot2 = slotData.GetSlotLv(1);
            this.Slot3 = slotData.GetSlotLv(2);
            this.Slot4 = slotData.GetSlotLv(3);
        }

        /// <summary>
        /// 抽象化防具リスト.
        /// </summary>
        private static Dictionary<Part, List<MasterArmorData>> AbstractMasterDic { get; set; }

        /// <summary>
        /// 抽象化防具リストを取得する.
        /// </summary>
        /// <returns></returns>
        public static List<MasterArmorData> GetAbstractArmorList(Part part)
        {
            // 一度も取得されていない場合は抽象化防具リストを生成.
            if (!AbstractMasterDic.ContainsKey(part))
            {
                // マスタを取得.
                var masterList = Ssm.Master.MasterArmor.GetPartList(part);

                // スロットをKEYに辞書に登録.
                var dic = new Dictionary<SlotData, List<MasterArmorData>>();
                foreach (var master in masterList)
                {
                    var slot = master.GetSlotData();
                    if (dic.ContainsKey(slot))
                    {
                        dic[slot].Add(master);
                    }
                    else
                    {
                        dic.Add(slot, new List<MasterArmorData>{ master });
                    }
                }

                // スロットKEYを並べ替えつつ、仮想防具マスタ情報へ変換.
                var abstractList = dic
                    .Where(ele => 0 != ele.Key.GetIndex())
                    .OrderBy(ele => ele.Key.GetIndex())
                    .Select(ele =>
                    {
                        var rare = ele.Value.Min(master => master.Rare);
                        var armor = (MasterArmorData)new MasterArmorAbstract(part, ele.Key, rare);
                        return armor;
                    })
                    .ToList();

                // 辞書に登録.
                AbstractMasterDic.Add(part, abstractList);
            }

            return AbstractMasterDic[part];
        }

        /// <summary>
        /// 部位の文字列化
        /// </summary>
        /// <returns></returns>
        public static string PartToName(Part part)
        {
            switch (part)
            {
                case Defines.Part.Head:  return "頭";
                case Defines.Part.Body:  return "胴";
                case Defines.Part.Arm:   return "腕";
                case Defines.Part.Waist: return "腰";
                case Defines.Part.Leg:   return "脚";
            }

            return "??";
        }

        /// <summary>
        /// 部位の文字列化
        /// </summary>
        /// <returns></returns>
        public static string PartToKana(Part part)
        {
            switch (part)
            {
                case Defines.Part.Head:  return "あたま";
                case Defines.Part.Body:  return "どう";
                case Defines.Part.Arm:   return "うで";
                case Defines.Part.Waist: return "こし";
                case Defines.Part.Leg:   return "きゃく";
            }

            return "??";
        }

        /// <summary>
        /// 抽象化防具かどうか.
        /// </summary>
        /// <returns></returns>
        public override bool IsAbstract()
        {
            return true;
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
            return "{0}{1}すろっと{2}".Fmt(this.ToString(), PartToKana(this.Part), string.Join(string.Empty, txtList));
        }

        /// <summary>
        /// 文字列化のオーバーライド.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            var slotData = this.GetSlotData();
            return "スロット{0} {1}装備".Fmt(slotData, PartToName(this.Part));
        }
    }
}
