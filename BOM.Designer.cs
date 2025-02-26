namespace AFTAB
{
    partial class BOM
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.text_doc = new System.Windows.Forms.TextBox();
            this.text_review = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.text_time1 = new System.Windows.Forms.TextBox();
            this.text_time3 = new System.Windows.Forms.TextBox();
            this.text_time2 = new System.Windows.Forms.TextBox();
            this.text_machine = new System.Windows.Forms.TextBox();
            this.text_volume = new System.Windows.Forms.TextBox();
            this.text_code = new System.Windows.Forms.TextBox();
            this.text_bom = new System.Windows.Forms.TextBox();
            this.text_name = new System.Windows.Forms.TextBox();
            this.lab_time1 = new System.Windows.Forms.Label();
            this.lab_time3 = new System.Windows.Forms.Label();
            this.lab_time2 = new System.Windows.Forms.Label();
            this.lab_producing = new System.Windows.Forms.Label();
            this.lab_packet = new System.Windows.Forms.Label();
            this.lab_code = new System.Windows.Forms.Label();
            this.lab_bom = new System.Windows.Forms.Label();
            this.lab_name = new System.Windows.Forms.Label();
            this.data_bom = new System.Windows.Forms.DataGridView();
            this.m_code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_need = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_unit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btn_submit = new System.Windows.Forms.Button();
            this.btn_add = new System.Windows.Forms.Button();
            this.btn_cancle = new System.Windows.Forms.Button();
            this.btn_delete = new System.Windows.Forms.Button();
            this.btn_clear = new System.Windows.Forms.Button();
            this.btn_print = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.data_bom)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.text_doc);
            this.panel1.Controls.Add(this.text_review);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.text_time1);
            this.panel1.Controls.Add(this.text_time3);
            this.panel1.Controls.Add(this.text_time2);
            this.panel1.Controls.Add(this.text_machine);
            this.panel1.Controls.Add(this.text_volume);
            this.panel1.Controls.Add(this.text_code);
            this.panel1.Controls.Add(this.text_bom);
            this.panel1.Controls.Add(this.text_name);
            this.panel1.Controls.Add(this.lab_time1);
            this.panel1.Controls.Add(this.lab_time3);
            this.panel1.Controls.Add(this.lab_time2);
            this.panel1.Controls.Add(this.lab_producing);
            this.panel1.Controls.Add(this.lab_packet);
            this.panel1.Controls.Add(this.lab_code);
            this.panel1.Controls.Add(this.lab_bom);
            this.panel1.Controls.Add(this.lab_name);
            this.panel1.Font = new System.Drawing.Font("0 Homa", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.panel1.Location = new System.Drawing.Point(12, 13);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(832, 174);
            this.panel1.TabIndex = 0;
            // 
            // text_doc
            // 
            this.text_doc.Location = new System.Drawing.Point(568, 121);
            this.text_doc.Name = "text_doc";
            this.text_doc.Size = new System.Drawing.Size(139, 35);
            this.text_doc.TabIndex = 13;
            // 
            // text_review
            // 
            this.text_review.Location = new System.Drawing.Point(322, 83);
            this.text_review.Name = "text_review";
            this.text_review.Size = new System.Drawing.Size(131, 35);
            this.text_review.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(459, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 28);
            this.label2.TabIndex = 11;
            this.label2.Text = "شماره بازنگری";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(767, 124);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 28);
            this.label1.TabIndex = 10;
            this.label1.Text = "کد مدرک";
            // 
            // text_time1
            // 
            this.text_time1.Location = new System.Drawing.Point(4, 4);
            this.text_time1.Name = "text_time1";
            this.text_time1.Size = new System.Drawing.Size(154, 35);
            this.text_time1.TabIndex = 7;
            this.text_time1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.text_time1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.text_time1_KeyPress);
            this.text_time1.Leave += new System.EventHandler(this.text_time1_Leave);
            // 
            // text_time3
            // 
            this.text_time3.Location = new System.Drawing.Point(4, 80);
            this.text_time3.Name = "text_time3";
            this.text_time3.Size = new System.Drawing.Size(154, 35);
            this.text_time3.TabIndex = 9;
            this.text_time3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.text_time3.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.text_time3_KeyPress);
            this.text_time3.Leave += new System.EventHandler(this.text_time3_Leave);
            // 
            // text_time2
            // 
            this.text_time2.Location = new System.Drawing.Point(4, 42);
            this.text_time2.Name = "text_time2";
            this.text_time2.Size = new System.Drawing.Size(154, 35);
            this.text_time2.TabIndex = 8;
            this.text_time2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.text_time2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.text_time2_KeyPress);
            this.text_time2.Leave += new System.EventHandler(this.text_time2_Leave);
            // 
            // text_machine
            // 
            this.text_machine.Location = new System.Drawing.Point(322, 42);
            this.text_machine.Name = "text_machine";
            this.text_machine.Size = new System.Drawing.Size(131, 35);
            this.text_machine.TabIndex = 5;
            this.text_machine.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // text_volume
            // 
            this.text_volume.Location = new System.Drawing.Point(322, 4);
            this.text_volume.Name = "text_volume";
            this.text_volume.Size = new System.Drawing.Size(131, 35);
            this.text_volume.TabIndex = 4;
            this.text_volume.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.text_volume.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.text_packet_KeyPress);
            // 
            // text_code
            // 
            this.text_code.Location = new System.Drawing.Point(568, 4);
            this.text_code.Name = "text_code";
            this.text_code.Size = new System.Drawing.Size(139, 35);
            this.text_code.TabIndex = 1;
            this.text_code.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // text_bom
            // 
            this.text_bom.Location = new System.Drawing.Point(568, 80);
            this.text_bom.Name = "text_bom";
            this.text_bom.Size = new System.Drawing.Size(139, 35);
            this.text_bom.TabIndex = 3;
            this.text_bom.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // text_name
            // 
            this.text_name.Location = new System.Drawing.Point(568, 42);
            this.text_name.Name = "text_name";
            this.text_name.Size = new System.Drawing.Size(139, 35);
            this.text_name.TabIndex = 2;
            this.text_name.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lab_time1
            // 
            this.lab_time1.AutoSize = true;
            this.lab_time1.Location = new System.Drawing.Point(164, 7);
            this.lab_time1.Name = "lab_time1";
            this.lab_time1.Size = new System.Drawing.Size(141, 28);
            this.lab_time1.TabIndex = 8;
            this.lab_time1.Text = "ساعت CIP بعد ازتولید";
            // 
            // lab_time3
            // 
            this.lab_time3.AutoSize = true;
            this.lab_time3.Location = new System.Drawing.Point(194, 83);
            this.lab_time3.Name = "lab_time3";
            this.lab_time3.Size = new System.Drawing.Size(111, 28);
            this.lab_time3.TabIndex = 7;
            this.lab_time3.Text = "ساعت آماده سازی";
            // 
            // lab_time2
            // 
            this.lab_time2.AutoSize = true;
            this.lab_time2.Location = new System.Drawing.Point(173, 45);
            this.lab_time2.Name = "lab_time2";
            this.lab_time2.Size = new System.Drawing.Size(132, 28);
            this.lab_time2.TabIndex = 6;
            this.lab_time2.Text = "ساعت بهینه برای تولید";
            // 
            // lab_producing
            // 
            this.lab_producing.AutoSize = true;
            this.lab_producing.Location = new System.Drawing.Point(469, 45);
            this.lab_producing.Name = "lab_producing";
            this.lab_producing.Size = new System.Drawing.Size(0, 28);
            this.lab_producing.TabIndex = 5;
            // 
            // lab_packet
            // 
            this.lab_packet.AutoSize = true;
            this.lab_packet.Location = new System.Drawing.Point(466, 7);
            this.lab_packet.Name = "lab_packet";
            this.lab_packet.Size = new System.Drawing.Size(80, 28);
            this.lab_packet.TabIndex = 4;
            this.lab_packet.Text = "حجم محصول";
            // 
            // lab_code
            // 
            this.lab_code.AutoSize = true;
            this.lab_code.Location = new System.Drawing.Point(754, 7);
            this.lab_code.Name = "lab_code";
            this.lab_code.Size = new System.Drawing.Size(70, 28);
            this.lab_code.TabIndex = 2;
            this.lab_code.Text = "کد محصول";
            // 
            // lab_bom
            // 
            this.lab_bom.AutoSize = true;
            this.lab_bom.Location = new System.Drawing.Point(706, 83);
            this.lab_bom.Name = "lab_bom";
            this.lab_bom.Size = new System.Drawing.Size(122, 28);
            this.lab_bom.TabIndex = 1;
            this.lab_bom.Text = "شماره فرمول ساخت";
            // 
            // lab_name
            // 
            this.lab_name.AutoSize = true;
            this.lab_name.Location = new System.Drawing.Point(754, 45);
            this.lab_name.Name = "lab_name";
            this.lab_name.Size = new System.Drawing.Size(74, 28);
            this.lab_name.TabIndex = 0;
            this.lab_name.Text = "نام محصول";
            // 
            // data_bom
            // 
            this.data_bom.AllowUserToAddRows = false;
            this.data_bom.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.data_bom.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.data_bom.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.data_bom.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.m_code,
            this.m_name,
            this.m_need,
            this.m_unit});
            this.data_bom.Location = new System.Drawing.Point(12, 193);
            this.data_bom.Name = "data_bom";
            this.data_bom.ReadOnly = true;
            this.data_bom.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("0 Homa", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.data_bom.Size = new System.Drawing.Size(833, 270);
            this.data_bom.TabIndex = 99;
            this.data_bom.TabStop = false;
            // 
            // m_code
            // 
            this.m_code.HeaderText = "کد محصول";
            this.m_code.Name = "m_code";
            this.m_code.ReadOnly = true;
            // 
            // m_name
            // 
            this.m_name.HeaderText = "نام محصول";
            this.m_name.Name = "m_name";
            this.m_name.ReadOnly = true;
            // 
            // m_need
            // 
            this.m_need.HeaderText = "ضریب مصرف";
            this.m_need.Name = "m_need";
            this.m_need.ReadOnly = true;
            // 
            // m_unit
            // 
            this.m_unit.HeaderText = "واحد";
            this.m_unit.Name = "m_unit";
            this.m_unit.ReadOnly = true;
            // 
            // btn_submit
            // 
            this.btn_submit.BackColor = System.Drawing.Color.DarkOrange;
            this.btn_submit.Location = new System.Drawing.Point(12, 486);
            this.btn_submit.Name = "btn_submit";
            this.btn_submit.Size = new System.Drawing.Size(75, 33);
            this.btn_submit.TabIndex = 9;
            this.btn_submit.Text = "ثبت";
            this.btn_submit.UseVisualStyleBackColor = false;
            this.btn_submit.Click += new System.EventHandler(this.btn_submit_Click);
            // 
            // btn_add
            // 
            this.btn_add.BackColor = System.Drawing.Color.DarkOrange;
            this.btn_add.Location = new System.Drawing.Point(93, 486);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(75, 33);
            this.btn_add.TabIndex = 10;
            this.btn_add.Text = "اضافه کردن";
            this.btn_add.UseVisualStyleBackColor = false;
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // btn_cancle
            // 
            this.btn_cancle.BackColor = System.Drawing.Color.DarkOrange;
            this.btn_cancle.Location = new System.Drawing.Point(769, 486);
            this.btn_cancle.Name = "btn_cancle";
            this.btn_cancle.Size = new System.Drawing.Size(75, 33);
            this.btn_cancle.TabIndex = 15;
            this.btn_cancle.Text = "انصراف";
            this.btn_cancle.UseVisualStyleBackColor = false;
            this.btn_cancle.Click += new System.EventHandler(this.btn_cancle_Click);
            // 
            // btn_delete
            // 
            this.btn_delete.BackColor = System.Drawing.Color.DarkOrange;
            this.btn_delete.Location = new System.Drawing.Point(174, 486);
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Size = new System.Drawing.Size(80, 32);
            this.btn_delete.TabIndex = 11;
            this.btn_delete.Text = "پاک کردن";
            this.btn_delete.UseVisualStyleBackColor = false;
            this.btn_delete.Click += new System.EventHandler(this.btn_delete_Click);
            // 
            // btn_clear
            // 
            this.btn_clear.BackColor = System.Drawing.Color.DarkOrange;
            this.btn_clear.Location = new System.Drawing.Point(263, 486);
            this.btn_clear.Name = "btn_clear";
            this.btn_clear.Size = new System.Drawing.Size(75, 33);
            this.btn_clear.TabIndex = 12;
            this.btn_clear.Text = "حذف سطر";
            this.btn_clear.UseVisualStyleBackColor = false;
            this.btn_clear.Click += new System.EventHandler(this.btn_clear_Click);
            // 
            // btn_print
            // 
            this.btn_print.BackColor = System.Drawing.Color.DarkOrange;
            this.btn_print.Location = new System.Drawing.Point(344, 486);
            this.btn_print.Name = "btn_print";
            this.btn_print.Size = new System.Drawing.Size(75, 32);
            this.btn_print.TabIndex = 13;
            this.btn_print.Text = "چاپ";
            this.btn_print.UseVisualStyleBackColor = false;
            this.btn_print.Click += new System.EventHandler(this.btn_print_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(476, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 28);
            this.label3.TabIndex = 14;
            this.label3.Text = "نام دستگاه";
            // 
            // BOM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(855, 531);
            this.Controls.Add(this.btn_print);
            this.Controls.Add(this.btn_clear);
            this.Controls.Add(this.btn_delete);
            this.Controls.Add(this.btn_cancle);
            this.Controls.Add(this.btn_add);
            this.Controls.Add(this.btn_submit);
            this.Controls.Add(this.data_bom);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("0 Homa", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.MinimizeBox = false;
            this.Name = "BOM";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.Text = "فرمول ساخت";
            this.Load += new System.EventHandler(this.BOM_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.data_bom)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lab_name;
        private System.Windows.Forms.Label lab_time3;
        private System.Windows.Forms.Label lab_time2;
        private System.Windows.Forms.Label lab_producing;
        private System.Windows.Forms.Label lab_packet;
        private System.Windows.Forms.Label lab_code;
        private System.Windows.Forms.Label lab_bom;
        private System.Windows.Forms.Label lab_time1;
        private System.Windows.Forms.TextBox text_code;
        private System.Windows.Forms.TextBox text_bom;
        private System.Windows.Forms.TextBox text_name;
        private System.Windows.Forms.TextBox text_time1;
        private System.Windows.Forms.TextBox text_time3;
        private System.Windows.Forms.TextBox text_time2;
        private System.Windows.Forms.TextBox text_machine;
        private System.Windows.Forms.TextBox text_volume;
        private System.Windows.Forms.DataGridView data_bom;
        private System.Windows.Forms.Button btn_submit;
        private System.Windows.Forms.Button btn_add;
        private System.Windows.Forms.Button btn_cancle;
        private System.Windows.Forms.Button btn_delete;
        private System.Windows.Forms.Button btn_clear;
        private System.Windows.Forms.Button btn_print;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_code;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_need;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_unit;
        private System.Windows.Forms.TextBox text_doc;
        private System.Windows.Forms.TextBox text_review;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
    }
}