using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using SkillSimulatorMHW.Controls;
using SkillSimulatorMHW.Result;

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
        /// <param name="title">見出し.</param>
        /// <param name="resultList">結果リスト.</param>
        public void SetResult(string title, List<ResultSet> resultList)
        {
            this.Text = title;

            // 結果コントロールに反映.
            this.ResultListControl.SetResult(resultList);
        }
    }
}
