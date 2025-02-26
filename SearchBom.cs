using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace AFTAB
{
    public partial class SearchBom : Form
    {
        string connection = ConfigurationManager.ConnectionStrings["MyDatabaseConnection"].ConnectionString;

        public SearchBom()
        {
            InitializeComponent();
        }

        private void text_search_TextChanged(object sender, EventArgs e)
        {
            string query = "SELECT DISTINCT ProductName, ProductCode, BomNumber FROM Bom WHERE ProductCode LIKE @searchText";

            using (SqlConnection conn = new SqlConnection(connection))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@searchText", "%" + text_search.Text + "%");

                try
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    // Clear existing rows in DataGridView
                    dataGridView1.Rows.Clear();

                    // Add rows to DataGridView
                    while (reader.Read())
                    {
                        dataGridView1.Rows.Add(
                            reader["ProductName"].ToString(),
                            reader["ProductCode"].ToString(),
                            reader["BomNumber"].ToString()
                        );
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"مشکلی پیش آمده: {ex.Message}");
                }
            }
        }

        private void btn_show_Click(object sender, EventArgs e)
        {
            // Check if any row is selected in the DataGridView
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Safely access the first selected row
                string productCode = dataGridView1.SelectedRows[0].Cells["ProductCode"].Value.ToString();

                // Check if BomShow form is already open
                foreach (Form child in this.MdiParent.MdiChildren)
                {
                    if (child is BomShow)
                    {
                        child.Activate();  // Bring the existing form to the front
                        return;             // Exit the method, preventing a new instance
                    }
                }

                // If not open, create and show the new instance
                BomShow BomShowForm = new BomShow(productCode)
                {
                    MdiParent = this.MdiParent  // Set the MDI parent
                };
                BomShowForm.Show();
            }
            else
            {
                MessageBox.Show("لطفا یک سطر را انتخاب کنید");
            }
        }
    }
}
