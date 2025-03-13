using Microsoft.Reporting.WinForms;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace AFTAB
{
    public partial class BomShow : Form
    {
        string connection = ConfigurationManager.ConnectionStrings["MyDatabaseConnection"].ConnectionString;
        private string _productCode;

        public BomShow(string productCode)
        {
            InitializeComponent();
            _productCode = productCode;
            this.Load += new EventHandler(BomShow_Load);
        }

        private void BomShow_Load(object sender, EventArgs e)
        {
            MessageBox.Show(_productCode); // Optional, just to display the product code
            FetchData();
        }

        private void FetchData()
        {
            string query = @"
        SELECT 
            b.ProductName,
            b.ProductCode,
            b.BomNumber,
            b.CipTime,
            b.OptimalTime,
            b.PreprationTime,
            b.Machine,
            b.Volume,
            b.DocCode,
            b.ReviewNumber,
            mtb.Factor,
            m.MaterialCode,
            m.MaterialName,
            u.UnitName
        FROM Bom b
        INNER JOIN MaterialToBom mtb ON b.ProductCode = mtb.ProductCode
        INNER JOIN Material m ON mtb.MaterialCode = m.MaterialCode
        INNER JOIN Units u ON mtb.Unit = u.ID
        WHERE b.ProductCode = @ProductCode";

            using (SqlConnection conn = new SqlConnection(connection))
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter(query, conn);
                dataAdapter.SelectCommand.Parameters.AddWithValue("@ProductCode", _productCode);

                DataTable dataTable = new DataTable();
                try
                {
                    dataAdapter.Fill(dataTable);

                    // If data is fetched, populate the controls
                    if (dataTable.Rows.Count > 0)
                    {
                        // Populate textboxes with single-row data (Bom details)
                        DataRow row = dataTable.Rows[0];
                        txtProductName.Text = row["ProductName"].ToString();
                        txtProductCode.Text = row["ProductCode"].ToString();
                        txtBomNumber.Text = row["BomNumber"].ToString();
                        txtCipTime.Text = row["CipTime"].ToString();
                        txtOptimalTime.Text = row["OptimalTime"].ToString();
                        txtPreprationTime.Text = row["PreprationTime"].ToString();
                        txtMachine.Text = row["Machine"].ToString();
                        txtVolume.Text = row["Volume"].ToString();
                        txtDoccode.Text = row["DocCode"].ToString();
                        txtEdit.Text = row["ReviewNumber"].ToString();


                        // Create a new DataTable for the related material data (only relevant columns)
                        DataTable materialTable = new DataTable();

                        materialTable.Columns.Add("MaterialName", typeof(string));
                        materialTable.Columns.Add("MaterialCode", typeof(string));
                        materialTable.Columns.Add("Factor", typeof(string));
                        materialTable.Columns.Add("UnitName", typeof(string));

                        // Populate the materialTable directly from the dataTable
                        foreach (DataRow materialRow in dataTable.Rows)
                        {
                            DataRow newRow = materialTable.NewRow();
                            newRow["MaterialName"] = materialRow["MaterialName"];
                            newRow["MaterialCode"] = materialRow["MaterialCode"];
                            newRow["Factor"] = materialRow["Factor"];
                            newRow["UnitName"] = materialRow["UnitName"];
                            materialTable.Rows.Add(newRow);
                        }

                        // Bind the materialTable to the DataGridView
                        dataGridViewBom.DataSource = materialTable;

                        // Change column titles (header text)
                        dataGridViewBom.Columns["MaterialName"].HeaderText = "ماده اولیه";
                        dataGridViewBom.Columns["MaterialCode"].HeaderText = "کد ماده اولیه";
                        dataGridViewBom.Columns["Factor"].HeaderText = "ضریب";
                        dataGridViewBom.Columns["UnitName"].HeaderText = "واحد";

                    }
                    else
                    {
                        MessageBox.Show("No data found for this product code.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred while fetching the data: {ex.Message}");
                }
            }
        }

        private void btn_print_Click(object sender, EventArgs e)
        {
            Form reportForm = new Form();
            ReportViewer reportViewer = new ReportViewer();

            reportViewer.Dock = DockStyle.Fill;
            reportForm.Controls.Add(reportViewer);
            reportForm.WindowState = FormWindowState.Maximized;

            // Fetch the data for BOM and MaterialToBom based on the ProductCode
            string productCode = txtProductCode.Text;

            DataTable bomTable = GetBomData(productCode);  // Function to retrieve BOM data
            DataTable materialTable = GetMaterialData(productCode);  // Function to retrieve MaterialToBom data
            DataTable unitTable = GetUnitData();  // New function to retrieve Unit data
            DataTable material = GetMaterial();

            // Add data sources to the report
            reportViewer.LocalReport.DataSources.Clear();
            reportViewer.LocalReport.DataSources.Add(new ReportDataSource("bom", bomTable));
            reportViewer.LocalReport.DataSources.Add(new ReportDataSource("MaterialToBom", materialTable));
            reportViewer.LocalReport.DataSources.Add(new ReportDataSource("unit", unitTable));  // Add UNIT data source
            reportViewer.LocalReport.DataSources.Add(new ReportDataSource("Material", material));
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
        private DataTable GetMaterial()
        {
            DataTable dt = new DataTable();
            string query = "SELECT * FROM Material";
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

        private void btn_edit_Click(object sender, EventArgs e)
        {
            bool isValid = true;

            if (btn_edit.Text.Trim().Equals("ویرایش", StringComparison.OrdinalIgnoreCase))
            {
                btn_edit.Text = "ثبت";

                // Add txtDoccode and txtEdit to the editable textboxes array
                TextBox[] textBoxes = { txtBomNumber, txtCipTime, txtMachine, txtOptimalTime, txtPreprationTime, txtProductName, txtVolume, txtDoccode, txtEdit };
                foreach (TextBox textBox in textBoxes)
                {
                    textBox.ReadOnly = false;
                    textBox.Enabled = true; // Ensure they are enabled
                }

                foreach (DataGridViewRow row in dataGridViewBom.Rows)
                {
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        cell.ReadOnly = false; // Allow editing
                    }
                }
                dataGridViewBom.ReadOnly = false; // Ensure grid is editable
            }
            else if (btn_edit.Text.Trim().Equals("ثبت", StringComparison.OrdinalIgnoreCase))
            {
                // Add txtDoccode and txtEdit to validation check
                TextBox[] textBoxes = { txtBomNumber, txtCipTime, txtMachine, txtOptimalTime, txtPreprationTime, txtProductName, txtVolume, txtDoccode, txtEdit };

                foreach (TextBox tb in textBoxes)
                {
                    if (string.IsNullOrWhiteSpace(tb.Text)) // Check for blank or whitespace inputs
                    {
                        isValid = false;
                        tb.Focus();
                        MessageBox.Show("تمام اطلاعات را وارد کنید");
                        return;
                    }
                }

                foreach (DataGridViewRow row in dataGridViewBom.Rows)
                {
                    // Skip new rows to avoid validation errors
                    if (row.IsNewRow) continue;

                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        if (cell.Value == null || string.IsNullOrWhiteSpace(cell.Value.ToString()))
                        {
                            isValid = false;
                            cell.DataGridView.CurrentCell = cell; // Highlight invalid cell
                            MessageBox.Show("تمام اطلاعات جدول را وارد کنید");
                            return;
                        }
                    }
                }

                if (isValid)
                {
                    btn_edit.Text = "ویرایش";

                    // Make all textboxes and DataGridView read-only again
                    foreach (TextBox textBox in textBoxes)
                    {
                        textBox.ReadOnly = true;
                        textBox.Enabled = false;
                    }

                    foreach (DataGridViewRow row in dataGridViewBom.Rows)
                    {
                        foreach (DataGridViewCell cell in row.Cells)
                        {
                            cell.ReadOnly = true;
                        }
                    }
                    dataGridViewBom.ReadOnly = true;

                    using (SqlConnection conn = new SqlConnection(connection))
                    {
                        conn.Open();

                        using (SqlTransaction transaction = conn.BeginTransaction())
                        {
                            try
                            {
                                String update = "UPDATE Bom SET ProductName = @name, BomNumber = @number, CipTime = @cip, OptimalTime = @optimal," +
                                    " PreprationTime = @pre,Volume = @vol, Machine = @machine, DocCode = @doc, ReviewNumber = @review WHERE ProductCode = @product;";
                                using (SqlCommand cmd = new SqlCommand(update, conn, transaction))
                                {
                                    TimeSpan cip = ParseTimeSpan(txtCipTime.Text);
                                    TimeSpan optimal = ParseTimeSpan(txtOptimalTime.Text);
                                    TimeSpan prepration = ParseTimeSpan(txtPreprationTime.Text);


                                    cmd.Parameters.AddWithValue("@product", txtProductCode.Text);
                                    cmd.Parameters.AddWithValue("@name", txtProductName.Text);
                                    cmd.Parameters.AddWithValue("@number", txtBomNumber.Text);
                                    cmd.Parameters.AddWithValue("@cip", cip);
                                    cmd.Parameters.AddWithValue("@optimal", optimal);
                                    cmd.Parameters.AddWithValue("@pre", prepration);
                                    cmd.Parameters.AddWithValue("@machine", txtMachine.Text);
                                    cmd.Parameters.AddWithValue("@doc", txtDoccode.Text);
                                    cmd.Parameters.AddWithValue("@review", txtEdit.Text);
                                    cmd.Parameters.AddWithValue("@vol", int.Parse(txtVolume.Text));
                                    cmd.ExecuteNonQuery();
                                }

                                foreach (DataGridViewRow row in dataGridViewBom.Rows)
                                {
                                    if (row.IsNewRow) continue; // Skip new rows

                                    // Validate the row data
                                    if (!ValidateRow(row))
                                    {
                                        MessageBox.Show("Please correct invalid data in the grid before saving.");
                                        return;
                                    }

                                    string column1 = row.Cells["MaterialName"].Value?.ToString();
                                    string column2 = row.Cells["MaterialCode"].Value?.ToString();
                                    string column3 = row.Cells["Factor"].Value?.ToString();
                                    string column4 = row.Cells["UnitName"].Value?.ToString();

                                    // Query the database to check if the record exists
                                    string checkQuery = "SELECT COUNT(1) FROM MaterialToBom WHERE ProductCode = @ProductCode AND MaterialCode = @MaterialCode;";
                                    using (SqlCommand checkCmd = new SqlCommand(checkQuery, conn, transaction))
                                    {
                                        checkCmd.Parameters.AddWithValue("@ProductCode", txtProductCode.Text ?? (object)DBNull.Value);
                                        checkCmd.Parameters.AddWithValue("@MaterialCode", column2 ?? (object)DBNull.Value);

                                        int recordExists = Convert.ToInt32(checkCmd.ExecuteScalar());

                                        if (recordExists == 0) // Record does not exist, perform INSERT
                                        {
                                            string insertQuery = "INSERT INTO MaterialToBom (ProductCode, MaterialCode, Factor, Unit) VALUES (@ProductCode, @MaterialCode, @Factor, (SELECT ID FROM Units WHERE UnitName = @UnitName));";

                                            using (SqlCommand cmd = new SqlCommand(insertQuery, conn, transaction))
                                            {
                                                cmd.Parameters.AddWithValue("@ProductCode", txtProductCode.Text ?? (object)DBNull.Value);
                                                cmd.Parameters.AddWithValue("@MaterialCode", column2 ?? (object)DBNull.Value);
                                                cmd.Parameters.AddWithValue("@Factor", column3 ?? (object)DBNull.Value);
                                                cmd.Parameters.AddWithValue("@UnitName", column4 ?? (object)DBNull.Value);
                                                cmd.ExecuteNonQuery();
                                            }
                                        }
                                        else // Record exists, perform UPDATE
                                        {
                                            string updateQuery = "UPDATE MaterialToBom SET Factor = @Factor, Unit = (SELECT ID FROM Units WHERE UnitName = @UnitName) WHERE ProductCode = @ProductCode AND MaterialCode = @MaterialCode;";
                                            using (SqlCommand cmd = new SqlCommand(updateQuery, conn, transaction))
                                            {
                                                cmd.Parameters.AddWithValue("@ProductCode", txtProductCode.Text ?? (object)DBNull.Value);
                                                cmd.Parameters.AddWithValue("@MaterialCode", column2 ?? (object)DBNull.Value);
                                                cmd.Parameters.AddWithValue("@Factor", column3 ?? (object)DBNull.Value);
                                                cmd.Parameters.AddWithValue("@UnitName", column4 ?? (object)DBNull.Value);
                                                cmd.ExecuteNonQuery();
                                            }
                                        }
                                    }

                                }

                                transaction.Commit();
                                MessageBox.Show("Data saved successfully!");
                            }
                            catch (Exception ex)
                            {
                                transaction.Rollback();
                                MessageBox.Show("An error occurred: " + ex.Message);
                            }
                        }
                    }
                }
            }
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
            else
            {

            }

            return TimeSpan.Zero; // Default to 00:00:00 if the format is invalid
        }
        private bool ValidateRow(DataGridViewRow row)
        {
            foreach (DataGridViewCell cell in row.Cells)
            {
                if (cell.Value == null || string.IsNullOrWhiteSpace(cell.Value.ToString()))
                {
                    cell.ErrorText = "This field cannot be empty.";
                    return false;
                }
                else
                {
                    cell.ErrorText = string.Empty; // Clear previous errors
                }
            }
            return true;
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "آیا میخواهید اطلاعات مورد نظر پاک شود",
                "تایید",
                MessageBoxButtons.YesNo);

            if (result == DialogResult.OK)
            {
                using (SqlConnection conn = new SqlConnection(connection))
                {
                    try
                    {
                        conn.Open();
                        string delete = "DELETE FROM Bom where ProductCode = @code";
                        string deleteM = "DELETE FROM MaterialToBom where ProductCode = @code";
                        using (SqlCommand Mdelete = new SqlCommand(deleteM, conn))
                        {
                            Mdelete.Parameters.AddWithValue("@code", txtProductCode.Text);
                            Mdelete.ExecuteNonQuery();
                        }
                        using (SqlCommand bomdelete = new SqlCommand(delete, conn))
                        {
                            bomdelete.Parameters.AddWithValue("@code", txtProductCode.Text);
                            bomdelete.ExecuteNonQuery();
                        }
                        conn.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }

                }
            }
            
        }

        private void btn_deleterow_Click(object sender, EventArgs e)
        {
            if (dataGridViewBom.SelectedRows.Count > 0)
            {
                DataGridViewRow Selected = dataGridViewBom.SelectedRows[0];
                int foriegenkey = Convert.ToInt32(Selected.Cells["MaterialCode"].Value);

                using (SqlConnection conn = new SqlConnection(connection))
                {
                    conn.Open();
                    string query = $"DELETE FROM MaterialToBom WHERE MaterialCode = @PrimaryKeyValue And ProductCode = @product";
                    SqlCommand command = new SqlCommand(query, conn);
                    command.Parameters.AddWithValue("@PrimaryKeyValue", foriegenkey);
                    command.Parameters.AddWithValue("@ProductCode", int.Parse(txtProductCode.Text));
                    command.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }
    }
}

