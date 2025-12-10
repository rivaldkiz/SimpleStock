using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace StockApp
{
    public partial class FormProduit : Form
    {
        SqlConnection con = new SqlConnection(
            System.Configuration.ConfigurationManager.ConnectionStrings["cnx"].ConnectionString);

        public FormProduit()
        {
            InitializeComponent();
            LoadData();
        }

        void LoadData()
        {
            try
            {
                string query = @"
                    SELECT m.IdMateriel, m.Libelle, m.Description, ISNULL(s.QteDispo, 0) AS Quantite, ISNULL(s.SeuilAlert, 0) AS Seuil
                    FROM Materiel m
                    LEFT JOIN Stock s ON m.IdMateriel = s.IdMateriel";

                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgv.DataSource = dt;

                dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgv.MultiSelect = false;
                dgv.ReadOnly = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors du chargement des données : " + ex.Message);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNom.Text))
            {
                MessageBox.Show("Veuillez saisir le nom du matériel.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txtQuantite.Text, out int qteInitiale) || qteInitiale < 0)
            {
                MessageBox.Show("Veuillez saisir une quantité initiale valide (>=0).", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                con.Open();

                // Insérer le matériel
                SqlCommand cmd = new SqlCommand(
                    "INSERT INTO Materiel(Libelle, Description) VALUES(@libelle,@desc); SELECT SCOPE_IDENTITY();", con);
                cmd.Parameters.AddWithValue("@libelle", txtNom.Text);
                cmd.Parameters.AddWithValue("@desc", txtDescription.Text);

                int idMateriel = Convert.ToInt32(cmd.ExecuteScalar());

                // Insérer le stock initial
                SqlCommand cmdStock = new SqlCommand(
                    "INSERT INTO Stock(IdMateriel, QteDispo) VALUES(@idMat, @qte)", con);
                cmdStock.Parameters.AddWithValue("@idMat", idMateriel);
                cmdStock.Parameters.AddWithValue("@qte", qteInitiale);
                cmdStock.ExecuteNonQuery();

                MessageBox.Show("Matériel ajouté avec succès.", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtNom.Clear();
                txtDescription.Clear();
                txtQuantite.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de l'ajout : " + ex.Message);
            }
            finally
            {
                con.Close();
                LoadData();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgv.SelectedRows.Count == 0) return;

            int idMat = (int)dgv.SelectedRows[0].Cells["IdMateriel"].Value;

            try
            {
                con.Open();

                // Mise à jour du matériel
                SqlCommand cmd = new SqlCommand(
                    "UPDATE Materiel SET Libelle=@libelle, Description=@desc WHERE IdMateriel=@id", con);
                cmd.Parameters.AddWithValue("@id", idMat);
                cmd.Parameters.AddWithValue("@libelle", txtNom.Text);
                cmd.Parameters.AddWithValue("@desc", txtDescription.Text);
                cmd.ExecuteNonQuery();

                // Mise à jour de la quantité (optionnel)
                if (int.TryParse(txtQuantite.Text, out int qte))
                {
                    SqlCommand cmdStock = new SqlCommand(
                        "UPDATE Stock SET QteDispo=@qte WHERE IdMateriel=@id", con);
                    cmdStock.Parameters.AddWithValue("@qte", qte);
                    cmdStock.Parameters.AddWithValue("@id", idMat);
                    cmdStock.ExecuteNonQuery();
                }

                MessageBox.Show("Matériel modifié avec succès.", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de la modification : " + ex.Message);
            }
            finally
            {
                con.Close();
                LoadData();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgv.SelectedRows.Count == 0) return;

            int idMat = (int)dgv.SelectedRows[0].Cells["IdMateriel"].Value;

            var result = MessageBox.Show("Voulez-vous vraiment supprimer ce matériel ?", "Confirmer la suppression", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result != DialogResult.Yes) return;

            try
            {
                con.Open();

                // Supprimer les mouvements liés
                SqlCommand cmdDelMvt = new SqlCommand(
                    "DELETE FROM MvtStock WHERE IdMateriel=@id", con);
                cmdDelMvt.Parameters.AddWithValue("@id", idMat);
                cmdDelMvt.ExecuteNonQuery();

                // Supprimer le stock
                SqlCommand cmdDelStock = new SqlCommand(
                    "DELETE FROM Stock WHERE IdMateriel=@id", con);
                cmdDelStock.Parameters.AddWithValue("@id", idMat);
                cmdDelStock.ExecuteNonQuery();

                // Supprimer le matériel
                SqlCommand cmdDelMat = new SqlCommand(
                    "DELETE FROM Materiel WHERE IdMateriel=@id", con);
                cmdDelMat.Parameters.AddWithValue("@id", idMat);
                cmdDelMat.ExecuteNonQuery();

                MessageBox.Show("Matériel supprimé avec succès.", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de la suppression : " + ex.Message);
            }
            finally
            {
                con.Close();
                LoadData();
            }
        }

        private void dgv_SelectionChanged(object sender, EventArgs e)
        {
            if (dgv.SelectedRows.Count == 0) return;

            txtNom.Text = dgv.SelectedRows[0].Cells["Libelle"].Value.ToString();
            txtDescription.Text = dgv.SelectedRows[0].Cells["Description"].Value.ToString();
            txtQuantite.Text = dgv.SelectedRows[0].Cells["Quantite"].Value.ToString();
        }

        private void FormProduit_Load(object sender, EventArgs e)
        {

        }
    }
}
