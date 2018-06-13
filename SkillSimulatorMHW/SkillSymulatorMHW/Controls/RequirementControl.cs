using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using SkillSimulatorMHW.Candidates;
using SkillSimulatorMHW.Data;
using SkillSimulatorMHW.Defines;
using SkillSimulatorMHW.Extensions;
using SkillSimulatorMHW.Forms;
using SkillSimulatorMHW.Masters;
using SkillSimulatorMHW.Requirements;

namespace SkillSimulatorMHW.Controls
{
    /// <summary>
    /// 条件コントロール.
    /// </summary>
    public partial class RequirementControl : UserControl
    {
        /// <summary>
        /// 静的コンストラクタ.
        /// </summary>
        static RequirementControl()
        {
            // 定義データを初期化.
            RequirementDataDic = new Dictionary<Part, ReqCtrlDef>
            {
                { Part.Wepon,     new ReqCtrlDef("武器",   CandidateWepon.TermsList     ) },
                { Part.Head,      new ReqCtrlDef("頭",     CandidateArmor.TermsList     ) },
                { Part.Body,      new ReqCtrlDef("胴",     CandidateArmor.TermsList     ) },
                { Part.Arm,       new ReqCtrlDef("腕",     CandidateArmor.TermsList     ) },
                { Part.Waist,     new ReqCtrlDef("腰",     CandidateArmor.TermsList     ) },
                { Part.Leg,       new ReqCtrlDef("脚",     CandidateArmor.TermsList     ) },
                { Part.Amulet,    new ReqCtrlDef("護石",   CandidateAmulet.TermsList    ) },
                { Part.Accessory, new ReqCtrlDef("装飾品", CandidateAccessory.TermsList ) },
            };
        }

        /// <summary>
        /// コンストラクタ.
        /// </summary>
        public RequirementControl(RequirementData requirementData, List<MasterDataBase> masterList)
        {
            InitializeComponent();

            if (null == requirementData)
            {
                Log.Write("検索条件コントロールの初期化に失敗しました(引数なし)");
                return;
            }

            var part = requirementData.Part;
            this.Def = RequirementDataDic.ContainsKey(part)
                ? RequirementDataDic[part]
                : new ReqCtrlDef();
            this.RequirementData = requirementData;
            this.MasterList = masterList;

            // 部位毎の初期化を実施.
            if (!RequirementDataDic.ContainsKey(part))
            {
                Log.Write("検索条件コントロール[{0}]の初期化に失敗しました(条件なし)".Fmt(part));
                return;
            }

            // 検索条件コンボボックス更新.
            var def = RequirementDataDic[part];
            this.chkPart.Text = def.Title;

            // コンボボックスの初期化を実施すると値が更新されてしまうので、
            // この時点で初期化値を確保しておく.
            var termType = this.RequirementData.TermsType;
            this.FixedIndex = this.RequirementData.FixedIndex;

            // 初期化.
            this.cmbRequirement.Init(def.CmbItemList);

            // 要素選択.
            foreach (var item in this.cmbRequirement.Items)
            {
                var val = item as TermsTypeData;
                if (null != val && val.TermsType == termType)
                {
                    this.cmbRequirement.SelectValue(item);
                    break;
                }
            }

            // 固定装備コンボボックス更新.
            this.UpdateCmbFixedEquip();

            // 固定装備コンボ再選択.
            foreach (var item in this.cmbFixedEquip.Items)
            {
                var val = item as MasterDataBase;
                if (null != val && val.GetIndex() == this.FixedIndex)
                {
                    this.cmbFixedEquip.SelectValue(item);
                    break;
                }
            }

            this.chkPart.Checked = termType != TermsType.Unused;
        }

        /// <summary>
        /// 初期化データリスト.
        /// </summary>
        private static Dictionary<Part, ReqCtrlDef> RequirementDataDic { get; set; }

        /// <summary>
        /// 定義データ.
        /// </summary>
        private ReqCtrlDef Def { get; set; }

        /// <summary>
        /// 検索条件データ.
        /// </summary>
        private RequirementData RequirementData { get; set; }

        /// <summary>
        /// マスタデータリスト.
        /// </summary>
        private List<MasterDataBase> MasterList { get; set; }

        /// <summary>
        /// 固定装備Index
        /// </summary>
        private int FixedIndex { get; set; }

        /// <summary>
        /// 有効/無効チェックボックス変更
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CallBackChkPartCheckedChanged(object sender, System.EventArgs e)
        {
            // 検索条件へ反映.
            this.UpdateRequirementData();
        }

        /// <summary>
        /// 条件コンボボックス選択.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CallBackCmbRequirementSelectedIndexChanged(object sender, System.EventArgs e)
        {
            // 検索条件へ反映.
            this.UpdateRequirementData();
        }

        /// <summary>
        /// 固定装備フィルタ変更.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CallBackTxtbEquipFilterTextChanged(object sender, System.EventArgs e)
        {
            // 固定装備コンボボックスを更新.
            this.UpdateCmbFixedEquip();
        }

