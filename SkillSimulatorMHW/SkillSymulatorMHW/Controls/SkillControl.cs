using System.Collections.Generic;
using System.Windows.Forms;
using SkillSimulatorMHW.Data;
using SkillSimulatorMHW.Extensions;
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

                if (!this.Skill.IsSeries())
                {
                    // 通常スキルの場合.
                    var skillLvList = new List<int>();
                    for (var i = 1; i <= Skill.Skill.MaxLv; i++)
                    {
                        skillLvList.Add(i);
                    }

                    this.cmbSkillLv.Recreate(skillLvList);
                    this.cmbSkillLv.SelectValue(Skill.Lv);
                }
                else
                {
                    // シリーズスキルの場合.
                    this.lblSkillLv.Text = @"シリーズ";
                    this.cmbSkillLv.Visible = false;
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
        /// スキルLvコンボボックス変更.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CallBackCmbSkillLvSelectedIndexChanged(object sender, System.EventArgs e)
        {
            this.Skill.Lv = this.cmbSkillLv.SelectedVal<int>();
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
