using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pryPozzoIE
{
    internal class clsRegistroProveedor
    {
        public void Registrar(Int32 id, string entidad, DateTime apertura, int expediente, string juzg, string juri, string direccion, string liquidador)
        {
            string archivoProveedor = "Listado de aseguradores.csv";

            try
            {
                // Crear una lista para almacenar los IDs existentes en el archivo
                List<int> idsExistentes = new List<int>();

                using (StreamReader sr = new StreamReader(archivoProveedor))
                {
                    string readLine;
                    while ((readLine = sr.ReadLine()) != null)
                    {
                        string[] separador = readLine.Split(';');

                        // Verificar si se pueden convertir los elementos de la línea a los tipos adecuados
                        if (separador.Length >= 1 && int.TryParse(separador[0], out int existingID))
                        {
                            idsExistentes.Add(existingID);
                        }
                    }
                }

                // Verificar si el ID ya existe en la lista de IDs existentes
                if (!idsExistentes.Contains(id))
                {
                    string nuevoRegistro = $"{id};{entidad};{apertura};{expediente};{juzg};{juri};{direccion};{liquidador}";

                    using (StreamWriter sw = new StreamWriter(archivoProveedor, true))
                    {
                        sw.WriteLine(nuevoRegistro);
                    }
                }
                else
                {
                    MessageBox.Show("El ID ya existe en el archivo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el archivo: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Modificar(Int32 id, string entidad, DateTime apertura, string expediente, string juzg, string juri, string direccion, string liquidador)
        {
            string archivoProveedor = "Listado de aseguradores.csv";

            try
            {
                List<string> lineas = new List<string>();
                bool primerLinea = true;

                using (StreamReader lector = new StreamReader(archivoProveedor))
                {
                    string readLine;
                    while ((readLine = lector.ReadLine()) != null)
                    {
                        string[] separador = readLine.Split(';');

                        if (separador.Length > 0 && int.TryParse(separador[0], out int existingID))
                        {
                            if (existingID == id)
                            {
                                string nuevaLinea = $"{id};{entidad};{apertura};{expediente};{juzg};{juri};{direccion};{liquidador}";
                                lineas.Add(nuevaLinea);
                            }
                            else
                            {
                                lineas.Add(readLine);
                            }
                        }
                    }
                }

                // Escribe las líneas en el archivo original
                using (StreamWriter sw = new StreamWriter(archivoProveedor, false))
                {
                    foreach (string linea in lineas)
                    {
                        // Agregar la primera línea con los títulos de las columnas
                        if (primerLinea)
                        {
                            sw.WriteLine(linea);
                            primerLinea = false;
                        }
                        else
                        {
                            sw.WriteLine(linea);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al modificar el archivo: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Eliminar(Int32 id)
        {
            string archivoProveedor = "Listado de aseguradores.csv";

            try
            {
                List<string> lineas = new List<string>();
                bool primerLinea = true; // Para mantener la primera línea con los títulos de las columnas

                using (StreamReader lector = new StreamReader(archivoProveedor))
                {
                    string readLine;
                    while ((readLine = lector.ReadLine()) != null)
                    {
                        string[] separador = readLine.Split(';');

                        if (separador.Length > 0 && int.TryParse(separador[0], out int existingID))
                        {
                            if (existingID == id)
                            {
                                // No agregamos esta línea, lo que equivale a eliminar el registro
                            }
                            else
                            {
                                lineas.Add(readLine);
                            }
                        }
                    }
                }

                // Escribe las líneas en el archivo original
                using (StreamWriter sw = new StreamWriter(archivoProveedor, false))
                {
                    foreach (string linea in lineas)
                    {
                        // Agregar la primera línea con los títulos de las columnas
                        if (primerLinea)
                        {
                            sw.WriteLine(linea);
                            primerLinea = false;
                        }
                        else
                        {
                            sw.WriteLine(linea);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al borrar el registro: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
