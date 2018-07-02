namespace SkillSimulatorMHW.Forms
{
    partial class DlgSelectCharacter
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
            this.cmbSelectedCharactor = new System.Windows.Forms.ComboBox();
            this.lblSelectedCharactor = new System.Windows.Forms.Label();
            this.grpCharactorEdit = new System.Windows.Forms.GroupBox();
            this.btnDeleteCharactor = new System.Windows.Forms.Button();
            this.chkTakeOver = new System.Windows.Forms.CheckBox();
            this.txtbCharactorName = new System.Windows.Forms.TextBox();
            this.btnAddCharactor = new System.Windows.Forms.Button();
            this.chkCharactorEdit = new System.Windows.Forms.CheckBox();
            this.grpCharactorEdit.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Font = new System.Drawing.Font("MS UI Gothic", 11F, System.Drawing.FontStyle.Bold);
            this.btnOK.Location = new System.Drawing.Point(126, 200);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(110, 25);
            this.btnOK.TabIndex = 5;
            this.btnOK.Text = "O K";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("MS UI Gothic", 11F, System.Drawing.FontStyle.Bold);
            this.btnCancel.Location = new System.Drawing.Point(242, 200);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(110, 25);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "キャンセル";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // cmbSelectedCharactor
            // 
            this.cmbSelectedCharactor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSelectedCharactor.FormattingEnabled = true;
            this.cmbSelectedCharactor.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.cmbSelectedCharactor.Location = new System.Drawing.Point(132, 12);
            this.cmbSelectedCharactor.Name = "cmbSelectedCharactor";
            this.cmbSelectedCharactor.Size = new System.Drawing.Size(206, 20);
            this.cmbSelectedCharactor.TabIndex = 8;
            // 
            // lblSelectedCharactor
            // 
            this.lblSelectedCharactor.AutoSize = true;
            this.lblSelectedCharactor.Location = new System.Drawing.Point(8, 15);
            this.lblSelectedCharactor.Name = "lblSelectedCharactor";
            this.lblSelectedCharactor.Size = new System.Drawing.Size(118, 12);
            this.lblSelectedCharactor.TabIndex = 7;
            this.lblSelectedCharactor.Text = "選択されているキャラクタ";
            // 
            // grpCharactorEdit
            // 
            this.grpCharactorEdit.Controls.Add(this.btnDeleteCharactor);
            this.grpCharactorEdit.Controls.Add(this.chkTakeOver);
            this.grpCharactorEdit.Controls.Add(this.txtbCharactorName);
            this.grpCharactorEdit.Controls.Add(this.btnAddCharactor);
            this.grpCharactorEdit.Enabled = false;
            this.grpCharactorEdit.Location = new System.Drawing.Point(10, 45);
            this.grpCharactorEdit.Name = "grpCharactorEdit";
            this.grpCharactorEdit.Size = new System.Drawing.Size(342, 149);
            this.grpCharactorEdit.TabIndex = 9;
            this.grpCharactorEdit.TabStop = false;
            // 
            // btnDeleteCharactor
            // 
            this.btnDeleteCharactor.Font = new System.Drawing.Font("MS UI Gothic", 11F, System.Drawing.FontStyle.Bold);
            this.btnDeleteCharactor.Location = new System.Drawing.Point(6, 106);
            this.btnDeleteCharactor.Name = "btnDeleteCharactor";
            this.btnDeleteCharactor.Size = new System.Drawing.Size(322, 25);
            this.btnDeleteCharactor.TabIndex = 7;
            this.btnDeleteCharactor.Text = "現在選択されているキャラクタを削除する";
            this.btnDeleteCharactor.UseVisualStyleBackColor = true;
            this.btnDeleteCharactor.Click += new System.EventHandler(this.CallBackBtnDeleteCharactorClick);
            // 
            // chkTakeOver
            // 
            this.chkTakeOver.AutoSize = true;
            this.chkTakeOver.Checked = true;
            this.chkTakeOver.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkTakeOver.Location = new System.Drawing.Point(6, 57);
            this.chkTakeOver.Name = "chkTakeOver";
            this.chkTakeOver.Size = new System.Drawing.Size(276, 16);
            this.chkTakeOver.TabIndex = 6;
            this.chkTakeOver.Text = "選択されているキャラクタの設定を引き継いで作成する";
            this.chkTakeOver.UseVisualStyleBackColor = true;
            // 
            // txtbCharactorName
            // 
            this.txtbCharactorName.Font = new System.Drawing.Font("MS UI Gothic", 10F);
            this.txtbCharactorName.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.txtbCharactorName.Location = new System.Drawing.Point(6, 28);
            this.txtbCharactorName.Name = "txtbCharactorName";
            this.txtbCharactorName.Size = new System.Drawing.Size(206, 21);
            this.txtbCharactorName.TabIndex = 2;
            // 
            // btnAddCharactor
            // 
            this.btnAddCharactor.Font = new System.Drawing.Font("MS UI Gothic", 11F, System.Drawing.FontStyle.Bold);
            this.btnAddCharactor.Location = new System.Drawing.Point(218, 26);
            this.btnAddCharactor.Name = "btnAddCharactor";
            this.btnAddCharactor.Size = new System.Drawing.Size(110, 25);
            this.btnAddCharactor.TabIndex = 5;
            this.btnAddCharactor.Text = "追加";
            this.btnAddCharactor.UseVisualStyleBackColor = true;
            this.btnAddCharactor.Click += new System.EventHandler(this.CallBackBtnAddCharactorClick);
            // 
            // chkCharactorEdit
            // 
            this.chkCharactorEdit.AutoSize = true;
            this.chkCharactorEdit.Location = new System.Drawing.Point(16, 44);
            this.chkCharactorEdit.Name = "chkCharactorEdit";
            this.chkCharactorEdit.Size = new System.Drawing.Size(148, 16);
            this.chkCharactorEdit.TabIndex = 10;
            this.chkCharactorEdit.Text = "キャラクタを追加/削除する";
            this.chkCharactorEdit.UseVisualStyleBackColor = true;
            this.chkCharactorEdit.CheckedChanged += new System.EventHandler(this.CallBackChkCharactorEditCheckedChanged);
            // 
            // DlgSelectCharacter
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(367, 236);
            this.Controls.Add(this.chkCharactorEdit);
            this.Controls.Add(this.grpCharactorEdit);
            this.Controls.Add(this.cmbSelectedCharactor);
            this.Controls.Add(this.lblSelectedCharactor);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "DlgSelectCharacter";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "キャラクタ選択";
            this.grpCharactorEdit.ResumeLayout(false);
            this.grpCharactorEdit.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ComboBox cmbSelectedCharactor;
        private System.Windows.Forms.Label lblSelectedCharactor;
        private System.Windows.Forms.GroupBox grpCharactorEdit;
        private System.Windows.Forms.CheckBox chkCharactorEdit;
        private System.Windows.Forms.TextBox txtbCharactorName;
        private System.Windows.Forms.Button btnAddCharactor;
        private System.Windows.Forms.Button btnDeleteCharactor;
        private System.Windows.Forms.CheckBox chkTakeOver;
    }
}