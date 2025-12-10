namespace StockApp
{
    partial class FormProduit
    {
        private System.ComponentModel.IContainer components = null;
        private TextBox txtNom;
        private TextBox txtDescription;
        private TextBox txtQuantite;
        private Button btnAdd;
        private Button btnUpdate;
        private Button btnDelete;
        private DataGridView dgv;
        private Label lblNom;
        private Label lblDesc;
        private Label lblQuantite;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            txtNom = new TextBox();
            txtDescription = new TextBox();
            txtQuantite = new TextBox();
            btnAdd = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            dgv = new DataGridView();
            lblNom = new Label();
            lblDesc = new Label();
            lblQuantite = new Label();
            SuspendLayout();

            // Labels
            lblNom.Text = "Nom :";
            lblNom.Location = new System.Drawing.Point(20, 20);
            lblDesc.Text = "Description :";
            lblDesc.Location = new System.Drawing.Point(20, 60);
            lblQuantite.Text = "Quantité initiale :";
            lblQuantite.Location = new System.Drawing.Point(20, 100);

            // TextBoxes
            txtNom.Location = new System.Drawing.Point(150, 20);
            txtNom.Size = new System.Drawing.Size(200, 23);

            txtDescription.Location = new System.Drawing.Point(150, 60);
            txtDescription.Size = new System.Drawing.Size(200, 23);

            txtQuantite.Location = new System.Drawing.Point(150, 100);
            txtQuantite.Size = new System.Drawing.Size(200, 23);

            // Buttons
            btnAdd.Text = "Ajouter";
            btnAdd.Location = new System.Drawing.Point(380, 20);
            btnAdd.Click += btnAdd_Click;

            btnUpdate.Text = "Modifier";
            btnUpdate.Location = new System.Drawing.Point(380, 60);
            btnUpdate.Click += btnUpdate_Click;

            btnDelete.Text = "Supprimer";
            btnDelete.Location = new System.Drawing.Point(380, 100);
            btnDelete.Click += btnDelete_Click;

            // DataGridView
            dgv.Location = new System.Drawing.Point(20, 150);
            dgv.Size = new System.Drawing.Size(600, 250);
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.MultiSelect = false;
            dgv.ReadOnly = true;
            dgv.SelectionChanged += dgv_SelectionChanged;

            // FormProduit
            ClientSize = new System.Drawing.Size(650, 450);
            Controls.Add(lblNom);
            Controls.Add(lblDesc);
            Controls.Add(lblQuantite);
            Controls.Add(txtNom);
            Controls.Add(txtDescription);
            Controls.Add(txtQuantite);
            Controls.Add(btnAdd);
            Controls.Add(btnUpdate);
            Controls.Add(btnDelete);
            Controls.Add(dgv);
            Text = "Gestion des matériels";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
