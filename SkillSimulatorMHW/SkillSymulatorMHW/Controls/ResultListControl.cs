﻿using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SkillSimulatorMHW.Defines;
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
            var dlg = new DlgResultFilter();
            dlg.SetResultFilter(this.ResultFilter);
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
            this.ResultList = resultList;

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
                var filteredList = this.ResultList;
                if (this.chkResultFilter.Checked)
                {
                    filteredList = this.ResultList
                        .Where(this.ResultFilter.Filter)
                        .ToList();
                }

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
    }
}