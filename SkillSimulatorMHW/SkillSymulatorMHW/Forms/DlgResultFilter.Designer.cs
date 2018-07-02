namespace SkillSimulatorMHW.Forms
{
    partial class DlgResultFilter
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
            this.btnShow = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblNeedBlankSlotLv1 = new System.Windows.Forms.Label();
            this.lblNeedBlankSlotLv2 = new System.Windows.Forms.Label();
            this.lblNeedBlankSlotLv3 = new System.Windows.Forms.Label();
            this.lblFilterdCount = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblPer = new System.Windows.Forms.Label();
            this.lblAllCount = new System.Windows.Forms.Label();
            this.txtbFilterdCount = new System.Windows.Forms.TextBox();
            this.txtbAllCount = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblAddSkill = new System.Windows.Forms.Label();
            this.cmbAddSkill1 = new System.Windows.Forms.ComboBox();
            this.cmbAddSkill2 = new System.Windows.Forms.ComboBox();
            this.cmbAddSkill3 = new System.Windows.Forms.ComboBox();
            this.numAddSkill3 = new SkillSimulatorMHW.Controls.NumericControl();
            this.numAddSkill2 = new SkillSimulatorMHW.Controls.NumericControl();
            this.numAddSkill1 = new SkillSimulatorMHW.Controls.NumericControl();
            this.numBlankSlotLv3 = new SkillSimulatorMHW.Controls.NumericControl();
            this.numBlankSlotLv2 = new SkillSimulatorMHW.Controls.NumericControl();
            this.numBlankSlotLv1 = new SkillSimulatorMHW.Controls.NumericControl();
            this.SuspendLayout();
            // 
            // btnShow
            // 
            this.btnShow.Font = new System.Drawing.Font("MS UI Gothic", 11F, System.Drawing.FontStyle.Bold);
            this.btnShow.Location = new System.Drawing.Point(14, 367);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(245, 25);
            this.btnShow.TabIndex = 5;
            this.btnShow.Text = "絞り込んだ結果を表示する";
            this.btnShow.UseVisualStyleBackColor = true;
            this.btnShow.Click += new System.EventHandler(this.CallBackBtnShowClick);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("MS UI Gothic", 11F, System.Drawing.FontStyle.Bold);
            this.btnCancel.Location = new System.Drawing.Point(266, 367);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(110, 25);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "閉じる";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // lblNeedBlankSlotLv1
            // 
            this.lblNeedBlankSlotLv1.AutoSize = true;
            this.lblNeedBlankSlotLv1.Location = new System.Drawing.Point(12, 47);
            this.lblNeedBlankSlotLv1.Name = "lblNeedBlankSlotLv1";
            this.lblNeedBlankSlotLv1.Size = new System.Drawing.Size(128, 12);
            this.lblNeedBlankSlotLv1.TabIndex = 7;
            this.lblNeedBlankSlotLv1.Text = "Lv1スロットの空いている数";
            // 
            // lblNeedBlankSlotLv2
            // 
            this.lblNeedBlankSlotLv2.AutoSize = true;
            this.lblNeedBlankSlotLv2.Location = new System.Drawing.Point(12, 74);
            this.lblNeedBlankSlotLv2.Name = "lblNeedBlankSlotLv2";
            this.lblNeedBlankSlotLv2.Size = new System.Drawing.Size(128, 12);
            this.lblNeedBlankSlotLv2.TabIndex = 7;
            this.lblNeedBlankSlotLv2.Text = "Lv2スロットの空いている数";
            // 
            // lblNeedBlankSlotLv3
            // 
            this.lblNeedBlankSlotLv3.AutoSize = true;
            this.lblNeedBlankSlotLv3.Location = new System.Drawing.Point(12, 101);
            this.lblNeedBlankSlotLv3.Name = "lblNeedBlankSlotLv3";
            this.lblNeedBlankSlotLv3.Size = new System.Drawing.Size(128, 12);
            this.lblNeedBlankSlotLv3.TabIndex = 10;
            this.lblNeedBlankSlotLv3.Text = "Lv3スロットの空いている数";
            // 
            // lblFilterdCount
            // 
            this.lblFilterdCount.AutoSize = true;
            this.lblFilterdCount.Location = new System.Drawing.Point(12, 9);
            this.lblFilterdCount.Name = "lblFilterdCount";
            this.lblFilterdCount.Size = new System.Drawing.Size(84, 12);
            this.lblFilterdCount.TabIndex = 7;
            this.lblFilterdCount.Text = "絞り込み結果数";
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Location = new System.Drawing.Point(1, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(387, 2);
            this.label2.TabIndex = 12;
            // 
            // lblPer
            // 
            this.lblPer.AutoSize = true;
            this.lblPer.Location = new System.Drawing.Point(168, 9);
            this.lblPer.Name = "lblPer";
            this.lblPer.Size = new System.Drawing.Size(11, 12);
            this.lblPer.TabIndex = 7;
            this.lblPer.Text = "/";
            // 
            // lblAllCount
            // 
            this.lblAllCount.AutoSize = true;
            this.lblAllCount.Location = new System.Drawing.Point(251, 9);
            this.lblAllCount.Name = "lblAllCount";
            this.lblAllCount.Size = new System.Drawing.Size(65, 12);
            this.lblAllCount.TabIndex = 7;
            this.lblAllCount.Text = "結果全件数";
            // 
            // txtbFilterdCount
            // 
            this.txtbFilterdCount.BackColor = System.Drawing.SystemColors.Control;
            this.txtbFilterdCount.Font = new System.Drawing.Font("MS UI Gothic", 10F);
            this.txtbFilterdCount.Location = new System.Drawing.Point(102, 5);
            this.txtbFilterdCount.Name = "txtbFilterdCount";
            this.txtbFilterdCount.ReadOnly = true;
            this.txtbFilterdCount.Size = new System.Drawing.Size(62, 21);
            this.txtbFilterdCount.TabIndex = 14;
            this.txtbFilterdCount.Text = "9999件";
            this.txtbFilterdCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtbAllCount
            // 
            this.txtbAllCount.BackColor = System.Drawing.SystemColors.Control;
            this.txtbAllCount.Font = new System.Drawing.Font("MS UI Gothic", 10F);
            this.txtbAllCount.Location = new System.Drawing.Point(183, 5);
            this.txtbAllCount.Name = "txtbAllCount";
            this.txtbAllCount.ReadOnly = true;
            this.txtbAllCount.Size = new System.Drawing.Size(62, 21);
            this.txtbAllCount.TabIndex = 14;
            this.txtbAllCount.Text = "9999件";
            this.txtbAllCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Location = new System.Drawing.Point(1, 129);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(387, 2);
            this.label1.TabIndex = 12;
            // 
            // lblAddSkill
            // 
            this.lblAddSkill.AutoSize = true;
            this.lblAddSkill.Location = new System.Drawing.Point(12, 145);
            this.lblAddSkill.Name = "lblAddSkill";
            this.lblAddSkill.Size = new System.Drawing.Size(184, 12);
            this.lblAddSkill.TabIndex = 18;
            this.lblAddSkill.Text = "絞り込み条件に追加したいスキルのLv";
            // 
            // cmbAddSkill1
            // 
            this.cmbAddSkill1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAddSkill1.Font = new System.Drawing.Font("MS UI Gothic", 10F);
            this.cmbAddSkill1.FormattingEnabled = true;
            this.cmbAddSkill1.Location = new System.Drawing.Point(14, 164);
            this.cmbAddSkill1.Name = "cmbAddSkill1";
            this.cmbAddSkill1.Size = new System.Drawing.Size(222, 21);
            this.cmbAddSkill1.TabIndex = 19;
            this.cmbAddSkill1.SelectedIndexChanged += new System.EventHandler(this.CallBackCmbAddSkillSelectedIndexChanged);
            // 
            // cmbAddSkill2
            // 
            this.cmbAddSkill2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAddSkill2.Font = new System.Drawing.Font("MS UI Gothic", 10F);
            this.cmbAddSkill2.FormattingEnabled = true;
            this.cmbAddSkill2.Location = new System.Drawing.Point(14, 191);
            this.cmbAddSkill2.Name = "cmbAddSkill2";
            this.cmbAddSkill2.Size = new System.Drawing.Size(222, 21);
            this.cmbAddSkill2.TabIndex = 19;
            this.cmbAddSkill2.SelectedIndexChanged += new System.EventHandler(this.CallBackCmbAddSkillSelectedIndexChanged);
            // 
            // cmbAddSkill3
            // 
            this.cmbAddSkill3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAddSkill3.Font = new System.Drawing.Font("MS UI Gothic", 10F);
            this.cmbAddSkill3.FormattingEnabled = true;
            this.cmbAddSkill3.Location = new System.Drawing.Point(14, 218);
            this.cmbAddSkill3.Name = "cmbAddSkill3";
            this.cmbAddSkill3.Size = new System.Drawing.Size(222, 21);
            this.cmbAddSkill3.TabIndex = 19;
            this.cmbAddSkill3.SelectedIndexChanged += new System.EventHandler(this.CallBackCmbAddSkillSelectedIndexChanged);
            // 
            // numAddSkill3
            // 
            this.numAddSkill3.Location = new System.Drawing.Point(253, 216);
            this.numAddSkill3.Max = 10;
            this.numAddSkill3.Min = 0;
            this.numAddSkill3.Name = "numAddSkill3";
            this.numAddSkill3.Size = new System.Drawing.Size(90, 26);
            this.numAddSkill3.TabIndex = 26;
            this.numAddSkill3.Value = 0;
            // 
            // numAddSkill2
            // 
            this.numAddSkill2.Location = new System.Drawing.Point(253, 189);
            this.numAddSkill2.Max = 10;
            this.numAddSkill2.Min = 0;
            this.numAddSkill2.Name = "numAddSkill2";
            this.numAddSkill2.Size = new System.Drawing.Size(90, 26);
            this.numAddSkill2.TabIndex = 26;
            this.numAddSkill2.Value = 0;
            // 
            // numAddSkill1
            // 
            this.numAddSkill1.Location = new System.Drawing.Point(253, 162);
            this.numAddSkill1.Max = 10;
            this.numAddSkill1.Min = 0;
            this.numAddSkill1.Name = "numAddSkill1";
            this.numAddSkill1.Size = new System.Drawing.Size(90, 26);
            this.numAddSkill1.TabIndex = 26;
            this.numAddSkill1.Value = 0;
            // 
            // numBlankSlotLv3
            // 
            this.numBlankSlotLv3.Location = new System.Drawing.Point(166, 95);
            this.numBlankSlotLv3.Max = 20;
            this.numBlankSlotLv3.Min = 0;
            this.numBlankSlotLv3.Name = "numBlankSlotLv3";
            this.numBlankSlotLv3.Size = new System.Drawing.Size(90, 26);
            this.numBlankSlotLv3.TabIndex = 25;
            this.numBlankSlotLv3.Value = 0;
            // 
            // numBlankSlotLv2
            // 
            this.numBlankSlotLv2.Location = new System.Drawing.Point(166, 68);
            this.numBlankSlotLv2.Max = 20;
            this.numBlankSlotLv2.Min = 0;
            this.numBlankSlotLv2.Name = "numBlankSlotLv2";
            this.numBlankSlotLv2.Size = new System.Drawing.Size(90, 26);
            this.numBlankSlotLv2.TabIndex = 24;
            this.numBlankSlotLv2.Value = 0;
            // 
            // numBlankSlotLv1
            // 
            this.numBlankSlotLv1.Location = new System.Drawing.Point(166, 41);
            this.numBlankSlotLv1.Max = 20;
            this.numBlankSlotLv1.Min = 0;
            this.numBlankSlotLv1.Name = "numBlankSlotLv1";
            this.numBlankSlotLv1.Size = new System.Drawing.Size(90, 26);
            this.numBlankSlotLv1.TabIndex = 23;
            this.numBlankSlotLv1.Value = 0;
            // 
            // DlgResultFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(388, 404);
            this.Controls.Add(this.numAddSkill3);
            this.Controls.Add(this.numAddSkill2);
            this.Controls.Add(this.numAddSkill1);
            this.Controls.Add(this.numBlankSlotLv3);
            this.Controls.Add(this.numBlankSlotLv2);
            this.Controls.Add(this.numBlankSlotLv1);
            this.Controls.Add(this.cmbAddSkill3);
            this.Controls.Add(this.cmbAddSkill2);
            this.Controls.Add(this.cmbAddSkill1);
            this.Controls.Add(this.lblAddSkill);
            this.Controls.Add(this.txtbAllCount);
            this.Controls.Add(this.txtbFilterdCount);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblNeedBlankSlotLv3);
            this.Controls.Add(this.lblNeedBlankSlotLv2);
            this.Controls.Add(this.lblPer);
            this.Controls.Add(this.lblAllCount);
            this.Controls.Add(this.lblFilterdCount);
            this.Controls.Add(this.lblNeedBlankSlotLv1);
            this.Controls.Add(this.btnShow);
            this.Controls.Add(this.btnCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "DlgResultFilter";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "結果の絞り込み条件";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnShow;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblNeedBlankSlotLv1;
        private System.Windows.Forms.Label lblNeedBlankSlotLv2;
        private System.Windows.Forms.Label lblNeedBlankSlotLv3;
        private System.Windows.Forms.Label lblFilterdCount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblPer;
        private System.Windows.Forms.Label lblAllCount;
        private System.Windows.Forms.TextBox txtbFilterdCount;
        private System.Windows.Forms.TextBox txtbAllCount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblAddSkill;
        private System.Windows.Forms.ComboBox cmbAddSkill1;
        private Controls.NumericControl numBlankSlotLv1;
        private Controls.NumericControl numBlankSlotLv2;
        private Controls.NumericControl numBlankSlotLv3;
        private Controls.NumericControl numAddSkill1;
        private System.Windows.Forms.ComboBox cmbAddSkill2;
        private Controls.NumericControl numAddSkill2;
        private System.Windows.Forms.ComboBox cmbAddSkill3;
        private Controls.NumericControl numAddSkill3;
    }
}