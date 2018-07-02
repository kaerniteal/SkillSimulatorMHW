namespace SkillSimulatorMHW.Controls
{
    partial class ResultListControl
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
            this.txtbResultCount = new System.Windows.Forms.TextBox();
            this.btnResultFilter = new System.Windows.Forms.Button();
            this.pnlResultList = new System.Windows.Forms.Panel();
            this.lblCount = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtbResultCount
            // 
            this.txtbResultCount.Location = new System.Drawing.Point(262, 6);
            this.txtbResultCount.Name = "txtbResultCount";
            this.txtbResultCount.ReadOnly = true;
            this.txtbResultCount.Size = new System.Drawing.Size(74, 19);
            this.txtbResultCount.TabIndex = 8;
            this.txtbResultCount.TabStop = false;
            this.txtbResultCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnResultFilter
            // 
            this.btnResultFilter.Enabled = false;
            this.btnResultFilter.Font = new System.Drawing.Font("MS UI Gothic", 10F, System.Drawing.FontStyle.Bold);
            this.btnResultFilter.Location = new System.Drawing.Point(3, 2);
            this.btnResultFilter.Name = "btnResultFilter";
            this.btnResultFilter.Size = new System.Drawing.Size(253, 25);
            this.btnResultFilter.TabIndex = 8;
            this.btnResultFilter.Text = "結果を絞り込む";
            this.btnResultFilter.UseVisualStyleBackColor = true;
            this.btnResultFilter.Click += new System.EventHandler(this.CallBackBtnResultFilterClick);
            // 
            // pnlResultList
            // 
            this.pnlResultList.AutoScroll = true;
            this.pnlResultList.BackColor = System.Drawing.SystemColors.Window;
            this.pnlResultList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlResultList.Location = new System.Drawing.Point(3, 31);
            this.pnlResultList.Name = "pnlResultList";
            this.pnlResultList.Size = new System.Drawing.Size(406, 540);
            this.pnlResultList.TabIndex = 7;
            // 
            // lblCount
            // 
            this.lblCount.AutoSize = true;
            this.lblCount.Location = new System.Drawing.Point(342, 9);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(67, 12);
            this.lblCount.TabIndex = 9;
            this.lblCount.Text = "(表示/全件)";
            // 
            // ResultListControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblCount);
            this.Controls.Add(this.txtbResultCount);
            this.Controls.Add(this.btnResultFilter);
            this.Controls.Add(this.pnlResultList);
            this.Name = "ResultListControl";
            this.Size = new System.Drawing.Size(412, 574);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtbResultCount;
        private System.Windows.Forms.Button btnResultFilter;
        private System.Windows.Forms.Panel pnlResultList;
        private System.Windows.Forms.Label lblCount;
    }
}
