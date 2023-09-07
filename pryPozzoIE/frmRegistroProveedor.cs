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

        private void InitializeTreeView()
        {
            // Establecer la carpeta raíz
            string rootFolderPath = @"D:\Escritorio\Repo\pryPozzoIE\Resources";

            // Crear el nodo raíz
            TreeNode rootNode = new TreeNode("Resources");
            treeView1.Nodes.Add(rootNode);

            // Cargar las subcarpetas y archivos de la carpeta raíz
            LoadSubfoldersAndFiles(rootFolderPath, rootNode);
        }

        private void LoadSubfoldersAndFiles(string folderPath, TreeNode parentNode)
        {
            try
            {
                // Obtener la lista de subcarpetas y archivos en la carpeta actual
                string[] subdirectories = Directory.GetDirectories(folderPath);
                string[] files = Directory.GetFiles(folderPath);

                // Agregar las subcarpetas como nodos secundarios
                foreach (string subdirectory in subdirectories)
                {
                    TreeNode subfolderNode = new TreeNode(Path.GetFileName(subdirectory));
                    parentNode.Nodes.Add(subfolderNode);
                }

                // Agregar los archivos como nodos secundarios
                foreach (string file in files)
                {
                    TreeNode fileNode = new TreeNode(Path.GetFileName(file));
                    parentNode.Nodes.Add(fileNode);
                }
            }
            catch (Exception ex)
            {
                // Manejar errores, si es necesario
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            // Al seleccionar un nodo, cargar las subcarpetas y archivos dentro de esa carpeta
            TreeNode selectedNode = e.Node;
            string selectedFolderPath = Path.Combine(@"D:\Escritorio\Repo\pryPozzoIE\Resources", selectedNode.FullPath);
            LoadSubfoldersAndFiles(selectedFolderPath, selectedNode);
        }
    }
}
