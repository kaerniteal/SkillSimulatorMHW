using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using SkillSimulatorMHW.Data;
using SkillSimulatorMHW.Defines;
using SkillSimulatorMHW.Engines.v0_6_0.Candidates;
using SkillSimulatorMHW.Extensions;
using SkillSimulatorMHW.Interface;
using SkillSimulatorMHW.Requirements;
using SkillSimulatorMHW.Result;

namespace SkillSimulatorMHW.Engines.v0_6_0
{
    /// <summary>
    /// 検索実行クラス.
    /// </summary>
    public class SearchEngine0_6_0 : SearchEngine
    {
        /// <summary>
        /// ID
        /// </summary>
        public const string Id = "stable";

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public SearchEngine0_6_0()
        {
            this.Requirements = null;
            this.MainForm = null;
            this.AnalyzeFactors = false;
            this.CandidateSet = null;
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
            this.ResultData = this.Search();
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
        /// 検索処理IDを返す.
        /// </summary>
        /// <returns>ID</returns>
        public override string GetId()
        {
            return Id;
        }

        /// <summary>
        /// パラメータセット.
        /// </summary>
        /// <param name="requirements">検索条件</param>
        /// <param name="mainForm">結果反映先</param>
        /// <param name="analyzeFactors">解析実施要否</param>
        public override void SetParam(Requirement requirements, IMainForm mainForm, bool analyzeFactors)
        {
            this.Requirements = requirements;
            this.MainForm = mainForm;
            this.AnalyzeFactors = analyzeFactors;
            this.CandidateSet = new CandidateSet(requirements);
            this.OverlapCount = 0;
            this.TotalCalled = 0;
            this.ResultData = new ResultData();
        }

        /// <summary>
        /// 検索処理.
        /// </summary>
        public override ResultData Search()
        {
            // 結果格納クラスを準備.
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
                    this.SearchMain(resultData);
                }
                catch (Exception e)
                {
                    var message = "【ERROR】検索処理で例外発生\n[{0}]".Fmt(e.Message);
                    MessageBox.Show(message, @"Error");
                    Log.Write(message);
                }

                // 処理時間計測.
                sw.Stop();

                // 結果出力
                var resultCount = resultData.GetSatisfiedCount();
                if (0 == resultCount)
                {

                    Log.Write("【検索完了】条件を満たす組み合わせなし。処理時間({1}\'{2}\"{3:000})".Fmt(resultCount, sw.Elapsed.Minutes, sw.Elapsed.Seconds, sw.Elapsed.Milliseconds));
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
        /// <remarks>再帰処理を呼び出す準備を行う</remarks>
        /// <param name="resultData"></param>
        /// <returns></returns>
        private void SearchMain(ResultData resultData)
        {
            this.SetProgress(0);

            // 開始時点の空の検索セットを生成.
            var searchSet = new SearchSet();

            // 検索前に確定している前提条件を反映.
            // ・使用しない
            // ・固定装備
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

            // 初期検索状況リポートを生成.
            var searchReport = this.CreateSearchReport(searchSet);

            // 未確定部位リストを生成.
            var remainingPartList = this.GetUnsettledPartList(searchSet);
            if (remainingPartList.Any())
            {
                // 再帰検索処理に渡す.
                this.RecursionSearch(resultData, searchSet, searchReport, remainingPartList, false, 0, 1, 100);
            }

            this.SetProgress(100);
        }

        /// <summary>
        /// 再帰検索処理.
        /// </summary>
        /// <param name="resultData">結果を格納</param>
        /// <param name="uppserSet">上位検索セット</param>
        /// <param name="remainingPartList">残未確定部位リスト</param>
        /// <param name="abstractArmorMode">仮想防具モードかどうか</param>
        /// <param name="upperReport">上位検索状況情報</param>
        /// <param name="nest">再帰階層</param>
        /// <param name="pBegin">この処理の開始時点の進捗</param>
        /// <param name="pEnd">この処理の終了時点の進捗</param>
        /// <returns>この処理で確定したセットの数(マイナスの場合は処理中断)</returns>
        private int RecursionSearch(ResultData resultData, SearchSet uppserSet, SearchReport upperReport, List<PartDataBase> remainingPartList, bool abstractArmorMode, int nest, int pBegin, int pEnd)
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

            // ネストで見つかった確定セット数を格納する.
            var determined = 0;

            // この処理での進捗幅.
            var partUnit = pEnd - pBegin;

            // このネストで検索する部位.
            var part = remainingPartList.ElementAt(0);

            // 残りの部位.
            var unsettledPartList = remainingPartList.ToList();
            unsettledPartList.RemoveAt(0);

            // 候補装備リスト管理データを作成.
            var candidateListCtrl = abstractArmorMode
                ? this.CandidateSet.GetArmorAbstract(part.Part, upperReport)
                : this.CandidateSet.GetCandidate(part.Part, upperReport);

            // 候補装備数.
            var allCount = candidateListCtrl.GetCount();

            // 検索セットを複製.
            var searchSet = new SearchSet(uppserSet);

            // 装備毎に走査.
            // 進捗管理の為に i が必要.
            for (var i = 0; i < allCount; i++)
            {
                var candidateData = candidateListCtrl.GetAt(i);

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
                        begin = pBegin + (i * candidateUnit);
                        end = begin + candidateUnit;
                    }
                }

                // 新たな候補をセットして.
                searchSet.SetPart(part.Part, candidate);

                // 検索数上限に到達しているかどうかをチェック.
                if (0 < Ssm.Config.SerchLimitCount &&
                    Ssm.Config.SerchLimitCount <= resultData.GetSatisfiedCount())
                {
                    Log.Write("検索結果上限[{0}件]に到達したので処理中断".Fmt(Ssm.Config.SerchLimitCount));
                    break;
                }

                // 検索状況リポートを生成.
                var searchReport = this.CreateSearchReport(searchSet);

                // 現状のセットが検索条件を満たすかどうかチェック.
                // スキルが要求を満たしている場合.
                if (!searchReport.UnsatisfyList.Any())
                {
                    ////////////////
                    // スキル満足 //
                    ////////////////

                    // スロットが必要数を満たしている場合.
                    if (!searchReport.LackSlotList.Any())
                    {
                        //////////
                        // 完成 //
                        //////////
                        resultData.AddSatisfiedSet(new ResultSet(searchSet));
                        determined += 1;

                        // 上位互換装備を候補リストから除く.
                        candidateListCtrl.RemoveUpwardCompatibility(candidate, searchReport);
                        continue;
                    }

                    // スロットが不足している場合、下記条件のいずれかにヒットしたら検索終了
                    // ・未確定防具が残っていない場合.
                    // ・抽象化防具を使用しない場合.
                    var abstractPartList = searchSet.GetUnsettledArmorList();
                    if (!abstractPartList.Any() || !Ssm.Config.UseArmorAbstract)
                    {
                        //////////////////////////
                        // スロット不足 → 終了 //
                        //////////////////////////

                        // 解析を実施する場合は解析結果に追加.
                        if (this.AnalyzeFactors)
                        {
                            // スロット不足で不十分な組み合わせ.
                            resultData.AddShortageSlot(searchReport.GetLackSlotKey(), new ResultSet(searchSet));
                        }

                        // これ以上の検索は不要.
                        continue;
                    }

                    //////////////////////////////////////////
                    // スロット不足 → 抽象化防具検索モード //
                    //////////////////////////////////////////
                    // ＞＞＞＞再帰呼び出し＜＜＜＜ //
                    // 検索処理を再帰呼び出し.
                    var result = this.RecursionSearch(resultData, searchSet, searchReport, abstractPartList, true, curNest, begin, end);
                    // ＞＞＞＞再帰呼び出し＜＜＜＜

                    // 条件を満たす組み合わせが見つかった場合.
                    if (0 < result)
                    {
                        // 結果に登録.
                        determined += result;
                    }
                    else if (result < 0)
                    {
                        // 処理中断の場合.
                        return result;
                    }
                }
                else
                {
                    ////////////////
                    // スキル不足 //
                    ////////////////

                    // 残りの部位が残っていない場合はスキル不足で不十分な組み合わせ.
                    if (!unsettledPartList.Any())
                    {
                        // 下記の条件を全て満たしている場合は解析結果に登録.
                        // ・不足しているスキルが一つ
                        // ・スロットは満たしている
                        // ・解析を実施する場合.
                        if (this.AnalyzeFactors &&
                            !searchReport.LackSlotList.Any() &&
                            1 == searchReport.UnsatisfyList.Count)
                        {
                            // スキル不足で不十分な組み合わせ.
                            resultData.AddShortageSkill(searchReport.GetUnsatisfyKey(), new ResultSet(searchSet));
                        }

                        // これ以上の検索は不要.
                        continue;
                    }

                    //////////////////////////////////
                    // スキル不足 → 通常検索モード //
                    //////////////////////////////////
                    // ＞＞＞＞再帰呼び出し＜＜＜＜
                    // 検索処理を再帰呼び出し.
                    var result = this.RecursionSearch(resultData, searchSet, searchReport, unsettledPartList, false, curNest, begin, end);
                    // ＞＞＞＞再帰呼び出し＜＜＜＜

                    // 条件を満たす組み合わせが見つかった場合.
                    if (0 < result)
                    {
                        // 結果に登録.
                        determined += result;
                    }
                    else if (result < 0)
                    {
                        // 処理中断の場合.
                        return result;
                    }
                }
            }

            // 進捗を更新.
            if (0 < partUnit)
            {
                this.SetProgress((int)pEnd);
            }
            
            return determined;
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

        /// <summary>
        /// 未確定部位リストを取得.
        /// </summary>
        /// <returns></returns>
        private List<PartDataBase> GetUnsettledPartList(SearchSet searchSet)
        {
            // 検索順序リスト.
            // この順序で再帰処理がまわる為、順序は意識する必要がある
            // ・装飾品は再帰処理に入る前のループで扱うため、処理不要
            // ・武器は未使用か固定の２択なので処理不要
            // ・護石は同じシリーズ護石で下位、上位がある為、再帰処理の中では最後に確定する.
            var searchList = new List<PartDataBase>
            {
                searchSet.Accessory,
                searchSet.Head,
                searchSet.Body,
                searchSet.Arm,
                searchSet.Waist,
                searchSet.Leg,
                searchSet.Amulet,
            };

            // 未確定部位だけのリストにして返却.
            return searchList
                .Where(part => PartState.Unsettled == part.State)
                .ToList();
        }
    }
}
