using System;
using System.Windows.Forms;
using SkillSimulatorMHW.Data;
using SkillSimulatorMHW.Extensions;
using SkillSimulatorMHW.Forms;

namespace SkillSimulatorMHW.Controls
{
    /// <summary>
    /// 解析結果表示コントロール.
    /// </summary>
    public partial class AnalyzeFactorControl : UserControl
    {
        /// <summary>
        /// コンストラクタ.
        /// </summary>
        public AnalyzeFactorControl(AnalyzeResultBase analyzeResult)
        {
            InitializeComponent();

            this.AnalyzeResult = analyzeResult;

            this.lblFactor.Text = analyzeResult.GetFactor();
            this.DetailsText = analyzeResult.GetDetails();
            if (this.DetailsText.IsEmpty())
            {
                this.btnDetails.Visible = false;
            }
            else
            {
                this.toolTipFactor.SetToolTip(this.lblFactor, this.DetailsText);
            }
            this.btnShow.Text = "{0}件".Fmt(analyzeResult.ResultSetList.Count);
        }

        /// <summary>
        /// 解析結果データ.
        /// </summary>
        private AnalyzeResultBase AnalyzeResult { get; set; }

        /// <summary>
        /// 詳細テキスト.
        /// </summary>
        private string DetailsText { get; set; }

        /// <summary>
        /// 詳細ボタン押下.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDetails_Click(object sender, EventArgs e)
        {
            MessageBox.Show(this.DetailsText, Ssm.Title);
        }

        /// <summary>
        /// 表示ボタン押下.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CallBackBtnShowClick(object sender, EventArgs e)
        {
            var dlg = new DlgResultList();
            dlg.SetResult(this.AnalyzeResult.GetFactor(), this.AnalyzeResult.ResultSetList);
            dlg.ShowDialog();
        }
    }
}
