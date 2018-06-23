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
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblNeedBlankSlotLv1 = new System.Windows.Forms.Label();
            this.btnFilterClear = new System.Windows.Forms.Button();
            this.lblNeedBlankSlotLv2 = new System.Windows.Forms.Label();
            this.lblNeedBlankSlotLv3 = new System.Windows.Forms.Label();
            this.lblFilterdCount = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblPer = new System.Windows.Forms.Label();
            this.lblAllCount = new System.Windows.Forms.Label();
            this.txtbFilterdCount = new System.Windows.Forms.TextBox();
            this.txtbAllCount = new System.Windows.Forms.TextBox();
            this.txtbValBlankSlotLv1 = new System.Windows.Forms.TextBox();
            this.btnPlusBlankSlotLv1 = new System.Windows.Forms.Button();
            this.btnMinusBlankSlotLv1 = new System.Windows.Forms.Button();
            this.btnMinusBlankSlotLv2 = new System.Windows.Forms.Button();
            this.btnPlusBlankSlotLv2 = new System.Windows.Forms.Button();
            this.txtbValBlankSlotLv2 = new System.Windows.Forms.TextBox();
            this.btnMinusBlankSlotLv3 = new System.Windows.Forms.Button();
            this.btnPlusBlankSlotLv3 = new System.Windows.Forms.Button();
            this.txtbValBlankSlotLv3 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Font = new System.Drawing.Font("MS UI Gothic", 11F, System.Drawing.FontStyle.Bold);
            this.btnOK.Location = new System.Drawing.Point(150, 367);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(110, 25);
            this.btnOK.TabIndex = 5;
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
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "キャンセル";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // lblNeedBlankSlotLv1
            // 
            this.lblNeedBlankSlotLv1.AutoSize = true;
            this.lblNeedBlankSlotLv1.Location = new System.Drawing.Point(12, 42);
            this.lblNeedBlankSlotLv1.Name = "lblNeedBlankSlotLv1";
            this.lblNeedBlankSlotLv1.Size = new System.Drawing.Size(128, 12);
            this.lblNeedBlankSlotLv1.TabIndex = 7;
            this.lblNeedBlankSlotLv1.Text = "Lv1スロットの空いている数";
            // 
            // btnFilterClear
            // 
            this.btnFilterClear.Font = new System.Drawing.Font("MS UI Gothic", 11F, System.Drawing.FontStyle.Bold);
            this.btnFilterClear.Location = new System.Drawing.Point(14, 367);
            this.btnFilterClear.Name = "btnFilterClear";
            this.btnFilterClear.Size = new System.Drawing.Size(132, 25);
            this.btnFilterClear.TabIndex = 9;
            this.btnFilterClear.Text = "フィルタをクリアする";
            this.btnFilterClear.UseVisualStyleBackColor = true;
            this.btnFilterClear.Click += new System.EventHandler(this.CallBackBtnFilterClearClick);
            // 
            // lblNeedBlankSlotLv2
            // 
            this.lblNeedBlankSlotLv2.AutoSize = true;
            this.lblNeedBlankSlotLv2.Location = new System.Drawing.Point(12, 67);
            this.lblNeedBlankSlotLv2.Name = "lblNeedBlankSlotLv2";
            this.lblNeedBlankSlotLv2.Size = new System.Drawing.Size(128, 12);
            this.lblNeedBlankSlotLv2.TabIndex = 7;
            this.lblNeedBlankSlotLv2.Text = "Lv2スロットの空いている数";
            // 
            // lblNeedBlankSlotLv3
            // 
            this.lblNeedBlankSlotLv3.AutoSize = true;
            this.lblNeedBlankSlotLv3.Location = new System.Drawing.Point(12, 92);
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
            // txtbValBlankSlotLv1
            // 
            this.txtbValBlankSlotLv1.BackColor = System.Drawing.Color.White;
            this.txtbValBlankSlotLv1.Font = new System.Drawing.Font("MS UI Gothic", 10F);
            this.txtbValBlankSlotLv1.Location = new System.Drawing.Point(196, 38);
            this.txtbValBlankSlotLv1.Name = "txtbValBlankSlotLv1";
            this.txtbValBlankSlotLv1.ReadOnly = true;
            this.txtbValBlankSlotLv1.Size = new System.Drawing.Size(30, 21);
            this.txtbValBlankSlotLv1.TabIndex = 17;
            // 
            // btnPlusBlankSlotLv1
            // 
            this.btnPlusBlankSlotLv1.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnPlusBlankSlotLv1.Location = new System.Drawing.Point(166, 36);
            this.btnPlusBlankSlotLv1.Name = "btnPlusBlankSlotLv1";
            this.btnPlusBlankSlotLv1.Size = new System.Drawing.Size(25, 25);
            this.btnPlusBlankSlotLv1.TabIndex = 15;
            this.btnPlusBlankSlotLv1.Text = "＋";
            this.btnPlusBlankSlotLv1.UseVisualStyleBackColor = true;
            this.btnPlusBlankSlotLv1.Click += new System.EventHandler(this.CallBackBtnPlusBlankSlotClick);
            // 
            // btnMinusBlankSlotLv1
            // 
            this.btnMinusBlankSlotLv1.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnMinusBlankSlotLv1.Location = new System.Drawing.Point(231, 36);
            this.btnMinusBlankSlotLv1.Name = "btnMinusBlankSlotLv1";
            this.btnMinusBlankSlotLv1.Size = new System.Drawing.Size(25, 25);
            this.btnMinusBlankSlotLv1.TabIndex = 16;
            this.btnMinusBlankSlotLv1.Text = "－";
            this.btnMinusBlankSlotLv1.UseVisualStyleBackColor = true;
            this.btnMinusBlankSlotLv1.Click += new System.EventHandler(this.CallBackBtnMinusBlankSlotClick);
            // 
            // btnMinusBlankSlotLv2
            // 
            this.btnMinusBlankSlotLv2.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnMinusBlankSlotLv2.Location = new System.Drawing.Point(231, 61);
            this.btnMinusBlankSlotLv2.Name = "btnMinusBlankSlotLv2";
            this.btnMinusBlankSlotLv2.Size = new System.Drawing.Size(25, 25);
            this.btnMinusBlankSlotLv2.TabIndex = 16;
            this.btnMinusBlankSlotLv2.Text = "－";
            this.btnMinusBlankSlotLv2.UseVisualStyleBackColor = true;
            this.btnMinusBlankSlotLv2.Click += new System.EventHandler(this.CallBackBtnMinusBlankSlotClick);
            // 
            // btnPlusBlankSlotLv2
            // 
            this.btnPlusBlankSlotLv2.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnPlusBlankSlotLv2.Location = new System.Drawing.Point(166, 61);
            this.btnPlusBlankSlotLv2.Name = "btnPlusBlankSlotLv2";
            this.btnPlusBlankSlotLv2.Size = new System.Drawing.Size(25, 25);
            this.btnPlusBlankSlotLv2.TabIndex = 15;
            this.btnPlusBlankSlotLv2.Text = "＋";
            this.btnPlusBlankSlotLv2.UseVisualStyleBackColor = true;
            this.btnPlusBlankSlotLv2.Click += new System.EventHandler(this.CallBackBtnPlusBlankSlotClick);
            // 
            // txtbValBlankSlotLv2
            // 
            this.txtbValBlankSlotLv2.BackColor = System.Drawing.Color.White;
            this.txtbValBlankSlotLv2.Font = new System.Drawing.Font("MS UI Gothic", 10F);
            this.txtbValBlankSlotLv2.Location = new System.Drawing.Point(196, 63);
            this.txtbValBlankSlotLv2.Name = "txtbValBlankSlotLv2";
            this.txtbValBlankSlotLv2.ReadOnly = true;
            this.txtbValBlankSlotLv2.Size = new System.Drawing.Size(30, 21);
            this.txtbValBlankSlotLv2.TabIndex = 17;
            // 
            // btnMinusBlankSlotLv3
            // 
            this.btnMinusBlankSlotLv3.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnMinusBlankSlotLv3.Location = new System.Drawing.Point(231, 86);
            this.btnMinusBlankSlotLv3.Name = "btnMinusBlankSlotLv3";
            this.btnMinusBlankSlotLv3.Size = new System.Drawing.Size(25, 25);
            this.btnMinusBlankSlotLv3.TabIndex = 16;
            this.btnMinusBlankSlotLv3.Text = "－";
            this.btnMinusBlankSlotLv3.UseVisualStyleBackColor = true;
            this.btnMinusBlankSlotLv3.Click += new System.EventHandler(this.CallBackBtnMinusBlankSlotClick);
            // 
            // btnPlusBlankSlotLv3
            // 
            this.btnPlusBlankSlotLv3.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnPlusBlankSlotLv3.Location = new System.Drawing.Point(166, 86);
            this.btnPlusBlankSlotLv3.Name = "btnPlusBlankSlotLv3";
            this.btnPlusBlankSlotLv3.Size = new System.Drawing.Size(25, 25);
            this.btnPlusBlankSlotLv3.TabIndex = 15;
            this.btnPlusBlankSlotLv3.Text = "＋";
            this.btnPlusBlankSlotLv3.UseVisualStyleBackColor = true;
            this.btnPlusBlankSlotLv3.Click += new System.EventHandler(this.CallBackBtnPlusBlankSlotClick);
            // 
            // txtbValBlankSlotLv3
            // 
            this.txtbValBlankSlotLv3.BackColor = System.Drawing.Color.White;
            this.txtbValBlankSlotLv3.Font = new System.Drawing.Font("MS UI Gothic", 10F);
            this.txtbValBlankSlotLv3.Location = new System.Drawing.Point(196, 88);
            this.txtbValBlankSlotLv3.Name = "txtbValBlankSlotLv3";
            this.txtbValBlankSlotLv3.ReadOnly = true;
            this.txtbValBlankSlotLv3.Size = new System.Drawing.Size(30, 21);
            this.txtbValBlankSlotLv3.TabIndex = 17;
            // 
            // DlgResultFilter
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(388, 404);
            this.Controls.Add(this.txtbValBlankSlotLv3);
            this.Controls.Add(this.txtbValBlankSlotLv2);
            this.Controls.Add(this.txtbValBlankSlotLv1);
            this.Controls.Add(this.btnPlusBlankSlotLv3);
            this.Controls.Add(this.btnMinusBlankSlotLv3);
            this.Controls.Add(this.btnPlusBlankSlotLv2);
            this.Controls.Add(this.btnMinusBlankSlotLv2);
            this.Controls.Add(this.btnPlusBlankSlotLv1);
            this.Controls.Add(this.btnMinusBlankSlotLv1);
            this.Controls.Add(this.txtbAllCount);
            this.Controls.Add(this.txtbFilterdCount);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblNeedBlankSlotLv3);
            this.Controls.Add(this.btnFilterClear);
            this.Controls.Add(this.lblNeedBlankSlotLv2);
            this.Controls.Add(this.lblPer);
            this.Controls.Add(this.lblAllCount);
            this.Controls.Add(this.lblFilterdCount);
            this.Controls.Add(this.lblNeedBlankSlotLv1);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "DlgResultFilter";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "結果の絞り込み条件";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblNeedBlankSlotLv1;
        private System.Windows.Forms.Button btnFilterClear;
        private System.Windows.Forms.Label lblNeedBlankSlotLv2;
        private System.Windows.Forms.Label lblNeedBlankSlotLv3;
        private System.Windows.Forms.Label lblFilterdCount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblPer;
        private System.Windows.Forms.Label lblAllCount;
        private System.Windows.Forms.TextBox txtbFilterdCount;
        private System.Windows.Forms.TextBox txtbAllCount;
        private System.Windows.Forms.TextBox txtbValBlankSlotLv1;
        private System.Windows.Forms.Button btnPlusBlankSlotLv1;
        private System.Windows.Forms.Button btnMinusBlankSlotLv1;
        private System.Windows.Forms.Button btnMinusBlankSlotLv2;
        private System.Windows.Forms.Button btnPlusBlankSlotLv2;
        private System.Windows.Forms.TextBox txtbValBlankSlotLv2;
        private System.Windows.Forms.Button btnMinusBlankSlotLv3;
        private System.Windows.Forms.Button btnPlusBlankSlotLv3;
        private System.Windows.Forms.TextBox txtbValBlankSlotLv3;
    }
}