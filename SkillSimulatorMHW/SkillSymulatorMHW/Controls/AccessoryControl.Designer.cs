namespace SkillSimulatorMHW.Controls
{
    partial class AccessoryControl
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnMinus = new System.Windows.Forms.Button();
            this.btnPlus = new System.Windows.Forms.Button();
            this.txtbPossession = new System.Windows.Forms.TextBox();
            this.lblAccessoryName = new System.Windows.Forms.Label();
            this.lblSkillName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Location = new System.Drawing.Point(4, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(387, 2);
            this.label1.TabIndex = 5;
            // 
            // btnMinus
            // 
            this.btnMinus.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnMinus.Location = new System.Drawing.Point(362, 3);
            this.btnMinus.Name = "btnMinus";
            this.btnMinus.Size = new System.Drawing.Size(25, 25);
            this.btnMinus.TabIndex = 6;
            this.btnMinus.Text = "－";
            this.btnMinus.UseVisualStyleBackColor = true;
            this.btnMinus.Click += new System.EventHandler(this.CallBackBtnMinusClick);
            // 
            // btnPlus
            // 
            this.btnPlus.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnPlus.Location = new System.Drawing.Point(297, 3);
            this.btnPlus.Name = "btnPlus";
            this.btnPlus.Size = new System.Drawing.Size(25, 25);
            this.btnPlus.TabIndex = 6;
            this.btnPlus.Text = "＋";
            this.btnPlus.UseVisualStyleBackColor = true;
            this.btnPlus.Click += new System.EventHandler(this.CallBackBtnPlusClick);
            // 
            // txtbPossession
            // 
            this.txtbPossession.BackColor = System.Drawing.Color.White;
            this.txtbPossession.Font = new System.Drawing.Font("MS UI Gothic", 10F);
            this.txtbPossession.Location = new System.Drawing.Point(327, 5);
            this.txtbPossession.Name = "txtbPossession";
            this.txtbPossession.ReadOnly = true;
            this.txtbPossession.Size = new System.Drawing.Size(30, 21);
            this.txtbPossession.TabIndex = 8;
            // 
            // lblAccessoryName
            // 
            this.lblAccessoryName.AutoSize = true;
            this.lblAccessoryName.Font = new System.Drawing.Font("MS UI Gothic", 10F, System.Drawing.FontStyle.Bold);
            this.lblAccessoryName.Location = new System.Drawing.Point(3, 8);
            this.lblAccessoryName.Name = "lblAccessoryName";
            this.lblAccessoryName.Size = new System.Drawing.Size(67, 14);
            this.lblAccessoryName.TabIndex = 9;
            this.lblAccessoryName.Text = "装飾品名";
            // 
            // lblSkillName
            // 
            this.lblSkillName.AutoSize = true;
            this.lblSkillName.Font = new System.Drawing.Font("MS UI Gothic", 9F);
            this.lblSkillName.Location = new System.Drawing.Point(102, 9);
            this.lblSkillName.Name = "lblSkillName";
            this.lblSkillName.Size = new System.Drawing.Size(46, 12);
            this.lblSkillName.TabIndex = 10;
            this.lblSkillName.Text = "スキル名";
            // 
            // AccessoryControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblSkillName);
            this.Controls.Add(this.lblAccessoryName);
            this.Controls.Add(this.txtbPossession);
            this.Controls.Add(this.btnPlus);
            this.Controls.Add(this.btnMinus);
            this.Controls.Add(this.label1);
            this.Name = "AccessoryControl";
            this.Size = new System.Drawing.Size(392, 36);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnMinus;
        private System.Windows.Forms.Button btnPlus;
        private System.Windows.Forms.TextBox txtbPossession;
        private System.Windows.Forms.Label lblAccessoryName;
        private System.Windows.Forms.Label lblSkillName;
    }
}
