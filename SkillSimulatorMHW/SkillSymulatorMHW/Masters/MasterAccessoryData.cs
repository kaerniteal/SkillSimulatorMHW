using System;
using System.Collections.Generic;
using System.Linq;
using SkillSimulatorMHW.Data;
using SkillSimulatorMHW.Extensions;

namespace SkillSimulatorMHW.Masters
{
    /// <summary>
    /// 抽象化装飾品マスタデータ.
    /// </summary>
    public class MasterAccessoryData : MasterDataBase
    {
        /// <summary>
        /// コンストラクタ.
        /// </summary>
        public MasterAccessoryData()
        {
            this.CacheSkillIndexList = null;
            this.CacheSkillList = null;
            this.CacheFilterText = String.Empty;
        }

        /// <summary>
        /// Index
        /// </summary>
        protected int Index { get; set; }

        /// <summary>
        /// 名称.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 読み
        /// </summary>
        public string Kana { get; set; }

        /// <summary>
        /// スロットLv.
        /// </summary>
        public int SlotLv { get; set; }

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
        /// レア度
        /// </summary>
        public int Rare { get; set; }

        /// <summary>
        /// スキルIndexリスト(キャッシュを格納するバッファ).
        /// </summary>
        private List<int> CacheSkillIndexList { get; set; }

        /// <summary>
        /// スキルリスト(キャッシュを格納するバッファ).
        /// </summary>
        private List<SkillData> CacheSkillList { get; set; }

        /// <summary>
        /// フィルタ文字列(キャッシュ)
        /// </summary>
        private string CacheFilterText { get; set; }

        /// <summary>
        /// スキルのIndexリスト.
        /// </summary>
        /// <returns></returns>
        public List<int> GetAllMemberSkillIndexList()
        {
            // 未作成ならキャッシュを作成
            if (null == this.CacheSkillIndexList)
            {
                // スキルメンバのIndexリストを生成.
                var skillMemberAllIndexList = new List<int>
                {
                    this.Skill1Id,
                    this.Skill2Id,
                };

                // 有効なIdのスキルだけ抽出.
                this.CacheSkillIndexList = skillMemberAllIndexList
                    .Where(index => 0 != index)
                    .ToList();
            }

            // スキルのリストを返す.
            return this.CacheSkillIndexList.ToList();
        }

        /// <summary>
        /// スキルのリスト.
        /// </summary>
        /// <returns></returns>
        public List<SkillData> GetSkillDataList()
        {
            // 未作成ならキャッシュを作成
            if (null == CacheSkillList)
            {
                // メンバのスキルとLvのペアリストを作成.
                var skillMemberList = new List<Tuple<int, int>>
                {
                    Tuple.Create(this.Skill1Id, this.Skill1Lv),
                    Tuple.Create(this.Skill2Id, this.Skill2Lv),
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

            return 0;
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
            if (this.CacheFilterText.IsEmpty())
            {
                var skillFilterTextList = this.GetSkillDataList()
                    .Select(skill => skill.Skill.GetFilterText())
                    .ToList();

                this.CacheFilterText = this.Name + this.Kana + string.Join("", skillFilterTextList);
            }

            return this.CacheFilterText;
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
            this.SlotLv = row[3].CsvToIntNotNull();
            this.Skill1Id = row[4].CsvToInt();
            this.Skill1Lv = row[5].CsvToInt();
            this.Skill2Id = row[6].CsvToInt();
            this.Skill2Lv = row[7].CsvToInt();
            this.Rare = row[8].CsvToIntNotNull();
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
                this.SlotLv.ToString(),
                this.Skill1Id.ToString(),
                this.Skill1Lv.ToString(),
                this.Skill2Id.ToString(),
                this.Skill2Lv.ToString(),
                this.Rare.ToString(),
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
