namespace StockApp
{
    partial class FormStock
    {
        private System.ComponentModel.IContainer components = null;
        private DataGridView dgvStock;
        private TextBox txtFiltre;
        private Label lblFiltre;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            dgvStock = new DataGridView();
            txtFiltre = new TextBox();
            lblFiltre = new Label();
            SuspendLayout();

            // Label filtre
            lblFiltre.Text = "Filtrer par matériel / seuil :";
            lblFiltre.Location = new System.Drawing.Point(20, 20);
            lblFiltre.Size = new System.Drawing.Size(200, 23);

            // TextBox filtre
            txtFiltre.Location = new System.Drawing.Point(230, 20);
            txtFiltre.Size = new System.Drawing.Size(200, 23);
            txtFiltre.TextChanged += txtFiltre_TextChanged;

            // DataGridView
            dgvStock.Location = new System.Drawing.Point(20, 60);
            dgvStock.Size = new System.Drawing.Size(600, 350);
            dgvStock.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvStock.MultiSelect = false;
            dgvStock.ReadOnly = true;

            // Form
            ClientSize = new System.Drawing.Size(650, 450);
            Controls.Add(lblFiltre);
            Controls.Add(txtFiltre);
            Controls.Add(dgvStock);
            Text = "Gestion du Stock";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
