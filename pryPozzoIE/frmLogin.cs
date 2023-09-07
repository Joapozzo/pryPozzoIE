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

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }

        private void txtContraseña_TextChanged(object sender, EventArgs e)
        {
            if (txtContraseña.Text !="")
            {
                btnLogin.Enabled = true;
            }
            else
            {
                btnLogin.Enabled = false;
            }
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

        private void txtUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            //// Verificar si la tecla presionada es una letra o una tecla de control.
            //if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))
            //{
            //    // Si no es una letra ni una tecla de control, se suprime la entrada.
            //    e.Handled = true;
            //}
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
           
            //si el usuario y pass son correctos
            string usuario = txtUsuario.Text;
            string contraseña = txtContraseña.Text;

            // Ruta del archivo que contiene los datos de usuario y contraseña
            string archivoUsuarios = "usuarios.txt";
            // Verificar si el archivo existe
            int intentos = 0;
            if (File.Exists(archivoUsuarios))
            {
                using (StreamReader sr = new StreamReader(archivoUsuarios))
                {
                    string linea;
                    while ((linea = sr.ReadLine()) != null)
                    {
                        // Dividir la línea en usuario y contraseña
                        string[] partes = linea.Split(':');

                        if (partes.Length == 2)
                        {
                            string usuarioArchivo = partes[0];
                            string contraseñaArchivo = partes[1];

                            // Verificar si los datos coinciden
                            if (usuario == usuarioArchivo && contraseña == contraseñaArchivo && intentos < 3)
                            {
                                MessageBox.Show("Inicio de sesión válido.");
                                this.Hide();
                                frmMain forMain = new frmMain();
                                forMain.ShowDialog();
                                break;
                            }
                            else
                            {
                                MessageBox.Show("Usuario o contraseña incorrectos.");
                                intentos = intentos + 1;
                                MessageBox.Show(intentos + " de 3 intentos");
                                clearText();
                                break;
                            }
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("El archivo de usuarios no existe.");
            }

            //registro de log
            StreamWriter sw = new StreamWriter("logInicio", true);

            sw.WriteLine(txtUsuario.Text + " - Fecha: " + DateTime.Now);

            sw.Close();
        }

        public void clearText() 
        {
            txtContraseña.Text = "";
            txtUsuario.Text = "";
        }

    }
}
