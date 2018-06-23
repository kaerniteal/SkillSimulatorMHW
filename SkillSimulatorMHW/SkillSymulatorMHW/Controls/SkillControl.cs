using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SkillSimulatorMHW.Data;
using SkillSimulatorMHW.Interface;

namespace SkillSimulatorMHW.Controls
{
    /// <summary>
    /// スキルコントロール.
    /// </summary>
    public partial class SkillControl : UserControl
    {
        /// <summary>
        /// コンストラクタ.
        /// </summary>
        public SkillControl(SkillData skillData, IMainForm mainForm)
        {
            InitializeComponent();

            this.Skill = skillData;
            this.MainForm = mainForm;

            // セットされた値をコンポーネントに反映.
            if (null != this.Skill)
            {
                this.lblSkillName.Text = Skill.Skill.ToString();
                this.lblSkillRemarks.Text = Skill.Skill.Remarks;

                if (this.Skill.IsSeries())
                {
                    // シリーズスキルの場合.
                    this.lblSkillLv.Text = @"シリーズ";
                    this.btnPlus.Visible = false;
                    this.txtbLv.Visible = false;
                    this.btnMinus.Visible = false;
                }
                else
                {
                    // 通常スキルの場合.
                    this.txtbLv.Text = Skill.Lv.ToString();

                    // Lv選択が不要な場合.
                    if (1 == this.Skill.Skill.MaxLv)
                    {
                        this.lblSkillLv.Visible = false;
                        this.btnPlus.Visible = false;
                        this.txtbLv.Visible = false;
                        this.btnMinus.Visible = false;
                    }
                }
            }
        }

        /// <summary>
        /// スキルデータ.
        /// </summary>
        private SkillData Skill { get; set; }

        /// <summary>
        /// メインフレーム.
        /// </summary>
        private IMainForm MainForm { get; set; }

        /// <summary>
        /// スキルLvをインクリメントする.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CallBackBtnPlusClick(object sender, EventArgs e)
        {
            var val = Int32.Parse(this.txtbLv.Text) + 1;
            if (this.Skill.Skill.MaxLv < val)
            {
                val = this.Skill.Skill.MaxLv;
            }

            this.txtbLv.Text = val.ToString();

            this.Skill.Lv = Int32.Parse(this.txtbLv.Text);
        }

        /// <summary>
        /// スキルLvをデクリメントする.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CallBackBtnMinusClick(object sender, EventArgs e)
        {
            var val = Int32.Parse(this.txtbLv.Text) - 1;
            if (val < 1)
            {
                val = 1;
            }

            this.txtbLv.Text = val.ToString();

            this.Skill.Lv = Int32.Parse(this.txtbLv.Text);
        }

        /// <summary>
        /// ×ボタン押下.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CallBackBtnAppExitClick(object sender, System.EventArgs e)
        {
            MainForm.DeleteSkill(this.Skill);
        }
    }
}
