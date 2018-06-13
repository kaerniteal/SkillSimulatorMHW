using System;
using System.Collections.Generic;
using System.Linq;
using SkillSimulatorMHW.Candidates;
using SkillSimulatorMHW.Data;
using SkillSimulatorMHW.Defines;
using SkillSimulatorMHW.Interface;
using SkillSimulatorMHW.Requirements;
using SkillSimulatorMHW.Extensions;
using SkillSimulatorMHW.Result;

namespace SkillSimulatorMHW.Executors
{
    /// <summary>
    /// 検索実行クラス.
    /// </summary>
    public class SearchExecutor : ProgressExecutorBase
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="requirements"></param>
        /// <param name="mainForm"></param>
        /// <param name="analyzeFactors"></param>
        public SearchExecutor(Requirement requirements, IMainForm mainForm, bool analyzeFactors)
        {
            this.Requirements = requirements;
            this.MainForm = mainForm;
            this.AnalyzeFactors = analyzeFactors;
            this.CandidateSet = new CandidateSet(requirements);
            this.DicDoneKey = new Dictionary<string, SearchSet>();
            this.OverlapCount = 0;
            this.TotalCalled = 0;
            this.ResultData = new ResultData();
        }

        /// <summary>
        /// 検索条件.
        /// </summary>
        protected Requirement Requirements { get; set; }

        /// <summary>
        /// メインフレーム.
        /// </summary>
        protected IMainForm MainForm { get; set; }

        /// <summary>
        /// 不足要因解析を実施するかどうか.
        /// </summary>
        protected bool AnalyzeFactors { get; set; }

        /// <summary>
        /// 候補装備リスト.
        /// </summary>
        protected CandidateSet CandidateSet { get; set; }

        /// <summary>
        /// 検索済みKey辞書
        /// </summary>
        protected Dictionary<string, SearchSet> DicDoneKey { get; set; }

        /// <summary>
        /// 重複数.
        /// </summary>
        protected int OverlapCount { get; set; }

        /// <summary>
        /// 総チェック回数.
        /// </summary>
        protected int TotalCalled { get; set; }

        /// <summary>
        /// 検索結果を保持.
        /// </summary>
        protected ResultData ResultData { get; set; }

        /// <summary>
        /// 検索実行.
        /// </summary>
        protected override void Execute()
        {
            this.ResultData = this.SerchMain();
        }

        /// <summary>
        /// 検索終了.
        /// </summary>
        public override void Closing()
        {
            // 結果を登録
            this.MainForm.SetResult(this.ResultData);
        }

        /// <summary>
        /// 検索処理.
        /// </summary>
        public ResultData SerchMain()
        {
            var resultData = new ResultData
            {
                 AnalyzeFactors = this.AnalyzeFactors,
            };

            try
            {
                Log.Write("▽検索開始▽");

                if (Ssm.Config.ShowDebugLog)
                {
                    Log.Write("【DEBUG】組み合わせ総数:{0}".Fmt(this.CandidateSet.GetTotalCcombination()));
                }

                // 処理時間計測.
                var sw = new System.Diagnostics.Stopwatch();
                sw.Start();

                try
                {
                    // 検索を開始.
                    this.Search(resultData);
                }
                catch (Exception e)
                {
                    Log.Write("【ERROR】検索処理で例外発生[{0}]".Fmt(e.Message));
                }

                // 処理時間計測.
                sw.Stop();

                if (Ssm.Config.ShowDebugLog)
                {
                    Log.Write("【DEBUG】総組み合わせチェック回数:{0}".Fmt(this.TotalCalled));
                    if (Ssm.Config.EnableDuplicateCheck)
                    {
                        Log.Write("【DEBUG】重複数:{0})".Fmt(this.OverlapCount));
                    }
                }

                // 結果出力
                var resultCount = resultData.GetSatisfiedCount();
                if (0 == resultCount)
                {

                    Log.Write("【検索完了】条件を満たす組み合わせが見つかりませんでした。処理時間({1}\'{2}\"{3:000})".Fmt(resultCount, sw.Elapsed.Minutes, sw.Elapsed.Seconds, sw.Elapsed.Milliseconds));
                }
                else
                {
                    Log.Write("【検索完了】{0}件見つかりました。処理時間({1}\'{2}\"{3:000})".Fmt(resultCount, sw.Elapsed.Minutes, sw.Elapsed.Seconds, sw.Elapsed.Milliseconds));
                }
            }
            catch (Exception ex)
            {
                Log.Write("検索中に例外発生。[" + ex.Message + "]");
            }

            return resultData;
        }

