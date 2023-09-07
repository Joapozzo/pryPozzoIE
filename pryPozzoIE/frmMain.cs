using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;

namespace pryPozzoIE
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        int contador = 0;

        private void timer1_Tick(object sender, EventArgs e)
        {   
            contador += 1;

            if (contador > 1)
            {
                toolStripStatusLabel2.Text = Convert.ToString(DateTime.Now.ToString("HH:mm:ss"));
            }

        }

        private void activosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //registro de log
            StreamWriter sw = new StreamWriter("logGeneral", true);

            sw.WriteLine(lblUsuario.Text + " - Fecha: " + DateTime.Now + " - Accede: " + menuActivo.Text );

            sw.Close();

            frmRegistroProveedor f = new frmRegistroProveedor();
            f.ShowDialog();
        }

        private void activosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StreamWriter sw = new StreamWriter("logGeneral", true);

            sw.WriteLine(lblUsuario.Text + " - Fecha: " + DateTime.Now + " - Accede: " + registroProeedor.Text);

            sw.Close();
        }
    }
}
