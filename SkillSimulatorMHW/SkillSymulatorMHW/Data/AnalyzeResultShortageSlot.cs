using System;
using System.Collections.Generic;
using System.Linq;
using SkillSimulatorMHW.Extensions;
using SkillSimulatorMHW.Result;

namespace SkillSimulatorMHW.Data
{
    /// <summary>
    /// 要因解析データ(スロット不足).
    /// </summary>
    public class AnalyzeResultShortageSlot : AnalyzeResultBase
    {
        /// <summary>
        /// コンストラクタ.
        /// </summary>
        public AnalyzeResultShortageSlot(string key, List<ResultSet> resultSetList)
            : base(key, resultSetList)
        {
            this.SlotList = key.Split('.')
                .Select(Int32.Parse)
                .ToList();
        }

        /// <summary>
        /// スロットデータを格納.
        /// </summary>
        private List<int> SlotList { get; set; }

        /// <summary>
        /// 解析結果タイプを返す.
        /// </summary>
        /// <returns></returns>
        public override AnalyzeResultType GetAnalyzeResultType()
        {
            return AnalyzeResultType.ShortageSlot;
        }

        /// <summary>
        /// 要因を説明する文字列を取得.
        /// </summary>
        /// <returns></returns>
        public override string GetFactor()
        {
            var slots = this.SlotList
                .Select(SlotData.IntToStr)
                .ToList();

            return "スロット[{0}]が不足しています。".Fmt(string.Join("", slots));
        }

        /// <summary>
        /// 詳細を説明する文字列を取得.
        /// </summary>
        /// <returns></returns>
        public override string GetDetails()
        {
            // TODO:nakamura ③を○個、①を○個・・みたいな文字列に変える？

            return string.Empty;
        }

        /// <summary>
        /// 発令までに惜しいかどうか
        /// </summary>
        /// <returns></returns>
        public override bool IsNearly()
        {
            return 1 == this.SlotList.Count;
        }
    }
}
