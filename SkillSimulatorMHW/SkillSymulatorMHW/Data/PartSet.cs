using System.Collections.Generic;
using System.Linq;
using SkillSimulatorMHW.Defines;

namespace SkillSimulatorMHW.Data
{
    /// <summary>
    /// 部位セット.
    /// </summary>
    public class PartSet
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public PartSet()
        {
            this.Wepon = new PartDataWepon();
            this.Head = new PartDataArmor(Part.Head);
            this.Body = new PartDataArmor(Part.Body);
            this.Arm = new PartDataArmor(Part.Arm);
            this.Waist = new PartDataArmor(Part.Waist);
            this.Leg = new PartDataArmor(Part.Leg);
            this.Amulet = new PartDataAmulet();
            this.Accessory = new PartDataAccessory();
        }

        /// <summary>
        /// 武器.
        /// </summary>
        public PartDataWepon Wepon { get; set; }

        /// <summary>
        /// 頭防具.
        /// </summary>
        public PartDataArmor Head { get; set; }

        /// <summary>
        /// 胴防具.
        /// </summary>
        public PartDataArmor Body { get; set; }

        /// <summary>
        /// 腕防具.
        /// </summary>
        public PartDataArmor Arm { get; set; }

        /// <summary>
        /// 腰防具.
        /// </summary>
        public PartDataArmor Waist { get; set; }

        /// <summary>
        /// 脚防具.
        /// </summary>
        public PartDataArmor Leg { get; set; }

        /// <summary>
        /// 護石.
        /// </summary>
        public PartDataAmulet Amulet { get; set; }

        /// <summary>
        /// 装飾品リスト.
        /// </summary>
        public PartDataAccessory Accessory { get; set; }

        /// <summary>
        /// 全部位リストを取得
        /// </summary>
        /// <returns></returns>
        public List<PartDataBase> GetPartList()
        {
            // 全部位のリストを返す.
            return new List<PartDataBase>
            {
                this.Wepon,
                this.Head,
                this.Body,
                this.Arm,
                this.Waist,
                this.Leg,
                this.Amulet,
                this.Accessory,
            };
        }

        /// <summary>
        /// 確定部位リストを取得.
        /// </summary>
        /// <returns></returns>
        public List<PartDataBase> GetDeterminedPartList()
        {
            return this.GetPartList()
                .Where(part => PartState.Determined == part.State)
                .ToList();
        }

        /// <summary>
        /// 現在のセットが装備している全てのスロットのLvリストを取得する.
        /// </summary>
        public List<int> GetEquippedSlotLvList()
        {
            var equippedSlot = new List<int>();

            // パフォーマンス改善の為にLinqではなく平文で.
            if (PartState.Determined == this.Wepon.State)
            {
                this.Wepon.GetEquippedSlot(equippedSlot);
            }

            if (PartState.Determined == this.Head.State)
            {
                this.Head.GetEquippedSlot(equippedSlot);
            }

            if (PartState.Determined == this.Body.State)
            {
                this.Body.GetEquippedSlot(equippedSlot);
            }

            if (PartState.Determined == this.Arm.State)
            {
                this.Arm.GetEquippedSlot(equippedSlot);
            }

            if (PartState.Determined == this.Waist.State)
            {
                this.Waist.GetEquippedSlot(equippedSlot);
            }

            if (PartState.Determined == this.Leg.State)
            {
                this.Leg.GetEquippedSlot(equippedSlot);
            }

            if (1 < equippedSlot.Count)
            {
                // 並べ替えは必要.
                equippedSlot.Sort();
            }

            return equippedSlot;
        }

        /// <summary>
        /// 空きスロットを取得する.
        /// </summary>
        /// <returns>空きスロットのリスト</returns>
        public List<int> GetBlankSlot()
        {
            // 結果を格納.
            var blankSlotList = new List<int>();

            // 現在のセットが装備している全てのスロットのLvリスト
            var equippedSlotLvList = this.GetEquippedSlotLvList();

            // 必要スロットリスト
            var needSlotLvList = this.Accessory.GetNeedSlotLvList();

            // 装備スロットを下位Lvから走査.
            // 必要スロットLvと装備スロットLvを低いほうから順番に比較して、
            // 必要スロットLv <= 装備スロットLvであれば格納可能と判定する.
            var needIndex = 0;
            foreach (var equippedLv in equippedSlotLvList)
            {
                // 必要スロットがまだ残っていてかつ装備Lvが必要Lvを超えていれば装備可能.
                if (needIndex < needSlotLvList.Count &&
                    needSlotLvList[needIndex] <= equippedLv)
                {
                    // 装備可能なので必要Indexを進める.
                    needIndex++;
                    continue;
                }

                // 超えていない場合は装備Indexだけ進めて次の評価へ回す(より高いLvのが出てくるまで進める)
                // 空きスロットリストに追加.
                blankSlotList.Add(equippedLv);
            }

            return blankSlotList;
        }

        /// <summary>
        /// この検索セットを一意に表す文字列表現を取得.
        /// </summary>
        /// <returns></returns>
        public string GetKey()
        {
            var keyList = this.GetPartList()
                .SelectMany(part => part.GetIndexList())
                .Select(index => index.ToString())
                .ToList();

            return string.Join(".", keyList);
        }
    }
}
