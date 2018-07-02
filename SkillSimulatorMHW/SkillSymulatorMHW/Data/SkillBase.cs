using System;
using SkillSimulatorMHW.Extensions;

namespace SkillSimulatorMHW.Data
{
    /// <summary>
    /// スキルデータ(基底).
    /// </summary>
    public class SkillBase
    {
        /// <summary>
        /// 文字列表現のセパレータ.
        /// </summary>
        private const char Separator = '-';

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public SkillBase(int index = 0, int lv = 1)
        {
            this.Index = index;
            this.Lv = lv;
        }

        /// <summary>
        /// スキル
        /// </summary>
        public int Index { get; set; }

        /// <summary>
        /// スキルレベル.
        /// </summary>
        public int Lv { get; set; }

        /// <summary>
        /// このスキルの文字列表現.
        /// </summary>
        /// <returns></returns>
        public virtual string GetText()
        {
            return "{0}{1}{2}".Fmt(this.Index, Separator, this.Lv);
        }

        /// <summary>
        /// 文字列表現から生成.
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static SkillBase CreateFromText(string text)
        {
            var facts = text.Split(Separator);
            return 2 == facts.Length
                ? new SkillBase(Int32.Parse(facts[0]), Int32.Parse(facts[1]))
                : new SkillBase(0);
        }
    }
}
