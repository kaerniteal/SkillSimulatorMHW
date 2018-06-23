using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using SkillSimulatorMHW.Extensions;
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
        /// <param name="defaultFilter"></param>
        /// <param name="resultList"></param>
        public DlgResultFilter(ResultFilter defaultFilter, List<ResultSet> resultList)
        {
            this.ResultList = resultList;

            InitializeComponent();

            this.btnPlusBlankSlotLv1.Tag = this.txtbValBlankSlotLv1;
            this.btnPlusBlankSlotLv2.Tag = this.txtbValBlankSlotLv2;
            this.btnPlusBlankSlotLv3.Tag = this.txtbValBlankSlotLv3;
            this.btnMinusBlankSlotLv1.Tag = this.txtbValBlankSlotLv1;
            this.btnMinusBlankSlotLv2.Tag = this.txtbValBlankSlotLv2;
            this.btnMinusBlankSlotLv3.Tag = this.txtbValBlankSlotLv3;

            this.SetResultFilter(defaultFilter);
        }

        /// <summary>
        /// 検索結果リスト.
        /// </summary>
        private List<ResultSet> ResultList { get; set; }

        /// <summary>
        /// フィルタを取得.
        /// </summary>
        /// <returns></returns>
        public ResultFilter GetResultFilter()
        {
            // 画面の内容を反映.
            return new ResultFilter
            {
                NeedBlankSlotLv1 = Int32.Parse(this.txtbValBlankSlotLv1.Text),
                NeedBlankSlotLv2 = Int32.Parse(this.txtbValBlankSlotLv2.Text),
                NeedBlankSlotLv3 = Int32.Parse(this.txtbValBlankSlotLv3.Text),
            };
        }

        /// <summary>
        /// 空きスロット条件をインクリメントする.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CallBackBtnPlusBlankSlotClick(object sender, EventArgs e)
        {
            var btn = sender as Button;
            if (null == btn)
            {
                return;
            }

            var txtb = btn.Tag as TextBox;
            if (null == txtb)
            {
                return;
            }

            var val = Int32.Parse(txtb.Text) + 1;
            txtb.Text = val.ToString();

            this.UpdateFilterdCount();
        }

        /// <summary>
        /// 空きスロット条件をデクリメントする.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CallBackBtnMinusBlankSlotClick(object sender, EventArgs e)
        {
            var btn = sender as Button;
            if (null == btn)
            {
                return;
            }

            var txtb = btn.Tag as TextBox;
            if (null == txtb)
            {
                return;
            }

            var val = Int32.Parse(txtb.Text) - 1;
            if (val < 0)
            {
                val = 0;
            }

            txtb.Text = val.ToString();

            this.UpdateFilterdCount();
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

        /// <summary>
        /// フィルタを反映.
        /// </summary>
        /// <param name="defaultFilter"></param>
        private void SetResultFilter(ResultFilter defaultFilter)
        {
            this.txtbValBlankSlotLv1.Text = defaultFilter.NeedBlankSlotLv1.ToString();
            this.txtbValBlankSlotLv2.Text = defaultFilter.NeedBlankSlotLv2.ToString();
            this.txtbValBlankSlotLv3.Text = defaultFilter.NeedBlankSlotLv3.ToString();

            this.UpdateFilterdCount();
        }

        /// <summary>
        /// フィルタ後のカウントを更新する.
        /// </summary>
        private void UpdateFilterdCount()
        {
            var resultFilter = this.GetResultFilter();

            var filterdCount = this.ResultList
                .Where(resultFilter.Filter)
                .Count();

            this.txtbFilterdCount.Text = "{0}件".Fmt(filterdCount);
            this.txtbAllCount.Text = "{0}件".Fmt(this.ResultList.Count);
        }
    }
}
