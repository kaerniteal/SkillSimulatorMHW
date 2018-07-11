using System;
using System.Collections.Generic;
using System.Linq;
using SkillSimulatorMHW.Data;
using SkillSimulatorMHW.Defines;
using SkillSimulatorMHW.Extensions;

namespace SkillSimulatorMHW.Masters
{
    /// <summary>
    /// 防具マスタデータ.
    /// </summary>
    public class MasterArmorData : MasterDataBase
    {
        /// <summary>
        /// コンストラクタ.
        /// </summary>
        public MasterArmorData()
        {
            this.Part = Part.Non;
            this.CacheAllSkillIndexList = null;
            this.CacheSkillList = null;
            this.CacheSeriesList = null;
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
        /// 読み
        /// </summary>
        public string Kana { get; set; }

        /// <summary>
        /// 部位.
        /// </summary>
        public Part Part { get; set; }

        /// <summary>
        /// スキル1Id
        /// </summary>
        public int Skill1Id { get; set; }

        /// <summary>
        /// スキル1Lv
        /// </summary>
        public int Skill1Lv { get; set; }

        /// <summary>
        /// スキル2Id
        /// </summary>
        public int Skill2Id { get; set; }

        /// <summary>
        /// スキル2Lv
        /// </summary>
        public int Skill2Lv { get; set; }

        /// <summary>
        /// スキル3Id
        /// </summary>
        public int Skill3Id { get; set; }

        /// <summary>
        /// スキル3Lv
        /// </summary>
        public int Skill3Lv { get; set; }

        /// <summary>
        /// シリーズスキル1Id
        /// </summary>
        public int Series1Id { get; set; }

        /// <summary>
        /// シリーズスキル2Id
        /// </summary>
        public int Series2Id { get; set; }

        /// <summary>
        /// シリーズスキル3Id
        /// </summary>
        public int Series3Id { get; set; }

        /// <summary>
        /// レア度
        /// </summary>
        public int Rare { get; set; }

        /// <summary>
        /// 防御力(初期)
        /// </summary>
        public int DefInit { get; set; }

        /// <summary>
        /// 防御力(最大)
        /// </summary>
        public int DefMax { get; set; }

        /// <summary>
        /// 防御力(カスタム)
        /// </summary>
        public int DefCustom { get; set; }

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
        /// 属性防御(火)
        /// </summary>
        public int AttrFire { get; set; }

        /// <summary>
        /// 属性防御(水)
        /// </summary>
        public int AttrWater { get; set; }

        /// <summary>
        /// 属性防御(雷)
        /// </summary>
        public int AttrLightning { get; set; }

        /// <summary>
        /// 属性防御(氷)
        /// </summary>
        public int AttrIce { get; set; }

        /// <summary>
        /// 属性防御(龍)
        /// </summary>
        public int AttrDragon { get; set; }

        /// <summary>
        /// 全スキルIndexリスト(キャッシュを格納するバッファ).
        /// </summary>
        private List<int> CacheAllSkillIndexList { get; set; }

        /// <summary>
        /// スキルリスト(キャッシュを格納するバッファ).
        /// </summary>
        private List<SkillData> CacheSkillList { get; set; }

        /// <summary>
        /// シリーズスキルリスト(キャッシュを格納するバッファ).
        /// </summary>
        private List<SkillData> CacheSeriesList { get; set; }

        /// <summary>
        /// スロットデータ(キャッシュ)
        /// </summary>
        private SlotData SlotData { get; set; }

        /// <summary>
        /// 全スキルのIndexリスト.
        /// </summary>
        /// <returns></returns>
        private List<int> GetAllMemberSkillIndexList()
        {
            // 未作成ならキャッシュを作成
            if (null == this.CacheAllSkillIndexList)
            {
                // 全スキルメンバのIndexリストを生成.
                var skillMemberAllIndexList = new List<int>
                {
                    this.Skill1Id,
                    this.Skill2Id,
                    this.Skill3Id,
                    this.Series1Id,
                    this.Series2Id,
                    this.Series3Id,
                };

                // 有効なIdのスキルだけ抽出.
                this.CacheAllSkillIndexList = skillMemberAllIndexList
                    .Where(index => 0 != index)
                    .ToList();
            }

            // スキルのリストを返す.
            return this.CacheAllSkillIndexList.ToList();
        }

        /// <summary>
        /// スキルのリスト.
        /// </summary>
        /// <returns></returns>
        public List<SkillData> GetSkillDataList()
        {
            // 未作成ならキャッシュを作成
            if (null == this.CacheSkillList)
            {
                // メンバのスキルとLvのペアリストを作成.
                var skillMemberList = new List<Tuple<int, int>>
                {
                    Tuple.Create(this.Skill1Id, this.Skill1Lv),
                    Tuple.Create(this.Skill2Id, this.Skill2Lv),
                    Tuple.Create(this.Skill3Id, this.Skill3Lv),
                };

                // 有効なIdのスキルだけ、マスタレコードに変換してLvとのペアリストを作成.
                var skillMasterList = skillMemberList
                    .Where(tuple => 0 != tuple.Item1)
                    .Select(tuple =>
                    {
                        var master = Ssm.Master.MasterSkill.GetRecord(tuple.Item1);
                        return Tuple.Create(master, tuple.Item2);
                    })
                    .Where(tuple => null != tuple.Item1)
                    .ToList();

                // スキルデータに変換してリスト化
                this.CacheSkillList = skillMasterList
                    .Select(tuple => new SkillData(tuple.Item1, tuple.Item2))
                    .ToList();
            }

            // スキルのリストを返す.
            return this.CacheSkillList.ToList();
        }

        /// <summary>
        /// シリーズスキルのリスト.
        /// </summary>
        /// <returns></returns>
        public List<SkillData> GetSeriesList()
        {
            // 未作成ならキャッシュを作成
            if (null == this.CacheSeriesList)
            {
                // メンバのスキルとLvのペアリストを作成.
                var skillMemberList = new List<int>
                {
                    this.Series1Id,
                    this.Series2Id,
                    this.Series3Id,
                };

                // 有効なIdのスキルだけ、スキルデータに変換してリスト化
                this.CacheSeriesList = skillMemberList
                    .Where(id => 0 != id)
                    .Select(id =>
                    {
                        var master = Ssm.Master.MasterSkill.GetRecord(id);
                        return new SkillData(master);
                    })
                    .ToList();
            }

            // スキルのリストを返す.
            return this.CacheSeriesList.ToList();
        }

        /// <summary>
        /// 対象装備が対象のスキルを持っているかどうかを判定する.
        /// </summary>
        /// <param name="requirementList">検索対象スキルIndexリスト</param>
        /// <returns>持っているかどうか</returns>
        public bool HaveSkill(List<int> requirementList)
        {
            return this.GetAllMemberSkillIndexList()
                .Any(member => requirementList.Any(requirement => requirement == member));
        }

        /// <summary>
        /// 指定されたスキルのスキルLvを取得.
        /// </summary>
        /// <param name="index">スキルIndex</param>
        /// <returns>合計スキルLv</returns>
        public int GetSkillLv(int index)
        {
            // 処理の高速化の為、平文で記述.
            if (this.Skill1Id == index)
            {
                return this.Skill1Lv;
            }

            if (this.Skill2Id == index)
            {
                return this.Skill2Lv;
            }

            if (this.Skill3Id == index)
            {
                return this.Skill3Lv;
            }

            return 0;
        }

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
            return this.Name + this.Kana;
        }

