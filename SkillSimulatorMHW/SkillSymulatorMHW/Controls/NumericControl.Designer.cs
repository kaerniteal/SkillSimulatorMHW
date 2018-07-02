namespace SkillSimulatorMHW.Controls
{
    partial class NumericControl
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
            this.txtbVal = new System.Windows.Forms.TextBox();
            this.btnPlus = new System.Windows.Forms.Button();
            this.btnMinus = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtbVal
            // 
            this.txtbVal.BackColor = System.Drawing.Color.White;
            this.txtbVal.Font = new System.Drawing.Font("MS UI Gothic", 10F);
            this.txtbVal.Location = new System.Drawing.Point(30, 2);
            this.txtbVal.Name = "txtbVal";
            this.txtbVal.ReadOnly = true;
            this.txtbVal.Size = new System.Drawing.Size(30, 21);
            this.txtbVal.TabIndex = 25;
            this.txtbVal.TabStop = false;
            this.txtbVal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnPlus
            // 
            this.btnPlus.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnPlus.Location = new System.Drawing.Point(0, 0);
            this.btnPlus.Name = "btnPlus";
            this.btnPlus.Size = new System.Drawing.Size(25, 25);
            this.btnPlus.TabIndex = 23;
            this.btnPlus.Text = "＋";
            this.btnPlus.UseVisualStyleBackColor = true;
            this.btnPlus.Click += new System.EventHandler(this.CallBackBtnPlusClick);
            // 
            // btnMinus
            // 
            this.btnMinus.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnMinus.Location = new System.Drawing.Point(65, 0);
            this.btnMinus.Name = "btnMinus";
            this.btnMinus.Size = new System.Drawing.Size(25, 25);
            this.btnMinus.TabIndex = 24;
            this.btnMinus.Text = "－";
            this.btnMinus.UseVisualStyleBackColor = true;
            this.btnMinus.Click += new System.EventHandler(this.CallBackBtnMinusClick);
            // 
            // NumericControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtbVal);
            this.Controls.Add(this.btnPlus);
            this.Controls.Add(this.btnMinus);
            this.Name = "NumericControl";
            this.Size = new System.Drawing.Size(90, 26);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtbVal;
        private System.Windows.Forms.Button btnPlus;
        private System.Windows.Forms.Button btnMinus;
    }
}
