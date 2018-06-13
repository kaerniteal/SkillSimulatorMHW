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
            this.chkResultFilter = new System.Windows.Forms.CheckBox();
            this.pnlResultList = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // txtbResultCount
            // 
            this.txtbResultCount.Location = new System.Drawing.Point(356, 3);
            this.txtbResultCount.Name = "txtbResultCount";
            this.txtbResultCount.ReadOnly = true;
            this.txtbResultCount.Size = new System.Drawing.Size(50, 19);
            this.txtbResultCount.TabIndex = 8;
            this.txtbResultCount.Text = "9999件";
            this.txtbResultCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnResultFilter
            // 
            this.btnResultFilter.Font = new System.Drawing.Font("MS UI Gothic", 10F, System.Drawing.FontStyle.Bold);
            this.btnResultFilter.Location = new System.Drawing.Point(108, 0);
            this.btnResultFilter.Name = "btnResultFilter";
            this.btnResultFilter.Size = new System.Drawing.Size(242, 25);
            this.btnResultFilter.TabIndex = 8;
            this.btnResultFilter.Text = "絞り込み条件の編集";
            this.btnResultFilter.UseVisualStyleBackColor = true;
            this.btnResultFilter.Click += new System.EventHandler(this.CallBackBtnResultFilterClick);
            // 
            // chkResultFilter
            // 
            this.chkResultFilter.AutoSize = true;
            this.chkResultFilter.Checked = true;
            this.chkResultFilter.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkResultFilter.Location = new System.Drawing.Point(3, 6);
            this.chkResultFilter.Name = "chkResultFilter";
            this.chkResultFilter.Size = new System.Drawing.Size(99, 16);
            this.chkResultFilter.TabIndex = 0;
            this.chkResultFilter.Text = "結果を絞り込む";
            this.chkResultFilter.UseVisualStyleBackColor = true;
            this.chkResultFilter.CheckedChanged += new System.EventHandler(this.CallBackChkResultFilterCheckedChanged);
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
            // ResultListControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtbResultCount);
            this.Controls.Add(this.btnResultFilter);
            this.Controls.Add(this.chkResultFilter);
            this.Controls.Add(this.pnlResultList);
            this.Name = "ResultListControl";
            this.Size = new System.Drawing.Size(412, 574);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtbResultCount;
        private System.Windows.Forms.Button btnResultFilter;
        private System.Windows.Forms.CheckBox chkResultFilter;
        private System.Windows.Forms.Panel pnlResultList;
    }
}
