using System;
using System.Configuration;
using System.Windows.Forms;

namespace AFTAB
{

    public partial class Main : Form
    {
        string connection = ConfigurationManager.ConnectionStrings["MyDatabaseConnection"].ConnectionString;

        private string UserRole;
        private bool isClosingConfirmed = false;

        public Main(string Role)
        {
            InitializeComponent();

            // Handle empty or null role gracefully
            UserRole = string.IsNullOrEmpty(Role) ? "Guest" : Role;

            this.FormClosing += Main_FormClosing; // Attach the event handler
            Main_menu.Visible = false;
            ShowLoginForm();  // Show the login form first
        }

        private void CemicalMaterial_Click(object sender, EventArgs e)
        {
            bool isFormOpen = false;

            foreach (Form childForm in this.MdiChildren)
            {
                if (childForm is Material)
                {
                    isFormOpen = true;
                    childForm.BringToFront(); // Bring the existing form to the front
                    break;
                }
            }

            if (!isFormOpen)
            {
                // If the RawMaterial form is not open, create and show it
                Material cemicalMaterilaForm = new Material();
                cemicalMaterilaForm.MdiParent = this;  // Set the MDI Parent
                cemicalMaterilaForm.Show();
            }
        }

        private void CreateBom_Click(object sender, EventArgs e)
        {
            bool isFormOpen = false;

            foreach (Form childForm in this.MdiChildren)
            {
                if (childForm is BOM)
                {
                    isFormOpen = true;
                    childForm.BringToFront(); // Bring the existing form to the front
                    break;
                }
            }

            if (!isFormOpen)
            {
                // If the RawMaterial form is not open, create and show it
                BOM createBomForm = new BOM();
                createBomForm.MdiParent = this;  // Set the MDI Parent
                createBomForm.Show();
            }
        }

        private void Main_Load(object sender, EventArgs e)
        {
            // Set the IsMdiContainer property to true.
            IsMdiContainer = true;
        }


        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!isClosingConfirmed && e.CloseReason == CloseReason.UserClosing)
            {
                DialogResult result = MessageBox.Show(
                    "Are you sure you want to close the application?",
                    "Exit Confirmation",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (result == DialogResult.Yes)
                {
                    isClosingConfirmed = true;
                    Application.Exit();
                }
                if (!isClosingConfirmed)
                {
                    e.Cancel = true;
                }


                
            }
        }

        private void ShowLoginForm()
        {
            // Create an instance of the login form
            Login loginForm = new Login();
            loginForm.MdiParent = this;  // Set the parent as the main MDI container
            loginForm.Show();
            loginForm.LoginSuccessful += LoginForm_LoginSuccessful;

        }
        private void LoginForm_LoginSuccessful(object sender, EventArgs e)
        {
            // Hide the login form
            ((Form)sender).Close();

            // Show main elements, like menus or panels
            this.Main_menu.Visible = true;  // Example: showing a menu strip
                                             // Load other elements or child forms as needed
        }

        private void NewUser_Click(object sender, EventArgs e)
        {
            bool isFormOpen = false;

            foreach (Form childForm in this.MdiChildren)
            {
                if (childForm is NewUser)
                {
                    isFormOpen = true;
                    childForm.BringToFront(); // Bring the existing form to the front
                    break;
                }
            }

            if (!isFormOpen)
            {
                // If the RawMaterial form is not open, create and show it
                NewUser createNewuser = new NewUser();
                createNewuser.MdiParent = this;  // Set the MDI Parent
                createNewuser.Show();
            }
        }

        private void BomSearch_Click(object sender, EventArgs e)
        {
            bool isFormOpen = false;

            // Iterate over the MDI children of the MDI parent
            foreach (Form childForm in this.MdiChildren)
            {
                if (childForm is SearchBom)
                {
                    isFormOpen = true;
                    childForm.BringToFront();  // Bring the existing form to the front
                    break;
                }
            }

            // If the SearchBom form is not open, create and show it
            if (!isFormOpen)
            {
                SearchBom createSearchBom = new SearchBom();
                createSearchBom.MdiParent = this;  // Set the MDI Parent correctly
                createSearchBom.Show();
            }
        }



    }
}
