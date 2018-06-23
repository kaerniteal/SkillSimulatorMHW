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
            this.btnAppExit = new System.Windows.Forms.Button();
            this.lblSkillLv = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtbLv = new System.Windows.Forms.TextBox();
            this.btnPlus = new System.Windows.Forms.Button();
            this.btnMinus = new System.Windows.Forms.Button();
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
            this.lblSkillLv.Location = new System.Drawing.Point(216, 9);
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
            // txtbLv
            // 
            this.txtbLv.BackColor = System.Drawing.Color.White;
            this.txtbLv.Font = new System.Drawing.Font("MS UI Gothic", 10F);
            this.txtbLv.Location = new System.Drawing.Point(276, 6);
            this.txtbLv.Name = "txtbLv";
            this.txtbLv.ReadOnly = true;
            this.txtbLv.Size = new System.Drawing.Size(30, 21);
            this.txtbLv.TabIndex = 11;
            // 
            // btnPlus
            // 
            this.btnPlus.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnPlus.Location = new System.Drawing.Point(246, 4);
            this.btnPlus.Name = "btnPlus";
            this.btnPlus.Size = new System.Drawing.Size(25, 25);
            this.btnPlus.TabIndex = 9;
            this.btnPlus.Text = "＋";
            this.btnPlus.UseVisualStyleBackColor = true;
            this.btnPlus.Click += new System.EventHandler(this.CallBackBtnPlusClick);
            // 
            // btnMinus
            // 
            this.btnMinus.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnMinus.Location = new System.Drawing.Point(311, 4);
            this.btnMinus.Name = "btnMinus";
            this.btnMinus.Size = new System.Drawing.Size(25, 25);
            this.btnMinus.TabIndex = 10;
            this.btnMinus.Text = "－";
            this.btnMinus.UseVisualStyleBackColor = true;
            this.btnMinus.Click += new System.EventHandler(this.CallBackBtnMinusClick);
            // 
            // SkillControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtbLv);
            this.Controls.Add(this.btnPlus);
            this.Controls.Add(this.btnMinus);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblSkillLv);
            this.Controls.Add(this.btnAppExit);
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
        private System.Windows.Forms.Button btnAppExit;
        private System.Windows.Forms.Label lblSkillLv;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtbLv;
        private System.Windows.Forms.Button btnPlus;
        private System.Windows.Forms.Button btnMinus;
    }
}
