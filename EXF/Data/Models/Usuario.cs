using EXF.Data.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EXF.Data.Models
{
    internal class Usuario
    {
        public int Id { get; set; }
        public string nombreProducto { get; set; }
        public string marca { get; set; }
        public string modelo { get; set; }
        public decimal precioUnitario { get; set; }
        public int stock { get; set; }
        public DateTime fechaVenta { get; set; }

        public Usuario(int ID, string Nombreproducto, string Marca, string Modelo, decimal Preciounitario, int Stock, DateTime FechaVenta)
        {
            Id = ID;
            nombreProducto = Nombreproducto;
            marca = Marca;
            modelo = Modelo;
            precioUnitario = Preciounitario;
            stock = Stock;
            fechaVenta = FechaVenta;

        }
        public Usuario()
        {

        }
    }
}


