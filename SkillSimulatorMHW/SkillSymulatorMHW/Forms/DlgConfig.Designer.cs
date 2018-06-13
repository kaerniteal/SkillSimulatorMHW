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
            this.tabPageConfig1 = new System.Windows.Forms.TabPage();
            this.spinShowResultLimitCount = new System.Windows.Forms.NumericUpDown();
            this.lblShowResultLimitCount = new System.Windows.Forms.Label();
            this.tabPageConfigSearch = new System.Windows.Forms.TabPage();
            this.cmbAnalyzeType = new System.Windows.Forms.ComboBox();
            this.chkEnableAsyncExec = new System.Windows.Forms.CheckBox();
            this.chkUseArmorAbstract = new System.Windows.Forms.CheckBox();
            this.spinSerchLimitCount = new System.Windows.Forms.NumericUpDown();
            this.lblAnalyzeType = new System.Windows.Forms.Label();
            this.lblSerchLimitCount = new System.Windows.Forms.Label();
            this.tabPageConfigDebug = new System.Windows.Forms.TabPage();
            this.cmbSearchEngine = new System.Windows.Forms.ComboBox();
            this.lblSearchEngine = new System.Windows.Forms.Label();
            this.chkShowDebugLog = new System.Windows.Forms.CheckBox();
            this.btnDefault = new System.Windows.Forms.Button();
            this.tabCtrlConfigView.SuspendLayout();
            this.tabPageConfig1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spinShowResultLimitCount)).BeginInit();
            this.tabPageConfigSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spinSerchLimitCount)).BeginInit();
            this.tabPageConfigDebug.SuspendLayout();
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
            this.tabCtrlConfigView.Controls.Add(this.tabPageConfig1);
            this.tabCtrlConfigView.Controls.Add(this.tabPageConfigSearch);
            this.tabCtrlConfigView.Controls.Add(this.tabPageConfigDebug);
            this.tabCtrlConfigView.Location = new System.Drawing.Point(12, 12);
            this.tabCtrlConfigView.Name = "tabCtrlConfigView";
            this.tabCtrlConfigView.SelectedIndex = 0;
            this.tabCtrlConfigView.Size = new System.Drawing.Size(364, 349);
            this.tabCtrlConfigView.TabIndex = 5;
            // 
            // tabPageConfig1
            // 
            this.tabPageConfig1.Controls.Add(this.spinShowResultLimitCount);
            this.tabPageConfig1.Controls.Add(this.lblShowResultLimitCount);
            this.tabPageConfig1.Location = new System.Drawing.Point(4, 22);
            this.tabPageConfig1.Name = "tabPageConfig1";
            this.tabPageConfig1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageConfig1.Size = new System.Drawing.Size(356, 323);
            this.tabPageConfig1.TabIndex = 0;
            this.tabPageConfig1.Text = "表示設定";
            this.tabPageConfig1.UseVisualStyleBackColor = true;
            // 
            // spinShowResultLimitCount
            // 
            this.spinShowResultLimitCount.Location = new System.Drawing.Point(270, 16);
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
            this.lblShowResultLimitCount.Location = new System.Drawing.Point(3, 18);
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
            this.tabPageConfig1.ResumeLayout(false);
            this.tabPageConfig1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spinShowResultLimitCount)).EndInit();
            this.tabPageConfigSearch.ResumeLayout(false);
            this.tabPageConfigSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spinSerchLimitCount)).EndInit();
            this.tabPageConfigDebug.ResumeLayout(false);
            this.tabPageConfigDebug.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TabControl tabCtrlConfigView;
        private System.Windows.Forms.TabPage tabPageConfig1;
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
    }
}