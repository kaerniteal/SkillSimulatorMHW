using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SkillSimulatorMHW.Controls;
using SkillSimulatorMHW.Data;
using SkillSimulatorMHW.Defines;
using SkillSimulatorMHW.Executors;
using SkillSimulatorMHW.Interface;
using SkillSimulatorMHW.Masters;
using SkillSimulatorMHW.Requirements;
using SkillSimulatorMHW.Extensions;
using SkillSimulatorMHW.Result;

namespace SkillSimulatorMHW.Forms
{
    /// <summary>
    /// メインフォーム
    /// </summary>
    public partial class MainForm : Form, IMainForm, Log.ILogWriter
    {
        /// <summary>
        /// コンストラクタ.
        /// </summary>
        public MainForm()
        {
            this.Requirements = Requirement.Load();
            this.ResultData = new ResultData();
            this.ResultListControl = new ResultListControl();

            InitializeComponent();

            // ログ出力先(ILogWriter)として自身をセット.
            Log.SetWriter(this);

            Log.Write("メインフォーム初期化");
        }

        /// <summary>
        /// 検索条件.
        /// </summary>
        private Requirement Requirements { get; set; }

        /// <summary>
        /// 結果データ.
        /// </summary>
        private ResultData ResultData { get; set; }

        /// <summary>
        /// 結果表示コントロール.
        /// </summary>
        private ResultListControl ResultListControl { get; set; }

        /// <summary>
        /// メインフォームロード.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CallBackMainFormLoad(object sender, EventArgs e)
        {
            // タイトルをセット.
            this.Text = "{0}      {1}".Fmt(Ssm.Title, SkillSimulatorMhw.Implementator);

            // スキル選択コンボボックスの初期化.
            this.UpdateSkillSelectComb();

            // 検索条件(武器)の初期化.
            var wepon = this.Requirements.RequirementDataList.Get(Part.Wepon);
            var masterWepon = Ssm.Master.MasterWepon.GetRecordList()
                .OrderByDescending(awp => awp.GetIndex())
                .Select(awp => (MasterDataBase)awp)
                .ToList();
            var ctrlWepon = new RequirementControl(wepon, masterWepon)
            {
                Location = new Point(6, 16)
            };
            this.grpbSerchRequirements.Controls.Add(ctrlWepon);

            // 検索条件レア度の初期化.
            switch (this.Requirements.RequirementRareData.Rank)
            {
                case Rank.Non:
                    this.radioRareAll.Checked = true;
                    break;

                case Rank.Low:
                    this.radioRareLow.Checked = true;
                    break;

                case Rank.High:
                    this.radioRareHigh.Checked = true;
                    break;
            }

            // 検索条件(防具)の初期化.
            var baseY = 66;
            for (var i = 0; i < Define.ArmorList.Count; i++)
            {
                var part = Define.ArmorList[i];
                var y = baseY + (i * 66);

                var armor = this.Requirements.RequirementDataList.Get(part);
                var masterArmor= Ssm.Master.MasterArmor.GetMasterDataList(part);
                var ctrlArmor = new RequirementControl(armor, masterArmor)
                {
                    Location = new Point(6, y)
                };
                this.grpbRequirementArmor.Controls.Add(ctrlArmor);
            }

            // 検索条件(護符)の初期化.
            var amulet = this.Requirements.RequirementDataList.Get(Part.Amulet);
            var masterAmulet = Ssm.Master.MasterAmulet.GetMasterDataList();
            var ctrlAmulet = new RequirementControl(amulet, masterAmulet)
            {
                Location = new Point(6, 510)
            };
            this.grpbSerchRequirements.Controls.Add(ctrlAmulet);

            // 検索条件(装飾品)の初期化.
            var accessory = this.Requirements.RequirementDataList.Get(Part.Accessory);
            var masterAccessory = Ssm.Master.MasterAccessory.GetMasterDataList();
            var ctrlAccessory = new RequirementControl(accessory, masterAccessory)
            {
                Location = new Point(6, 580)
            };
            this.grpbSerchRequirements.Controls.Add(ctrlAccessory);

            // 設定内容を反映.
            this.UpdateMainForm();

            // 結果コントロールを生成.
            this.ResultListControl.Init();
            this.ResultListControl.Location = new Point(3, 12);
            this.grpbSearchResult.Controls.Add(this.ResultListControl);

            Log.Write("メインフォームの初期化完了");
        }

        /// <summary>
        /// スキル選択フィルタ変更.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CallBackTxtbSkillSelectFilterTextChanged(object sender, System.EventArgs e)
        {
            this.UpdateSkillSelectComb();
        }

