namespace SkillSimulatorMHW.Controls
{
    partial class AnalyzeFactorControl
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.lblFactor = new System.Windows.Forms.Label();
            this.btnShow = new System.Windows.Forms.Button();
            this.toolTipFactor = new System.Windows.Forms.ToolTip(this.components);
            this.btnDetails = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Location = new System.Drawing.Point(4, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(527, 2);
            this.label1.TabIndex = 6;
            // 
            // lblFactor
            // 
            this.lblFactor.AutoSize = true;
            this.lblFactor.Font = new System.Drawing.Font("MS UI Gothic", 10F, System.Drawing.FontStyle.Bold);
            this.lblFactor.Location = new System.Drawing.Point(3, 8);
            this.lblFactor.Name = "lblFactor";
            this.lblFactor.Size = new System.Drawing.Size(37, 14);
            this.lblFactor.TabIndex = 10;
            this.lblFactor.Text = "要因";
            // 
            // btnShow
            // 
            this.btnShow.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnShow.Location = new System.Drawing.Point(465, 3);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(64, 25);
            this.btnShow.TabIndex = 12;
            this.btnShow.Text = "表示";
            this.btnShow.UseVisualStyleBackColor = true;
            this.btnShow.Click += new System.EventHandler(this.CallBackBtnShowClick);
            // 
            // toolTipFactor
            // 
            this.toolTipFactor.AutomaticDelay = 0;
            this.toolTipFactor.AutoPopDelay = 60000;
            this.toolTipFactor.InitialDelay = 100;
            this.toolTipFactor.ReshowDelay = 100;
            // 
            // btnDetails
            // 
            this.btnDetails.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnDetails.Location = new System.Drawing.Point(396, 3);
            this.btnDetails.Name = "btnDetails";
            this.btnDetails.Size = new System.Drawing.Size(64, 25);
            this.btnDetails.TabIndex = 12;
            this.btnDetails.Text = "詳細";
            this.btnDetails.UseVisualStyleBackColor = true;
            this.btnDetails.Click += new System.EventHandler(this.btnDetails_Click);
            // 
            // AnalyzeFactorControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnDetails);
            this.Controls.Add(this.btnShow);
            this.Controls.Add(this.lblFactor);
            this.Controls.Add(this.label1);
            this.Name = "AnalyzeFactorControl";
            this.Size = new System.Drawing.Size(532, 36);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblFactor;
        private System.Windows.Forms.Button btnShow;
        private System.Windows.Forms.ToolTip toolTipFactor;
        private System.Windows.Forms.Button btnDetails;
    }
}
