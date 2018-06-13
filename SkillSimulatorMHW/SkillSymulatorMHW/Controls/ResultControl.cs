using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using SkillSimulatorMHW.Data;
using SkillSimulatorMHW.Defines;
using SkillSimulatorMHW.Extensions;
using SkillSimulatorMHW.Forms;
using SkillSimulatorMHW.Result;

namespace SkillSimulatorMHW.Controls
{
    /// <summary>
    /// 結果コントロール.
    /// </summary>
    public partial class ResultControl : UserControl
    {
        /// <summary>
        /// コンストラクタ.
        /// </summary>
        public ResultControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 結果セット.
        /// </summary>
        public ResultSet ResultSet { get; set; }

        /// <summary>
        /// 値セット.
        /// </summary>
        public void Set(int index, ResultSet resultSet)
        {
            if (null == resultSet)
            {
                return;
            }

            // 結果セットを反映.
            this.ResultSet = resultSet;

            // ステータス.
            this.lblStatus.Text = "({0}) 防：{1}".Fmt(index, this.GetStatusText());

            var ctrolColor = Color.White;
            var abstractColor = Color.Gainsboro;

            // 武器.
            this.lblWepon.Text = resultSet.Wepon.GetText();

            // 防具.
            this.lblHead.Tag = resultSet.Head;
            this.lblHead.Text = resultSet.Head.GetText();
            this.toolTipArmor.SetToolTip(this.lblHead, this.GetArmorToolTipText(resultSet.Head));
            this.lblHead.BackColor = resultSet.Head.IsAbstract()
                ? abstractColor
                : ctrolColor;
            this.lblBody.Tag = resultSet.Body;
            this.lblBody.Text = resultSet.Body.GetText();
            this.toolTipArmor.SetToolTip(this.lblBody, this.GetArmorToolTipText(resultSet.Body));
            this.lblBody.BackColor = resultSet.Body.IsAbstract()
                ? abstractColor
                : ctrolColor;
            this.lblArm.Tag = resultSet.Arm;
            this.lblArm.Text = resultSet.Arm.GetText();
            this.toolTipArmor.SetToolTip(this.lblArm, this.GetArmorToolTipText(resultSet.Arm));
            this.lblArm.BackColor = resultSet.Arm.IsAbstract()
                ? abstractColor
                : ctrolColor;
            this.lblWaist.Tag = resultSet.Waist;
            this.lblWaist.Text = resultSet.Waist.GetText();
            this.toolTipArmor.SetToolTip(this.lblWaist, this.GetArmorToolTipText(resultSet.Waist));
            this.lblWaist.BackColor = resultSet.Waist.IsAbstract()
                ? abstractColor
                : ctrolColor;
            this.lblLeg.Tag = resultSet.Leg;
            this.lblLeg.Text = resultSet.Leg.GetText();
            this.toolTipArmor.SetToolTip(this.lblLeg, this.GetArmorToolTipText(resultSet.Leg));
            this.lblLeg.BackColor = resultSet.Leg.IsAbstract()
                ? abstractColor
                : ctrolColor;

            // 護石.
            this.lblAmulet.Text = resultSet.Amulet.GetText();

            // 空きスロット.
            this.lblSlot.Text = "空： {0}".Fmt(this.GetBlankSlotText());

            // 装飾品
            this.txtbAccessory.Text = this.GetAccessoryText();

            // スキル.
            this.txtbSkill.Text = this.GetSkillText();
        }

        /// <summary>
        /// 防具テキストクリック.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CallBackLblArmorClick(object sender, System.EventArgs e)
        {
            var lbl = sender as Label;
            var armor = null != lbl
                ? lbl.Tag as PartDataArmor
                : null;
            if (null != armor && armor.IsAbstract())
            {
                // スロットが一致する防具をリストアップ.
                var equip = armor.Master.GetSlotData();
                var armorList = Ssm.Master.MasterArmor.GetPartList(armor.Part)
                    .Where(master =>
                    {
                        var slotData = master.GetSlotData();
                        return slotData.Equals(equip);
                    })
                    .ToList();

                var dlg = new DlgArmorList();
                dlg.SetArmorList(armorList);
                dlg.ShowDialog();
            }
        }

