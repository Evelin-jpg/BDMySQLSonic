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
    public partial class Personaje : Form
    {
        string consulta;
        public Personaje()
        {
            InitializeComponent();
        }

        private void Personaje_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }
        private void MostrarDatos()
        {
            dataGridView1.DataSource = ConexionMySQL.EjecutaConsultaSelect("SELECT * FROM Personaje ORDER BY idPersonaje");
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string Nombre = textBox1.Text;
            string Especie = textBox2.Text;
            string Arco = textBox5.Text;
            string Descripcion = textBox3.Text;
            string idJugador = textBox4.Text;
            string idHistoria = textBox6.Text;

            consulta = "INSERT INTO Personaje(Nombre, Especie, Arco,Descripcion, idJugador, idHistoria) VALUES ('" + Nombre + "', + '" + Especie + "','" + Arco + "', '" + Descripcion + "', '" + idJugador + "', '" + idHistoria + "')";
            ConexionMySQL.EjecutaConsulta(consulta);
            MostrarDatos();

            textBox1.Clear();
            textBox2.Clear();
            textBox5.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox6.Clear();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            string Nombre = textBox1.Text;
            string Especie = textBox2.Text;
            string Arco = textBox5.Text;
            string Descripcion = textBox3.Text;
            string idJugador = textBox4.Text;
            string idHistoria = textBox6.Text;
            int idPersonaje = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE Personaje SET Nombre = '" + Nombre + "',Especie = '" + Especie + "',Arco = '" + Arco + "',Descripcion = '" + Descripcion + "',idJugador = '" + idJugador + "',idHistoria = '" + idHistoria + "'  WHERE idPersonaje = " + idPersonaje.ToString();
            ConexionMySQL.EjecutaConsulta(consulta);
            MostrarDatos();

            textBox1.Clear();
            textBox2.Clear();
            textBox5.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox6.Clear();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            int idPersonaje = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE Personaje SET  estatus = 0 WHERE idPersonaje =  " + idPersonaje.ToString(); ;
            ConexionMySQL.EjecutaConsulta(consulta);
            MostrarDatos();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            Plataforma app = new Plataforma();
            app.Show();
            this.Hide();
        }
    }
}
