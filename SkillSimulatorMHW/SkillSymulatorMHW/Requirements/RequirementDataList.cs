using System.Collections.Generic;
using System.Linq;
using SkillSimulatorMHW.Defines;

namespace SkillSimulatorMHW.Requirements
{
    /// <summary>
    /// 検索条件リスト.
    /// </summary>
    /// <remarks>シリアライズの為、辞書ではなくリストで保持</remarks>
    public class RequirementDataList : List<RequirementData>
    {
        /// <summary>
        /// 検索条件をセット(上書き)
        /// </summary>
        /// <param name="requirementData"></param>
        public void Set(RequirementData requirementData)
        {
            // 既に存在する場合は削除.
            this.RemoveAll(req => req.Part == requirementData.Part);

            // 要素を追加する.
            this.Add(requirementData);
        }

        /// <summary>
        /// 検索条件取得.
        /// </summary>
        /// <param name="part">部位</param>
        /// <returns></returns>
        public RequirementData Get(Part part)
        {
            var requirementData = this.FirstOrDefault(req => req.Part == part);
            if (null == requirementData)
            {
                requirementData = new RequirementData(part);
                this.Add(requirementData);
            }

            return requirementData;
        }
    }

}
