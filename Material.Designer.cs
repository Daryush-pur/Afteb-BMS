namespace AFTAB
{
    partial class Material
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.text_name = new System.Windows.Forms.TextBox();
            this.text_code = new System.Windows.Forms.TextBox();
            this.combo_unit = new System.Windows.Forms.ComboBox();
            this.btn_submit = new System.Windows.Forms.Button();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.radio_cemical = new System.Windows.Forms.RadioButton();
            this.radio_raw = new System.Windows.Forms.RadioButton();
            this.radio_packeting = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "نام محصول";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(41, 139);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 29);
            this.label2.TabIndex = 1;
            this.label2.Text = "کد محصول";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 29);
            this.label3.TabIndex = 2;
            this.label3.Text = "واحد اندازه گیری";
            // 
            // text_name
            // 
            this.text_name.Location = new System.Drawing.Point(152, 29);
            this.text_name.Name = "text_name";
            this.text_name.Size = new System.Drawing.Size(233, 37);
            this.text_name.TabIndex = 3;
            // 
            // text_code
            // 
            this.text_code.Location = new System.Drawing.Point(152, 136);
            this.text_code.Name = "text_code";
            this.text_code.Size = new System.Drawing.Size(233, 37);
            this.text_code.TabIndex = 4;
            // 
            // combo_unit
            // 
            this.combo_unit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo_unit.FormattingEnabled = true;
            this.combo_unit.Location = new System.Drawing.Point(152, 80);
            this.combo_unit.Name = "combo_unit";
            this.combo_unit.Size = new System.Drawing.Size(233, 37);
            this.combo_unit.TabIndex = 5;
            // 
            // btn_submit
            // 
            this.btn_submit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btn_submit.Location = new System.Drawing.Point(102, 246);
            this.btn_submit.Name = "btn_submit";
            this.btn_submit.Size = new System.Drawing.Size(102, 40);
            this.btn_submit.TabIndex = 6;
            this.btn_submit.Text = "ثبت";
            this.btn_submit.UseVisualStyleBackColor = false;
            this.btn_submit.Click += new System.EventHandler(this.btn_submit_Click);
            // 
            // btn_cancel
            // 
            this.btn_cancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.btn_cancel.Location = new System.Drawing.Point(213, 246);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(112, 40);
            this.btn_cancel.TabIndex = 7;
            this.btn_cancel.Text = "پاک کردن";
            this.btn_cancel.UseVisualStyleBackColor = false;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // radio_cemical
            // 
            this.radio_cemical.AutoSize = true;
            this.radio_cemical.Location = new System.Drawing.Point(274, 188);
            this.radio_cemical.Name = "radio_cemical";
            this.radio_cemical.Size = new System.Drawing.Size(110, 33);
            this.radio_cemical.TabIndex = 8;
            this.radio_cemical.TabStop = true;
            this.radio_cemical.Text = "مواد شیمیایی";
            this.radio_cemical.UseVisualStyleBackColor = true;
            this.radio_cemical.CheckedChanged += new System.EventHandler(this.radio_cemical_CheckedChanged);
            // 
            // radio_raw
            // 
            this.radio_raw.AutoSize = true;
            this.radio_raw.Location = new System.Drawing.Point(182, 188);
            this.radio_raw.Name = "radio_raw";
            this.radio_raw.Size = new System.Drawing.Size(86, 33);
            this.radio_raw.TabIndex = 9;
            this.radio_raw.TabStop = true;
            this.radio_raw.Text = "مواد اولیه";
            this.radio_raw.UseVisualStyleBackColor = true;
            this.radio_raw.CheckedChanged += new System.EventHandler(this.radio_raw_CheckedChanged);
            // 
            // radio_packeting
            // 
            this.radio_packeting.AutoSize = true;
            this.radio_packeting.Location = new System.Drawing.Point(58, 188);
            this.radio_packeting.Name = "radio_packeting";
            this.radio_packeting.Size = new System.Drawing.Size(118, 33);
            this.radio_packeting.TabIndex = 10;
            this.radio_packeting.TabStop = true;
            this.radio_packeting.Text = "مواد بسته بندی";
            this.radio_packeting.UseVisualStyleBackColor = true;
            this.radio_packeting.CheckedChanged += new System.EventHandler(this.radio_packeting_CheckedChanged);
            // 
            // Material
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(418, 351);
            this.Controls.Add(this.radio_packeting);
            this.Controls.Add(this.radio_raw);
            this.Controls.Add(this.radio_cemical);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.btn_submit);
            this.Controls.Add(this.combo_unit);
            this.Controls.Add(this.text_code);
            this.Controls.Add(this.text_name);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("0 Homa", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.MaximumSize = new System.Drawing.Size(434, 390);
            this.Name = "Material";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.ShowIcon = false;
            this.Text = "مواد شیمیایی";
            this.Load += new System.EventHandler(this.CemicalMaterial_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox text_name;
        private System.Windows.Forms.TextBox text_code;
        private System.Windows.Forms.ComboBox combo_unit;
        private System.Windows.Forms.Button btn_submit;
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.RadioButton radio_cemical;
        private System.Windows.Forms.RadioButton radio_raw;
        private System.Windows.Forms.RadioButton radio_packeting;
    }
}