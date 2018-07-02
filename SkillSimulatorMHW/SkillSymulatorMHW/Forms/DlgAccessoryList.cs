using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using SkillSimulatorMHW.Controls;
using SkillSimulatorMHW.Data;
using SkillSimulatorMHW.Extensions;

namespace SkillSimulatorMHW.Forms
{
    /// <summary>
    /// 装飾品リストダイアログクラス.
    /// </summary>
    public partial class DlgAccessoryList : Form
    {
        /// <summary>
        /// コンストラクタ.
        /// </summary>
        public DlgAccessoryList()
        {
            this.AccessoryCtrlList = new List<AccessoryControl>();

            InitializeComponent();

            this.UpdateAccessoryList();
        }

        /// <summary>
        /// アクセサリコントロールリスト.
        /// </summary>
        private List<AccessoryControl> AccessoryCtrlList { get; set; }

        /// <summary>
        /// ラジオボタン変更.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CallBackRadioCheckedChanged(object sender, System.EventArgs e)
        {
            // ラジオボタンを切り替えると
            // ONになるボタンとOFFになるボタンの二つからイベントが呼ばれ２回処理が走ってしまう為
            // ONになったイベントの場合のみ処理する.
            var radioBtn = sender as RadioButton;
            if (null != radioBtn && radioBtn.Checked)
            {
                // フィルタはクリアする
                this.txtbAccessoryFilter.Text = string.Empty;
                this.UpdateAccessoryList();
            }
        }

        /// <summary>
        /// 装飾品テキストフィルター入力
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CallBackTxtbAccessoryFilterTextChanged(object sender, System.EventArgs e)
        {
            this.UpdateAccessoryList();
        }

        /// <summary>
        /// テキストフィルタクリアボタン押下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CallBackBtnAccessoryFilterClearClick(object sender, System.EventArgs e)
        {
            this.txtbAccessoryFilter.Text = string.Empty;
        }

        /// <summary>
        /// 編集対象リストをセットする.
        /// </summary>
        /// <returns></returns>
        public void SetPossessionList(List<int> possessionList)
        {
            // 所持リストをIndex毎にグループ化.
            var groupedList = possessionList
                .GroupBy(possession => possession)
                .ToList();

            // マスタデータリストを装飾品データに変換.
            var accessoryList = Ssm.Master.MasterAccessory.GetRecordList()
                .OrderByDescending(master => master.SlotLv)
                .Select(master =>
                {
                    // 所持リストに登録がない場合.
                    var first = groupedList.FirstOrDefault(group => group.Key == master.GetIndex());
                    if (null == first)
                    {
                        return new AccessoryData(master, 0);
                    }

                    // 登録がある場合は個数をセット.
                    return new AccessoryData(master, first.Count());
                })
                .ToList();

            // 装飾品データリストを装飾品コントロールリストに変換.
            this.AccessoryCtrlList = accessoryList
                .Select(accessory =>
                {
                    var ctrl = new AccessoryControl();
                    ctrl.SetAccessory(accessory);
                    return ctrl;
                })
                .ToList();

            // リストを更新.
            this.UpdateAccessoryList();
        }

        /// <summary>
        /// 編集結果リストを返す.
        /// </summary>
        /// <returns></returns>
        public List<int> GetPossessionList()
        {
            var indexList = new List<int>();

            foreach (var ctrl in this.AccessoryCtrlList)
            {
                var accessory = ctrl.AccessoryData;
                for (var i = 0; i < accessory.Possession; i++)
                {
                    indexList.Add(accessory.Index);
                }
            }

            return indexList;
        }

        /// <summary>
        /// 装飾品リスト更新.
        /// </summary>
        private void UpdateAccessoryList()
        {
            // 別スレッドから呼び出された場合
            if (this.InvokeRequired)
            {
                this.BeginInvoke(this.UpdateAccessoryList);
                return;
            }

            // 描画更新の停止.
            this.pnlAccessoryList.BeginControlUpdate();

            try
            {
                // 表示対象リストを絞り込み対象に合わせて絞り込み.
                var targetList = this.AccessoryCtrlList;
                if (this.radioPositive.Checked)
                {
                    targetList = this.AccessoryCtrlList
                        .Where(ctrl => 0 < ctrl.AccessoryData.Possession)
                        .ToList();
                }
                else if(this.radioNegative.Checked)
                {
                    targetList = this.AccessoryCtrlList
                        .Where(ctrl => ctrl.AccessoryData.Possession <= 0)
                        .ToList();
                }

                List<AccessoryControl> filteredList;
                var filter = this.txtbAccessoryFilter.Text;
                if (filter.IsEmpty())
                {
                    // フィルタ無しの場合は全て.
                    filteredList = targetList;
                }
                else
                {
                    // 文字の入力がある場合、絞込みワードを抽出(半角スペースで複数取得).
                    var wards = filter.Split(' ')
                        .Where(ward => !ward.IsEmpty());

                    // 絞込みワードのいずれかを含むレコードのみ抽出.
                    filteredList = targetList
                        .Where(ctrl => wards.Any(ward => ctrl.AccessoryData.Master.GetFilterText().Contains(ward)))
                        .ToList();
                }

                // パネルをクリア.
                this.pnlAccessoryList.Controls.Clear();

                // コントロールを追加.
                for (var i = 0; i < filteredList.Count; i++)
                {
                    var ctrl = filteredList[i];
                    this.pnlAccessoryList.Controls.Add(ctrl);
                    var y = i * ctrl.Size.Height;
                    ctrl.Location = new Point(0, y);
                }
            }
            finally
            {
                // 描画更新の再開.
                this.pnlAccessoryList.EndControlUpdate();
            }
        }
    }
}
