using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace AFTAB
{
    public partial class Login : Form
    {
        string connection = ConfigurationManager.ConnectionStrings["MyDatabaseConnection"].ConnectionString;
        public string UserRole { get; private set; } = "";

        // Event to notify successful login
        public event EventHandler LoginSuccessful;

        public Login()
        {
            InitializeComponent();
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUsername.Text) || string.IsNullOrEmpty(txtPassword.Text))
            {
                MessageBox.Show("Please enter both username and password.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connection))
                {
                    string query = "SELECT * FROM Users WHERE PersonalCode = @username AND Password = @password";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@username", txtUsername.Text);
                    cmd.Parameters.AddWithValue("@password", txtPassword.Text);  // Replace with hashed comparison in production

                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read()) // Successful login
                        {
                            UserRole = GetUserRole(txtUsername.Text);
                            this.Hide();  // Hide login form
                            LoginSuccessful?.Invoke(this, EventArgs.Empty);  // Raise event to notify Main Form
                        }
                        else
                        {
                            MessageBox.Show("Invalid credentials!", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtPassword.Clear();
                            txtUsername.Focus();
                        }
                    }
                }
            }
            catch (Exception)
            {
                // Log the error internally; show a generic message to users
                MessageBox.Show("An error occurred during login. Please try again later.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Log ex.Message to a log file or database in production
            }
        }

        private string GetUserRole(string personalCode)
        {
            string roleName = "";
            string query = @"SELECT R.RoleName
                             FROM Roles R
                             INNER JOIN RoleToUser RTU ON R.ID = RTU.RoleID
                             WHERE RTU.PersonalCode = @personalcode";

            try
            {
                using (SqlConnection conn = new SqlConnection(connection))
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@personalcode", personalCode);

                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())  // Check if a role is found
                    {
                        roleName = reader["RoleName"].ToString();
                    }
                }
            }
            catch (Exception)
            {
                // Log the error internally; show a generic message
                MessageBox.Show("Failed to fetch user role.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return roleName;
        }

        private void Login_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
