using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace StockApp
{
    public partial class FormStock : Form
    {
        SqlConnection con = new SqlConnection(
            System.Configuration.ConfigurationManager.ConnectionStrings["cnx"].ConnectionString);

        public FormStock()
        {
            InitializeComponent();
            LoadStock();
        }

        void LoadStock(string filtre = "")
        {
            string query = @"
                SELECT s.IdStock, m.Libelle AS Materiel, s.QteDispo, s.SeuilAlert
                FROM Stock s
                INNER JOIN Materiel m ON s.IdMateriel = m.IdMateriel";

            if (!string.IsNullOrEmpty(filtre))
            {
                query += " WHERE m.Libelle LIKE @filtre OR s.QteDispo <= s.SeuilAlert";
            }

            SqlDataAdapter da = new SqlDataAdapter(query, con);
            if (!string.IsNullOrEmpty(filtre))
            {
                da.SelectCommand.Parameters.AddWithValue("@filtre", "%" + filtre + "%");
            }

            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvStock.DataSource = dt;

            dgvStock.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvStock.MultiSelect = false;
            dgvStock.ReadOnly = true;
        }

        private void txtFiltre_TextChanged(object sender, EventArgs e)
        {
            LoadStock(txtFiltre.Text.Trim());
        }
    }
}
