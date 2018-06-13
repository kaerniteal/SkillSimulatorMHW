using System.Collections.Generic;
using SkillSimulatorMHW.Defines;

namespace SkillSimulatorMHW.Requirements
{
    /// <summary>
    /// 検索条件データ.
    /// </summary>
    public class RequirementData
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public RequirementData()
        {
            this.Part = Part.Non;
            this.SetDefault();
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public RequirementData(Part part)
        {
            this.Part = part;
            this.SetDefault();
        }

        /// <summary>
        /// 部位.
        /// </summary>
        public Part Part { get; set; }

        /// <summary>
        /// 検索条件種別.
        /// </summary>
        public TermsType TermsType { get; set; }

        /// <summary>
        /// 固定装備Index.
        /// </summary>
        public int FixedIndex { get; set; }

        /// <summary>
        /// 除外リスト.
        /// </summary>
        public List<int> IgnoreList { get; set; }

        /// <summary>
        /// 所持リスト.
        /// </summary>
        public List<int> PossessionList { get; set; }

        /// <summary>
        /// デフォルトをセット.
        /// </summary>
        private void SetDefault()
        {
            switch (this.Part)
            {
                case Part.Head:
                case Part.Body:
                case Part.Arm:
                case Part.Waist:
                case Part.Leg:
                case Part.Amulet:
                    this.TermsType = TermsType.All;
                    break;
                default:
                    this.TermsType = TermsType.Unused;
                    break;
            }

            this.FixedIndex = 0;
            this.IgnoreList = new List<int>();
            this.PossessionList = new List<int>();
        }
    }
}
