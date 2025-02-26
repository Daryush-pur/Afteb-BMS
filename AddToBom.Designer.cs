namespace AFTAB
{
    partial class AddToBom
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
            this.text_code = new System.Windows.Forms.TextBox();
            this.text_fraction = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.text_search = new System.Windows.Forms.TextBox();
            this.list_search = new System.Windows.Forms.ListBox();
            this.combo_unit = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(370, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "کد محصول";
            // 
            // text_code
            // 
            this.text_code.Location = new System.Drawing.Point(450, 80);
            this.text_code.Name = "text_code";
            this.text_code.Size = new System.Drawing.Size(256, 37);
            this.text_code.TabIndex = 2;
            // 
            // text_fraction
            // 
            this.text_fraction.Location = new System.Drawing.Point(450, 123);
            this.text_fraction.Name = "text_fraction";
            this.text_fraction.Size = new System.Drawing.Size(256, 37);
            this.text_fraction.TabIndex = 3;
            this.text_fraction.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.text_fraction_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(407, 169);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 29);
            this.label3.TabIndex = 7;
            this.label3.Text = "واحد";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(357, 126);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 29);
            this.label4.TabIndex = 8;
            this.label4.Text = "ضریب مصرف";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(121, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 29);
            this.label2.TabIndex = 6;
            this.label2.Text = "نام محصول";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.button1.Location = new System.Drawing.Point(12, 299);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(144, 42);
            this.button1.TabIndex = 6;
            this.button1.Text = "اضافه کردن";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // text_search
            // 
            this.text_search.Location = new System.Drawing.Point(218, 12);
            this.text_search.Name = "text_search";
            this.text_search.Size = new System.Drawing.Size(344, 37);
            this.text_search.TabIndex = 1;
            // 
            // list_search
            // 
            this.list_search.FormattingEnabled = true;
            this.list_search.ItemHeight = 29;
            this.list_search.Location = new System.Drawing.Point(22, 78);
            this.list_search.Name = "list_search";
            this.list_search.Size = new System.Drawing.Size(288, 207);
            this.list_search.TabIndex = 11;
            // 
            // combo_unit
            // 
            this.combo_unit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo_unit.FormattingEnabled = true;
            this.combo_unit.Location = new System.Drawing.Point(450, 166);
            this.combo_unit.Name = "combo_unit";
            this.combo_unit.Size = new System.Drawing.Size(256, 37);
            this.combo_unit.TabIndex = 12;
            // 
            // AddToBom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(728, 353);
            this.Controls.Add(this.combo_unit);
            this.Controls.Add(this.list_search);
            this.Controls.Add(this.text_search);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.text_fraction);
            this.Controls.Add(this.text_code);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("0 Homa", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.Name = "AddToBom";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.ShowIcon = false;
            this.Text = "اضافه کردن مواد اولیه";
            this.Load += new System.EventHandler(this.AddToBom_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox text_code;
        private System.Windows.Forms.TextBox text_fraction;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox text_search;
        private System.Windows.Forms.ListBox list_search;
        private System.Windows.Forms.ComboBox combo_unit;
    }
}