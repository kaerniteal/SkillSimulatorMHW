namespace SkillSimulatorMHW.Controls
{
    partial class SkillControl
    {
        /// <summary> 
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region コンポーネント デザイナーで生成されたコード

        /// <summary> 
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を 
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.lblSkillName = new System.Windows.Forms.Label();
            this.lblSkillRemarks = new System.Windows.Forms.Label();
            this.cmbSkillLv = new System.Windows.Forms.ComboBox();
            this.btnAppExit = new System.Windows.Forms.Button();
            this.lblSkillLv = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblSkillName
            // 
            this.lblSkillName.AutoSize = true;
            this.lblSkillName.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.lblSkillName.Location = new System.Drawing.Point(1, 9);
            this.lblSkillName.Name = "lblSkillName";
            this.lblSkillName.Size = new System.Drawing.Size(50, 12);
            this.lblSkillName.TabIndex = 0;
            this.lblSkillName.Text = "スキル名";
            // 
            // lblSkillRemarks
            // 
            this.lblSkillRemarks.AutoSize = true;
            this.lblSkillRemarks.Font = new System.Drawing.Font("MS UI Gothic", 8F);
            this.lblSkillRemarks.Location = new System.Drawing.Point(3, 31);
            this.lblSkillRemarks.Name = "lblSkillRemarks";
            this.lblSkillRemarks.Size = new System.Drawing.Size(73, 11);
            this.lblSkillRemarks.TabIndex = 0;
            this.lblSkillRemarks.Text = "スキルの説明欄";
            // 
            // cmbSkillLv
            // 
            this.cmbSkillLv.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSkillLv.Font = new System.Drawing.Font("MS UI Gothic", 10F);
            this.cmbSkillLv.FormattingEnabled = true;
            this.cmbSkillLv.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7"});
            this.cmbSkillLv.Location = new System.Drawing.Point(306, 6);
            this.cmbSkillLv.Name = "cmbSkillLv";
            this.cmbSkillLv.Size = new System.Drawing.Size(33, 21);
            this.cmbSkillLv.TabIndex = 1;
            this.cmbSkillLv.SelectedIndexChanged += new System.EventHandler(this.CallBackCmbSkillLvSelectedIndexChanged);
            // 
            // btnAppExit
            // 
            this.btnAppExit.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.btnAppExit.Location = new System.Drawing.Point(342, 4);
            this.btnAppExit.Name = "btnAppExit";
            this.btnAppExit.Size = new System.Drawing.Size(25, 25);
            this.btnAppExit.TabIndex = 2;
            this.btnAppExit.Text = "×";
            this.btnAppExit.UseVisualStyleBackColor = true;
            this.btnAppExit.Click += new System.EventHandler(this.CallBackBtnAppExitClick);
            // 
            // lblSkillLv
            // 
            this.lblSkillLv.AutoSize = true;
            this.lblSkillLv.Font = new System.Drawing.Font("MS UI Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblSkillLv.Location = new System.Drawing.Point(281, 9);
            this.lblSkillLv.Name = "lblSkillLv";
            this.lblSkillLv.Size = new System.Drawing.Size(24, 14);
            this.lblSkillLv.TabIndex = 3;
            this.lblSkillLv.Text = "Lv";
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Location = new System.Drawing.Point(4, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(365, 2);
            this.label1.TabIndex = 4;
            // 
            // SkillControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblSkillLv);
            this.Controls.Add(this.btnAppExit);
            this.Controls.Add(this.cmbSkillLv);
            this.Controls.Add(this.lblSkillRemarks);
            this.Controls.Add(this.lblSkillName);
            this.Name = "SkillControl";
            this.Size = new System.Drawing.Size(370, 48);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSkillName;
        private System.Windows.Forms.Label lblSkillRemarks;
        private System.Windows.Forms.ComboBox cmbSkillLv;
        private System.Windows.Forms.Button btnAppExit;
        private System.Windows.Forms.Label lblSkillLv;
        private System.Windows.Forms.Label label1;
    }
}
