using EXF.Data.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EXF.Data
{
    internal class ConexionMySql
    {
        string connectionString = "server=localhost;database=db_universidad;user=root;password=Marcos";

        private MySqlConnection connection;

        public ConexionMySql()
        {
            connection = new MySqlConnection(connectionString);
        }

        public void Insertar(Usuario usr)
        {
            try
            {
                string query = "INSERT INTO venta_productos_electronicos (id_producto, nombre_producto, marca, modelo, precio_unitario, stock, fecha_venta) VALUES (@idproducto, @nombreProducto, @marca, @modelo, @precioUnitario, @stock, @fechaVenta)";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@idproducto", usr.Id);
                cmd.Parameters.AddWithValue("@nombreProducto", usr.nombreProducto);
                cmd.Parameters.AddWithValue("@marca", usr.marca);
                cmd.Parameters.AddWithValue("@modelo", usr.modelo);
                cmd.Parameters.AddWithValue("@precioUnitario", usr.precioUnitario);
                cmd.Parameters.AddWithValue("@stock", usr.stock);
                cmd.Parameters.AddWithValue("@fechaVenta", usr.fechaVenta);
                connection.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar el registro: " + ex.Message);
            }
            finally { connection.Close(); }
        }
        public List<Usuario> ObtenerTodosLosUsuarios()
        {
            List<Usuario> usuarios = new List<Usuario>();
            string query = "SELECT * FROM venta_productos_electronicos";
            MySqlCommand cmd = new MySqlCommand(query, connection);

            try
            {
                connection.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Usuario usuario = new Usuario
                        (
                            ID: reader.GetInt32("ID"),
                            Nombreproducto: reader.GetString("Nombre"),
                            Marca: reader.GetString("Marca"),
                            Modelo: reader.GetString("Modelo"),
                            Preciounitario: reader.GetDecimal("Precio"),
                            Stock: reader.GetInt32("Stock"),
                            FechaVenta: reader.GetDateTime("Stock")
                        );
                    usuarios.Add(usuario);
                }
                reader.Close();
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
            Console.WriteLine("Total de registros recuperados: " + usuarios.Count);
            return usuarios;
        }
        public void Eliminar(int idProducto)
        {
            try
            {
                string query = "DELETE FROM venta_productos_electronicos WHERE id_producto = @idProducto";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@idProducto", idProducto);
                connection.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar el registro: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

    }
}