        /// <summary>
        /// テキストコピークリック.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CallBackBtnTextCopyClick(object sender, System.EventArgs e)
        {
            Clipboard.SetText("【発動スキル】\n{0}\n\n防御力：{1}\n武器：{2}\n頭：{3}\n胴：{4}\n腕：{5}\n腰：{6}\n脚：{7}\n護石：{8}\n空きスロット：{9}\n{10}\n\n".Fmt(
                this.GetSkillText(),
                this.GetStatusText(),
                this.ResultSet.Wepon.GetText(),
                this.ResultSet.Head.GetText(),
                this.ResultSet.Body.GetText(),
                this.ResultSet.Arm.GetText(),
                this.ResultSet.Waist.GetText(),
                this.ResultSet.Leg.GetText(),
                this.ResultSet.Amulet.GetText(),
                this.GetBlankSlotText(),
                this.GetAccessoryText()
            ));
        }

        /// <summary>
        /// ステータス文字列を取得.
        /// </summary>
        /// <returns></returns>
        private string GetStatusText()
        {
            var defList = this.ResultSet.GetDefense()
                .Select(def => def.ToString())
                .ToList();

            return string.Join("/", defList);
        }

        /// <summary>
        /// 防具の詳細な説明を取得.
        /// </summary>
        /// <returns></returns>
        private string GetArmorToolTipText(PartDataArmor partDataArmor)
        {
            if (PartState.Determined != partDataArmor.State ||
                null == partDataArmor.Master)
            {
                return string.Empty;
            }

            // 抽象化かどうか.
            var result = string.Empty;
            var master = partDataArmor.Master;
            if (partDataArmor.IsAbstract())
            {
                // スロットが一致する防具をリストアップ.
                var equip = master.GetSlotData();
                var armorList = Ssm.Master.MasterArmor.GetPartList(master.Part)
                    .Where(armor =>
                    {
                        var slotData = armor.GetSlotData();
                        return slotData.Equals(equip);
                    })
                    .ToList();

                var nameList = armorList
                    .Select(armor => armor.Name)
                    .ToList();

                result = string.Join("\r\n", nameList);
            }
            else
            {
                var slotData = master.GetSlotData();
                var skillTextList = master.GetSkillDataList()
                    .Select(skill => skill.GetText())
                    .ToList();

                result = "{0} {1}\n防御力：{2}/{3}/{4} {5}".Fmt(
                    master.Name,
                    slotData.ToString(),
                    master.DefInit,
                    master.DefMax,
                    master.DefCustom,
                    string.Join(" ", skillTextList));
            }

            return result;
        }

        /// <summary>
        /// 空きスロット文字列を取得.
        /// </summary>
        /// <returns></returns>
        private string GetBlankSlotText()
        {
            var blankSlotList = new List<int>();
            this.ResultSet.GetBlankSlot(blankSlotList);

            var blankSlotTextList = blankSlotList
                .GroupBy(lv => lv)
                .OrderByDescending(lvs => lvs.Key)
                .Select(lvs => "{0}*{1}".Fmt(SlotData.IntToStr(lvs.Key), lvs.Count()))
                .ToList();

            return blankSlotTextList.Any()
                ? string.Join(" ", blankSlotTextList)
                : "－";
        }

        /// <summary>
        /// 装飾品文字列を取得.
        /// </summary>
        /// <returns></returns>
        private string GetAccessoryText()
        {
            var accessoryList = this.ResultSet.Accessory.GetTextList();

            return accessoryList.Any()
                ? string.Join("\r\n", accessoryList)
                : "－";
        }

        /// <summary>
        /// スキル文字列を取得.
        /// </summary>
        /// <returns></returns>
        private string GetSkillText()
        {
            var skillTextList = this.ResultSet.GetAllSkillList()
                .Select(skill => skill.GetText())
                .ToList();

            return skillTextList.Any()
                ? string.Join("\r\n", skillTextList)
                : "－";
        }
    }
}