        /// <summary>
        /// CSV行データをセットする.
        /// </summary>
        /// <param name="row"></param>
        public override void SetFromCsv(CsvIo.CsvRow row)
        {
            this.Index = row[0].CsvToIntNotNull();
            this.Name =  row[1];
            this.Kana =  row[2];
            this.Part =  row[3].CsvToEnum<Part>();
            this.Skill1Id = row[4].CsvToInt();
            this.Skill1Lv = row[5].CsvToInt();
            this.Skill2Id = row[6].CsvToInt();
            this.Skill2Lv = row[7].CsvToInt();
            this.Skill3Id = row[8].CsvToInt();
            this.Skill3Lv = row[9].CsvToInt();
            this.Series1Id = row[10].CsvToInt();
            this.Series2Id = row[11].CsvToInt();
            this.Series3Id = row[12].CsvToInt();
            this.Rare =      row[13].CsvToInt();
            this.DefInit =   row[14].CsvToInt();
            this.DefMax =    row[15].CsvToInt();
            this.DefCustom = row[16].CsvToInt();
            this.Slot1 = row[17].CsvToInt();
            this.Slot2 = row[18].CsvToInt();
            this.Slot3 = row[19].CsvToInt();
            this.Slot4 = row[20].CsvToInt();
            this.AttrFire =      row[21].CsvToInt();
            this.AttrWater =     row[22].CsvToInt();
            this.AttrLightning = row[23].CsvToInt();
            this.AttrIce =       row[24].CsvToInt();
            this.AttrDragon =    row[25].CsvToInt();
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
                this.Kana,
                ((int) this.Part).ToString(),
                this.Skill1Id.ToString(),
                this.Skill1Lv.ToString(),
                this.Skill2Id.ToString(),
                this.Skill2Lv.ToString(),
                this.Skill3Id.ToString(),
                this.Skill3Lv.ToString(),
                this.Series1Id.ToString(),
                this.Series2Id.ToString(),
                this.Series3Id.ToString(),
                this.Rare.ToString(),
                this.DefInit.ToString(),
                this.DefMax.ToString(),
                this.DefCustom.ToString(),
                this.Slot1.ToString(),
                this.Slot2.ToString(),
                this.Slot3.ToString(),
                this.Slot4.ToString(),
                this.AttrFire.ToString(),
                this.AttrWater.ToString(),
                this.AttrLightning.ToString(),
                this.AttrIce.ToString(),
                this.AttrDragon.ToString(),
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
