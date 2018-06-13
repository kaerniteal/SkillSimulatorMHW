using System.Collections.Generic;
using SkillSimulatorMHW.Data;
using SkillSimulatorMHW.Defines;
using SkillSimulatorMHW.Extensions;

namespace SkillSimulatorMHW.Masters
{
    /// <summary>
    /// 武器データ.
    /// </summary>
    public class MasterWeponData : MasterDataBase
    {
        /// <summary>
        /// コンストラクタ.
        /// </summary>
        public MasterWeponData()
        {
            this.SlotData = null;
        }

        /// <summary>
        /// Index
        /// </summary>
        public int Index { get; set; }

        /// <summary>
        /// 名称.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 部位.
        /// </summary>
        public Part Part { get; set; }

        /// <summary>
        /// スロット1.
        /// </summary>
        public int Slot1 { get; set; }

        /// <summary>
        /// スロット2.
        /// </summary>
        public int Slot2 { get; set; }

        /// <summary>
        /// スロット3.
        /// </summary>
        public int Slot3 { get; set; }

        /// <summary>
        /// スロット4.
        /// </summary>
        public int Slot4 { get; set; }

        /// <summary>
        /// スロットデータ(キャッシュ)
        /// </summary>
        private SlotData SlotData { get; set; }

        /// <summary>
        /// 所持するスロットの羅列を取得する
        /// </summary>
        /// <remarks>Lv1スロットを３つの場合1,1,1、Lv3スロット２つの場合3,3と入る</remarks>
        /// <returns></returns>
        public SlotData GetSlotData()
        {
            // キャッシュを作成.
            if (null == this.SlotData)
            {
                this.SlotData = new SlotData(new List<int>
                {
                    this.Slot1,
                    this.Slot2,
                    this.Slot3,
                    this.Slot4,
                });
            }

            return this.SlotData;
        }

        /// <summary>
        /// ユニークなIndexを取得する.
        /// </summary>
        /// <returns>Index</returns>
        public override int GetIndex()
        {
            return this.Index;
        }

        /// <summary>
        /// フィルタ対象文字列を取得する.
        /// </summary>
        /// <returns></returns>
        public override string GetFilterText()
        {
            return this.Name;
        }

        /// <summary>
        /// CSV行データをセットする.
        /// </summary>
        /// <param name="row"></param>
        public override void SetFromCsv(CsvIo.CsvRow row)
        {
            this.Index = row[0].CsvToIntNotNull();
            this.Name = row[1];
            this.Part = row[2].CsvToEnum<Part>();
            this.Slot1 = row[3].CsvToInt();
            this.Slot2 = row[4].CsvToInt();
            this.Slot3 = row[5].CsvToInt();
            this.Slot4 = row[6].CsvToInt();
        }

        /// <summary>
        /// CSV行データを取得する
        /// </summary>
        /// <returns></returns>
        public override CsvIo.CsvRow GetCsvRow()
        {
            return new CsvIo.CsvRow(new List<string>
            {
                this.Index.ToString(),
                this.Name,
                ((int) this.Part).ToString(),
                this.Slot1.ToString(),
                this.Slot2.ToString(),
                this.Slot3.ToString(),
                this.Slot4.ToString(),
            });
        }

        /// <summary>
        /// 文字列化のオーバーライド.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.Name;
        }
    }
}
