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
            this.spinNeedBlankSlotLv1 = new System.Windows.Forms.NumericUpDown();
            this.lblNeedBlankSlotLv1 = new System.Windows.Forms.Label();
            this.btnFilterClear = new System.Windows.Forms.Button();
            this.lblNeedBlankSlotLv2 = new System.Windows.Forms.Label();
            this.spinNeedBlankSlotLv2 = new System.Windows.Forms.NumericUpDown();
            this.spinNeedBlankSlotLv3 = new System.Windows.Forms.NumericUpDown();
            this.lblNeedBlankSlotLv3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.spinNeedBlankSlotLv1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinNeedBlankSlotLv2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinNeedBlankSlotLv3)).BeginInit();
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
            // spinNeedBlankSlotLv1
            // 
            this.spinNeedBlankSlotLv1.Location = new System.Drawing.Point(165, 19);
            this.spinNeedBlankSlotLv1.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.spinNeedBlankSlotLv1.Name = "spinNeedBlankSlotLv1";
            this.spinNeedBlankSlotLv1.Size = new System.Drawing.Size(80, 19);
            this.spinNeedBlankSlotLv1.TabIndex = 8;
            // 
            // lblNeedBlankSlotLv1
            // 
            this.lblNeedBlankSlotLv1.AutoSize = true;
            this.lblNeedBlankSlotLv1.Location = new System.Drawing.Point(12, 21);
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
            this.lblNeedBlankSlotLv2.Location = new System.Drawing.Point(12, 46);
            this.lblNeedBlankSlotLv2.Name = "lblNeedBlankSlotLv2";
            this.lblNeedBlankSlotLv2.Size = new System.Drawing.Size(128, 12);
            this.lblNeedBlankSlotLv2.TabIndex = 7;
            this.lblNeedBlankSlotLv2.Text = "Lv2スロットの空いている数";
            // 
            // spinNeedBlankSlotLv2
            // 
            this.spinNeedBlankSlotLv2.Location = new System.Drawing.Point(165, 44);
            this.spinNeedBlankSlotLv2.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.spinNeedBlankSlotLv2.Name = "spinNeedBlankSlotLv2";
            this.spinNeedBlankSlotLv2.Size = new System.Drawing.Size(80, 19);
            this.spinNeedBlankSlotLv2.TabIndex = 8;
            // 
            // spinNeedBlankSlotLv3
            // 
            this.spinNeedBlankSlotLv3.Location = new System.Drawing.Point(165, 69);
            this.spinNeedBlankSlotLv3.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.spinNeedBlankSlotLv3.Name = "spinNeedBlankSlotLv3";
            this.spinNeedBlankSlotLv3.Size = new System.Drawing.Size(80, 19);
            this.spinNeedBlankSlotLv3.TabIndex = 11;
            // 
            // lblNeedBlankSlotLv3
            // 
            this.lblNeedBlankSlotLv3.AutoSize = true;
            this.lblNeedBlankSlotLv3.Location = new System.Drawing.Point(12, 71);
            this.lblNeedBlankSlotLv3.Name = "lblNeedBlankSlotLv3";
            this.lblNeedBlankSlotLv3.Size = new System.Drawing.Size(128, 12);
            this.lblNeedBlankSlotLv3.TabIndex = 10;
            this.lblNeedBlankSlotLv3.Text = "Lv3スロットの空いている数";
            // 
            // DlgResultFilter
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(388, 404);
            this.Controls.Add(this.spinNeedBlankSlotLv3);
            this.Controls.Add(this.lblNeedBlankSlotLv3);
            this.Controls.Add(this.btnFilterClear);
            this.Controls.Add(this.spinNeedBlankSlotLv2);
            this.Controls.Add(this.spinNeedBlankSlotLv1);
            this.Controls.Add(this.lblNeedBlankSlotLv2);
            this.Controls.Add(this.lblNeedBlankSlotLv1);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "DlgResultFilter";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "結果の絞り込み条件";
            ((System.ComponentModel.ISupportInitialize)(this.spinNeedBlankSlotLv1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinNeedBlankSlotLv2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinNeedBlankSlotLv3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.NumericUpDown spinNeedBlankSlotLv1;
        private System.Windows.Forms.Label lblNeedBlankSlotLv1;
        private System.Windows.Forms.Button btnFilterClear;
        private System.Windows.Forms.Label lblNeedBlankSlotLv2;
        private System.Windows.Forms.NumericUpDown spinNeedBlankSlotLv2;
        private System.Windows.Forms.NumericUpDown spinNeedBlankSlotLv3;
        private System.Windows.Forms.Label lblNeedBlankSlotLv3;
    }
}