namespace Piskvorky
{
    partial class Hlavni_Okno
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.hraci_plocha = new Piskvorky.Hraci_plocha();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.menu_konec = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_nova_hra = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_hra = new System.Windows.Forms.ToolStripMenuItem();
            this.nova_hra = new System.Windows.Forms.ToolStripMenuItem();
            this.konec = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripNovaHra = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // hraci_plocha
            // 
            this.hraci_plocha.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.hraci_plocha.Barva_mrizky = System.Drawing.Color.Maroon;
            this.hraci_plocha.Location = new System.Drawing.Point(12, 31);
            this.hraci_plocha.Name = "hraci_plocha";
            this.hraci_plocha.Size = new System.Drawing.Size(408, 410);
            this.hraci_plocha.TabIndex = 0;
            this.hraci_plocha.Velikost_hraci_plochy = 20;
            this.hraci_plocha.Velikost_policka = 20;
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(71, 6);
            // 
            // menu_konec
            // 
            this.menu_konec.Name = "menu_konec";
            this.menu_konec.Size = new System.Drawing.Size(152, 26);
            this.menu_konec.Text = "Konec";
            // 
            // menu_nova_hra
            // 
            this.menu_nova_hra.Name = "menu_nova_hra";
            this.menu_nova_hra.Size = new System.Drawing.Size(152, 26);
            this.menu_nova_hra.Text = "Nová hra";
            // 
            // menu_hra
            // 
            this.menu_hra.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nova_hra,
            this.konec});
            this.menu_hra.Name = "menu_hra";
            this.menu_hra.Size = new System.Drawing.Size(47, 24);
            this.menu_hra.Text = "Hra";
            // 
            // nova_hra
            // 
            this.nova_hra.Name = "nova_hra";
            this.nova_hra.Size = new System.Drawing.Size(152, 26);
            this.nova_hra.Text = "Nová hra";
            // 
            // konec
            // 
            this.konec.Name = "konec";
            this.konec.Size = new System.Drawing.Size(152, 26);
            this.konec.Text = "Konec";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripNovaHra});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(432, 28);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStripNovaHra_ItemClicked);
            // 
            // toolStripNovaHra
            // 
            this.toolStripNovaHra.Name = "toolStripNovaHra";
            this.toolStripNovaHra.Size = new System.Drawing.Size(83, 24);
            this.toolStripNovaHra.Text = "Nová hra";
            // 
            // Hlavni_Okno
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(432, 453);
            this.Controls.Add(this.hraci_plocha);
            this.Controls.Add(this.menuStrip1);
            this.Name = "Hlavni_Okno";
            this.Text = "Piskvorky 1.0";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Hraci_plocha hraci_plocha;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem menu_konec;
        private System.Windows.Forms.ToolStripMenuItem menu_nova_hra;
        private System.Windows.Forms.ToolStripMenuItem menu_hra;
        private System.Windows.Forms.ToolStripMenuItem nova_hra;
        private System.Windows.Forms.ToolStripMenuItem konec;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripNovaHra;
    }
}

