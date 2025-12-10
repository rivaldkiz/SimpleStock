using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace StockApp
{
    public partial class FormMouvement : Form
    {
        SqlConnection con = new SqlConnection(
            System.Configuration.ConfigurationManager.ConnectionStrings["cnx"].ConnectionString);

        private int CurrentUserId = 1; // À adapter selon l'utilisateur connecté

        public FormMouvement()
        {
            InitializeComponent();
            LoadProduits();
            LoadData();
        }

        void LoadProduits()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT IdMateriel, Libelle FROM Materiel", con);
            DataTable dt = new DataTable();
            da.Fill(dt);

            cboProd.DataSource = dt;
            cboProd.ValueMember = "IdMateriel";
            cboProd.DisplayMember = "Libelle";
            cboProd.SelectedIndex = -1;
        }

        void LoadData()
        {
            string query = @"
                SELECT m.IdMvt, mat.Libelle AS Materiel, m.TypeMvt, m.Qte, m.DateMvt, 
                       m.Destinataire, u.Nom AS Utilisateur
                FROM MvtStock m
                INNER JOIN Materiel mat ON m.IdMateriel = mat.IdMateriel
                INNER JOIN Utilisateur u ON m.IdUser = u.IdUser
                ORDER BY m.DateMvt DESC";

            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgv.DataSource = dt;

            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.MultiSelect = false;
            dgv.ReadOnly = true;
        }

        private void btnValider_Click(object sender, EventArgs e)
        {
            if (cboProd.SelectedIndex == -1)
            {
                MessageBox.Show("Veuillez sélectionner un matériel.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txtQte.Text, out int qte) || qte <= 0)
            {
                MessageBox.Show("Veuillez entrer une quantité valide (>0).", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string typeMvt = cboType.Text;
            if (typeMvt != "Entree" && typeMvt != "Sortie")
            {
                MessageBox.Show("Veuillez sélectionner le type de mouvement (Entree ou Sortie).", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string destinataire = txtDestinataire.Text.Trim();

            SqlCommand cmd = new SqlCommand(
                "INSERT INTO MvtStock(IdMateriel, TypeMvt, Destinataire, Qte, DateMvt, IdUser) " +
                "VALUES(@idMat, @type, @dest, @qte, GETDATE(), @idUser)", con);

            cmd.Parameters.AddWithValue("@idMat", cboProd.SelectedValue);
            cmd.Parameters.AddWithValue("@type", typeMvt);
            cmd.Parameters.AddWithValue("@dest", string.IsNullOrEmpty(destinataire) ? DBNull.Value : (object)destinataire);
            cmd.Parameters.AddWithValue("@qte", qte);
            cmd.Parameters.AddWithValue("@idUser", CurrentUserId);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            LoadData();
            MessageBox.Show("Mouvement enregistré avec succès.", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Reset des champs
            cboProd.SelectedIndex = -1;
            cboType.SelectedIndex = -1;
            txtQte.Clear();
            txtDestinataire.Clear();
        }
    }
}