        /// <summary>
        /// フィルタクリアボタン押下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CallBackBtnEquipFilterClearClick(object sender, System.EventArgs e)
        {
            this.txtbEquipFilter.Text = String.Empty;
        }

        /// <summary>
        /// 固定装備コンボボックス選択.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CallBackCmbFixedEquipSelectedIndexChanged(object sender, System.EventArgs e)
        {
            // 検索条件へ反映.
            this.UpdateRequirementData();
        }

        /// <summary>
        /// 装備選択ボタン押下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CallBackBtnSelectClick(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 除外リスト編集ボタン押下.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CallBackBtnIgnoreClick(object sender, System.EventArgs e)
        {
            // TODO:nakamura 未実装.
        }

        /// <summary>
        /// 所持リスト編集ボタン押下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CallBackBtnPossessionClick(object sender, System.EventArgs e)
        {
            var part = this.RequirementData.Part;
            switch (part)
            {
                case Part.Accessory:
                    var dlg = new DlgAccessoryList();
                    dlg.SetPossessionList(this.RequirementData.PossessionList);
                    if (DialogResult.OK == dlg.ShowDialog())
                    {
                        this.RequirementData.PossessionList = dlg.GetPossessionList();
                    }
                    break;

                default:
                    Log.Write("[{0}]の所持リスト機能は未実装です。".Fmt(part));
                    break;
            }
        }

        /// <summary>
        /// 固定装備コンボボボックス更新.
        /// </summary>
        private void UpdateCmbFixedEquip()
        {
            // 別スレッドから呼び出された場合
            if (this.InvokeRequired)
            {
                this.BeginInvoke(this.UpdateCmbFixedEquip);
                return;
            }

            // テキストによるフィルタリング後のリストを取得.
            var filteredList = this.MasterList
                .GetRecordListWithStringFilter(this.txtbEquipFilter.Text);

            // フィルタ結果.
            if (filteredList.Any())
            {
                // フィルタ後のリストでコンボボックスを生成.
                this.cmbFixedEquip.Init(filteredList);
            }
            else
            {
                // フィルタリストが０件の場合
                this.cmbFixedEquip.Clear();
            }
        }

        /// <summary>
        /// 検索条件データ更新.
        /// </summary>
        private void UpdateRequirementData()
        {
            // 全コンポーネントを無効化で初期化しない理由は、
            // フィルタテキストボックスのフォーカスが失われるため.
            this.cmbRequirement.Visible = this.chkPart.Checked;

            // 有効無効チェックボックス
            if (this.chkPart.Checked)
            {
                // 選択されているオブジェクトを取得.
                var selectedTerm = this.cmbRequirement.SelectedObj<TermsTypeData>();

                // 固定の場合.
                var bfixed = TermsType.Fixed == selectedTerm.TermsType;
                this.txtbEquipFilter.Visible = bfixed;
                this.btnEquipFilterClear.Visible = bfixed;
                this.cmbFixedEquip.Visible = bfixed;

                // 除外リストの場合.
                this.btnIgnore.Visible = TermsType.Ignore == selectedTerm.TermsType;

                // 所持リストの場合.
                this.btnPossession.Visible = TermsType.Possession == selectedTerm.TermsType;

                // 検索条件を設定.
                this.RequirementData.TermsType = selectedTerm.TermsType;

                // 選択内容に合わせて値を取得.
                switch (selectedTerm.TermsType)
                {
                    case TermsType.Fixed:
                        var selected = this.cmbFixedEquip.SelectedObj<MasterDataBase>();
                        if (null != selected)
                        {
                            this.RequirementData.FixedIndex = selected.GetIndex();
                        }
                        break;
                }
            }
            else
            {
                // 全コンポーネントを無効化.
                this.txtbEquipFilter.Visible = false;
                this.btnEquipFilterClear.Visible = false;
                this.cmbFixedEquip.Visible = false;
                this.btnIgnore.Visible = false;
                this.btnPossession.Visible = false;

                // 検索条件を設定.
                this.RequirementData.TermsType = TermsType.Unused;
            }
        }

        /// <summary>
        /// 検索条件コントロール定義データインナークラス.
        /// </summary>
        private class ReqCtrlDef
        {
            /// <summary>
            /// コンストラクタ.
            /// </summary>
            public ReqCtrlDef()
            {
                this.Title = string.Empty;
                this.CmbItemList = new List<TermsTypeData>();
            }

            /// <summary>
            /// コンストラクタ.
            /// </summary>
            public ReqCtrlDef(string title, List<TermsTypeData> cmbItemList)
            {
                this.Title = title;
                this.CmbItemList = cmbItemList;
            }

            /// <summary>
            /// 見出し.
            /// </summary>
            public string Title { get; set; }

            /// <summary>
            /// コンボボックスアイテムリスト.
            /// </summary>
            public List<TermsTypeData> CmbItemList { get; set; }

        }
    }
}
