using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace BDServerSonic
{
    public partial class Jugador : Form
    {
        string consulta;
        public Jugador()
        {
            InitializeComponent();
        }

        private void Jugador_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }
        private void MostrarDatos()
        {
            dataGridView1.DataSource = ConexionMySQL.EjecutaConsultaSelect("SELECT * FROM Jugador ORDER BY idJugador");
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string Nombre = textBox1.Text;
           

            consulta = "INSERT INTO Jugador(Nombre) VALUES ('" + Nombre + "')";
            ConexionMySQL.EjecutaConsulta(consulta);
            MostrarDatos();

            textBox1.Clear();
           
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            string Nombre = textBox1.Text;
           

            int idJugador = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE Jugador SET Nombre = '" + Nombre +  "'  WHERE idJugador = " + idJugador.ToString();
            ConexionMySQL.EjecutaConsulta(consulta);
            MostrarDatos();

            textBox1.Clear();
           
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            int idJugador = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE Jugador SET  estatus = 0 WHERE idJugador =  " + idJugador.ToString();
            ConexionMySQL.EjecutaConsulta(consulta);
            MostrarDatos();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            Marcador app = new Marcador();
            app.Show();
            this.Hide();
        }
    }
}
