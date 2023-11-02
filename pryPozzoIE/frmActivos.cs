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
    public partial class frmActivos : Form
    {
        public frmActivos()
        {
            InitializeComponent();
        }

        private void AgregarCarpetasYArchivos(TreeNode parentNode, string ruta)
        {
            try
            {
                // Obtener carpetas y archivos dentro de la ruta especificada
                string[] carpetas = Directory.GetDirectories(ruta);
                string[] archivos = Directory.GetFiles(ruta);

                // Agregar carpetas al nodo actual
                foreach (string nombrecarpeta in carpetas)
                {
                    TreeNode carpetaNode = new TreeNode(Path.GetFileName(nombrecarpeta));
                    parentNode.Nodes.Add(carpetaNode);

                    // Llamar recursivamente para agregar carpetas y archivos dentro de esta carpeta
                    AgregarCarpetasYArchivos(carpetaNode, nombrecarpeta);
                }

                // Agregar archivos al nodo actual
                foreach (string nombreArchivo in archivos)
                {
                    TreeNode archivoNode = new TreeNode(Path.GetFileName(nombreArchivo));
                    archivoNode.Tag = nombreArchivo; // Almacena la ruta completa del archivo como un valor asociado
                    parentNode.Nodes.Add(archivoNode);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void frmActivos_Load(object sender, EventArgs e)
        {
            string rutaCompleta = @"../../archivos/Proveedores";

            // Agregar la carpeta principal al árbol
            TreeNode rootNode = new TreeNode("Carpetas y Archivos del Proyecto");
            tvCarpetas.Nodes.Add(rootNode);

            // Llamamos a un método recursivo para agregar carpetas y archivos
            AgregarCarpetasYArchivos(rootNode, rutaCompleta);
        }

        private void tvCarpetas_AfterSelect_1(object sender, TreeViewEventArgs e)
        {
            TreeNode selectedNode = e.Node;

            // Comprueba si el nodo seleccionado es un archivo (en lugar de una carpeta)
            if (selectedNode.Tag != null)
            {
                string archivoSeleccionado = selectedNode.Tag.ToString(); // Obtiene la ruta completa del archivo

                try
                {
                    // Lee el contenido del archivo
                    string contenido = File.ReadAllText(archivoSeleccionado);

                    rtbContenido.Visible = true;
                    // Muestra el contenido en el RichTextBox
                    rtbContenido.Text = contenido;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al abrir el archivo: " + ex.Message);
                }
            }
            else
            {
                // Si no es un archivo, borra el contenido del RichTextBox
                rtbContenido.Text = "";
            }
        }
    }
}
