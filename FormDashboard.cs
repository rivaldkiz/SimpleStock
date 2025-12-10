using System;
using System.Windows.Forms;

namespace StockApp
{
    public partial class FormDashboard : Form
    {
        public FormDashboard()
        {
            InitializeComponent();
        }

        private void menuProduit_Click(object sender, EventArgs e)
        {
            // Gestion des matériels
            new FormProduit().ShowDialog();
        }

        private void menuMouvement_Click(object sender, EventArgs e)
        {
            // Gestion des mouvements
            new FormMouvement().ShowDialog();
        }

        private void menuStock_Click(object sender, EventArgs e)
        {
            // Visualisation du stock
            new FormStock().ShowDialog();
        }

        private void menuLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            new FormLogin().Show();
        }

        private void FormDashboard_Load(object sender, EventArgs e)
        {
            // Ici on pourrait charger des stats rapides ou indicateurs si nécessaire
        }
    }
}
