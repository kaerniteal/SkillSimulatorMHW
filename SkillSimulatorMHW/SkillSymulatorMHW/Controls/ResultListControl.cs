using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SkillSimulatorMHW.Extensions;
using SkillSimulatorMHW.Forms;
using SkillSimulatorMHW.Result;

namespace SkillSimulatorMHW.Controls
{
    /// <summary>
    /// 結果リストコントロール.
    /// </summary>
    public partial class ResultListControl : UserControl
    {
        /// <summary>
        /// コンストラクタ.
        /// </summary>
        public ResultListControl()
        {
            this.ResultList = new List<ResultSet>();
            this.ResultCtrlList = new List<ResultControl>();
            this.ResultFilter = new ResultFilter();
            this.DicSetKey = new Dictionary<string, ResultSet>();

            InitializeComponent();

            // あらかじめインスタンスを生成しておく.
            for (var i = 0; i < Ssm.Config.ShowResultLimitCount; i++)
            {
                this.ResultCtrlList.Add(new ResultControl());
            }
        }

        /// <summary>
        /// 検索結果リスト.
        /// </summary>
        private List<ResultSet> ResultList { get; set; }

        /// <summary>
        /// 検索結果コントロールリスト.
        /// </summary>
        private List<ResultControl> ResultCtrlList { get; set; }

        /// <summary>
        /// 結果フィルタ.
        /// </summary>
        private ResultFilter ResultFilter { get; set; }

        /// <summary>
        /// Key辞書
        /// </summary>
        protected Dictionary<string, ResultSet> DicSetKey { get; set; }

        /// <summary>
        /// 結果フィルタチェックボックス.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CallBackChkResultFilterCheckedChanged(object sender, System.EventArgs e)
        {
            this.btnResultFilter.Enabled = this.chkResultFilter.Checked;

            this.UpdateResultList();
        }

        /// <summary>
        /// 結果フィルタ編集ボタン押下.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CallBackBtnResultFilterClick(object sender, System.EventArgs e)
        {
            var dlg = new DlgResultFilter(this.ResultFilter, this.ResultList);
            if (DialogResult.OK == dlg.ShowDialog())
            {
                this.ResultFilter = dlg.GetResultFilter();
                this.UpdateResultList();
            }
        }

        /// <summary>
        /// 初期化.
        /// </summary>
        public void Init()
        {
            // 結果フィルタ.
            this.chkResultFilter.Init(false);
        }

        /// <summary>
        /// 結果セットリストを登録.
        /// </summary>
        /// <param name="resultList">結果データ.</param>
        public void SetResult(List<ResultSet> resultList)
        {
            // 結果を格納.
            this.ResultList = this.SortList(resultList);

            // パネルに反映.
            // 現在のフィルタの状態によって更新の仕方が変わる.
            if (this.chkResultFilter.Checked)
            {
                // フィルタが有効な場合は、フィルタを外す事で更新もかかる.
                this.chkResultFilter.Checked = false;
            }
            else
            {
                // フィルタが無効な場合は直接更新処理をよぶ
                this.UpdateResultList();
            }

            // 出力結果保存.
            if (Ssm.Config.EnableResultOutput)
            {
                using (var sw = new StreamWriter(Ssm.Config.FileNameResultOutput, false, Encoding.UTF8))
                {
                    foreach (var result in this.ResultList)
                    {
                        sw.WriteLine(result.GetAllText());
                    }
                    sw.Close();
                }
            }
        }

        /// <summary>
        /// 結果リスト更新.
        /// </summary>
        private void UpdateResultList()
        {
            // 別スレッドから呼び出された場合
            if (this.InvokeRequired)
            {
                this.BeginInvoke(this.UpdateResultList);
                return;
            }

            // 描画更新の停止.
            this.pnlResultList.BeginControlUpdate();

            try
            {
                // パネルをクリア.
                this.pnlResultList.Controls.Clear();

                // 結果のフィルタ.
                var filteredList = !this.chkResultFilter.Checked
                    ? this.ResultList
                    : this.ResultList
                        .Where(this.ResultFilter.Filter)
                        .ToList();

                // 表示最大件数を求める.
                var limit = Ssm.Config.ShowResultLimitCount;
                var max = filteredList.Count;

                // リミットが有効(0以外)な場合、
                // リミットか結果数のどちらか小さいほうを最大とする.
                if (0 != limit && limit < max)
                {
                    max = limit;
                }

                // 件数を表示.
                this.txtbResultCount.Text = "{0}件".Fmt(max);

                for (var i = 0; i < max; i++)
                {
                    var result = filteredList[i];
                    ResultControl ctrl = null;
                    if (i < this.ResultCtrlList.Count)
                    {
                        ctrl = this.ResultCtrlList[i];
                    }
                    else
                    {
                        ctrl = new ResultControl();
                        this.ResultCtrlList.Add(ctrl);
                    }

                    ctrl.Set((i + 1), result);
                    this.pnlResultList.Controls.Add(ctrl);
                    var y = i * ctrl.Size.Height;
                    ctrl.Location = new Point(0, y);
                }
            }
            finally
            {
                // 描画更新の再開.
                this.pnlResultList.EndControlUpdate();
            }
        }

        /// <summary>
        /// 結果リストソート.
        /// </summary>
        /// <returns></returns>
        private List<ResultSet> SortList(List<ResultSet> resultList)
        {
            // 辞書に登録.
            this.DicSetKey.Clear();
            foreach (var set in resultList)
            {
                // このセットをユニークに表すKEY文字列を取得.
                var key = set.GetKey();
                if (this.DicSetKey.ContainsKey(key))
                {
                    if (Ssm.Config.EnableDuplicateCheck && Ssm.Config.ShowDebugLog)
                    {
                        Log.Write("【DEBUG】重複したセット:{0})".Fmt(set.GetAllText()));
                    }
                }
                else
                {
                    // まだ検索していないパターンは辞書登録.
                    this.DicSetKey.Add(key, set);
                }
            }

            return this.DicSetKey
                .OrderBy(elm => elm.Key)
                .Select(elm => elm.Value)
                .ToList();
        }
    }
}
