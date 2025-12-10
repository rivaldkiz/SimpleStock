namespace StockApp
{
    partial class FormMouvement
    {
        private System.ComponentModel.IContainer components = null;
        private ComboBox cboProd;
        private ComboBox cboType;
        private TextBox txtQte;
        private TextBox txtDestinataire;
        private Button btnValider;
        private DataGridView dgv;
        private Label lblProd;
        private Label lblType;
        private Label lblQte;
        private Label lblDestinataire;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            cboProd = new ComboBox();
            cboType = new ComboBox();
            txtQte = new TextBox();
            txtDestinataire = new TextBox();
            btnValider = new Button();
            dgv = new DataGridView();
            lblProd = new Label();
            lblType = new Label();
            lblQte = new Label();
            lblDestinataire = new Label();
            ((System.ComponentModel.ISupportInitialize)dgv).BeginInit();
            SuspendLayout();
            // 
            // cboProd
            // 
            cboProd.Location = new Point(120, 20);
            cboProd.Name = "cboProd";
            cboProd.Size = new Size(200, 23);
            cboProd.TabIndex = 4;
            // 
            // cboType
            // 
            cboType.DropDownStyle = ComboBoxStyle.DropDownList;
            cboType.Items.AddRange(new object[] { "Entree", "Sortie" });
            cboType.Location = new Point(120, 60);
            cboType.Name = "cboType";
            cboType.Size = new Size(200, 23);
            cboType.TabIndex = 5;
            // 
            // txtQte
            // 
            txtQte.Location = new Point(650, 12);
            txtQte.Name = "txtQte";
            txtQte.Size = new Size(200, 23);
            txtQte.TabIndex = 6;
            // 
            // txtDestinataire
            // 
            txtDestinataire.Location = new Point(650, 57);
            txtDestinataire.Name = "txtDestinataire";
            txtDestinataire.PlaceholderText = "Destinataire (optionnel)";
            txtDestinataire.Size = new Size(200, 23);
            txtDestinataire.TabIndex = 7;
            // 
            // btnValider
            // 
            btnValider.Location = new Point(362, 125);
            btnValider.Name = "btnValider";
            btnValider.Size = new Size(200, 30);
            btnValider.TabIndex = 8;
            btnValider.Text = "Valider";
            btnValider.Click += btnValider_Click;
            // 
            // dgv
            // 
            dgv.Location = new Point(12, 197);
            dgv.MultiSelect = false;
            dgv.Name = "dgv";
            dgv.ReadOnly = true;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.Size = new Size(991, 285);
            dgv.TabIndex = 9;
            // 
            // lblProd
            // 
            lblProd.Location = new Point(20, 20);
            lblProd.Name = "lblProd";
            lblProd.Size = new Size(100, 23);
            lblProd.TabIndex = 0;
            lblProd.Text = "Matériel :";
            // 
            // lblType
            // 
            lblType.Location = new Point(20, 60);
            lblType.Name = "lblType";
            lblType.Size = new Size(100, 23);
            lblType.TabIndex = 1;
            lblType.Text = "Type :";
            // 
            // lblQte
            // 
            lblQte.Location = new Point(550, 15);
            lblQte.Name = "lblQte";
            lblQte.Size = new Size(100, 23);
            lblQte.TabIndex = 2;
            lblQte.Text = "Quantité :";
            // 
            // lblDestinataire
            // 
            lblDestinataire.Location = new Point(550, 57);
            lblDestinataire.Name = "lblDestinataire";
            lblDestinataire.Size = new Size(100, 23);
            lblDestinataire.TabIndex = 3;
            lblDestinataire.Text = "Destinataire :";
            // 
            // FormMouvement
            // 
            ClientSize = new Size(1015, 533);
            Controls.Add(lblProd);
            Controls.Add(lblType);
            Controls.Add(lblQte);
            Controls.Add(lblDestinataire);
            Controls.Add(cboProd);
            Controls.Add(cboType);
            Controls.Add(txtQte);
            Controls.Add(txtDestinataire);
            Controls.Add(btnValider);
            Controls.Add(dgv);
            Name = "FormMouvement";
            Text = "Mouvements de Stock";
            ((System.ComponentModel.ISupportInitialize)dgv).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
