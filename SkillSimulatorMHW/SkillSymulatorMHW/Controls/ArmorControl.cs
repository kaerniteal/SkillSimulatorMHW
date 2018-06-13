using System.Linq;
using System.Windows.Forms;
using SkillSimulatorMHW.Extensions;
using SkillSimulatorMHW.Masters;

namespace SkillSimulatorMHW.Controls
{
    /// <summary>
    /// 防具コントロール.
    /// </summary>
    public partial class ArmorControl : UserControl
    {
        /// <summary>
        /// コンストラクタ.
        /// </summary>
        public ArmorControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 防具マスタ.
        /// </summary>
        public MasterArmorData MasterArmorData { get; set; }

        /// <summary>
        ///  装飾品データをセット.
        /// </summary>
        /// <param name="masterArmorData"></param>
        public void SetArmor(MasterArmorData masterArmorData)
        {
            this.MasterArmorData = masterArmorData;

            this.lblArmorName.Text = this.MasterArmorData.Name;

            var slotData = this.MasterArmorData.GetSlotData();
            this.lblSlot.Text = slotData.ToString();

            this.lblStatus.Text = "防御力：{0}/{1}/{2}  ".Fmt(
                this.MasterArmorData.DefInit,
                this.MasterArmorData.DefMax,
                this.MasterArmorData.DefCustom);

            // スキル.
            var skillTextList = this.MasterArmorData.GetSkillDataList()
                .Select(skill => skill.GetText())
                .ToList();
            this.txtbSkill.Text = string.Join("\r\n", skillTextList);
        }
    }
}
