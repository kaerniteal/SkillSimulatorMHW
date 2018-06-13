using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using SkillSimulatorMHW.Data;
using SkillSimulatorMHW.Extensions;

namespace SkillSimulatorMHW.Controls
{
    /// <summary>
    /// 装飾品コントロール.
    /// </summary>
    public partial class AccessoryControl : UserControl
    {
        /// <summary>
        /// コンストラクタ.
        /// </summary>
        public AccessoryControl()
        {
            this.AccessoryData = null;
            this.SkillList = new List<SkillData>();

            InitializeComponent();
        }

        /// <summary>
        /// 装飾品データ.
        /// </summary>
        /// <remarks>このフィールドは参照をかかえる。最終的のこのデータが直接元データへ反映される</remarks>
        public AccessoryData AccessoryData { get; set; }

        /// <summary>
        /// 対象スキルリスト.
        /// </summary>
        private List<SkillData> SkillList { get; set; }

        /// <summary>
        ///  装飾品データをセット.
        /// </summary>
        /// <param name="accessoryData"></param>
        public void SetAccessory(AccessoryData accessoryData)
        {
            this.AccessoryData = accessoryData;

            var master = accessoryData.Master;
            this.lblAccessoryName.Text = master.Name;

            this.SkillList = master.GetSkillDataList();
            var skills = this.SkillList
                .Select(skill => "{0}+{1}".Fmt(skill.Skill.Name, skill.Lv))
                .ToList();

            this.lblSkillName.Text = string.Join(" ", skills);

            // 所持数を更新.
            this.UpdatePossession();
        }

        /// <summary>
        /// ＋ボタン押下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CallBackBtnPlusClick(object sender, System.EventArgs e)
        {
            var max = this.SkillList.Max(skill => skill.Skill.MaxLv);
            if (this.AccessoryData.Possession < max)
            {
                this.AccessoryData.Possession++;
            }
            this.UpdatePossession();
        }

        /// <summary>
        /// －ボタン押下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CallBackBtnMinusClick(object sender, System.EventArgs e)
        {
            if (0 < this.AccessoryData.Possession)
            {
                this.AccessoryData.Possession--;
            }
            this.UpdatePossession();
        }

        /// <summary>
        /// 所持数を更新する.
        /// </summary>
        private void UpdatePossession()
        {
            this.txtbPossession.Text = this.AccessoryData.Possession.ToString();
        }
    }
}
