using System.Drawing;
using System.Windows.Forms;
using SkillSimulatorMHW.Controls;
using SkillSimulatorMHW.Data;

namespace SkillSimulatorMHW.Forms
{
    /// <summary>
    /// 結果リスト表示ダイアログクラス.
    /// </summary>
    public partial class DlgResultList : Form
    {
        /// <summary>
        /// コンストラクタ.
        /// </summary>
        public DlgResultList()
        {
            this.ResultListControl = new ResultListControl();

            InitializeComponent();

            // 結果コントロールを生成.
            this.ResultListControl.Init();
            this.ResultListControl.Location = new Point(3, 12);
            this.Controls.Add(this.ResultListControl);
        }

        /// <summary>
        /// 結果リストコントロール
        /// </summary>
        private ResultListControl ResultListControl { get; set; }

        /// <summary>
        /// 結果セットリストを登録.
        /// </summary>
        /// <param name="analyzeResultBase">解析結果.</param>
        public void SetResult(AnalyzeResultBase analyzeResultBase)
        {
            this.Text = analyzeResultBase.GetFactor();

            // 結果コントロールに反映.
            this.ResultListControl.SetResult(analyzeResultBase.ResultSetList);
        }
    }
}
