namespace SkillSimulatorMHW.Controls
{
    partial class ArmorControl
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
            this.txtbSkill = new System.Windows.Forms.RichTextBox();
            this.lblArmorName = new System.Windows.Forms.Label();
            this.lblSlot = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtbSkill
            // 
            this.txtbSkill.BackColor = System.Drawing.Color.White;
            this.txtbSkill.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtbSkill.Font = new System.Drawing.Font("MS UI Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtbSkill.Location = new System.Drawing.Point(254, 3);
            this.txtbSkill.Name = "txtbSkill";
            this.txtbSkill.ReadOnly = true;
            this.txtbSkill.Size = new System.Drawing.Size(135, 54);
            this.txtbSkill.TabIndex = 8;
            this.txtbSkill.Text = "";
            // 
            // lblArmorName
            // 
            this.lblArmorName.AutoSize = true;
            this.lblArmorName.Font = new System.Drawing.Font("MS UI Gothic", 10F, System.Drawing.FontStyle.Bold);
            this.lblArmorName.Location = new System.Drawing.Point(3, 8);
            this.lblArmorName.Name = "lblArmorName";
            this.lblArmorName.Size = new System.Drawing.Size(52, 14);
            this.lblArmorName.TabIndex = 10;
            this.lblArmorName.Text = "防具名";
            // 
            // lblSlot
            // 
            this.lblSlot.AutoSize = true;
            this.lblSlot.Font = new System.Drawing.Font("MS UI Gothic", 10F);
            this.lblSlot.Location = new System.Drawing.Point(190, 8);
            this.lblSlot.Name = "lblSlot";
            this.lblSlot.Size = new System.Drawing.Size(49, 14);
            this.lblSlot.TabIndex = 11;
            this.lblSlot.Text = "①①①";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("MS UI Gothic", 9F);
            this.lblStatus.Location = new System.Drawing.Point(4, 35);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(23, 12);
            this.lblStatus.TabIndex = 11;
            this.lblStatus.Text = "防：";
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Location = new System.Drawing.Point(3, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(387, 2);
            this.label1.TabIndex = 12;
            // 
            // ArmorControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.lblSlot);
            this.Controls.Add(this.lblArmorName);
            this.Controls.Add(this.txtbSkill);
            this.Name = "ArmorControl";
            this.Size = new System.Drawing.Size(392, 64);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox txtbSkill;
        private System.Windows.Forms.Label lblArmorName;
        private System.Windows.Forms.Label lblSlot;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label label1;
    }
}
