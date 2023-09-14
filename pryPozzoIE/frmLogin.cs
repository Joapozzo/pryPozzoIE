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

        private void txtContraseña_TextChanged(object sender, EventArgs e)
        {
            //if (txtContraseña.Text !="")
            //{
            //    btnLogin.Enabled = true;
            //}
            //else
            //{
            //    btnLogin.Enabled = false;
            //}
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
        bool inicioSesionExitoso = false;
        string usuarioIngresado;
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text;
            string contraseña = txtContraseña.Text;
            string archivoUsuarios = "usuarios.txt";
            bool inicioSesionExitoso = false;

            if (File.Exists(archivoUsuarios))
            {
                using (StreamReader sr = new StreamReader(archivoUsuarios))
                {
                    string linea;
                    while ((linea = sr.ReadLine()) != null)
                    {
                        
                        string[] partes = linea.Split(':');

                        if (partes.Length == 2)
                        {
                            string usuarioArchivo = partes[0];
                            string contraseñaArchivo = partes[1];

                            
                            if (usuario == usuarioArchivo && contraseña == contraseñaArchivo && intentos < 3)
                            {
                                clsUser objUser = new clsUser();
                                
                                usuarioIngresado = partes[0];

                                objUser.saveUser(usuarioIngresado);
                                MessageBox.Show("Inicio de sesión válido.", "Bienvenido", MessageBoxButtons.OK);
                                registerLog();
                                this.Hide();
                                frmMain forMain = new frmMain();
                                forMain.ShowDialog();
                                inicioSesionExitoso = true;
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

            if (!inicioSesionExitoso && intentos < 3)
            {
                MessageBox.Show("Usuario o contraseña incorrectos.", "Error", MessageBoxButtons.OK ,MessageBoxIcon.Error);
                intentos++;
                MessageBox.Show(intentos + " de 3 intentos");
                clearText();
            }

            if (!inicioSesionExitoso && intentos >= 3)
            {
                MessageBox.Show("Usted se ha quedado sin intentos, por favor espere " + (contador.Interval / 1000) + " segundos", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsuario.Enabled = false;
                txtContraseña.Enabled = false;
                btnLogin.Enabled = false;

                contador.Tick += contador_Tick;
                contador.Start();
            }
        }

        public void registerLog() 
        {
            StreamWriter sw = new StreamWriter("logInicio", true);

            sw.WriteLine(txtUsuario.Text + " - Fecha: " + DateTime.Now);

            sw.Close();
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
    }
}
