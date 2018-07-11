namespace SkillSimulatorMHW.Forms
{
    partial class DlgConfig
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.tabCtrlConfigView = new System.Windows.Forms.TabControl();
            this.tabPageConfigDebug = new System.Windows.Forms.TabPage();
            this.cmbSearchEngine = new System.Windows.Forms.ComboBox();
            this.lblSearchEngine = new System.Windows.Forms.Label();
            this.chkShowDebugLog = new System.Windows.Forms.CheckBox();
            this.tabPageConfigViewer = new System.Windows.Forms.TabPage();
            this.chkWeb = new System.Windows.Forms.CheckBox();
            this.spinShowResultLimitCount = new System.Windows.Forms.NumericUpDown();
            this.lblShowResultLimitCount = new System.Windows.Forms.Label();
            this.tabPageConfigSearch = new System.Windows.Forms.TabPage();
            this.cmbAnalyzeType = new System.Windows.Forms.ComboBox();
            this.chkEnableAsyncExec = new System.Windows.Forms.CheckBox();
            this.chkUseArmorAbstract = new System.Windows.Forms.CheckBox();
            this.spinSerchLimitCount = new System.Windows.Forms.NumericUpDown();
            this.lblAnalyzeType = new System.Windows.Forms.Label();
            this.lblSerchLimitCount = new System.Windows.Forms.Label();
            this.btnDefault = new System.Windows.Forms.Button();
            this.tabPageVersion = new System.Windows.Forms.TabPage();
            this.lblAppVersion = new System.Windows.Forms.Label();
            this.llblHomePage = new System.Windows.Forms.LinkLabel();
            this.lblHomePage = new System.Windows.Forms.Label();
            this.lblAppVerTitle = new System.Windows.Forms.Label();
            this.lblMailTitle = new System.Windows.Forms.Label();
            this.llblMail = new System.Windows.Forms.LinkLabel();
            this.tabCtrlConfigView.SuspendLayout();
            this.tabPageConfigDebug.SuspendLayout();
            this.tabPageConfigViewer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spinShowResultLimitCount)).BeginInit();
            this.tabPageConfigSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spinSerchLimitCount)).BeginInit();
            this.tabPageVersion.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Font = new System.Drawing.Font("MS UI Gothic", 11F, System.Drawing.FontStyle.Bold);
            this.btnOK.Location = new System.Drawing.Point(150, 367);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(110, 25);
            this.btnOK.TabIndex = 3;
            this.btnOK.Text = "O K";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("MS UI Gothic", 11F, System.Drawing.FontStyle.Bold);
            this.btnCancel.Location = new System.Drawing.Point(266, 367);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(110, 25);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "キャンセル";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // tabCtrlConfigView
            // 
            this.tabCtrlConfigView.Controls.Add(this.tabPageConfigDebug);
            this.tabCtrlConfigView.Controls.Add(this.tabPageVersion);
            this.tabCtrlConfigView.Controls.Add(this.tabPageConfigViewer);
            this.tabCtrlConfigView.Controls.Add(this.tabPageConfigSearch);
            this.tabCtrlConfigView.Location = new System.Drawing.Point(12, 12);
            this.tabCtrlConfigView.Name = "tabCtrlConfigView";
            this.tabCtrlConfigView.SelectedIndex = 0;
            this.tabCtrlConfigView.Size = new System.Drawing.Size(364, 349);
            this.tabCtrlConfigView.TabIndex = 5;
            // 
            // tabPageConfigDebug
            // 
            this.tabPageConfigDebug.Controls.Add(this.cmbSearchEngine);
            this.tabPageConfigDebug.Controls.Add(this.lblSearchEngine);
            this.tabPageConfigDebug.Controls.Add(this.chkShowDebugLog);
            this.tabPageConfigDebug.Location = new System.Drawing.Point(4, 22);
            this.tabPageConfigDebug.Name = "tabPageConfigDebug";
            this.tabPageConfigDebug.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageConfigDebug.Size = new System.Drawing.Size(356, 323);
            this.tabPageConfigDebug.TabIndex = 2;
            this.tabPageConfigDebug.Text = "Debug";
            this.tabPageConfigDebug.UseVisualStyleBackColor = true;
            // 
            // cmbSearchEngine
            // 
            this.cmbSearchEngine.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSearchEngine.FormattingEnabled = true;
            this.cmbSearchEngine.Location = new System.Drawing.Point(89, 42);
            this.cmbSearchEngine.Name = "cmbSearchEngine";
            this.cmbSearchEngine.Size = new System.Drawing.Size(261, 20);
            this.cmbSearchEngine.TabIndex = 6;
            // 
            // lblSearchEngine
            // 
            this.lblSearchEngine.AutoSize = true;
            this.lblSearchEngine.Location = new System.Drawing.Point(6, 45);
            this.lblSearchEngine.Name = "lblSearchEngine";
            this.lblSearchEngine.Size = new System.Drawing.Size(66, 12);
            this.lblSearchEngine.TabIndex = 5;
            this.lblSearchEngine.Text = "検索エンジン";
            // 
            // chkShowDebugLog
            // 
            this.chkShowDebugLog.AutoSize = true;
            this.chkShowDebugLog.Location = new System.Drawing.Point(6, 20);
            this.chkShowDebugLog.Name = "chkShowDebugLog";
            this.chkShowDebugLog.Size = new System.Drawing.Size(130, 16);
            this.chkShowDebugLog.TabIndex = 4;
            this.chkShowDebugLog.Text = "デバッグログを出力する";
            this.chkShowDebugLog.UseVisualStyleBackColor = true;
            // 
            // tabPageConfigViewer
            // 
            this.tabPageConfigViewer.Controls.Add(this.chkWeb);
            this.tabPageConfigViewer.Controls.Add(this.spinShowResultLimitCount);
            this.tabPageConfigViewer.Controls.Add(this.lblShowResultLimitCount);
            this.tabPageConfigViewer.Location = new System.Drawing.Point(4, 22);
            this.tabPageConfigViewer.Name = "tabPageConfigViewer";
            this.tabPageConfigViewer.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageConfigViewer.Size = new System.Drawing.Size(356, 323);
            this.tabPageConfigViewer.TabIndex = 0;
            this.tabPageConfigViewer.Text = "動作設定";
            this.tabPageConfigViewer.UseVisualStyleBackColor = true;
            // 
            // chkWeb
            // 
            this.chkWeb.AutoSize = true;
            this.chkWeb.Checked = true;
            this.chkWeb.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkWeb.Location = new System.Drawing.Point(6, 18);
            this.chkWeb.Name = "chkWeb";
            this.chkWeb.Size = new System.Drawing.Size(190, 16);
            this.chkWeb.TabIndex = 4;
            this.chkWeb.Text = "インターネットへの接続を有効にする";
            this.chkWeb.UseVisualStyleBackColor = true;
            // 
            // spinShowResultLimitCount
            // 
            this.spinShowResultLimitCount.Location = new System.Drawing.Point(270, 42);
            this.spinShowResultLimitCount.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.spinShowResultLimitCount.Name = "spinShowResultLimitCount";
            this.spinShowResultLimitCount.Size = new System.Drawing.Size(80, 19);
            this.spinShowResultLimitCount.TabIndex = 1;
            // 
            // lblShowResultLimitCount
            // 
            this.lblShowResultLimitCount.AutoSize = true;
            this.lblShowResultLimitCount.Location = new System.Drawing.Point(4, 44);
            this.lblShowResultLimitCount.Name = "lblShowResultLimitCount";
            this.lblShowResultLimitCount.Size = new System.Drawing.Size(227, 12);
            this.lblShowResultLimitCount.TabIndex = 0;
            this.lblShowResultLimitCount.Text = "結果の最大表示件数 (０を設定すると無制限)";
            // 
            // tabPageConfigSearch
            // 
            this.tabPageConfigSearch.Controls.Add(this.cmbAnalyzeType);
            this.tabPageConfigSearch.Controls.Add(this.chkEnableAsyncExec);
            this.tabPageConfigSearch.Controls.Add(this.chkUseArmorAbstract);
            this.tabPageConfigSearch.Controls.Add(this.spinSerchLimitCount);
            this.tabPageConfigSearch.Controls.Add(this.lblAnalyzeType);
            this.tabPageConfigSearch.Controls.Add(this.lblSerchLimitCount);
            this.tabPageConfigSearch.Location = new System.Drawing.Point(4, 22);
            this.tabPageConfigSearch.Name = "tabPageConfigSearch";
            this.tabPageConfigSearch.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageConfigSearch.Size = new System.Drawing.Size(356, 323);
            this.tabPageConfigSearch.TabIndex = 1;
            this.tabPageConfigSearch.Text = "検索設定";
            this.tabPageConfigSearch.UseVisualStyleBackColor = true;
            // 
            // cmbAnalyzeType
            // 
            this.cmbAnalyzeType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAnalyzeType.FormattingEnabled = true;
            this.cmbAnalyzeType.Location = new System.Drawing.Point(89, 86);
            this.cmbAnalyzeType.Name = "cmbAnalyzeType";
            this.cmbAnalyzeType.Size = new System.Drawing.Size(261, 20);
            this.cmbAnalyzeType.TabIndex = 4;
            // 
            // chkEnableAsyncExec
            // 
            this.chkEnableAsyncExec.AutoSize = true;
            this.chkEnableAsyncExec.Location = new System.Drawing.Point(6, 64);
            this.chkEnableAsyncExec.Name = "chkEnableAsyncExec";
            this.chkEnableAsyncExec.Size = new System.Drawing.Size(257, 16);
            this.chkEnableAsyncExec.TabIndex = 3;
            this.chkEnableAsyncExec.Text = "検索を非同期で実行する (キャンセル可能にする)";
            this.chkEnableAsyncExec.UseVisualStyleBackColor = true;
            // 
            // chkUseArmorAbstract
            // 
            this.chkUseArmorAbstract.AutoSize = true;
            this.chkUseArmorAbstract.Location = new System.Drawing.Point(6, 42);
            this.chkUseArmorAbstract.Name = "chkUseArmorAbstract";
            this.chkUseArmorAbstract.Size = new System.Drawing.Size(296, 16);
            this.chkUseArmorAbstract.TabIndex = 3;
            this.chkUseArmorAbstract.Text = "抽象化防具を検索結果に含める (例：スロット① 胴防具)";
            this.chkUseArmorAbstract.UseVisualStyleBackColor = true;
            // 
            // spinSerchLimitCount
            // 
            this.spinSerchLimitCount.Location = new System.Drawing.Point(270, 16);
            this.spinSerchLimitCount.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.spinSerchLimitCount.Name = "spinSerchLimitCount";
            this.spinSerchLimitCount.Size = new System.Drawing.Size(80, 19);
            this.spinSerchLimitCount.TabIndex = 2;
            // 
            // lblAnalyzeType
            // 
            this.lblAnalyzeType.AutoSize = true;
            this.lblAnalyzeType.Location = new System.Drawing.Point(6, 89);
            this.lblAnalyzeType.Name = "lblAnalyzeType";
            this.lblAnalyzeType.Size = new System.Drawing.Size(77, 12);
            this.lblAnalyzeType.TabIndex = 1;
            this.lblAnalyzeType.Text = "条件未達解析";
            // 
            // lblSerchLimitCount
            // 
            this.lblSerchLimitCount.AutoSize = true;
            this.lblSerchLimitCount.Location = new System.Drawing.Point(3, 18);
            this.lblSerchLimitCount.Name = "lblSerchLimitCount";
            this.lblSerchLimitCount.Size = new System.Drawing.Size(203, 12);
            this.lblSerchLimitCount.TabIndex = 1;
            this.lblSerchLimitCount.Text = "検索の検出上限 (０を設定すると無制限)";
            // 
            // btnDefault
            // 
            this.btnDefault.Font = new System.Drawing.Font("MS UI Gothic", 11F, System.Drawing.FontStyle.Bold);
            this.btnDefault.Location = new System.Drawing.Point(12, 367);
            this.btnDefault.Name = "btnDefault";
            this.btnDefault.Size = new System.Drawing.Size(132, 25);
            this.btnDefault.TabIndex = 3;
            this.btnDefault.Text = "デフォルトに戻す";
            this.btnDefault.UseVisualStyleBackColor = true;
            this.btnDefault.Click += new System.EventHandler(this.CallBackBtnDefaultClick);
            // 
            // tabPageVersion
            // 
            this.tabPageVersion.Controls.Add(this.llblMail);
            this.tabPageVersion.Controls.Add(this.llblHomePage);
            this.tabPageVersion.Controls.Add(this.lblAppVerTitle);
            this.tabPageVersion.Controls.Add(this.lblMailTitle);
            this.tabPageVersion.Controls.Add(this.lblHomePage);
            this.tabPageVersion.Controls.Add(this.lblAppVersion);
            this.tabPageVersion.Location = new System.Drawing.Point(4, 22);
            this.tabPageVersion.Name = "tabPageVersion";
            this.tabPageVersion.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageVersion.Size = new System.Drawing.Size(356, 323);
            this.tabPageVersion.TabIndex = 3;
            this.tabPageVersion.Text = "このアプリケーションについて";
            this.tabPageVersion.UseVisualStyleBackColor = true;
            // 
            // lblAppVersion
            // 
            this.lblAppVersion.AutoSize = true;
            this.lblAppVersion.Location = new System.Drawing.Point(18, 35);
            this.lblAppVersion.Name = "lblAppVersion";
            this.lblAppVersion.Size = new System.Drawing.Size(147, 12);
            this.lblAppVersion.TabIndex = 0;
            this.lblAppVersion.Text = "SkillSimulatorMhw Ver X.x.x";
            // 
            // llblHomePage
            // 
            this.llblHomePage.AutoSize = true;
            this.llblHomePage.Location = new System.Drawing.Point(18, 88);
            this.llblHomePage.Name = "llblHomePage";
            this.llblHomePage.Size = new System.Drawing.Size(266, 12);
            this.llblHomePage.TabIndex = 1;
            this.llblHomePage.TabStop = true;
            this.llblHomePage.Text = "https://kaerniteal.web.fc2.com/SkillSimulatorMHW/";
            this.llblHomePage.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llblHomePage_LinkClicked);
            // 
            // lblHomePage
            // 
            this.lblHomePage.AutoSize = true;
            this.lblHomePage.Location = new System.Drawing.Point(18, 65);
            this.lblHomePage.Name = "lblHomePage";
            this.lblHomePage.Size = new System.Drawing.Size(77, 12);
            this.lblHomePage.TabIndex = 0;
            this.lblHomePage.Text = "【ホームページ】";
            // 
            // lblAppVerTitle
            // 
            this.lblAppVerTitle.AutoSize = true;
            this.lblAppVerTitle.Location = new System.Drawing.Point(18, 14);
            this.lblAppVerTitle.Name = "lblAppVerTitle";
            this.lblAppVerTitle.Size = new System.Drawing.Size(62, 12);
            this.lblAppVerTitle.TabIndex = 0;
            this.lblAppVerTitle.Text = "【バージョン】";
            // 
            // lblMailTitle
            // 
            this.lblMailTitle.AutoSize = true;
            this.lblMailTitle.Location = new System.Drawing.Point(18, 215);
            this.lblMailTitle.Name = "lblMailTitle";
            this.lblMailTitle.Size = new System.Drawing.Size(108, 12);
            this.lblMailTitle.TabIndex = 0;
            this.lblMailTitle.Text = "【作者にメールを送る】";
            // 
            // llblMail
            // 
            this.llblMail.AutoSize = true;
            this.llblMail.Location = new System.Drawing.Point(18, 237);
            this.llblMail.Name = "llblMail";
            this.llblMail.Size = new System.Drawing.Size(159, 12);
            this.llblMail.TabIndex = 2;
            this.llblMail.TabStop = true;
            this.llblMail.Text = "SkillSimulatorMHW@gmail.com";
            this.llblMail.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llblMail_LinkClicked);
            // 
            // DlgConfig
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(388, 404);
            this.Controls.Add(this.tabCtrlConfigView);
            this.Controls.Add(this.btnDefault);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "DlgConfig";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "動作設定";
            this.Load += new System.EventHandler(this.CallBackDlgConfigLoad);
            this.tabCtrlConfigView.ResumeLayout(false);
            this.tabPageConfigDebug.ResumeLayout(false);
            this.tabPageConfigDebug.PerformLayout();
            this.tabPageConfigViewer.ResumeLayout(false);
            this.tabPageConfigViewer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spinShowResultLimitCount)).EndInit();
            this.tabPageConfigSearch.ResumeLayout(false);
            this.tabPageConfigSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spinSerchLimitCount)).EndInit();
            this.tabPageVersion.ResumeLayout(false);
            this.tabPageVersion.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TabControl tabCtrlConfigView;
        private System.Windows.Forms.TabPage tabPageConfigViewer;
        private System.Windows.Forms.TabPage tabPageConfigSearch;
        private System.Windows.Forms.NumericUpDown spinShowResultLimitCount;
        private System.Windows.Forms.Label lblShowResultLimitCount;
        private System.Windows.Forms.Label lblSerchLimitCount;
        private System.Windows.Forms.NumericUpDown spinSerchLimitCount;
        private System.Windows.Forms.CheckBox chkUseArmorAbstract;
        private System.Windows.Forms.CheckBox chkEnableAsyncExec;
        private System.Windows.Forms.Button btnDefault;
        private System.Windows.Forms.TabPage tabPageConfigDebug;
        private System.Windows.Forms.CheckBox chkShowDebugLog;
        private System.Windows.Forms.ComboBox cmbAnalyzeType;
        private System.Windows.Forms.Label lblAnalyzeType;
        private System.Windows.Forms.ComboBox cmbSearchEngine;
        private System.Windows.Forms.Label lblSearchEngine;
        private System.Windows.Forms.CheckBox chkWeb;
        private System.Windows.Forms.TabPage tabPageVersion;
        private System.Windows.Forms.LinkLabel llblHomePage;
        private System.Windows.Forms.Label lblAppVersion;
        private System.Windows.Forms.Label lblHomePage;
        private System.Windows.Forms.Label lblAppVerTitle;
        private System.Windows.Forms.Label lblMailTitle;
        private System.Windows.Forms.LinkLabel llblMail;
    }
}