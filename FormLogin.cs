using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace StockApp
{
    public partial class FormLogin : Form
    {
        SqlConnection con = new SqlConnection(
            System.Configuration.ConfigurationManager.ConnectionStrings["cnx"].ConnectionString);

        public FormLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(
                    "SELECT COUNT(*) FROM Utilisateur WHERE Nom=@u AND Password=@p", con);

                cmd.Parameters.AddWithValue("@u", txtUser.Text);
                cmd.Parameters.AddWithValue("@p", txtPass.Text);

                int count = (int)cmd.ExecuteScalar();

                if (count == 1)
                {
                    new FormDashboard().Show();
                    this.Hide();
                }
                else
                {
                    lblError.Text = "Identifiants incorrects.";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur : " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {

        }

        private void txtUser_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