        /// <summary>
        /// 検索処理(本体)
        /// </summary>
        /// <remarks>装飾品の検索条件を設定して再起処理に渡す</remarks>
        /// <param name="resultData"></param>
        /// <returns></returns>
        private void Search(ResultData resultData)
        {
            this.SetProgress(0);

            // 開始時点の空の検索セットを生成.
            var searchSet = new SearchSet();

            // 検索前に確定している前提条件を反映.
            foreach (var requirementData in this.Requirements.RequirementDataList)
            {
                var part = requirementData.Part;
                var partData = searchSet.GetPart(part);
                switch (requirementData.TermsType)
                {
                    // 使用しない.
                    case TermsType.Unused:
                        partData.State = PartState.Unuse;
                        break;

                    // 固定装備部位
                    case TermsType.Fixed:
                        // 部位毎に固定データを生成してセットする.
                        partData.SetFixed(requirementData.FixedIndex);
                        break;
                }
            }

            // 検索状況リポートを生成..
            var searchReport = this.CreateSearchReport(searchSet);

            // 装飾品の組み合わせを取得.
            // 装飾品の組み合わせは、装飾品0個もひとつの組み合わせとみなす為、０件はありえない.
            // 「使用しない」設定であっても0個の組み合わせ１件を返すようになっている.
            var candidateAccessory = this.CandidateSet.GetCandidate(Part.Accessory, searchReport);

            // 装飾品の組み合わせ毎に走査.
            var allCount = candidateAccessory.GetCount();
            var unit = 100 / allCount;
            for (var i = 0; i < allCount; i++)
            {
                var accessoryData = candidateAccessory.GetAt(i);

                // 無効装備は無視.
                if (null == accessoryData || !accessoryData.Enable)
                {
                    continue;
                }

                // 候補装備.
                var accessory = accessoryData.PartData;

                // 進捗の最小単位を計算.
                var begin = i * unit;
                var end = (i + 1) * unit;

                // 新たな候補をセットして.
                searchSet.SetPart(Part.Accessory, accessory);

                // 再帰検索処理に渡す.
                var result = this.RecursionSearch(resultData, searchSet, Part.Non, 0, begin, end);

                // セットした候補を外す.
                searchSet.RemovePart(Part.Accessory);

                // 処理中断の場合.
                if (result < 0)
                {
                    break;
                }
            }

            this.SetProgress(100);
        }

