using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pryPozzoIE
{
    public partial class frmLogoEmpresa : Form
    {
        public frmLogoEmpresa()
        {
            InitializeComponent();
        }

        int contadorTiempo = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            contadorTiempo += 1000;
            if (contadorTiempo > 3000)
            {
                this.Hide();
                frmLogin formularioLoguin = new frmLogin();
                formularioLoguin.Show();
                timer1.Enabled = false;
            }

        }

        private void frmLogoEmpresa_Load(object sender, EventArgs e)
        {

        }
    }
}
