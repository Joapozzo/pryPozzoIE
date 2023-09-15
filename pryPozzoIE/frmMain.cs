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
    internal partial class frmMain : Form
    {

        public clsUser usuarioActual;

        public frmMain(clsUser usuarioActual)
        {
            InitializeComponent();

            if (usuarioActual != null)
            {
                this.usuarioActual = usuarioActual; // Usa 'this' para referenciar la variable miembro
            }
            else
            {
                // Maneja el caso en el que usuarioActual sea null si es necesario
            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            if (usuarioActual != null)
            {
                lblUsuarioMain.Text = usuarioActual.UserName;
            }
        }

        int contador = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {   
            contador += 1;

            if (contador > 1)
            {
                lblDateMenu.Text = Convert.ToString(DateTime.Now.ToString("HH:mm:ss"));
            }

        }

        private void activosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //registro de log
            StreamWriter sw = new StreamWriter("logGeneral", true);

            sw.WriteLine(lblUsuarioMain.Text + " - Fecha: " + DateTime.Now + " - Accede: " + menuActivo.Text );

            sw.Close();

            frmRegistroProveedor f = new frmRegistroProveedor();
            f.ShowDialog();
        }

        private void activosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Registro
            StreamWriter sw = new StreamWriter("logGeneral", true);

            sw.WriteLine(lblUsuarioMain.Text + " - Fecha: " + DateTime.Now + " - Accede: " + registroProeedor.Text);

            sw.Close();


        }
    }
}