        /// <summary>
        /// スキル選択フィルタクリアボタン押下.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CallBackBtnSkillSelectFilterClearClick(object sender, EventArgs e)
        {
            this.txtbSkillSelectFilter.Text = string.Empty;
        }

        /// <summary>
        /// スキル追加ボタン押下.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CallBackAddSkillClick(object sender, System.EventArgs e)
        {
            var master = this.cmbSkillSelect.SelectedObj<MasterSkillData>();
            if (null == master)
            {
                Log.Write("スキルが選択されていません。");
                return;
            }

            // 追加済みの場合は追加しない.
            if (this.Requirements.RequirementSkillList
                .GetAllIndexList()
                .Contains(master.Index))
            {
                return;
            }

            // 検索条件のスキルリストに登録.
            this.Requirements.RequirementSkillList.Add(new SkillData(master));

            // スキル一覧を更新
            this.UpdateSkillList();
        }

        /// <summary>
        /// 検索実行ボタン押下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CallBackBtnExecClick(object sender, EventArgs e)
        {
            // 検索実行.
            this.Search(AnalyzeType.Always == Ssm.Config.AnalyzeType);
        }

        /// <summary>
        /// レア度ラジオボタン変更
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CallBackRadioRareCheckedChanged(object sender, EventArgs e)
        {
            // ラジオボタンを切り替えると
            // ONになるボタンとOFFになるボタンの二つからイベントが呼ばれ２回処理が走ってしまう為
            // ONになったイベントの場合のみ処理する.
            var radioBtn = sender as RadioButton;
            if (null != radioBtn && radioBtn.Checked)
            {
                if (this.radioRareHigh.Checked)
                {
                    this.Requirements.RequirementRareData.SetRare(Rank.High);
                }
                else if (this.radioRareLow.Checked)
                {
                    this.Requirements.RequirementRareData.SetRare(Rank.Low);
                }
                else
                {
                    this.Requirements.RequirementRareData.SetRare(Rank.Non);
                }
            }
        }

        /// <summary>
        /// 解析結果表示ボタン.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CallBackBtnShowAnalyzeClick(object sender, EventArgs e)
        {
            // 解析結果ダイアログを表示.
            this.ShowAnalyzeResult();
        }

        /// <summary>
        /// 動作設定ボタン押下.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CallBackBtnAppSettingClick(object sender, EventArgs e)
        {
            var dlg = new DlgConfig();
            if (DialogResult.OK == dlg.ShowDialog())
            {
                var config = dlg.GetConfig();

                // 保存して.
                config.Save();

                // アプリケーションへ反映.
                SkillSimulatorMhw.Instance.Config = config;
            }
        }

        /// <summary>
        /// 終了ボタン押下.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CallBackBtnAppExitClick(object sender, System.EventArgs e)
        {
            SkillSimulatorMhw.Instance.Exit();
        }

        /// <summary>
        /// 終了時.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        /// <summary>
        /// メインフォームを更新.
        /// </summary>
        private void UpdateMainForm()
        {
            // 別スレッドから呼び出された場合
            if (this.InvokeRequired)
            {
                this.BeginInvoke(this.UpdateMainForm);
                return;
            }

            // スキルリストを更新.
            this.UpdateSkillList();
        }

        /// <summary>
        /// スキル選択コンボボボックス更新.
        /// </summary>
        private void UpdateSkillSelectComb()
        {
            // 別スレッドから呼び出された場合
            if (this.InvokeRequired)
            {
                this.BeginInvoke(this.UpdateSkillSelectComb);
                return;
            }

            // テキストによるフィルタリング後のスキルリストを取得.
            var filteredList = Ssm.Master.MasterSkill.GetMasterDataList()
                .GetRecordListWithStringFilter(this.txtbSkillSelectFilter.Text);

            // フィルタ結果.
            if (filteredList.Any())
            {
                // フィルタ後のリストでコンボボックスを生成.
                this.cmbSkillSelect.Init(filteredList);
            }
            else
            {
                // フィルタリストが０件の場合
                this.cmbSkillSelect.Clear();
            }

            // コンボボックスにスキルが選択されていない場合は.
            this.btnAddSkill.Enabled = (null != this.cmbSkillSelect.SelectedObj<MasterSkillData>());
        }

