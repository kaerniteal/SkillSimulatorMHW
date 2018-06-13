namespace SkillSimulatorMHW.Forms
{
    partial class MainForm
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
            this.txtbLog = new System.Windows.Forms.TextBox();
            this.grpbSkill = new System.Windows.Forms.GroupBox();
            this.btnSkillSelectFilterClear = new System.Windows.Forms.Button();
            this.btnAddSkill = new System.Windows.Forms.Button();
            this.cmbSkillSelect = new System.Windows.Forms.ComboBox();
            this.txtbSkillSelectFilter = new System.Windows.Forms.TextBox();
            this.pnlSkillList = new System.Windows.Forms.Panel();
            this.grpbSerchRequirements = new System.Windows.Forms.GroupBox();
            this.grpbRequirementArmor = new System.Windows.Forms.GroupBox();
            this.radioRareAll = new System.Windows.Forms.RadioButton();
            this.radioRareLow = new System.Windows.Forms.RadioButton();
            this.radioRareHigh = new System.Windows.Forms.RadioButton();
            this.btnAppExit = new System.Windows.Forms.Button();
            this.btnAppSetting = new System.Windows.Forms.Button();
            this.btnExec = new System.Windows.Forms.Button();
            this.grpbSearchResult = new System.Windows.Forms.GroupBox();
            this.btnShowAnalyze = new System.Windows.Forms.Button();
            this.grpbSkill.SuspendLayout();
            this.grpbSerchRequirements.SuspendLayout();
            this.grpbRequirementArmor.SuspendLayout();
            this.grpbSearchResult.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtbLog
            // 
            this.txtbLog.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtbLog.Font = new System.Drawing.Font("MS UI Gothic", 9F);
            this.txtbLog.Location = new System.Drawing.Point(12, 595);
            this.txtbLog.Multiline = true;
            this.txtbLog.Name = "txtbLog";
            this.txtbLog.ReadOnly = true;
            this.txtbLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtbLog.Size = new System.Drawing.Size(410, 81);
            this.txtbLog.TabIndex = 4;
            this.txtbLog.WordWrap = false;
            // 
            // grpbSkill
            // 
            this.grpbSkill.Controls.Add(this.btnSkillSelectFilterClear);
            this.grpbSkill.Controls.Add(this.btnAddSkill);
            this.grpbSkill.Controls.Add(this.cmbSkillSelect);
            this.grpbSkill.Controls.Add(this.txtbSkillSelectFilter);
            this.grpbSkill.Controls.Add(this.pnlSkillList);
            this.grpbSkill.Location = new System.Drawing.Point(12, 10);
            this.grpbSkill.Name = "grpbSkill";
            this.grpbSkill.Size = new System.Drawing.Size(410, 537);
            this.grpbSkill.TabIndex = 5;
            this.grpbSkill.TabStop = false;
            this.grpbSkill.Text = "検索対象スキル選択";
            // 
            // btnSkillSelectFilterClear
            // 
            this.btnSkillSelectFilterClear.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btnSkillSelectFilterClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSkillSelectFilterClear.Font = new System.Drawing.Font("MS UI Gothic", 5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnSkillSelectFilterClear.Location = new System.Drawing.Point(62, 18);
            this.btnSkillSelectFilterClear.Margin = new System.Windows.Forms.Padding(0);
            this.btnSkillSelectFilterClear.Name = "btnSkillSelectFilterClear";
            this.btnSkillSelectFilterClear.Size = new System.Drawing.Size(15, 15);
            this.btnSkillSelectFilterClear.TabIndex = 8;
            this.btnSkillSelectFilterClear.Text = "×";
            this.btnSkillSelectFilterClear.UseVisualStyleBackColor = true;
            this.btnSkillSelectFilterClear.Click += new System.EventHandler(this.CallBackBtnSkillSelectFilterClearClick);
            // 
            // btnAddSkill
            // 
            this.btnAddSkill.Font = new System.Drawing.Font("MS UI Gothic", 10F, System.Drawing.FontStyle.Bold);
            this.btnAddSkill.Location = new System.Drawing.Point(308, 13);
            this.btnAddSkill.Name = "btnAddSkill";
            this.btnAddSkill.Size = new System.Drawing.Size(96, 25);
            this.btnAddSkill.TabIndex = 0;
            this.btnAddSkill.Text = "スキル追加";
            this.btnAddSkill.UseVisualStyleBackColor = true;
            this.btnAddSkill.Click += new System.EventHandler(this.CallBackAddSkillClick);
            // 
            // cmbSkillSelect
            // 
            this.cmbSkillSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSkillSelect.Font = new System.Drawing.Font("MS UI Gothic", 10F);
            this.cmbSkillSelect.FormattingEnabled = true;
            this.cmbSkillSelect.Location = new System.Drawing.Point(80, 15);
            this.cmbSkillSelect.Name = "cmbSkillSelect";
            this.cmbSkillSelect.Size = new System.Drawing.Size(222, 21);
            this.cmbSkillSelect.TabIndex = 2;
            // 
            // txtbSkillSelectFilter
            // 
            this.txtbSkillSelectFilter.Font = new System.Drawing.Font("MS UI Gothic", 10F);
            this.txtbSkillSelectFilter.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.txtbSkillSelectFilter.Location = new System.Drawing.Point(6, 15);
            this.txtbSkillSelectFilter.Name = "txtbSkillSelectFilter";
            this.txtbSkillSelectFilter.Size = new System.Drawing.Size(54, 21);
            this.txtbSkillSelectFilter.TabIndex = 1;
            this.txtbSkillSelectFilter.TextChanged += new System.EventHandler(this.CallBackTxtbSkillSelectFilterTextChanged);
            // 
            // pnlSkillList
            // 
            this.pnlSkillList.AutoScroll = true;
            this.pnlSkillList.BackColor = System.Drawing.SystemColors.Window;
            this.pnlSkillList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlSkillList.Location = new System.Drawing.Point(6, 42);
            this.pnlSkillList.Name = "pnlSkillList";
            this.pnlSkillList.Size = new System.Drawing.Size(398, 489);
            this.pnlSkillList.TabIndex = 0;
            // 
            // grpbSerchRequirements
            // 
            this.grpbSerchRequirements.Controls.Add(this.grpbRequirementArmor);
            this.grpbSerchRequirements.Location = new System.Drawing.Point(428, 10);
            this.grpbSerchRequirements.Name = "grpbSerchRequirements";
            this.grpbSerchRequirements.Size = new System.Drawing.Size(420, 666);
            this.grpbSerchRequirements.TabIndex = 6;
            this.grpbSerchRequirements.TabStop = false;
            this.grpbSerchRequirements.Text = "検索条件設定";
            // 
            // grpbRequirementArmor
            // 
            this.grpbRequirementArmor.Controls.Add(this.radioRareAll);
            this.grpbRequirementArmor.Controls.Add(this.radioRareLow);
            this.grpbRequirementArmor.Controls.Add(this.radioRareHigh);
            this.grpbRequirementArmor.Location = new System.Drawing.Point(6, 88);
            this.grpbRequirementArmor.Name = "grpbRequirementArmor";
            this.grpbRequirementArmor.Size = new System.Drawing.Size(408, 415);
            this.grpbRequirementArmor.TabIndex = 7;
            this.grpbRequirementArmor.TabStop = false;
            this.grpbRequirementArmor.Text = "防具";
            // 
            // radioRareAll
            // 
            this.radioRareAll.AutoSize = true;
            this.radioRareAll.Font = new System.Drawing.Font("MS UI Gothic", 9F);
            this.radioRareAll.Location = new System.Drawing.Point(154, 18);
            this.radioRareAll.Name = "radioRareAll";
            this.radioRareAll.Size = new System.Drawing.Size(44, 16);
            this.radioRareAll.TabIndex = 0;
            this.radioRareAll.Text = "全て";
            this.radioRareAll.UseVisualStyleBackColor = true;
            this.radioRareAll.CheckedChanged += new System.EventHandler(this.CallBackRadioRareCheckedChanged);
            // 
            // radioRareLow
            // 
            this.radioRareLow.AutoSize = true;
            this.radioRareLow.Font = new System.Drawing.Font("MS UI Gothic", 9F);
            this.radioRareLow.Location = new System.Drawing.Point(80, 18);
            this.radioRareLow.Name = "radioRareLow";
            this.radioRareLow.Size = new System.Drawing.Size(68, 16);
            this.radioRareLow.TabIndex = 0;
            this.radioRareLow.Text = "下位のみ";
            this.radioRareLow.UseVisualStyleBackColor = true;
            this.radioRareLow.CheckedChanged += new System.EventHandler(this.CallBackRadioRareCheckedChanged);
            // 
            // radioRareHigh
            // 
            this.radioRareHigh.AutoSize = true;
            this.radioRareHigh.Checked = true;
            this.radioRareHigh.Font = new System.Drawing.Font("MS UI Gothic", 9F);
            this.radioRareHigh.Location = new System.Drawing.Point(6, 18);
            this.radioRareHigh.Name = "radioRareHigh";
            this.radioRareHigh.Size = new System.Drawing.Size(68, 16);
            this.radioRareHigh.TabIndex = 0;
            this.radioRareHigh.TabStop = true;
            this.radioRareHigh.Text = "上位のみ";
            this.radioRareHigh.UseVisualStyleBackColor = true;
            this.radioRareHigh.CheckedChanged += new System.EventHandler(this.CallBackRadioRareCheckedChanged);
            // 
            // btnAppExit
            // 
            this.btnAppExit.Font = new System.Drawing.Font("MS UI Gothic", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnAppExit.Location = new System.Drawing.Point(1162, 645);
            this.btnAppExit.Name = "btnAppExit";
            this.btnAppExit.Size = new System.Drawing.Size(110, 25);
            this.btnAppExit.TabIndex = 1;
            this.btnAppExit.Text = "終了";
            this.btnAppExit.UseVisualStyleBackColor = true;
            this.btnAppExit.Click += new System.EventHandler(this.CallBackBtnAppExitClick);
            // 
            // btnAppSetting
            // 
            this.btnAppSetting.Font = new System.Drawing.Font("MS UI Gothic", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnAppSetting.Location = new System.Drawing.Point(1046, 645);
            this.btnAppSetting.Name = "btnAppSetting";
            this.btnAppSetting.Size = new System.Drawing.Size(110, 25);
            this.btnAppSetting.TabIndex = 1;
            this.btnAppSetting.Text = "動作設定";
            this.btnAppSetting.UseVisualStyleBackColor = true;
            this.btnAppSetting.Click += new System.EventHandler(this.CallBackBtnAppSettingClick);
            // 
            // btnExec
            // 
            this.btnExec.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnExec.Location = new System.Drawing.Point(12, 553);
            this.btnExec.Name = "btnExec";
            this.btnExec.Size = new System.Drawing.Size(410, 36);
            this.btnExec.TabIndex = 1;
            this.btnExec.Text = "検　索　開　始";
            this.btnExec.UseVisualStyleBackColor = true;
            this.btnExec.Click += new System.EventHandler(this.CallBackBtnExecClick);
            // 
            // grpbSearchResult
            // 
            this.grpbSearchResult.Controls.Add(this.btnShowAnalyze);
            this.grpbSearchResult.Location = new System.Drawing.Point(854, 10);
            this.grpbSearchResult.Name = "grpbSearchResult";
            this.grpbSearchResult.Size = new System.Drawing.Size(418, 629);
            this.grpbSearchResult.TabIndex = 8;
            this.grpbSearchResult.TabStop = false;
            this.grpbSearchResult.Text = "検索結果";
            // 
            // btnShowAnalyze
            // 
            this.btnShowAnalyze.Enabled = false;
            this.btnShowAnalyze.Font = new System.Drawing.Font("MS UI Gothic", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnShowAnalyze.Location = new System.Drawing.Point(6, 585);
            this.btnShowAnalyze.Name = "btnShowAnalyze";
            this.btnShowAnalyze.Size = new System.Drawing.Size(406, 36);
            this.btnShowAnalyze.TabIndex = 9;
            this.btnShowAnalyze.Text = "条件を満たさなかったセットの要因解析結果";
            this.btnShowAnalyze.UseVisualStyleBackColor = true;
            this.btnShowAnalyze.Click += new System.EventHandler(this.CallBackBtnShowAnalyzeClick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1284, 682);
            this.Controls.Add(this.grpbSearchResult);
            this.Controls.Add(this.btnAppSetting);
            this.Controls.Add(this.btnExec);
            this.Controls.Add(this.btnAppExit);
            this.Controls.Add(this.grpbSerchRequirements);
            this.Controls.Add(this.grpbSkill);
            this.Controls.Add(this.txtbLog);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MHW スキルシミュレータ";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.CallBackMainFormLoad);
            this.grpbSkill.ResumeLayout(false);
            this.grpbSkill.PerformLayout();
            this.grpbSerchRequirements.ResumeLayout(false);
            this.grpbRequirementArmor.ResumeLayout(false);
            this.grpbRequirementArmor.PerformLayout();
            this.grpbSearchResult.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtbLog;
        private System.Windows.Forms.GroupBox grpbSkill;
        private System.Windows.Forms.GroupBox grpbSerchRequirements;
        private System.Windows.Forms.Panel pnlSkillList;
        private System.Windows.Forms.Button btnAddSkill;
        private System.Windows.Forms.Button btnAppExit;
        private System.Windows.Forms.Button btnAppSetting;
        private System.Windows.Forms.Button btnExec;
        private System.Windows.Forms.TextBox txtbSkillSelectFilter;
        private System.Windows.Forms.ComboBox cmbSkillSelect;
        private System.Windows.Forms.GroupBox grpbSearchResult;
        private System.Windows.Forms.GroupBox grpbRequirementArmor;
        private System.Windows.Forms.RadioButton radioRareAll;
        private System.Windows.Forms.RadioButton radioRareLow;
        private System.Windows.Forms.RadioButton radioRareHigh;
        private System.Windows.Forms.Button btnSkillSelectFilterClear;
        private System.Windows.Forms.Button btnShowAnalyze;
    }
}