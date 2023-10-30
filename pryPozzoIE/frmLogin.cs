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
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void txtUsuario_TextChanged(object sender, EventArgs e)
        {
            if (txtUsuario.Text != "")
            {
                txtContraseña.Enabled = true;
            }
            else
            {
                txtContraseña.Enabled = false;
            }

        }

        int intentos = 0;
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text;
            string contraseña = txtContraseña.Text;

            clsUser objUser = clsUser.Login(usuario, contraseña);

            if (objUser != null)
            {
                clsUser.RegisterLog(usuario);
                this.Hide();
                frmMain forMain = new frmMain(objUser);
                forMain.ShowDialog();
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                intentos++;
                MessageBox.Show(intentos + " de 3 intentos");
                clearText();

                if (intentos >= 3)
                {
                    MessageBox.Show("Usted se ha quedado sin intentos, por favor espere " + (contador.Interval / 1000) + " segundos", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtUsuario.Enabled = false;
                    txtContraseña.Enabled = false;
                    btnLogin.Enabled = false;

                    contador.Tick += contador_Tick;
                    contador.Start();
                }
            }
        }


        public void clearText() 
        {
            txtContraseña.Text = "";
            txtUsuario.Text = "";
        }
        private void contador_Tick(object sender, EventArgs e)
        {
            // Habilitar el botón y detener el temporizador.
            intentos = 0;
            txtUsuario.Enabled = true;
            txtContraseña.Enabled = true;
            btnLogin.Enabled = true;
            contador.Stop();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }

        private void btnRegistrarse_Click(object sender, EventArgs e)
        {
            frmRegistrar fRegistrar = new frmRegistrar();
            fRegistrar.ShowDialog();
            this.Hide();
        }
    }
}