        /// <summary>
        /// スキルリスト更新.
        /// </summary>
        private void UpdateSkillList()
        {
            // 別スレッドから呼び出された場合
            if (this.InvokeRequired)
            {
                this.BeginInvoke(this.UpdateSkillList);
                return;
            }

            // 描画更新の停止.
            this.pnlSkillList.BeginControlUpdate();

            try
            {
                // パネルをクリア.
                this.pnlSkillList.Controls.Clear();

                // スキルリストを生成.
                var skillDataList = new List<SkillData>();
                skillDataList.AddRange(this.Requirements.RequirementSkillList.SeriesList);
                skillDataList.AddRange(this.Requirements.RequirementSkillList.SkillList);

                // パネルにして追加する.
                for (var i = 0; i < skillDataList.Count; i++)
                {
                    var ctrl = new SkillControl(skillDataList[i], this);
                    this.pnlSkillList.Controls.Add(ctrl);
                    var y = i * ctrl.Size.Height;
                    ctrl.Location = new Point(0, y);
                }
            }
            finally
            {
                // 描画更新の再開.
                this.pnlSkillList.EndControlUpdate();
            }
        }

        /// <summary>
        /// 検索処理.
        /// </summary>
        private void Search(bool analyze)
        {
            this.btnExec.Enabled = false;

            try
            {
                this.Requirements.Save();

                // 検索処理オブジェクトを格納.
                SearchEngine exec = null;

                // 検索処理を取得.
                exec = SearchEngine.GetSearchEngine();
                exec.SetParam(this.Requirements, this, analyze);

                if (Ssm.Config.EnableAsyncExec)
                {
                    // 進捗表示機能付き非同期処理.
                    // 非同期なのでIMainFormのSetResultで結果を格納する.
                    DlgProgress.ProgressProcess(@"検索.", exec);
                }
                else
                {
                    // 同期実行.
                    var result = exec.Search();

                    // 結果を格納.
                    this.SetResult(result);
                }
            }
            finally
            {
                this.btnExec.Enabled = true;
            }
        }

        /// <summary>
        /// スキルリストからスキルを削除.
        /// </summary>
        /// <param name="skillData"></param>
        public void DeleteSkill(SkillData skillData)
        {
            // スキルを削除.
            this.Requirements.RequirementSkillList.Remove(skillData);
            this.UpdateSkillList();
        }

        /// <summary>
        /// 結果を登録.
        /// </summary>
        /// <param name="resultData">結果データ.</param>
        public void SetResult(ResultData resultData)
        {
            // 結果を格納.
            this.ResultData = resultData;
            
            // 条件を満たしたリスト.
            var satisfiedList = resultData.GetSatisfiedList();

            // 出力結果保存.
            if (Ssm.Config.EnableResultOutput)
            {
                using (var sw = new StreamWriter(Ssm.Config.FileNameResultOutput, false, Encoding.UTF8))
                {
                    foreach (var result in satisfiedList)
                    {
                        sw.WriteLine(result.GetAllText());
                    }
                    sw.Close();
                }
            }

            // 結果コントロールに反映.
            this.ResultListControl.SetResult(satisfiedList);

            // 解析結果表示ボタンを制御.
            this.btnShowAnalyze.Enabled = resultData.AnalyzeFactors;

            // 条件を満たしたセットが存在しない場合.
            if (!satisfiedList.Any())
            {
                // 解析を実行した場合.
                if (resultData.AnalyzeFactors)
                {
                    // 解析結果ダイアログを表示.
                    this.ShowAnalyzeResult();
                }
                // 条件を満たすセットが存在しないときには解析する場合.
                else if (AnalyzeType.Non != Ssm.Config.AnalyzeType)
                {
                    if (DialogResult.Yes == MessageBox.Show("条件を満たす組み合わせが見つかりませんでした。\n条件を満たさなかったセットの要因解析を実施しますか？",
                            Ssm.Title, MessageBoxButtons.YesNo))
                    {
                        // 再検索を実施する.
                        this.Search(true);
                    }
                }
                else
                {
                    MessageBox.Show(@"条件を満たす組み合わせが見つかりませんでした。", Ssm.Title);
                }
            }
        }

        /// <summary>
        /// 解析結果表示.
        /// </summary>
        public void ShowAnalyzeResult()
        {
            // 解析結果ダイアログを表示.
            var dlg = new DlgAnalyzeResult();
            dlg.SetAnalyzeResult(this.ResultData);
            dlg.ShowDialog();
        }

        /// <summary>
        /// Log.ILogWriterインタフェースの実装.
        /// </summary>
        /// <param name="log">ログ</param>
        public void LogWrite(string log)
        {
            // 別スレッドから呼び出された場合
            if (this.InvokeRequired)
            {
                this.BeginInvoke(
                    () =>
                    {
                        this.LogWrite(log);
                    });
                return;
            }

            this.txtbLog.SelectionStart = this.txtbLog.Text.Length;
            this.txtbLog.SelectionLength = 0;
            this.txtbLog.SelectedText = log;
        }
    }
}
