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
                this.usuarioActual = usuarioActual;
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
                lblUsuarioMain.Text = usuarioActual.User;
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

        }

        private void activosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRegistroProveedor frmRegProv = new frmRegistroProveedor();
            frmRegProv.ShowDialog();

            int idUsuarioActual = usuarioActual.Id;
            DateTime fechaLog = DateTime.Now;
            string categoria = registroProveedor.Text;

            clsUser objMenuClick = new clsUser();
            objMenuClick.MenuLog(idUsuarioActual, fechaLog, categoria);
        }
    }
}
