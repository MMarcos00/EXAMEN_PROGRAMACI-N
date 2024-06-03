using EXF.Data;
using EXF.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Configuration;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EXF
{
    public partial class Form1 : Form
    {
        ConexionMySql Clscone = new ConexionMySql();

        Usuario usr = new Usuario();
        List<Usuario> todos = new List<Usuario>();
        ClsCursor cursor1 = new ClsCursor();
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonGrabar_Click(object sender, EventArgs e)
        {
            decimal precio = decimal.Parse(textBoxPrecio.Text);
            int stock = int.Parse(textBoxStock.Text);
            int idProducto = int.Parse(textBoxIdProducto.Text);

            Clscone.Insertar(usr);

            MessageBox.Show("Registro agregado correctamente");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            usr.nombreProducto = textBoxNombre.Text;
            usr.marca = textBoxMarca.Text;
            usr.modelo = textBoxModelo.Text;
            usr.precioUnitario = decimal.Parse(textBoxPrecio.Text);
            usr.stock = int.Parse(textBoxStock.Text);
            usr.fechaVenta = dateTimePicker1.Value;
            usr.Id = int.Parse(textBoxIdProducto.Text);
            Clscone.Insertar(usr);
            MessageBox.Show("Registro agregado correctamente");

        }
        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxModelo_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonTodos_Click(object sender, EventArgs e)
        {

            MessageBox.Show("xxx");


            todos = Clscone.ObtenerTodosLosUsuarios(); 

            
            if (todos.Count > 0)
            {
                dataGridView1.DataSource = todos;  
                cursor1.totalRegistros = todos.Count;
                MessageBox.Show("Total de registros: " + cursor1.totalRegistros);
            }
            else
            {
                MessageBox.Show("NO hay registros");
            }
        }

        private void MostrarRegistros()
        {
            if(cursor1.current >= 0 && cursor1.current < cursor1.totalRegistros)
            {
                Usuario u = todos[cursor1.current];
                textBoxIdProducto.Text = u.Id.ToString();
                textBoxNombre.Text = u.nombreProducto;
                textBoxMarca.Text = u.marca;
                textBoxModelo.Text = u.modelo;
                textBoxPrecio.Text = u.precioUnitario.ToString();
                textBoxStock.Text = u.stock.ToString();
                dateTimePicker1.Value = u.fechaVenta;
                cursor1.current++;
                if(cursor1.current >= cursor1.totalRegistros)
                {
                    cursor1.current = 0;
                    MessageBox.Show("Fin de Registros");
                }

            }
        }
        private void buttonSiguiente_Click(object sender, EventArgs e)
        {
            MostrarRegistros();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void buttonEliminar_Click(object sender, EventArgs e)
        {
            int idProducto = int.Parse(textBoxIdProducto.Text);

            Clscone.Eliminar(idProducto);

            MessageBox.Show("Registro eliminado correctamente");

            
            todos = Clscone.ObtenerTodosLosUsuarios();
            dataGridView1.DataSource = todos;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void buttonActualizar_Click(object sender, EventArgs e)
        {
            
        }
    }
}
