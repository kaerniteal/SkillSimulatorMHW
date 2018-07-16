﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using SkillSimulatorMHW.Data;
using SkillSimulatorMHW.Defines;
using SkillSimulatorMHW.Engines.v0_0_0.Candidates;
using SkillSimulatorMHW.Extensions;
using SkillSimulatorMHW.Interface;
using SkillSimulatorMHW.Requirements;
using SkillSimulatorMHW.Result;

namespace SkillSimulatorMHW.Engines.v0_0_0
{
    /// <summary>
    /// 検索実行クラス.
    /// </summary>
    public class SearchEngine0_0_0 : SearchEngine
    {
        /// <summary>
        /// ID
        /// </summary>
        public const string Id = "0.0.0";

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public SearchEngine0_0_0()
        {
            this.Requirements = null;
            this.MainForm = null;
            this.AnalyzeFactors = false;
            this.CandidateSet = null;
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
            this.DicDoneKey = new Dictionary<string, SearchSet>();
            this.OverlapCount = 0;
            this.TotalCalled = 0;
            this.ResultData = new ResultData();
        }

        /// <summary>
        /// 検索処理.
        /// </summary>
        public override ResultData Search()
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
        /// <remarks>装飾品の検索条件を設定して再起処理に渡す</remarks>
        /// <param name="resultData"></param>
        /// <returns></returns>
        private void SearchMain(ResultData resultData)
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

                // スロットが不足している場合、下記条件のいずれかにヒットしたら検索終了
                // ・未確定防具が残っていない場合.
                // ・抽象化防具を使用しない場合.
                unsettledPartList = searchSet.GetUnsettledArmorList();
                if (!unsettledPartList.Any() || !Ssm.Config.UseArmorAbstract)
                {
                    // 解析を実施する場合.
                    if (this.AnalyzeFactors)
                    {
                        // スロット不足で不十分な組み合わせ.
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
                unsettledPartList = this.GetUnsettledPartList(searchSet, lastFixedPart);

                // 未確定防具が残っていない場合はスキル不足で不十分な組み合わせ.
                if (!unsettledPartList.Any())
                {
                    // 下記の条件を全て満たしている場合.
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

            // スキルの評価.
            {
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
            }

            // スロットの評価.
            {
                // 現在のセットが装備している全てのスロットのLvリスト
                var equippedSlotLvList = searchSet.GetEquippedSlotLvList();

                // 必要スロットリスト
                var needSlotLvList = searchSet.Accessory.GetNeedSlotLvList();

                // 装備スロットを下位Lvから走査.
                // 必要スロットLvと装備スロットLvを低いほうから順番に比較して、
                // 必要スロットLv <= 装備スロットLvであれば格納可能と判定する.
                var needIndex = 0;
                foreach (var equippedLv in equippedSlotLvList)
                {
                    // 必要スロットがまだ残っていてかつ装備Lvが必要Lvを超えていれば装備可能.
                    if (needIndex < needSlotLvList.Count &&
                        needSlotLvList[needIndex] <= equippedLv)
                    {
                        // 装備可能なので必要Indexを進める.
                        needIndex++;
                    }
                }

                // 残っている必要スロットがあれば不足リストに追加.
                // 上のループでインクリメントしたneedIndexをそのまま使用する.
                for (; needIndex < needSlotLvList.Count; needIndex++)
                {
                    searchReport.LackSlotList.Add(needSlotLvList[needIndex]);
                }
            }

            // 生成したリポートを返す.
            return searchReport;
        }

        /// <summary>
        /// 指定部位よりもPart順で後位の未確定部位リストを取得.
        /// </summary>
        /// <returns></returns>
        private List<PartDataBase> GetUnsettledPartList(SearchSet searchSet, Part lastPart)
        {
            // 検索順序リスト.
            // この順序で再帰処理がまわる為、順序は意識する必要がある
            // ・装飾品は再帰処理に入る前のループで扱うため、処理不要
            // ・武器は未使用か固定の２択なので処理不要
            // ・護石は同じシリーズ護石で下位、上位がある為、再帰処理の中では最初に確定する.
            var searchList = new List<PartDataBase>
            {
                searchSet.Head,
                searchSet.Body,
                searchSet.Arm,
                searchSet.Waist,
                searchSet.Leg,
                searchSet.Amulet,
            };

            // 検索順序リストの順で、最終セットされた部位よりも後ろでかつ、未確定の部位のリストを生成する.
            // 組み合わせは総当りで検索するが、
            // 未確定部位リストの前方には戻らない(順序違いの同じ組み合わせが出てくるから)
            // lastPartには一つ上位のレイヤで確定した部位が入っている為、
            // 以降に検索すべきはlastPartより後方の未確定部位のみとなる。
            var hitLast = Part.Non == lastPart;
            var unsettledPartList = new List<PartDataBase>();
            foreach (var part in searchList)
            {
                // フラグがONでかつ、未確定部位ならばリストに追加.
                if (hitLast && PartState.Unsettled == part.State)
                {
                    unsettledPartList.Add(part);
                }
                // 最終格納部位を見つけたらフラグON
                else if (part.Part == lastPart)
                {
                    hitLast = true;
                }
            }

            // 全部位のリストを返す.
            return unsettledPartList;
        }
    }
}
