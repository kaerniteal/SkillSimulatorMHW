namespace SkillSimulatorMHW.Forms
{
    partial class DlgAnalyzeResult
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.radioAll = new System.Windows.Forms.RadioButton();
            this.radioNearly = new System.Windows.Forms.RadioButton();
            this.lblAnalyzeResult = new System.Windows.Forms.Label();
            this.pnlAnalyzeResultList = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("MS UI Gothic", 11F, System.Drawing.FontStyle.Bold);
            this.btnCancel.Location = new System.Drawing.Point(462, 525);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(110, 25);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "閉じる";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // radioAll
            // 
            this.radioAll.AutoSize = true;
            this.radioAll.Location = new System.Drawing.Point(157, 24);
            this.radioAll.Name = "radioAll";
            this.radioAll.Size = new System.Drawing.Size(68, 16);
            this.radioAll.TabIndex = 7;
            this.radioAll.Text = "全て表示";
            this.radioAll.UseVisualStyleBackColor = true;
            this.radioAll.CheckedChanged += new System.EventHandler(this.CallBackRadioNearlyCheckedChanged);
            // 
            // radioNearly
            // 
            this.radioNearly.AutoSize = true;
            this.radioNearly.Location = new System.Drawing.Point(14, 24);
            this.radioNearly.Name = "radioNearly";
            this.radioNearly.Size = new System.Drawing.Size(122, 16);
            this.radioNearly.TabIndex = 6;
            this.radioNearly.Text = "惜しいセットだけ表示";
            this.radioNearly.UseVisualStyleBackColor = true;
            this.radioNearly.CheckedChanged += new System.EventHandler(this.CallBackRadioNearlyCheckedChanged);
            // 
            // lblAnalyzeResult
            // 
            this.lblAnalyzeResult.AutoSize = true;
            this.lblAnalyzeResult.Location = new System.Drawing.Point(12, 9);
            this.lblAnalyzeResult.Name = "lblAnalyzeResult";
            this.lblAnalyzeResult.Size = new System.Drawing.Size(243, 12);
            this.lblAnalyzeResult.TabIndex = 5;
            this.lblAnalyzeResult.Text = "条件を満たさなかったセットの要因を表示しています";
            // 
            // pnlAnalyzeResultList
            // 
            this.pnlAnalyzeResultList.AutoScroll = true;
            this.pnlAnalyzeResultList.BackColor = System.Drawing.SystemColors.Window;
            this.pnlAnalyzeResultList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlAnalyzeResultList.Location = new System.Drawing.Point(14, 46);
            this.pnlAnalyzeResultList.Name = "pnlAnalyzeResultList";
            this.pnlAnalyzeResultList.Size = new System.Drawing.Size(558, 473);
            this.pnlAnalyzeResultList.TabIndex = 8;
            // 
            // DlgAnalyzeResult
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(584, 562);
            this.Controls.Add(this.pnlAnalyzeResultList);
            this.Controls.Add(this.radioAll);
            this.Controls.Add(this.radioNearly);
            this.Controls.Add(this.lblAnalyzeResult);
            this.Controls.Add(this.btnCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "DlgAnalyzeResult";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "条件を満たさなかったセットの要因解析結果";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.RadioButton radioAll;
        private System.Windows.Forms.RadioButton radioNearly;
        private System.Windows.Forms.Label lblAnalyzeResult;
        private System.Windows.Forms.Panel pnlAnalyzeResultList;
    }
}