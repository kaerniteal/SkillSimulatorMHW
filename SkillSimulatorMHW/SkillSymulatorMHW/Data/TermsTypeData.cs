using SkillSimulatorMHW.Defines;

namespace SkillSimulatorMHW.Data
{
    /// <summary>
    /// 検索条件種別データ.
    /// </summary>
    public class TermsTypeData
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public TermsTypeData(TermsType termsType)
        {
            this.TermsType = termsType;
        }

        /// <summary>
        /// 検索条件種別.
        /// </summary>
        public TermsType TermsType { get; set; }

        /// <summary>
        /// 文字列化.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            switch (TermsType)
            {
                case TermsType.Unused:		return "使用しない";
                case TermsType.All:			return "全てを対象にする";
                case TermsType.Ignore:		return "除外リストを使用する";
                case TermsType.Possession:	return "所持リストを使用する";
                case TermsType.Fixed:		return "特定の装備を指定する";
            }

            return string.Empty;
        }
    }
}
