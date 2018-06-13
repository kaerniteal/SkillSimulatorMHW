using System.Collections.Generic;
using System.Linq;
using SkillSimulatorMHW.Data;
using SkillSimulatorMHW.Defines;
using SkillSimulatorMHW.Extensions;

namespace SkillSimulatorMHW.Result
{
    /// <summary>
    /// 結果セット.
    /// </summary>
    public class ResultSet : PartSet
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public ResultSet(PartSet src)
        {
            this.Wepon = src.Wepon;
            this.Head = src.Head;
            this.Body = src.Body;
            this.Arm = src.Arm;
            this.Waist = src.Waist;
            this.Leg = src.Leg;
            this.Amulet = src.Amulet;
            this.Accessory = src.Accessory;
        }

        /// <summary>
        /// 全防具リストを取得
        /// </summary>
        /// <returns></returns>
        private List<PartDataArmor> GetArmorList()
        {
            // 全防具のリストを返す.
            return new List<PartDataArmor>
            {
                this.Head,
                this.Body,
                this.Arm,
                this.Waist,
                this.Leg,
            };
        }

        /// <summary>
        /// 有効なシリーズスキルを取得.
        /// </summary>
        /// <returns></returns>
        private List<SkillData> GetActiveSeries()
        {
            // 確定防具が持つシリーズスキルを全て取得.
            var seriesSkillList = this.GetArmorList()
                .Where(armor => PartState.Determined == armor.State)
                .SelectMany(armor => armor.GetSeriesList())
                .ToList();

            // グループ化して、必要数を超えているスキルだけ返す.
            return seriesSkillList
                .GroupBy(series => series.Index)
                .Select(group =>
                {
                    var master = group.First().Skill;
                    return group.Count() < master.Need
                        ? null
                        : new SkillData(master);
                })
                .Where(skill => null != skill)
                .ToList();
        }

        /// <summary>
        /// 現在確定している装備のスキルを取得.
        /// </summary>
        /// <returns></returns>
        private List<SkillData> GetSkillList()
        {
            // 有効な装備が持つスキルを全て取得.
            return this.GetDeterminedPartList()
                .SelectMany(part => part.GetSkillList())
                .GroupBy(skill => skill.Index)
                .Select(group =>
                {
                    var master = group.First().Skill;
                    return new SkillData(master, group.Sum(skill => skill.Lv));
                })
                .ToList();
        }

        /// <summary>
        /// 防御力を取得する.
        /// </summary>
        /// <returns></returns>
        public List<int> GetDefense()
        {
            // 確定防具リストを取得.
            var armorList = this.GetArmorList()
                .Where(armor => PartState.Determined == armor.State)
                .ToList();

            // 確定防具が持つ防御力を計算して返す.
            return new List<int>
            {
                armorList.Sum(armor => armor.Master.DefInit),
                armorList.Sum(armor => armor.Master.DefMax),
                armorList.Sum(armor => armor.Master.DefCustom),
            };
        }

        /// <summary>
        /// 結果セットが持つスキルの一覧を取得.
        /// </summary>
        /// <returns></returns>
        public List<SkillData> GetAllSkillList()
        {
            // シリーズスキルを格納しておく.
            var allSkillList = this.GetActiveSeries();

            // 発動スキルを追加して.
            allSkillList.AddRange(this.GetSkillList());

            // 返す.
            return allSkillList;
        }

        /// <summary>
        /// 結果セットに対する文字列表現を取得.
        /// </summary>
        /// <returns></returns>
        public string GetAllText()
        {
            var partList = this.GetPartList()
                .Select(part => part.GetText())
                .ToList();

            var skillList = this.GetAllSkillList()
                .Select(skill => skill.GetText())
                .ToList();

            return "{0}:{1}".Fmt(string.Join(".", partList), string.Join(".", skillList));
        }
    }
}
