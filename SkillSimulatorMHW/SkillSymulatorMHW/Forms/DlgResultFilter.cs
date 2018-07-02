using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using SkillSimulatorMHW.Controls;
using SkillSimulatorMHW.Data;
using SkillSimulatorMHW.Extensions;
using SkillSimulatorMHW.Masters;
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
        /// <param name="resultList"></param>
        public DlgResultFilter(List<ResultSet> resultList)
        {
            this.ResultList = resultList;
            this.FilterdList = new List<ResultSet>();

            InitializeComponent();

            // 値変更のイベントのハンドラを追加.
            this.numBlankSlotLv1.ValueChange += this.CallBackNumValueChange;
            this.numBlankSlotLv2.ValueChange += this.CallBackNumValueChange;
            this.numBlankSlotLv3.ValueChange += this.CallBackNumValueChange;
            this.numAddSkill1.ValueChange += this.CallBackNumValueChange;
            this.numAddSkill2.ValueChange += this.CallBackNumValueChange;
            this.numAddSkill3.ValueChange += this.CallBackNumValueChange;

            // コンボボックスに対応した数値入力を紐付ける.
            this.cmbAddSkill1.Tag = this.numAddSkill1;
            this.cmbAddSkill2.Tag = this.numAddSkill2;
            this.cmbAddSkill3.Tag = this.numAddSkill3;

            // 追加スキルコンボボックスを初期化.
            var skillList = resultList
                .SelectMany(result => result.GetAllSkillList())
                .Select(skillData => skillData.Skill)
                .Distinct()
                .Where(skill => !skill.IsSeries())
                .OrderBy(skill => skill.Index)
                .ToList();
            skillList.Insert(0, new MasterSkillData());
            this.cmbAddSkill1.Init(skillList.ToList());
            this.cmbAddSkill2.Init(skillList.ToList());
            this.cmbAddSkill3.Init(skillList.ToList());

            this.SetDefaultFilter();
        }

        /// <summary>
        /// 検索結果リスト.
        /// </summary>
        private List<ResultSet> ResultList { get; set; }

        /// <summary>
        /// フィルタ後のリスト.
        /// </summary>
        private List<ResultSet> FilterdList { get; set; }

        /// <summary>
        /// ブランクスロットの値変更イベントハンドラ.
        /// </summary>
        /// <param name="val"></param>
        private void CallBackNumValueChange(int val)
        {
            this.CreateFilterdList();
        }
 
        /// <summary>
        /// 追加スキルコンボボックスを変更する.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CallBackCmbAddSkillSelectedIndexChanged(object sender, EventArgs e)
        {
            var cmb = sender as ComboBox;
            if (null == cmb)
            {
                return;
            }

            var num = cmb.Tag as NumericControl;
            if (null == num)
            {
                return;
            }

            var masterSkill = cmb.SelectedObj<MasterSkillData>();
            num.Max = masterSkill.MaxLv;

            this.CreateFilterdList();
        }

        /// <summary>
        /// 絞り込んだ結果を表示するボタン押下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CallBackBtnShowClick(object sender, EventArgs e)
        {
            var dlg = new DlgResultList();
            dlg.SetResult(@"絞り込み結果", this.FilterdList);
            dlg.ShowDialog();
        }

        /// <summary>
        /// デフォルトの条件にセット.
        /// </summary>
        private void SetDefaultFilter()
        {
            this.numBlankSlotLv1.Value = 0;
            this.numBlankSlotLv2.Value = 0;
            this.numBlankSlotLv3.Value = 0;

            this.cmbAddSkill1.SelectedIndex = 0;
            this.cmbAddSkill2.SelectedIndex = 0;
            this.cmbAddSkill3.SelectedIndex = 0;

            this.CreateFilterdList();
        }

        /// <summary>
        /// フィルタしたリストを生成する.
        /// </summary>
        private void CreateFilterdList()
        {
            var addSkill1 = this.cmbAddSkill1.SelectedObj<MasterSkillData>();
            var addSkill2 = this.cmbAddSkill2.SelectedObj<MasterSkillData>();
            var addSkill3 = this.cmbAddSkill3.SelectedObj<MasterSkillData>();
            var skill1Idx = null == addSkill1 ? 0 : addSkill1.Index;
            var skill2Idx = null == addSkill2 ? 0 : addSkill2.Index;
            var skill3Idx = null == addSkill3 ? 0 : addSkill3.Index;

            // 画面の内容からフィルタを生成.
            var filter = new ResultFilter
            {
                NeedBlankSlotLv1 = this.numBlankSlotLv1.Value,
                NeedBlankSlotLv2 = this.numBlankSlotLv2.Value,
                NeedBlankSlotLv3 = this.numBlankSlotLv3.Value,
                NeedSkill1 = new SkillBase(skill1Idx, this.numAddSkill1.Value),
                NeedSkill2 = new SkillBase(skill2Idx, this.numAddSkill2.Value),
                NeedSkill3 = new SkillBase(skill3Idx, this.numAddSkill3.Value),
            };

            // フィルタした結果を生成.
            this.FilterdList = this.ResultList
                .Where(filter.Filter)
                .ToList();

            // 画面に反映.
            this.txtbFilterdCount.Text = "{0}件".Fmt(this.FilterdList.Count);
            this.txtbAllCount.Text = "{0}件".Fmt(this.ResultList.Count);
        }
    }
}
