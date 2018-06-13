using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using SkillSimulatorMHW.Controls;
using SkillSimulatorMHW.Data;
using SkillSimulatorMHW.Extensions;
using SkillSimulatorMHW.Result;

namespace SkillSimulatorMHW.Forms
{
    /// <summary>
    /// 解析結果表示ダイアログクラス.
    /// </summary>
    public partial class DlgAnalyzeResult : Form
    {
        /// <summary>
        /// コンストラクタ.
        /// </summary>
        public DlgAnalyzeResult()
        {
            InitializeComponent();

            this.AnalyzeResultList = new List<AnalyzeResultBase>();
        }

        /// <summary>
        /// 要因解析結果.
        /// </summary>
        private List<AnalyzeResultBase> AnalyzeResultList { get; set; }

        /// <summary>
        /// ラジオボタン変更.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CallBackRadioNearlyCheckedChanged(object sender, EventArgs e)
        {
            // ラジオボタンを切り替えると
            // ONになるボタンとOFFになるボタンの二つからイベントが呼ばれ２回処理が走ってしまう為
            // ONになったイベントの場合のみ処理する.
            var radioBtn = sender as RadioButton;
            if (null != radioBtn && radioBtn.Checked)
            {
                this.UpdateAnalyzeResult();
            }
        }

        /// <summary>
        /// 要因解析結果データをセットする.
        /// </summary>
        /// <returns></returns>
        public void SetAnalyzeResult(ResultData resultData)
        {
            this.AnalyzeResultList = resultData.GetAnalyzeResultList();

            // チェックボックスにチェックをつけることでリストの更新も実施.
            if (this.AnalyzeResultList.Any(result => result.IsNearly()))
            {
                // 惜しい要因が存在する場合.
                this.radioNearly.Checked = true;
            }
            else
            {
                // 惜しい要因が存在しない場合.
                this.radioAll.Checked = true;
            }
        }

        /// <summary>
        /// 要因一覧更新
        /// </summary>
        private void UpdateAnalyzeResult()
        {
            // 別スレッドから呼び出された場合
            if (this.InvokeRequired)
            {
                this.BeginInvoke(this.UpdateAnalyzeResult);
                return;
            }

            // 描画更新の停止.
            this.pnlAnalyzeResultList.BeginControlUpdate();

            try
            {
                var resultList = this.AnalyzeResultList;

                // リストの絞込みを実施.
                if (this.radioNearly.Checked)
                {
                    resultList = this.AnalyzeResultList
                        .Where(res => res.IsNearly())
                        .ToList();
                }

                // パネルをクリア.
                this.pnlAnalyzeResultList.Controls.Clear();

                // コントロールを追加.
                for (var i = 0; i < resultList.Count; i++)
                {
                    var ctrl = new AnalyzeFactorControl(resultList[i]);
                    this.pnlAnalyzeResultList.Controls.Add(ctrl);
                    var y = i * ctrl.Size.Height;
                    ctrl.Location = new Point(0, y);
                }
            }
            finally
            {
                // 描画更新の再開.
                this.pnlAnalyzeResultList.EndControlUpdate();
            }
        }
    }
}
