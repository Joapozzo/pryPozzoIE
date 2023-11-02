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
    public partial class frmRegistrar : Form
    {
        public frmRegistrar()
        {
            InitializeComponent();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (txtContraseña.Text != txtRepetirContraseña.Text)
            {
                MessageBox.Show("Las contraseñas no coinciden");
            }
            else
            {            
                string newUser = txtUsuario.Text;
                string newPassword = txtContraseña.Text;
                string rol = cmbRol.Text;

                clsUser objUser = new clsUser();
                objUser.RegistrarUsuario(newUser, newPassword, rol);
                frmLogin fLogin = new frmLogin();
                fLogin.ShowDialog();
                this.Hide();
            }

        }

        private void cmbRol_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbRol.SelectedIndex != -1)
            {
                txtContraseña.Enabled = true;
            }
            else
            {
                txtContraseña.Enabled = false;
            }
        }

        private void txtUsuario_TextChanged(object sender, EventArgs e)
        {
            if (txtUsuario.Text != "")
            {
                cmbRol.Enabled = true;
            }
            else
            {
                cmbRol.Enabled = false;
            }
        }

        private void txtContraseña_TextChanged(object sender, EventArgs e)
        {
            if (txtContraseña.Text != "")
            {
                txtRepetirContraseña.Enabled = true;
            }
            else
            {
                txtRepetirContraseña.Enabled = false;
            }
        }

        private void txtRepetirContraseña_TextChanged(object sender, EventArgs e)
        {
            if (txtRepetirContraseña.Text != "")
            {
                btnRegistrar.Enabled = true;
            }
            else
            {
                btnRegistrar.Enabled = false;
            }
        }

        private void frmRegistrar_Load(object sender, EventArgs e)
        {

        }
    }
}
