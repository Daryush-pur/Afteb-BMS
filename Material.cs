using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace AFTAB
{
    public partial class Material : Form
    {
        string connection = ConfigurationManager.ConnectionStrings["MyDatabaseConnection"].ConnectionString;
        public Material()
        {
            InitializeComponent();
        }

        private void radio_packeting_CheckedChanged(object sender, EventArgs e)
        {
            if (radio_packeting.Checked == true)
            { 
                radio_raw.Checked = false;
                radio_cemical.Checked = false;
            }
        }

        private void radio_raw_CheckedChanged(object sender, EventArgs e)
        {
            if (radio_raw.Checked == true)
            {
                radio_cemical.Checked = false ;
                radio_packeting.Checked = false;
            }
        }

        private void radio_cemical_CheckedChanged(object sender, EventArgs e)
        {
            if (radio_cemical.Checked == true)
            {
                radio_raw.Checked = false ;
                radio_packeting.Checked= false;
            }
        }

        private void CemicalMaterial_Load(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connection))
            {
                string loaduser = "SELECT * FROM Units";
                using (SqlCommand load = new SqlCommand(loaduser, conn))
                {
                    conn.Open();
                    SqlDataReader reader = load.ExecuteReader();
                    while (reader.Read())
                    {
                        combo_unit.Items.Add(reader["UnitName"].ToString());
                    }
                    conn.Close();
                }
            }
        }

        private void btn_submit_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connection))
                {
                    conn.Open();

                    // Query to check for existing duplicates based on MaterialCode or MaterialName
                    string checkDuplicate = "SELECT COUNT(*) FROM Material WHERE MaterialCode = @code OR MaterialName = @name";
                    using (SqlCommand checkCmd = new SqlCommand(checkDuplicate, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@code", text_code.Text);
                        checkCmd.Parameters.AddWithValue("@name", text_name.Text);

                        // ExecuteScalar returns the first column of the first row
                        int duplicateCount = (int)checkCmd.ExecuteScalar();

                        if (duplicateCount > 0)
                        {
                            MessageBox.Show("این ماده با کد یا نام وارد شده در پایگاه داده موجود است.", "Duplicate Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return; // Stop further execution
                        }
                    }

                    // Proceed with insertion if no duplicates are found
                    string insert = "INSERT INTO Material (MaterialCode, MaterialName, MaterialType, MaterialUnit) " +
                                    "VALUES (@code, @name, @type, (SELECT ID FROM Units WHERE UnitName = @unit))";

                    using (SqlCommand cmd = new SqlCommand(insert, conn))
                    {
                        cmd.Parameters.AddWithValue("@code", text_code.Text);
                        cmd.Parameters.AddWithValue("@name", text_name.Text);
                        cmd.Parameters.AddWithValue("@unit", combo_unit.Text);

                        if (radio_cemical.Checked)
                        {
                            cmd.Parameters.AddWithValue("@type", radio_cemical.Text);
                        }
                        else if (radio_packeting.Checked)
                        {
                            cmd.Parameters.AddWithValue("@type", radio_packeting.Text);
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@type", radio_raw.Text);
                        }

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("اطلاعات با موفقیت ذخیره شد");
                    }
                }

                // Clear form fields after successful insertion
                text_code.Clear();
                text_name.Clear();
                radio_cemical.Checked = false;
                radio_packeting.Checked = false;
                radio_raw.Checked = false;
                combo_unit.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"خطا در ذخیره‌سازی: {ex.Message}");
            }
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            text_code.Clear();
            text_name.Clear();
            radio_cemical.Checked = false;
            radio_packeting.Checked = false;
            radio_raw.Checked = false;
            combo_unit.SelectedIndex = -1;
        }
    }
}
