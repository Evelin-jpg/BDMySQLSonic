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
    public partial class Musica : Form
    {
        string consulta;
        public Musica()
        {
            InitializeComponent();
        }

        private void Musica_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }
        private void MostrarDatos()
        {
            dataGridView1.DataSource = ConexionMySQL.EjecutaConsultaSelect("SELECT * FROM Musica ORDER BY idMusica");
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string Nombre = textBox1.Text;
            string Genero = textBox3.Text;
            string idJugador = textBox4.Text;

            consulta = "INSERT INTO Musica(Nombre, Genero, idJugador) VALUES ('" + Nombre + "', '" + Genero + "', '" + idJugador + "')";
            ConexionMySQL.EjecutaConsulta(consulta);
            MostrarDatos();

            textBox1.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            string Nombre = textBox1.Text;
            string Genero = textBox3.Text;
            string idJugador = textBox4.Text;
            int idMusica = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE Musica SET Nombre = '" + Nombre + "',Genero = '" + Genero + "',idJugador = '" + idJugador + "'  WHERE idMusica = " + idMusica.ToString();
            ConexionMySQL.EjecutaConsulta(consulta);
            MostrarDatos();

            textBox1.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            int idMusica = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE Musica SET  estatus = 0 WHERE idMusica =  " + idMusica.ToString(); ;
            ConexionMySQL.EjecutaConsulta(consulta);
            MostrarDatos();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            Personaje app = new Personaje();
            app.Show();
            this.Hide();
        }
    }
}
