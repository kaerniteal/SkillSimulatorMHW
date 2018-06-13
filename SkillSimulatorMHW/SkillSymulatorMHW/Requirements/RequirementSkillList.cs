using System.Collections.Generic;
using System.Linq;
using SkillSimulatorMHW.Data;

namespace SkillSimulatorMHW.Requirements
{
    /// <summary>
    /// 検索条件(スキル).
    /// </summary>
    public class RequirementSkillList
    {
        /// <summary>
        /// コンストラクタ.
        /// </summary>
        public RequirementSkillList()
        {
            this.SeriesList = new List<SkillData>();
            this.SkillList = new List<SkillData>();
        }

        /// <summary>
        /// シリーズスキルリスト.
        /// </summary>
        public List<SkillData> SeriesList { get; set; }

        /// <summary>
        /// スキルリスト
        /// </summary>
        public List<SkillData> SkillList { get; set; }

        /// <summary>
        /// 追加する.
        /// </summary>
        /// <param name="skillData"></param>
        public void Add(SkillData skillData)
        {
            if (skillData.IsSeries())
            {
                this.SeriesList.Add(skillData);
            }
            else
            {
                this.SkillList.Add(skillData);
            }
        }

        /// <summary>
        /// 削除する.
        /// </summary>
        /// <param name="skillData"></param>
        public void Remove(SkillData skillData)
        {
            if (skillData.IsSeries())
            {
                this.SeriesList.Remove(skillData);
            }
            else
            {
                this.SkillList.Remove(skillData);
            }
        }

        /// <summary>
        /// スキルIndexのリストを取得.
        /// </summary>
        /// <returns></returns>
        public List<int> GetAllIndexList()
        {
            var result = new List<int>();

            result.AddRange(this.SeriesList.Select(series => series.Index));
            result.AddRange(this.SkillList.Select(skill => skill.Index));

            return result;
        }
    }
}
