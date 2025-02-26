using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Configuration;
using Microsoft.Reporting.WinForms;



namespace AFTAB
{
    public partial class BOM : Form
    {
        string connection = ConfigurationManager.ConnectionStrings["MyDatabaseConnection"].ConnectionString;
        public BOM()
        {
            InitializeComponent();
        }
        private void btn_add_Click(object sender, EventArgs e)
        {
            foreach (Form child in this.MdiParent.MdiChildren)
            {
                if (child is AddToBom)
                {
                    child.Activate();  // Bring the existing form to the front
                    return;             // Exit the method, preventing a new instance
                }
            }

            // If not open, create and show the new instance
            AddToBom addToBomForm = new AddToBom(this)
            {
                MdiParent = this.MdiParent  // Set the MDI parent
            };
            addToBomForm.Show();
        }
        public void AddMaterialToGrid(string materialName, string materialCode, string materialUnit, decimal fraction)
        {
            // Add data to the DataGridView (assuming columns are in order)
            data_bom.Rows.Add(materialCode, materialName, fraction, materialUnit);
        }
        private void btn_delete_Click(object sender, EventArgs e)
        {
            text_bom.Clear();
            text_code.Clear();
            text_name.Clear();
            text_volume.Clear();
            text_machine.Clear();
            text_time1.Clear();
            text_time2.Clear();
            text_time3.Clear();
            data_bom.Rows.Clear();
            text_review.Clear();
            text_doc.Clear();
        }
        private void btn_cancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void text_packet_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar))
            {
                return;  
            }

            if (!char.IsDigit(e.KeyChar))
            {
                e.Handled = true;  
            }
        }
        private void text_time1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar))
            {
                return;  
            }

            if (char.IsDigit(e.KeyChar))
            {
                return;  
            }

            if (e.KeyChar == ':')
            {
                if (text_time1.Text.Contains(":"))
                {
                    e.Handled = true;  
                }
                else
                {
                    return;  
                }
            }

            e.Handled = true;
        }
        private void text_time1_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(text_time1.Text))
            {

            }
            else 
            {
                if (!IsValidTimeFormat(text_time1.Text))
                {
                    MessageBox.Show("لطفا زمان را به صورت ساعت:دقیقه وارد کنید", "Invalid Time", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    text_time1.Focus();
                }
            }


        }
        private bool IsValidTimeFormat(string input)
        {
            TimeSpan parsedTime;
            return TimeSpan.TryParse(input, out parsedTime);
        }
        private void btn_submit_Click(object sender, EventArgs e)
        {
            TextBox[] textBoxes = { text_bom, text_code, text_name, text_volume, text_machine, text_time1, text_time2, text_time3, text_doc, text_review};
            bool isValid = true;

            // Validate if all textboxes have values
            foreach (TextBox tb in textBoxes)
            {
                if (string.IsNullOrEmpty(tb.Text))
                {
                    MessageBox.Show("لطفا تمام اطلاعات را وارد کنید");
                    isValid = false;
                    tb.Focus();
                    return;
                }
            }

            // Validate DataGridView rows
            if (data_bom.Rows.Count == 0 || (data_bom.Rows.Count == 1 && data_bom.Rows[0].IsNewRow))
            {
                MessageBox.Show("لطفا مواد اولیه و بسته بندی را انتخاب کنید");
                isValid = false;
            }

            string query = @"IF EXISTS (SELECT 1 FROM Bom WHERE ProductCode = @productcode)
                 SELECT 1
                 ELSE
                 SELECT 0";
            int result = 0;

            using (SqlConnection conn = new SqlConnection(connection))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand command = new SqlCommand(query, conn))
                    {
                        command.Parameters.AddWithValue("@productcode", text_code.Text);

                        object resultObj = command.ExecuteScalar();
                        result = resultObj != null ? Convert.ToInt32(resultObj) : 0;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                }
            }

            if (result == 1)
            {
                isValid = false;
            }

            if (isValid)
            {
                string insertbom = "INSERT INTO Bom (ProductName, BomNumber, ProductCode, Volume, Machine, CipTime, OptimalTime, PreprationTime, SubmitDate, DocCode, ReviewNumber) VALUES " +
                    "(@Name, @bom, @code, @volume, @machine, @cip, @optimal, @prepration, @date, @doc, @review)";
                string insertraw = @"INSERT INTO MaterialToBom (ProductCode, MaterialCode, Factor, Unit) VALUES" +
                    "(@p_code, @m_code, @factor, (SELECT ID FROM Units WHERE UnitName = @unit))";

                using (SqlConnection conn = new SqlConnection(connection))
                {
                    conn.Open();
                    SqlTransaction transaction = conn.BeginTransaction();

                    try
                    {
                        // Insert into Bom table
                        using (SqlCommand bom = new SqlCommand(insertbom, conn, transaction))
                        {
                            int volume = int.Parse(text_volume.Text);


                            TimeSpan cip = ParseTimeSpan(text_time1.Text);
                            TimeSpan optimal = ParseTimeSpan(text_time2.Text);
                            TimeSpan prepration = ParseTimeSpan(text_time3.Text);

                            bom.Parameters.AddWithValue("@Name", text_name.Text);
                            bom.Parameters.AddWithValue("@bom", text_bom.Text);
                            bom.Parameters.AddWithValue("@code", text_code.Text);
                            bom.Parameters.AddWithValue("@volume", volume);
                            bom.Parameters.AddWithValue("@machine", text_machine.Text);
                            bom.Parameters.AddWithValue("@cip", cip);
                            bom.Parameters.AddWithValue("@optimal", optimal);
                            bom.Parameters.AddWithValue("@prepration", prepration);
                            bom.Parameters.Add("@date", SqlDbType.Date).Value = DateTime.Now.Date;
                            bom.Parameters.AddWithValue("@doc", text_doc.Text);
                            bom.Parameters.AddWithValue("@review", text_review.Text);

                            bom.ExecuteNonQuery();
                        }

                        // Insert into MaterialToBom table
                        foreach (DataGridViewRow row in data_bom.Rows)
                        {
                            if (!row.IsNewRow)
                            {
                                using (SqlCommand raw = new SqlCommand(insertraw, conn, transaction))
                                {
                                    decimal factor = 0;
                                    if (!decimal.TryParse(row.Cells["m_need"].Value?.ToString(), out factor))
                                    {
                                        MessageBox.Show("مقدار 'فاکتور' معتبر نیست");
                                        return;
                                    }


                                    raw.Parameters.AddWithValue("@p_code", text_code.Text);
                                    raw.Parameters.AddWithValue("@m_code", row.Cells["m_code"].Value?.ToString() ?? string.Empty);
                                    raw.Parameters.AddWithValue("@factor", factor);
                                    raw.Parameters.AddWithValue("@unit", row.Cells["m_unit"].Value?.ToString() ?? string.Empty);
                                    raw.ExecuteNonQuery();
                                }
                            }
                        }

                        transaction.Commit();
                        MessageBox.Show("محصول با موفقیت ثبت شد");
                        btn_print.Enabled = true;
                    }
                    catch (Exception ex)
                    {
                        // Rollback transaction in case of an error
                        transaction.Rollback();
                        MessageBox.Show($"مشکلی پیش آمده است: {ex.Message}");
                    }
                }
            }
            else 
            {
                MessageBox.Show("مشکلی پیش آمده است");
            }
        }
        private void BOM_Load(object sender, EventArgs e)
        {
            btn_print.Enabled = false;
        }
        private TimeSpan ParseTimeSpan(string timeString)
        {
            if (timeString.Contains(":"))
            {
                // If the time is in hh:mm format
                var timeParts = timeString.Split(':');
                if (timeParts.Length == 2)
                {
                    int hours = int.Parse(timeParts[0]);
                    int minutes = int.Parse(timeParts[1]);
                    return new TimeSpan(hours, minutes, 0);  // Return as TimeSpan
                }
            }

            return TimeSpan.Zero; // Default to 00:00:00 if the format is invalid
        }
        private void btn_clear_Click(object sender, EventArgs e)
        {
            if (data_bom.CurrentRow != null && !data_bom.CurrentRow.IsNewRow)
            {
                // Optional: Confirm deletion with the user
                DialogResult result = MessageBox.Show(
                    "آیا میخوتهید این سطر را پاک کنید؟",
                    "Confirm Deletion",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    // Remove the selected row from the DataGridView
                    data_bom.Rows.Remove(data_bom.CurrentRow);
                }
            }
            else
            {
                MessageBox.Show("لطفا سطر مورد نظر را انتخاب کنید", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void text_time2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar))
            {
                return;
            }

            if (char.IsDigit(e.KeyChar))
            {
                return;
            }

            if (e.KeyChar == ':')
            {
                if (text_time2.Text.Contains(":"))
                {
                    e.Handled = true;
                }
                else
                {
                    return;
                }
            }

            e.Handled = true;
        }
        private void text_time3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar))
            {
                return;
            }

            if (char.IsDigit(e.KeyChar))
            {
                return;
            }

            if (e.KeyChar == ':')
            {
                if (text_time3.Text.Contains(":"))
                {
                    e.Handled = true;
                }
                else
                {
                    return;
                }
            }

            e.Handled = true;
        }
        private void text_time2_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(text_time2.Text))
            {

            }
            else
            {
                if (!IsValidTimeFormat(text_time2.Text))
                {
                    MessageBox.Show("لطفا زمان را به صورت ساعت:دقیقه وارد کنید", "Invalid Time", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    text_time1.Focus();
                }
            }
        }
        private void text_time3_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(text_time3.Text))
            {

            }
            else
            {
                if (!IsValidTimeFormat(text_time3.Text))
                {
                    MessageBox.Show("لطفا زمان را به صورت ساعت:دقیقه وارد کنید", "Invalid Time", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    text_time1.Focus();
                }
            }
        }
        ///Report codes
        private void btn_print_Click(object sender, EventArgs e)
        {
            Form reportForm = new Form();
            ReportViewer reportViewer = new ReportViewer();

            reportViewer.Dock = DockStyle.Fill;
            reportForm.Controls.Add(reportViewer);
            reportForm.WindowState = FormWindowState.Maximized;

            // Fetch the data for BOM and MaterialToBom based on the ProductCode
            string productCode = text_code.Text;

            DataTable bomTable = GetBomData(productCode);  // Function to retrieve BOM data
            DataTable materialTable = GetMaterialData(productCode);  // Function to retrieve MaterialToBom data
            DataTable unitTable = GetUnitData();  // New function to retrieve Unit data

            // Add data sources to the report
            reportViewer.LocalReport.DataSources.Clear();
            reportViewer.LocalReport.DataSources.Add(new ReportDataSource("bom", bomTable));
            reportViewer.LocalReport.DataSources.Add(new ReportDataSource("MaterialToBom", materialTable));
            reportViewer.LocalReport.DataSources.Add(new ReportDataSource("unit", unitTable));  // Add UNIT data source

            // Load the RDLC report
            reportViewer.LocalReport.ReportPath = "D:\\Aftab\\AFTAB\\Report1.rdlc";  // Update with your report's actual path

            // Set report parameter
            ReportParameter productCodeParam = new ReportParameter("ProductCode", productCode);
            reportViewer.LocalReport.SetParameters(productCodeParam);

            // Refresh the report
            reportViewer.RefreshReport();

            // Show the report in a new form
            reportForm.ShowDialog();
        }
        private DataTable GetBomData(string productCode)
        {
            DataTable dt = new DataTable();
            string query = "SELECT * FROM BOM WHERE ProductCode = @ProductCode";
            using (SqlConnection conn = new SqlConnection(connection)) // Ensure connection string is set
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ProductCode", productCode);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dt);
                }
            }
            return dt;
        }
        private DataTable GetMaterialData(string productCode)
        {
            DataTable dt = new DataTable();
            string query = "SELECT * FROM MaterialToBom WHERE ProductCode = @ProductCode";
            using (SqlConnection conn = new SqlConnection(connection)) // Ensure connection string is set
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ProductCode", productCode);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dt);
                }
            }
            return dt;
        }
        private DataTable GetUnitData()
        {
            DataTable dt = new DataTable();
            string query = "SELECT ID, UnitName FROM Units"; // Adjust query as needed
            using (SqlConnection conn = new SqlConnection(connection)) // Ensure connection string is set
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dt);
                }
            }
            return dt;
        }


    }
}
