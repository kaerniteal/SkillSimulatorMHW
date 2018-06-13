using System;
using System.Windows.Forms;
using SkillSimulatorMHW.Data;
using SkillSimulatorMHW.Result;

namespace SkillSimulatorMHW.Forms
{
    /// <summary>
    /// 結果フィルタ設定ダイアログクラス.
    /// </summary>
    public partial class DlgResultFilter : Form
    {
        /// <summary>
        /// コンストラクタ.
        /// </summary>
        public DlgResultFilter()
        {
            InitializeComponent();
        }

        /// <summary>
        /// コンフィグを反映.
        /// </summary>
        /// <param name="filter"></param>
        public void SetResultFilter(ResultFilter filter)
        {
            this.spinNeedBlankSlotLv1.Text = filter.NeedBlankSlotLv1.ToString();
            this.spinNeedBlankSlotLv2.Text = filter.NeedBlankSlotLv2.ToString();
            this.spinNeedBlankSlotLv3.Text = filter.NeedBlankSlotLv3.ToString();

        }

        /// <summary>
        /// フィルタを取得.
        /// </summary>
        /// <returns></returns>
        public ResultFilter GetResultFilter()
        {
            // 画面の内容を反映.
            return new ResultFilter
            {
                NeedBlankSlotLv1 = Int32.Parse(this.spinNeedBlankSlotLv1.Text),
                NeedBlankSlotLv2 = Int32.Parse(this.spinNeedBlankSlotLv2.Text),
                NeedBlankSlotLv3 = Int32.Parse(this.spinNeedBlankSlotLv3.Text),
            };
        }

        /// <summary>
        /// フィルタをクリアする.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CallBackBtnFilterClearClick(object sender, EventArgs e)
        {
            // デフォルトの設定を画面に反映.
            this.SetResultFilter(new ResultFilter());
        }
    }
}
