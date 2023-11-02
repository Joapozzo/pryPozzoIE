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
            cargarGrilla();
        }

        private void cargarGrilla()
        {
            string archivoProveedor = @"../../archivos/Listado de aseguradores.csv";
            dgvDatosRegistro.Rows.Clear();
            try
            {
                using (StreamReader sr = new StreamReader(archivoProveedor))
                {
                    string readLine = sr.ReadLine();
                    if (readLine != null)
                    {
                        readLine = sr.ReadLine();
                        string[] separador = readLine.Split(';');

                        HashSet<string> jurisdiccionesUnicas = new HashSet<string>();
                        HashSet<string> responsablesUnicos = new HashSet<string>();
                        HashSet<string> juzgadosUnicos = new HashSet<string>();



                        while (!sr.EndOfStream)
                        {
                            separador = readLine.Split(';');
                            dgvDatosRegistro.Rows.Add(separador);

                            

                            juzgadosUnicos.Add(separador[4]);
                            jurisdiccionesUnicas.Add(separador[5]);
                            responsablesUnicos.Add(separador[7]);

                            readLine = sr.ReadLine();
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

                        foreach (string juzgado in juzgadosUnicos)
                        {
                            cmbJuzgado.Items.Add(juzgado);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el archivo: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void limpiarGrilla()
        {
            dgvDatosRegistro.Rows.Clear();
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
            string Expediente = txtNumExpediente.Text;
            string Juzgado = cmbJuzgado.Text;
            string Jurisdiccion = cmbJurisdiccion.Text;
            string Direccion = txtDireccion.Text;
            string Liquidador = cmbResponsable.Text;
            DateTime fechaApertura = dtpApertura.Value;

            clsRegistroProveedor registroProveedor = new clsRegistroProveedor();
            registroProveedor.Registrar(Numero, Entidad, fechaApertura, Expediente, Juzgado, Jurisdiccion, Direccion, Liquidador);
            cargarGrilla();

        }

        private void dgvDatosRegistro_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dgvDatosRegistro.Rows[e.RowIndex];

                string numeroRegistro = selectedRow.Cells[0].Value.ToString();
                string entidad = selectedRow.Cells[1].Value.ToString();
                DateTime apertura = DateTime.Parse(selectedRow.Cells[2].Value.ToString());
                string numExpediente = selectedRow.Cells[3].Value.ToString();
                string juzgado = selectedRow.Cells[4].Value.ToString();
                string jurisdiccion = selectedRow.Cells[5].Value.ToString();
                string direccion = selectedRow.Cells[6].Value.ToString();
                string responsable = selectedRow.Cells[7].Value.ToString();

                txtNumeroRegistro.Text = numeroRegistro;
                txtEntidad.Text = entidad;
                dtpApertura.Value = apertura;
                txtNumExpediente.Text = numExpediente;
                cmbJuzgado.Text = juzgado;
                cmbJurisdiccion.Text = jurisdiccion;
                txtDireccion.Text = direccion;
                cmbResponsable.Text = responsable;
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            int Numero = int.Parse(txtNumeroRegistro.Text);
            string Entidad = txtEntidad.Text;
            string Expediente = txtNumExpediente.Text;
            string Juzgado = cmbJuzgado.Text;
            string Jurisdiccion = cmbJurisdiccion.Text;
            string Direccion = txtDireccion.Text;
            string Liquidador = cmbResponsable.Text;
            DateTime fechaApertura = dtpApertura.Value;
            clsRegistroProveedor registroProveedor = new clsRegistroProveedor();
            registroProveedor.Modificar(Numero, Entidad, fechaApertura, Expediente, Juzgado, Jurisdiccion, Direccion, Liquidador);
            cargarGrilla();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int Numero = int.Parse(txtNumeroRegistro.Text);
            string Entidad = txtEntidad.Text;
            string Expediente = txtNumExpediente.Text;
            string Juzgado = cmbJuzgado.Text;
            string Jurisdiccion = cmbJurisdiccion.Text;
            string Direccion = txtDireccion.Text;
            string Liquidador = cmbResponsable.Text;
            DateTime fechaApertura = dtpApertura.Value;
            clsRegistroProveedor registroProveedor = new clsRegistroProveedor();
            registroProveedor.Eliminar(Numero);
            cargarGrilla();

        }
    }

        
}