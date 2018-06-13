namespace SkillSimulatorMHW.Controls
{
    partial class RequirementControl
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
            this.cmbRequirement = new System.Windows.Forms.ComboBox();
            this.cmbFixedEquip = new System.Windows.Forms.ComboBox();
            this.txtbEquipFilter = new System.Windows.Forms.TextBox();
            this.btnIgnore = new System.Windows.Forms.Button();
            this.btnPossession = new System.Windows.Forms.Button();
            this.chkPart = new System.Windows.Forms.CheckBox();
            this.btnEquipFilterClear = new System.Windows.Forms.Button();
            this.btnSelect = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmbRequirement
            // 
            this.cmbRequirement.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRequirement.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.cmbRequirement.FormattingEnabled = true;
            this.cmbRequirement.Location = new System.Drawing.Point(65, 7);
            this.cmbRequirement.Name = "cmbRequirement";
            this.cmbRequirement.Size = new System.Drawing.Size(212, 20);
            this.cmbRequirement.TabIndex = 3;
            this.cmbRequirement.SelectedIndexChanged += new System.EventHandler(this.CallBackCmbRequirementSelectedIndexChanged);
            // 
            // cmbFixedEquip
            // 
            this.cmbFixedEquip.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFixedEquip.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.cmbFixedEquip.FormattingEnabled = true;
            this.cmbFixedEquip.Location = new System.Drawing.Point(77, 32);
            this.cmbFixedEquip.Name = "cmbFixedEquip";
            this.cmbFixedEquip.Size = new System.Drawing.Size(200, 20);
            this.cmbFixedEquip.TabIndex = 3;
            this.cmbFixedEquip.SelectedIndexChanged += new System.EventHandler(this.CallBackCmbFixedEquipSelectedIndexChanged);
            // 
            // txtbEquipFilter
            // 
            this.txtbEquipFilter.Font = new System.Drawing.Font("MS UI Gothic", 10F);
            this.txtbEquipFilter.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.txtbEquipFilter.Location = new System.Drawing.Point(3, 31);
            this.txtbEquipFilter.Name = "txtbEquipFilter";
            this.txtbEquipFilter.Size = new System.Drawing.Size(54, 21);
            this.txtbEquipFilter.TabIndex = 6;
            this.txtbEquipFilter.TextChanged += new System.EventHandler(this.CallBackTxtbEquipFilterTextChanged);
            // 
            // btnIgnore
            // 
            this.btnIgnore.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnIgnore.Location = new System.Drawing.Point(283, 4);
            this.btnIgnore.Name = "btnIgnore";
            this.btnIgnore.Size = new System.Drawing.Size(106, 25);
            this.btnIgnore.TabIndex = 7;
            this.btnIgnore.Text = "除外リストを編集";
            this.btnIgnore.UseVisualStyleBackColor = true;
            this.btnIgnore.Click += new System.EventHandler(this.CallBackBtnIgnoreClick);
            // 
            // btnPossession
            // 
            this.btnPossession.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnPossession.Location = new System.Drawing.Point(283, 30);
            this.btnPossession.Name = "btnPossession";
            this.btnPossession.Size = new System.Drawing.Size(106, 25);
            this.btnPossession.TabIndex = 7;
            this.btnPossession.Text = "所持リストを編集";
            this.btnPossession.UseVisualStyleBackColor = true;
            this.btnPossession.Click += new System.EventHandler(this.CallBackBtnPossessionClick);
            // 
            // chkPart
            // 
            this.chkPart.AutoSize = true;
            this.chkPart.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.chkPart.Location = new System.Drawing.Point(3, 9);
            this.chkPart.Margin = new System.Windows.Forms.Padding(2);
            this.chkPart.Name = "chkPart";
            this.chkPart.Size = new System.Drawing.Size(60, 16);
            this.chkPart.TabIndex = 8;
            this.chkPart.Text = "装飾品";
            this.chkPart.UseVisualStyleBackColor = true;
            this.chkPart.CheckedChanged += new System.EventHandler(this.CallBackChkPartCheckedChanged);
            // 
            // btnEquipFilterClear
            // 
            this.btnEquipFilterClear.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btnEquipFilterClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEquipFilterClear.Font = new System.Drawing.Font("MS UI Gothic", 5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnEquipFilterClear.Location = new System.Drawing.Point(59, 34);
            this.btnEquipFilterClear.Margin = new System.Windows.Forms.Padding(0);
            this.btnEquipFilterClear.Name = "btnEquipFilterClear";
            this.btnEquipFilterClear.Size = new System.Drawing.Size(15, 15);
            this.btnEquipFilterClear.TabIndex = 9;
            this.btnEquipFilterClear.Text = "×";
            this.btnEquipFilterClear.UseVisualStyleBackColor = true;
            this.btnEquipFilterClear.Click += new System.EventHandler(this.CallBackBtnEquipFilterClearClick);
            // 
            // btnSelect
            // 
            this.btnSelect.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnSelect.Location = new System.Drawing.Point(65, 30);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(212, 25);
            this.btnSelect.TabIndex = 7;
            this.btnSelect.Text = "装備";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Visible = false;
            this.btnSelect.Click += new System.EventHandler(this.CallBackBtnSelectClick);
            // 
            // RequirementControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.Controls.Add(this.btnEquipFilterClear);
            this.Controls.Add(this.chkPart);
            this.Controls.Add(this.btnPossession);
            this.Controls.Add(this.btnIgnore);
            this.Controls.Add(this.txtbEquipFilter);
            this.Controls.Add(this.cmbFixedEquip);
            this.Controls.Add(this.cmbRequirement);
            this.Controls.Add(this.btnSelect);
            this.Name = "RequirementControl";
            this.Size = new System.Drawing.Size(392, 60);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbRequirement;
        private System.Windows.Forms.ComboBox cmbFixedEquip;
        private System.Windows.Forms.TextBox txtbEquipFilter;
        private System.Windows.Forms.Button btnIgnore;
        private System.Windows.Forms.Button btnPossession;
        private System.Windows.Forms.CheckBox chkPart;
        private System.Windows.Forms.Button btnEquipFilterClear;
        private System.Windows.Forms.Button btnSelect;

    }
}
