namespace StockApp
{
    partial class FormDashboard
    {
        private System.ComponentModel.IContainer components = null;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem menuProduit;
        private ToolStripMenuItem menuMouvement;
        private ToolStripMenuItem menuStock;
        private ToolStripMenuItem menuLogout;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            menuStrip1 = new MenuStrip();
            menuProduit = new ToolStripMenuItem();
            menuMouvement = new ToolStripMenuItem();
            menuStock = new ToolStripMenuItem();
            menuLogout = new ToolStripMenuItem();

            menuStrip1.SuspendLayout();
            SuspendLayout();

            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { menuProduit, menuMouvement, menuStock, menuLogout });
            menuStrip1.Location = new System.Drawing.Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new System.Drawing.Size(800, 24);
            menuStrip1.TabIndex = 0;

            // 
            // menuProduit
            // 
            menuProduit.Name = "menuProduit";
            menuProduit.Size = new System.Drawing.Size(63, 20);
            menuProduit.Text = "Produits";
            menuProduit.Click += menuProduit_Click;

            // 
            // menuMouvement
            // 
            menuMouvement.Name = "menuMouvement";
            menuMouvement.Size = new System.Drawing.Size(120, 20);
            menuMouvement.Text = "Mouvements stock";
            menuMouvement.Click += menuMouvement_Click;

            // 
            // menuStock
            // 
            menuStock.Name = "menuStock";
            menuStock.Size = new System.Drawing.Size(50, 20);
            menuStock.Text = "Stock";
            menuStock.Click += menuStock_Click;

            // 
            // menuLogout
            // 
            menuLogout.Name = "menuLogout";
            menuLogout.Size = new System.Drawing.Size(89, 20);
            menuLogout.Text = "Déconnexion";
            menuLogout.Click += menuLogout_Click;

            // 
            // FormDashboard
            // 
            ClientSize = new System.Drawing.Size(800, 450);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "FormDashboard";
            Text = "Dashboard";
            Load += FormDashboard_Load;

            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
