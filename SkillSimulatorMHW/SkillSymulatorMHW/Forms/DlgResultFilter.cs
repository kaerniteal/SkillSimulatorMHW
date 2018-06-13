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
                NeedBlankSlotLv1 = decimal.ToInt32(this.spinNeedBlankSlotLv1.Value),
                NeedBlankSlotLv2 = decimal.ToInt32(this.spinNeedBlankSlotLv2.Value),
                NeedBlankSlotLv3 = decimal.ToInt32(this.spinNeedBlankSlotLv3.Value),
            };
        }

        /// <summary>
        /// フィルタ条件を変更する.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CallBackResultFilterValueChanged(object sender, EventArgs e)
        {
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
            this.spinNeedBlankSlotLv1.Value = defaultFilter.NeedBlankSlotLv1;
            this.spinNeedBlankSlotLv2.Value = defaultFilter.NeedBlankSlotLv2;
            this.spinNeedBlankSlotLv3.Value = defaultFilter.NeedBlankSlotLv3;

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
