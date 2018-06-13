namespace SkillSimulatorMHW.Forms
{
    partial class DlgAccessoryList
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
            this.pnlAccessoryList = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.lblAccessory = new System.Windows.Forms.Label();
            this.radioAll = new System.Windows.Forms.RadioButton();
            this.radioPositive = new System.Windows.Forms.RadioButton();
            this.radioNegative = new System.Windows.Forms.RadioButton();
            this.txtbAccessoryFilter = new System.Windows.Forms.TextBox();
            this.btnAccessoryFilterClear = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // pnlAccessoryList
            // 
            this.pnlAccessoryList.AutoScroll = true;
            this.pnlAccessoryList.BackColor = System.Drawing.SystemColors.Window;
            this.pnlAccessoryList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlAccessoryList.Location = new System.Drawing.Point(14, 73);
            this.pnlAccessoryList.Name = "pnlAccessoryList";
            this.pnlAccessoryList.Size = new System.Drawing.Size(418, 446);
            this.pnlAccessoryList.TabIndex = 1;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("MS UI Gothic", 11F, System.Drawing.FontStyle.Bold);
            this.btnCancel.Location = new System.Drawing.Point(322, 525);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(110, 25);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "キャンセル";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Font = new System.Drawing.Font("MS UI Gothic", 11F, System.Drawing.FontStyle.Bold);
            this.btnOK.Location = new System.Drawing.Point(206, 525);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(110, 25);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "O K";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // lblAccessory
            // 
            this.lblAccessory.AutoSize = true;
            this.lblAccessory.Location = new System.Drawing.Point(12, 9);
            this.lblAccessory.Name = "lblAccessory";
            this.lblAccessory.Size = new System.Drawing.Size(243, 12);
            this.lblAccessory.TabIndex = 3;
            this.lblAccessory.Text = "検索に使用する装飾品の個数を入力してください。";
            // 
            // radioAll
            // 
            this.radioAll.AutoSize = true;
            this.radioAll.Checked = true;
            this.radioAll.Location = new System.Drawing.Point(14, 24);
            this.radioAll.Name = "radioAll";
            this.radioAll.Size = new System.Drawing.Size(68, 16);
            this.radioAll.TabIndex = 4;
            this.radioAll.TabStop = true;
            this.radioAll.Text = "全て表示";
            this.radioAll.UseVisualStyleBackColor = true;
            this.radioAll.CheckedChanged += new System.EventHandler(this.CallBackRadioCheckedChanged);
            // 
            // radioPositive
            // 
            this.radioPositive.AutoSize = true;
            this.radioPositive.Location = new System.Drawing.Point(88, 24);
            this.radioPositive.Name = "radioPositive";
            this.radioPositive.Size = new System.Drawing.Size(128, 16);
            this.radioPositive.TabIndex = 4;
            this.radioPositive.Text = "所持装飾品のみ表示";
            this.radioPositive.UseVisualStyleBackColor = true;
            this.radioPositive.CheckedChanged += new System.EventHandler(this.CallBackRadioCheckedChanged);
            // 
            // radioNegative
            // 
            this.radioNegative.AutoSize = true;
            this.radioNegative.Location = new System.Drawing.Point(222, 24);
            this.radioNegative.Name = "radioNegative";
            this.radioNegative.Size = new System.Drawing.Size(176, 16);
            this.radioNegative.TabIndex = 4;
            this.radioNegative.Text = "所持していない装飾品のみ表示";
            this.radioNegative.UseVisualStyleBackColor = true;
            this.radioNegative.CheckedChanged += new System.EventHandler(this.CallBackRadioCheckedChanged);
            // 
            // txtbAccessoryFilter
            // 
            this.txtbAccessoryFilter.Font = new System.Drawing.Font("MS UI Gothic", 10F);
            this.txtbAccessoryFilter.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.txtbAccessoryFilter.Location = new System.Drawing.Point(14, 46);
            this.txtbAccessoryFilter.Name = "txtbAccessoryFilter";
            this.txtbAccessoryFilter.Size = new System.Drawing.Size(54, 21);
            this.txtbAccessoryFilter.TabIndex = 5;
            this.txtbAccessoryFilter.TextChanged += new System.EventHandler(this.CallBackTxtbAccessoryFilterTextChanged);
            // 
            // btnAccessoryFilterClear
            // 
            this.btnAccessoryFilterClear.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btnAccessoryFilterClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAccessoryFilterClear.Font = new System.Drawing.Font("MS UI Gothic", 5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnAccessoryFilterClear.Location = new System.Drawing.Point(71, 49);
            this.btnAccessoryFilterClear.Margin = new System.Windows.Forms.Padding(0);
            this.btnAccessoryFilterClear.Name = "btnAccessoryFilterClear";
            this.btnAccessoryFilterClear.Size = new System.Drawing.Size(15, 15);
            this.btnAccessoryFilterClear.TabIndex = 9;
            this.btnAccessoryFilterClear.Text = "×";
            this.btnAccessoryFilterClear.UseVisualStyleBackColor = true;
            this.btnAccessoryFilterClear.Click += new System.EventHandler(this.CallBackBtnAccessoryFilterClearClick);
            // 
            // DlgAccessoryList
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(444, 562);
            this.Controls.Add(this.btnAccessoryFilterClear);
            this.Controls.Add(this.txtbAccessoryFilter);
            this.Controls.Add(this.radioNegative);
            this.Controls.Add(this.radioPositive);
            this.Controls.Add(this.radioAll);
            this.Controls.Add(this.lblAccessory);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.pnlAccessoryList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "DlgAccessoryList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "装飾品リスト";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlAccessoryList;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label lblAccessory;
        private System.Windows.Forms.RadioButton radioAll;
        private System.Windows.Forms.RadioButton radioPositive;
        private System.Windows.Forms.RadioButton radioNegative;
        private System.Windows.Forms.TextBox txtbAccessoryFilter;
        private System.Windows.Forms.Button btnAccessoryFilterClear;
    }
}