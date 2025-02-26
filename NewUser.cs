using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace AFTAB
{
    public partial class NewUser : Form
    {
        string connection = ConfigurationManager.ConnectionStrings["MyDatabaseConnection"].ConnectionString;
        public NewUser()
        {
            InitializeComponent();
            Tip.SetToolTip(txt_name, "نام و نا خانوادگی را وارد کنید");
            Tip.SetToolTip(txt_code, "کد پرسنلی را وارد کنید");
            Tip.SetToolTip(txt_pass, "رمز عبور مابین 6 - 20 کاراکتر");
            Tip.SetToolTip(com_role, "دسترسی مورد نظر را انتخاب کنید");
        }

        private void NewUser_Load(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connection)) 
            {
                string loaduser = "SELECT * FROM Roles";
                using (SqlCommand load = new SqlCommand(loaduser, conn)) 
                {
                    conn.Open();
                    SqlDataReader reader = load.ExecuteReader();
                    while (reader.Read())
                    {
                        com_role.Items.Add(reader["RoleName"].ToString());
                    }
                    conn.Close();
                }
            }
        }

        private void btn_submit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_code.Text) || string.IsNullOrEmpty(txt_name.Text) || string.IsNullOrEmpty(txt_pass.Text) || string.IsNullOrEmpty(com_role.Text)) 
            {
                MessageBox.Show("اطلاعات نمیتواند خالی باشد");
            }
            else 
            {
                int id = 0;
                using (SqlConnection conn = new SqlConnection(connection))
                {
                    string selectrole = "SELECT ID FROM Roles WHERE RoleName = @name";
                    using (SqlCommand select = new SqlCommand(selectrole, conn)) 
                    {
                        select.Parameters.AddWithValue("@name", com_role.Text);
                        conn.Open();
                        SqlDataReader reader = select.ExecuteReader();
                        while (reader.Read()) 
                        {
                            id = Convert.ToInt32(reader["id"].ToString());
                        }
                        conn.Close();
                    }

                    string query = @"
                                    INSERT INTO Users (PersonalName, PersonalCode, Password) 
                                    VALUES (@PersonalName, @PersonalCode, @Password);

                                    INSERT INTO RoleToUser (PersonalCode, RoleID) 
                                    VALUES (@PersonalCode, @RoleID);";  // Correct order of parameters


                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        // Add parameters for both INSERT statements
                        cmd.Parameters.AddWithValue("@PersonalName", txt_name.Text);
                        cmd.Parameters.AddWithValue("@PersonalCode", txt_code.Text);
                        cmd.Parameters.AddWithValue("@Password", txt_pass.Text);  // Fixed case consistency
                        cmd.Parameters.AddWithValue("@RoleID", id);               // Ensure 'id' is correctly defined

                        conn.Open();
                        SqlTransaction transaction = conn.BeginTransaction();

                        try
                        {
                            cmd.Transaction = transaction;  // Assign the transaction to the command
                            cmd.ExecuteNonQuery();          // Execute both INSERTs within the transaction
                            transaction.Commit();           // Commit if both succeed
                            MessageBox.Show("User and role assigned successfully!");
                            txt_code.Clear();
                            txt_name.Clear();
                            txt_pass.Clear();
                            com_role.SelectedItem = null;
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();         // Rollback if there is an error
                            MessageBox.Show($"Transaction failed: {ex.Message}");
                        }
                        conn.Close();
                    }

                }
            }
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            txt_code.Clear();
            txt_name.Clear();
            txt_pass.Clear();
            com_role.SelectedItem = null;
        }
    }
}
