using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using SkillSimulatorMHW.Data;
using SkillSimulatorMHW.Defines;
using SkillSimulatorMHW.Engines;
using SkillSimulatorMHW.Extensions;
using SkillSimulatorMHW.Web;

namespace SkillSimulatorMHW.Forms
{
    /// <summary>
    /// 動作設定ダイアログクラス.
    /// </summary>
    public partial class DlgConfig : Form
    {
        /// <summary>
        /// コンストラクタ.
        /// </summary>
        public DlgConfig()
        {
            InitializeComponent();

            this.lblAppVersion.Text = Ssm.Title;
            this.llblHomePage.Text = SkillSimulatorMhw.UrlHome;

            
            // コンボボックス生成.
            this.cmbAnalyzeType.Init(new List<CmbItem<AnalyzeType>>
            {
                new CmbItem<AnalyzeType>("使用しない", AnalyzeType.Non),
                new CmbItem<AnalyzeType>("条件を満たすセットが存在しない場合解析する", AnalyzeType.NotExist),
                new CmbItem<AnalyzeType>("常に解析する", AnalyzeType.Always),
            });

            this.cmbSearchEngine.Init(SearchEngine.SearchEngines
                .Select(engine => new CmbItem<string>(engine.GetId(), engine.GetId()))
                .ToList());

            if (!Ssm.Config.IsDebug)
            {
                this.tabCtrlConfigView.TabPages.Remove(this.tabPageConfigDebug);
            }
        }

        /// <summary>
        /// コンフィグを反映.
        /// </summary>
        /// <param name="config"></param>
        public void SetConfig(Config config)
        {
            this.chkWeb.Checked = config.EnableWeb;
            this.spinShowResultLimitCount.Value = config.ShowResultLimitCount;

            this.spinSerchLimitCount.Value    = config.SerchLimitCount;
            this.chkUseArmorAbstract.Checked = config.UseArmorAbstract;
            this.chkEnableAsyncExec.Checked  = config.EnableAsyncExec;
            this.cmbAnalyzeType.SelectCmbItem(config.AnalyzeType);

            this.chkShowDebugLog.Checked = config.ShowDebugLog;
            this.cmbSearchEngine.SelectCmbItem(config.SearchEngineId);
        }

        /// <summary>
        /// コンフィグを取得.
        /// </summary>
        /// <returns></returns>
        public Config GetConfig()
        {
            // この画面に表示されていない値を保持するために新たにロード.
            var config = Config.Load();

            // 画面の内容を反映.
            config.EnableWeb = this.chkWeb.Checked;
            config.ShowResultLimitCount = decimal.ToInt32(this.spinShowResultLimitCount.Value);

            config.SerchLimitCount = decimal.ToInt32(this.spinSerchLimitCount.Value);
            config.UseArmorAbstract = this.chkUseArmorAbstract.Checked;
            config.EnableAsyncExec = this.chkEnableAsyncExec.Checked;

            config.AnalyzeType = this.cmbAnalyzeType.SelectedCmbItem<AnalyzeType>();

            config.ShowDebugLog = this.chkShowDebugLog.Checked;
            config.SearchEngineId = this.cmbSearchEngine.SelectedCmbItem<string>();

            return config;
        }

        /// <summary>
        /// ダイアログロード
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CallBackDlgConfigLoad(object sender, System.EventArgs e)
        {
            // 現在の設定を画面に反映.
            this.SetConfig(Ssm.Config);
        }

        /// <summary>
        /// HomePageのLinkクリック.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void llblHomePage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            WebInfo.OpenHomePage();
        }

        /// <summary>
        /// メール送信クリック.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void llblMail_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            WebInfo.SendMail();
        }

        /// <summary>
        /// デフォルトに戻すボタン押下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CallBackBtnDefaultClick(object sender, EventArgs e)
        {
            // デフォルトの設定を画面に反映.
            this.SetConfig(new Config());
        }
    }
}
