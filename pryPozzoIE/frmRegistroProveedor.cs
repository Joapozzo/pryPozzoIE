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
    public partial class frmRegistroProveedor : Form
    {
        public frmRegistroProveedor()
        {
            InitializeComponent();
        }
        private void frmRegistroProveedor_Load(object sender, EventArgs e)
        {
            string archivoProveedor = "Listado de aseguradores.csv";

            try
            {
                using (StreamReader sr = new StreamReader(archivoProveedor))
                {
                    string readLine = sr.ReadLine();
                    if (readLine != null)
                    {
                        string[] separador = readLine.Split(';');

                        foreach (string columna in separador)
                        {
                            dgvDatosRegistro.Columns.Add(columna, columna);
                        }

                        HashSet<string> jurisdiccionesUnicas = new HashSet<string>();
                        HashSet<string> responsablesUnicos = new HashSet<string>();


                        while (!sr.EndOfStream)
                        {
                            readLine = sr.ReadLine();
                            separador = readLine.Split(';');
                            dgvDatosRegistro.Rows.Add(separador);

                            jurisdiccionesUnicas.Add(separador[5]);
                            responsablesUnicos.Add(separador[7]);


                        }

                        //Carga de jurisdiccions unicas sin repetir
                        foreach (string jurisdiccion in jurisdiccionesUnicas)
                        {
                            cmbJurisdiccion.Items.Add(jurisdiccion);
                        }

                        foreach (string responsable in responsablesUnicos)
                        {
                            cmbResponsable.Items.Add(responsable);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el archivo: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtNumeroRegistro_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            int Numero = int.Parse(txtNumeroRegistro.Text);
            string Entidad = txtEntidad.Text;
            int Expediente = int.Parse(txtNumExpediente.Text);
            string Jurisdiccion = cmbJurisdiccion.Text;
            string Direccion = txtDireccion.Text;
            string Liquidador = cmbResponsable.Text;
            DateTime fechaApertura = dtpApertura.Value;

            clsRegistroProveedor registroProveedor = new clsRegistroProveedor();
            registroProveedor.Registrar(Numero, Entidad, fechaApertura, Expediente, Jurisdiccion, Direccion, Liquidador);
        }
    }
}