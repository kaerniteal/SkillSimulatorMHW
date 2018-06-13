namespace SkillSimulatorMHW.Forms
{
    partial class DlgArmorList
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
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.pnlArmorList = new System.Windows.Forms.Panel();
            this.txtbAccessoryFilter = new System.Windows.Forms.TextBox();
            this.lblAccessory = new System.Windows.Forms.Label();
            this.btnAccessoryFilterClear = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Font = new System.Drawing.Font("MS UI Gothic", 11F, System.Drawing.FontStyle.Bold);
            this.btnOK.Location = new System.Drawing.Point(206, 525);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(110, 25);
            this.btnOK.TabIndex = 3;
            this.btnOK.Text = "O K";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("MS UI Gothic", 11F, System.Drawing.FontStyle.Bold);
            this.btnCancel.Location = new System.Drawing.Point(322, 525);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(110, 25);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "キャンセル";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // pnlArmorList
            // 
            this.pnlArmorList.AutoScroll = true;
            this.pnlArmorList.BackColor = System.Drawing.SystemColors.Window;
            this.pnlArmorList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlArmorList.Location = new System.Drawing.Point(14, 73);
            this.pnlArmorList.Name = "pnlArmorList";
            this.pnlArmorList.Size = new System.Drawing.Size(418, 446);
            this.pnlArmorList.TabIndex = 5;
            // 
            // txtbAccessoryFilter
            // 
            this.txtbAccessoryFilter.Font = new System.Drawing.Font("MS UI Gothic", 10F);
            this.txtbAccessoryFilter.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.txtbAccessoryFilter.Location = new System.Drawing.Point(14, 46);
            this.txtbAccessoryFilter.Name = "txtbAccessoryFilter";
            this.txtbAccessoryFilter.Size = new System.Drawing.Size(54, 21);
            this.txtbAccessoryFilter.TabIndex = 6;
            this.txtbAccessoryFilter.TextChanged += new System.EventHandler(this.CallBackTxtbAccessoryFilterTextChanged);
            // 
            // lblAccessory
            // 
            this.lblAccessory.AutoSize = true;
            this.lblAccessory.Location = new System.Drawing.Point(12, 9);
            this.lblAccessory.Name = "lblAccessory";
            this.lblAccessory.Size = new System.Drawing.Size(83, 12);
            this.lblAccessory.TabIndex = 7;
            this.lblAccessory.Text = "防具の一覧です";
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
            this.btnAccessoryFilterClear.TabIndex = 10;
            this.btnAccessoryFilterClear.Text = "×";
            this.btnAccessoryFilterClear.UseVisualStyleBackColor = true;
            this.btnAccessoryFilterClear.Click += new System.EventHandler(this.btnAccessoryFilterClear_Click);
            // 
            // DlgArmorList
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(444, 562);
            this.Controls.Add(this.btnAccessoryFilterClear);
            this.Controls.Add(this.lblAccessory);
            this.Controls.Add(this.txtbAccessoryFilter);
            this.Controls.Add(this.pnlArmorList);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "DlgArmorList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "防具リスト";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Panel pnlArmorList;
        private System.Windows.Forms.TextBox txtbAccessoryFilter;
        private System.Windows.Forms.Label lblAccessory;
        private System.Windows.Forms.Button btnAccessoryFilterClear;
    }
}