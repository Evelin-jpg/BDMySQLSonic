using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BDServerSonic
{
    public partial class Menu : Form
    {
        string consulta;
        public Menu()
        {
            InitializeComponent();
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }
        private void MostrarDatos()
        {
            dataGridView1.DataSource = ConexionMySQL.EjecutaConsultaSelect("SELECT * FROM Menu ORDER BY idMenu");
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string Nombre = textBox1.Text;
            string Descripcion = textBox2.Text;
            string AyudaYOpciones = textBox3.Text;
            string idJugador = textBox4.Text;

            consulta = "INSERT INTO Menu(Nombre, Descripcion, AyudaYOpciones, idJugador) VALUES ('" + Nombre + "', + '" + Descripcion + "', '" + AyudaYOpciones + "', '" + idJugador + "')";
            ConexionMySQL.EjecutaConsulta(consulta);
            MostrarDatos();

            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            string Nombre = textBox1.Text;
            string Descripcion = textBox2.Text;
            string AyudaYOpciones = textBox3.Text;
            string idJugador = textBox4.Text;
            int idMenu = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE Menu SET Nombre = '" + Nombre + "',Descripcion = '" + Descripcion + "',AyudaYOpciones = '" + AyudaYOpciones + "',idJugador = '" + idJugador + "'  WHERE idMenu = " + idMenu.ToString();
            ConexionMySQL.EjecutaConsulta(consulta);
            MostrarDatos();

            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            int idMenu = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE Menu SET  estatus = 0 WHERE idMenu =  " + idMenu.ToString(); ;
            ConexionMySQL.EjecutaConsulta(consulta);
            MostrarDatos();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            Mercancia app = new Mercancia();
            app.Show();
            this.Hide();
        }
    }
}
