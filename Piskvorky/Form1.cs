using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Piskvorky
{
    public partial class Hlavni_Okno : Form
    {
        public Hlavni_Okno()
        {
            InitializeComponent();
        }

        private void toolStripNovaHra_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            hraci_plocha.Start_hry();
        }
    }
}