        /// <summary>
        /// 再帰検索処理.
        /// </summary>
        /// <param name="resultData">結果を格納</param>
        /// <param name="searchSet">現在までの検索状態</param>
        /// <param name="lastFixedPart">最終確定部位</param>
        /// <param name="nest">再帰階層</param>
        /// <param name="pBegin">この処理の開始時点の進捗</param>
        /// <param name="pEnd">この処理の終了時点の進捗</param>
        /// <returns>この処理で確定したセットの数(マイナスの場合は処理中断)</returns>
        private int RecursionSearch(ResultData resultData, SearchSet searchSet, Part lastFixedPart, int nest, int pBegin, int pEnd)
        {
            // 呼び出され回数をインクリメント
            this.TotalCalled++;

            // 階層をインクリメント.
            var curNest = nest + 1;

            // キャンセルされたか調べる
            if (this.IsCancel())
            {
                // キャンセルされたとき
                return -1;
            }

            // この組み合わせで見つかった確定セット数.
            var determined = 0;

            // 進捗幅.
            var progressUnit = pEnd - pBegin;

            // 重複チェック.
            if (Ssm.Config.EnableDuplicateCheck && this.CheckDuplicate(searchSet))
            {
                // 既に検索済みのパターンの場合はこれ以上の検索不要.
                this.OverlapCount++;
                return 0;
            }

            // 検索数上限に到達しているかどうかをチェック.
            if (0 < Ssm.Config.SerchLimitCount && Ssm.Config.SerchLimitCount <= resultData.GetSatisfiedCount())
            {
                Log.Write("検索結果上限[{0}]件に到達したので中断".Fmt(Ssm.Config.SerchLimitCount));
                return -1;
            }

            // 未確定部位リストを格納
            // ・通常再帰処理の場合は未確定部位・・防具か護石
            // ・スロットのみ不足している場合は抽象化防具を割り当て可能な未確定防具部位のリストを格納.
            var abstractArmorMode = false;
            List<PartDataBase> unsettledPartList;

            // 検索状況リポートを生成..
            var searchReport = this.CreateSearchReport(searchSet);

            // 現状のセットが検索条件を満たすかどうかチェック.
            // スキルが要求を満たしているかどうかチェック.
            if (!searchReport.UnsatisfyList.Any())
            {
                // スロットが必要数を満たしているかチェック.
                if (!searchReport.LackSlotList.Any())
                {
                    // スロットも満たしていれば完成.
                    resultData.AddSatisfiedSet(new ResultSet(searchSet));
                    return 1;
                }

                // スロットが不足している場合.

                // 未確定防具が残っているかどうかチェック.
                unsettledPartList = searchSet.GetUnsettledArmorList();
                if (!unsettledPartList.Any())
                {
                    // 未確定防具が残っていない場合は.
                    // スロット不足で不十分な組み合わせ.
                    if (this.AnalyzeFactors)
                    {
                        resultData.AddShortageSlot(searchReport.GetLackSlotKey(), new ResultSet(searchSet));
                    }

                    // これ以上の検索は不要.
                    return 0;
                }

                // 抽象化防具を使用しない場合.
                if (!Ssm.Config.UseArmorAbstract)
                {
                    // この時点で検索打ち切り.
                    if (this.AnalyzeFactors)
                    {
                        resultData.AddShortageSlot(searchReport.GetLackSlotKey(), new ResultSet(searchSet));
                    }

                    // これ以上の検索は不要.
                    return 0;
                }

                // 未確定防具が残っている場合.
                // 抽象化防具検索モードへ移行.
                abstractArmorMode = true;
            }
            else
            {
                // スキルが不足している場合は未確定部位リストを取得.
                unsettledPartList = searchSet.GetUnsettledPartList(lastFixedPart);

                // 未確定防具が残っていない場合はスキル不足で不十分な組み合わせ.
                if (!unsettledPartList.Any())
                {
                    // 不足しているスキルが一つで、かつ解析を実施する場合.
                    if (this.AnalyzeFactors && 1 == searchReport.UnsatisfyList.Count)
                    {
                        resultData.AddShortageSkill(searchReport.GetUnsatisfyKey(), new ResultSet(searchSet));
                    }

                    // これ以上の検索は不要.
                    return 0;
                }
            }

            // 部位毎の進捗単位を計算.
            var partUnit = 0;
            if (0 < progressUnit && 0 < unsettledPartList.Count)
            {
                partUnit = progressUnit / unsettledPartList.Count;
            }

            // 未確定部位毎に走査.
            // 進捗計算のために i が必要
            for (var i = 0; i < unsettledPartList.Count; i++)
            {
                // 未確定部位.
                var unsettledPart = unsettledPartList[i];

                // 未確定部位の候補装備のリスト管理データを格納.
                var candidatePart = abstractArmorMode
                    ? this.CandidateSet.GetArmorAbstract(unsettledPart.Part, searchReport)
                    : this.CandidateSet.GetCandidate(unsettledPart.Part, searchReport);

                // 候補装備数.
                var allCount = candidatePart.GetCount();

                // 最後の未確定部位でかつ、候補装備が存在しない場合.
                if ((i + 1) == unsettledPartList.Count && 0 == allCount)
                {
                    // 進捗の最小単位を計算.
                    var begin = pBegin;
                    var end = pBegin + (i * partUnit);

                    // 部位を取得.
                    var part = searchSet.GetPart(unsettledPart.Part);

                    // 候補なしにセット.
                    part.State = PartState.NotExist;

                    // ＞＞＞＞再帰呼び出し＜＜＜＜
                    // 検索処理を再帰呼び出し.
                    var result = this.RecursionSearch(resultData, searchSet, unsettledPart.Part, curNest, begin, end);
                    // ＞＞＞＞再帰呼び出し＜＜＜＜

                    // 未確定に戻して処理継続.
                    part.State = PartState.Unsettled;

                    // 条件を満たす組み合わせが見つかった場合.
                    if (0 < result)
                    {
                        // 結果に登録.
                        determined += result;
                    }
                    else if (result < 0)
                    {
                        // 処理中断の場合.
                        return -1;
                    }

                    continue;
                }

                // 装備毎に走査.
                // 進捗管理の為に j が必要.
                for (var j = 0; j < allCount; j++)
                {
                    var candidateData = candidatePart.GetAt(j);

                    // 無効装備は無視.
                    if (null == candidateData || !candidateData.Enable)
                    {
                        continue;
                    }

                    // 候補装備.
                    var candidate = candidateData.PartData;

                    // 進捗の最小単位を計算.
                    var begin = pBegin;
                    var end = pBegin;
                    if (0 < partUnit)
                    {
                        // 候補装備毎の進捗単位を計算.
                        // 要素数を取得.
                        var candidateUnit = partUnit / allCount;
                        if (0 < candidateUnit)
                        {
                            begin = pBegin + (i * partUnit) + (j * candidateUnit);
                            end = begin + candidateUnit;
                        }
                    }

                    // 新たな候補をセットして.
                    searchSet.SetPart(unsettledPart.Part, candidate);

                    // ＞＞＞＞再帰呼び出し＜＜＜＜
                    // 検索処理を再帰呼び出し.
                    var result = this.RecursionSearch(resultData, searchSet, unsettledPart.Part, curNest, begin, end);
                    // ＞＞＞＞再帰呼び出し＜＜＜＜

                    // セットした候補を外す.
                    searchSet.RemovePart(unsettledPart.Part);

                    // 条件を満たす組み合わせが見つかった場合.
                    if (0 < result)
                    {
                        // 結果に登録.
                        determined += result;

                        // 上位互換装備を候補リストから除く.
                        candidatePart.RemoveUpwardCompatibility(candidate, searchReport);
                    }
                    else if (result < 0)
                    {
                        // 処理中断の場合.
                        return -1;
                    }
                }
            }

            // 進捗を更新.
            if (1 <= (pEnd - pBegin))
            {
                this.SetProgress((int)pEnd);
            }

            return determined;
        }

