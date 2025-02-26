using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace AFTAB
{
    public partial class AddToBom : Form
    {
        string connection = ConfigurationManager.ConnectionStrings["MyDatabaseConnection"].ConnectionString;
        private BOM _bomForm;

        public AddToBom(BOM bomForm)
        {
            InitializeComponent();
            // Bind events
            text_search.TextChanged += TextSearch_TextChanged;
            list_search.SelectedIndexChanged += ListSearch_SelectedIndexChanged;
            _bomForm = bomForm;
        }

        // Event triggered when text in the search box changes
        private void TextSearch_TextChanged(object sender, EventArgs e)
        {
            string searchText = text_search.Text.Trim();
            if (!string.IsNullOrEmpty(searchText))
            {
                FetchSuggestions(searchText);
            }
            else
            {
                list_search.Items.Clear(); // Clear suggestions if search box is empty
            }
        }

        // Method to fetch suggestions based on the text entered
        private void FetchSuggestions(string searchText)
        {
            // Clear current suggestions
            list_search.Items.Clear();

            // SQL query to fetch suggestions that contain the search text anywhere in the MaterialName column
            string query = "SELECT DISTINCT MaterialName FROM Material WHERE MaterialName LIKE @searchText";

            using (SqlConnection conn = new SqlConnection(connection))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@searchText", "%" + searchText + "%");
                try
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        list_search.Items.Add(reader["MaterialName"].ToString()); // Add each suggestion to ListBox
                    }
                    conn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                }
            }
        }

        // Event triggered when an item is selected from the ListBox
        private void ListSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (list_search.SelectedItem != null)
            {
                string selectedName = list_search.SelectedItem.ToString();
                PopulateFields(selectedName);
            }
        }

        // Method to populate additional fields when an item is selected from the ListBox
        private void PopulateFields(string selectedName)
        {
            string query = "SELECT Material.MaterialName, Material.MaterialCode, Material.MaterialType, Material.MaterialUnit " +
               "FROM Material " +
               "WHERE Material.MaterialName = @selectedName;";

            using (SqlConnection conn = new SqlConnection(connection))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@selectedName", selectedName);
                    try
                    {
                        conn.Open();
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            text_code.Text = reader["MaterialCode"].ToString(); // Adjust field names accordingly
                                                                                // Populate other fields as needed
                        }
                        conn.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error: {ex.Message}");
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Collect data from textboxes
            string materialName = list_search.SelectedItem.ToString();
            string materialCode = text_code.Text;
            string materialUnit = combo_unit.SelectedItem.ToString();
            decimal fraction = decimal.Parse(text_fraction.Text);

            // Call the method on the BOM form to add data to the DataGridView
            _bomForm.AddMaterialToGrid(materialName, materialCode, materialUnit, fraction);

            // Optionally, clear textboxes after adding
            text_code.Clear();
            text_fraction.Clear();

            
        }

        private void text_fraction_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow control characters like Backspace, Delete, etc.
            if (char.IsControl(e.KeyChar))
            {
                return;  // Allow control key processing
            }

            // Check if the key is a digit (0-9)
            if (char.IsDigit(e.KeyChar))
            {
                return;  // Allow the digit
            }

            // Check if the key is a decimal point
            if (e.KeyChar == '/')
            {
                // If there's already a decimal point in the TextBox, reject the input
                if (text_fraction.Text.Contains("/"))
                {
                    e.Handled = true;  // Block the second decimal point
                }
                else
                {
                    return;  // Allow the decimal point
                }
            }

            // Reject any other character
            e.Handled = true;
        }

        private void AddToBom_Load(object sender, EventArgs e)
        {
            string selectUnit = "SELECT * FROM Units;";
            using (SqlConnection conn = new SqlConnection(connection))
            {
                using (SqlCommand cmd2 = new SqlCommand(selectUnit, conn))
                {
                    try
                    {
                        conn.Open();
                        SqlDataReader reader = cmd2.ExecuteReader();
                        while (reader.Read())
                        {
                            combo_unit.Items.Add(reader["UnitName"].ToString().Trim());
                        }
                        conn.Close();
                    }
                    catch
                    {
                        MessageBox.Show("مشکلی در بارگزاری واحد ها پیش آمده است");
                    }
                }
            }
        }
    }
}
