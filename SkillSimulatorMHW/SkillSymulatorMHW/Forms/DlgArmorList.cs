using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using SkillSimulatorMHW.Controls;
using SkillSimulatorMHW.Masters;
using SkillSimulatorMHW.Data;
using SkillSimulatorMHW.Extensions;

namespace SkillSimulatorMHW.Forms
{
    public partial class DlgArmorList : Form
    {
        /// <summary>
        /// コンストラクタ.
        /// </summary>
        public DlgArmorList()
        {
            this.ArmorCtrlList = new List<ArmorControl>();

            InitializeComponent();

            this.UpdateArmorList();
        }

        /// <summary>
        /// 防具コントロールリスト.
        /// </summary>
        private List<ArmorControl> ArmorCtrlList { get; set; }

        /// <summary>
        /// テキストフィルタクリアボタン押下.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAccessoryFilterClear_Click(object sender, EventArgs e)
        {
            this.txtbAccessoryFilter.Text = string.Empty;
        }

        /// <summary>
        /// 防具リストをセットする.
        /// </summary>
        /// <returns></returns>
        public void SetArmorList(List<MasterArmorData> masterArmorDataList)
        {
            // 防具マスタリストを防具コントロールリストに変換.
            this.ArmorCtrlList = masterArmorDataList
                .Select(master =>
                {
                    var ctrl = new ArmorControl();
                    ctrl.SetArmor(master);
                    return ctrl;
                })
                .ToList();

            // リストを更新.
            this.UpdateArmorList();
        }

        /// <summary>
        /// 防具リスト更新.
        /// </summary>
        private void UpdateArmorList()
        {
            // 別スレッドから呼び出された場合
            if (this.InvokeRequired)
            {
                this.BeginInvoke(this.UpdateArmorList);
                return;
            }

            // 描画更新の停止.
            this.pnlArmorList.BeginControlUpdate();

            try
            {
                List<ArmorControl> filteredList;
                var filter = this.txtbAccessoryFilter.Text;
                if (filter.IsEmpty())
                {
                    // フィルタ無しの場合は全て.
                    filteredList = this.ArmorCtrlList;
                }
                else
                {
                    // 文字の入力がある場合、絞込みワードを抽出(半角スペースで複数取得).
                    var wards = filter.Split(' ')
                        .Where(ward => !ward.IsEmpty());

                    // 絞込みワードのいずれかを含むレコードのみ抽出.
                    filteredList = this.ArmorCtrlList
                        .Where(ctrl => wards.Any(ward => ctrl.MasterArmorData.GetFilterText().Contains(ward)))
                        .ToList();
                }

                // パネルをクリア.
                this.pnlArmorList.Controls.Clear();

                // コントロールを追加.
                for (var i = 0; i < filteredList.Count; i++)
                {
                    var ctrl = filteredList[i];
                    this.pnlArmorList.Controls.Add(ctrl);
                    var y = i * ctrl.Size.Height;
                    ctrl.Location = new Point(0, y);
                }
            }
            finally
            {
                // 描画更新の再開.
                this.pnlArmorList.EndControlUpdate();
            }
        }

        /// <summary>
        /// 装飾品テキストフィルター入力
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CallBackTxtbAccessoryFilterTextChanged(object sender, EventArgs e)
        {
            this.UpdateArmorList();
        }
    }
}
