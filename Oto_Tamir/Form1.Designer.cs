namespace Oto_Tamir
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.müşterilerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tedarikçilerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.elemanlarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.araçlarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.işlemlerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ürünlerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stokToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.borçlarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.alacaklarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gelirGiderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.splitContainer1.Size = new System.Drawing.Size(284, 237);
            this.splitContainer1.SplitterDistance = 111;
            this.splitContainer1.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.müşterilerToolStripMenuItem,
            this.tedarikçilerToolStripMenuItem,
            this.elemanlarToolStripMenuItem,
            this.araçlarToolStripMenuItem,
            this.işlemlerToolStripMenuItem,
            this.ürünlerToolStripMenuItem,
            this.stokToolStripMenuItem,
            this.borçlarToolStripMenuItem,
            this.alacaklarToolStripMenuItem,
            this.gelirGiderToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(284, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // müşterilerToolStripMenuItem
            // 
            this.müşterilerToolStripMenuItem.Name = "müşterilerToolStripMenuItem";
            this.müşterilerToolStripMenuItem.Size = new System.Drawing.Size(72, 20);
            this.müşterilerToolStripMenuItem.Text = "Müşteriler";
            this.müşterilerToolStripMenuItem.Click += new System.EventHandler(this.müşterilerToolStripMenuItem_Click);
            // 
            // tedarikçilerToolStripMenuItem
            // 
            this.tedarikçilerToolStripMenuItem.Name = "tedarikçilerToolStripMenuItem";
            this.tedarikçilerToolStripMenuItem.Size = new System.Drawing.Size(78, 20);
            this.tedarikçilerToolStripMenuItem.Text = "Tedarikçiler";
            this.tedarikçilerToolStripMenuItem.Click += new System.EventHandler(this.tedarikcilerToolStripMenuItem_Click);
            // 
            // elemanlarToolStripMenuItem
            // 
            this.elemanlarToolStripMenuItem.Name = "elemanlarToolStripMenuItem";
            this.elemanlarToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.elemanlarToolStripMenuItem.Text = "Elemanlar";
            // 
            // araçlarToolStripMenuItem
            // 
            this.araçlarToolStripMenuItem.Name = "araçlarToolStripMenuItem";
            this.araçlarToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.araçlarToolStripMenuItem.Text = "Araçlar";
            // 
            // işlemlerToolStripMenuItem
            // 
            this.işlemlerToolStripMenuItem.Name = "işlemlerToolStripMenuItem";
            this.işlemlerToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.işlemlerToolStripMenuItem.Text = "İşlemler";
            // 
            // ürünlerToolStripMenuItem
            // 
            this.ürünlerToolStripMenuItem.Name = "ürünlerToolStripMenuItem";
            this.ürünlerToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
            this.ürünlerToolStripMenuItem.Text = "Ürünler";
            // 
            // stokToolStripMenuItem
            // 
            this.stokToolStripMenuItem.Name = "stokToolStripMenuItem";
            this.stokToolStripMenuItem.Size = new System.Drawing.Size(42, 20);
            this.stokToolStripMenuItem.Text = "Stok";
            // 
            // borçlarToolStripMenuItem
            // 
            this.borçlarToolStripMenuItem.Name = "borçlarToolStripMenuItem";
            this.borçlarToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.borçlarToolStripMenuItem.Text = "Borçlar";
            // 
            // alacaklarToolStripMenuItem
            // 
            this.alacaklarToolStripMenuItem.Name = "alacaklarToolStripMenuItem";
            this.alacaklarToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.alacaklarToolStripMenuItem.Text = "Alacaklar";
            // 
            // gelirGiderToolStripMenuItem
            // 
            this.gelirGiderToolStripMenuItem.Name = "gelirGiderToolStripMenuItem";
            this.gelirGiderToolStripMenuItem.Size = new System.Drawing.Size(76, 20);
            this.gelirGiderToolStripMenuItem.Text = "Gelir/Gider";
            // 
            // MainForm
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Ana Sayfa";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}

