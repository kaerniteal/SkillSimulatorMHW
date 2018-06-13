using System;
using SkillSimulatorMHW.Defines;

namespace SkillSimulatorMHW.Requirements
{
    /// <summary>
    /// 検索条件(レア度).
    /// </summary>
    public class RequirementRareData
    {
        /// <summary>
        /// 最小レア度.
        /// </summary>
        public const int RareMin = 1;

        /// <summary>
        /// 下位最大レア度.
        /// </summary>
        public const int RareLowerMax = 4;

        /// <summary>
        /// 上位最大レア度
        /// </summary>
        public const int RareUpperMax = 8;

        /// <summary>
        /// コンストラクタ.
        /// </summary>
        public RequirementRareData()
        {
            this.SetRare(Rank.High);
        }

        /// <summary>
        /// 指定ランク.
        /// </summary>
        public Rank Rank { get; set; }

        /// <summary>
        /// 下限.
        /// </summary>
        public int Lower { get; set; }

        /// <summary>
        /// 上限.
        /// </summary>
        public int Upper { get; set; }

        /// <summary>
        /// レア度セット.
        /// </summary>
        /// <param name="rank"></param>
        public void SetRare(Rank rank)
        {
            this.Rank = rank;

            switch (rank)
            {
                case Rank.Non:
                    this.Lower = RareMin;
                    this.Upper = RareUpperMax;
                    break;

                case Rank.Low:
                    this.Lower = RareMin;
                    this.Upper = RareLowerMax;
                    break;

                case Rank.High:
                    this.Lower = RareLowerMax + 1;
                    this.Upper = RareUpperMax;
                    break;

                case Rank.G:
                    this.Lower = RareUpperMax;
                    this.Upper = RareUpperMax;
                    break;

                default:
                    throw new ArgumentOutOfRangeException("rank", rank, null);
            }
        }

        /// <summary>
        /// レア度セット.
        /// </summary>
        public void SetRare(int lower, int upper)
        {
            this.Rank = Rank.Non;
            this.Lower = lower;
            this.Upper = upper;
        }
    }
}
