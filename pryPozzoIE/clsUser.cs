using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.OleDb;

namespace pryPozzoIE
{
    internal class clsUser
    {
        //Guardamos datos del usuario actual
        public string User { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }

        public void ConectarBase()
        {
            string rutaArchivo = @"../../archivos/usuarios.accdb";
            string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + rutaArchivo;
            OleDbConnection conn = new OleDbConnection(connectionString);

            try
            {
                conn.Open();
            }
            catch (OleDbException)
            {
                MessageBox.Show("Test");
            }
            finally
            {
                conn.Close();
            }
        }


        //procedimiento validar usuario y contraseña
        public static bool Login(string usuario, string contraseña)
        {
            string rutaArchivo = @"../../archivos/usuarios.accdb";
            string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + rutaArchivo;
            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                conn.Open();
                string sql = "SELECT COUNT(*) FROM Usuarios WHERE Usuario = @Usuario AND Contraseña = @Contraseña";
                using (OleDbCommand cmd = new OleDbCommand(sql, conn))
                {

                    try
                    {
                        cmd.Parameters.AddWithValue("@Usuario", usuario);
                        cmd.Parameters.AddWithValue("@Contraseña", contraseña);
                        int count = (int)cmd.ExecuteScalar();
                        return count > 0;
                    }

                    catch (OleDbException ex)
                    {
                        MessageBox.Show(ex.Message);
                        throw;
                    }
                }
            }

        }

        public static void RegisterLog(string usuario)
        {
            StreamWriter sw = new StreamWriter("logInicio.txt", true);
            sw.WriteLine("Inicio sesion el usuario: " + usuario + " - Fecha: " + DateTime.Now);
            sw.Close();
        }

        public void MenuLog()
        {
            string rutaArchivo = @"../../archivos/usuarios.accdb";
            string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + rutaArchivo;

            // Usar parámetros en lugar de insertar valores directamente en la sentencia SQL
            string sql = "INSERT INTO Logs(IdUsuario, Fecha, Categoria) VALUES (1, #10/10/2023#, 'ADM')";

            try
            {
                using (OleDbConnection conn = new OleDbConnection(connectionString))
                {
                    conn.Open();

                    using (OleDbCommand cmd = new OleDbCommand(sql, conn))
                    {
                        // Ejecutar la consulta
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