        /// <summary>
        /// 重複チェック.
        /// </summary>
        /// <returns></returns>
        private bool CheckDuplicate(SearchSet searchSet)
        {
            // この検索セットの組み合わせをユニークに表すKEY文字列を取得.
            var key = searchSet.GetKey();
            if (this.DicDoneKey.ContainsKey(key))
            {
                // 重複あり.
                return true;
            }

            // まだ検索していないパターンの場合は検索を継続.
            this.DicDoneKey.Add(key, searchSet);

            // 重複なし.
            return false;
        }

        /// <summary>
        /// 検索中の状態レポートを生成する.
        /// </summary>
        /// <param name="searchSet"></param>
        /// <returns></returns>
        private SearchReport CreateSearchReport(SearchSet searchSet)
        {
            var searchReport = new SearchReport();

            // 要求されているシリーズスキルリスト.
            var needSeriesList = this.Requirements.RequirementSkillList.SeriesList;

            // 必要シリーズスキルを一つずつチェックする.
            foreach (var needSeries in needSeriesList)
            {
                // 発動しているかどうかをチェック.
                var count = searchSet.GetSeriesCount(needSeries.Index);
                if (needSeries.Skill.Need <= count)
                {
                    // 満たしているスキルに登録.
                    searchReport.SatisfyList.Add(needSeries.Index);
                }
                else
                {
                    // 満たしていないスキルに登録.
                    searchReport.UnsatisfyList.Add(needSeries.Index);
                    searchReport.UnsatisfyBaseList.Add(new SkillBase(
                        needSeries.Index,
                        needSeries.Skill.Need - count));
                }
            }

            // 要求されているスキルリスト.
            var needSkillList = this.Requirements.RequirementSkillList.SkillList;

            // 必要スキルを一つずつチェックする.
            foreach (var needSkill in needSkillList)
            {
                // 検索セットが必要スキルLvを満たしている場合.
                var sumLv = searchSet.GetSkillLvSum(needSkill.Index);
                if (needSkill.Lv <= sumLv)
                {
                    // 満たしているスキルに登録.
                    searchReport.SatisfyList.Add(needSkill.Index);
                }
                else
                {
                    // 満たしていないスキルに登録.
                    searchReport.UnsatisfyList.Add(needSkill.Index);
                    searchReport.UnsatisfyBaseList.Add(new SkillBase(
                        needSkill.Index,
                        needSkill.Lv - sumLv));
                }
            }

            // 空き、不足スロット状況を格納.
            searchSet.GetBlankSlot(searchReport.BlankSlotList, searchReport.LackSlotList);

            // 生成したリポートを返す.
            return searchReport;
        }
    }
}
