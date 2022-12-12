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
    public partial class ModoDeJuegoJugador : Form
    {
        string consulta;
        public ModoDeJuegoJugador()
        {
            InitializeComponent();
        }

        private void ModoDeJuegoJugador_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }
        private void MostrarDatos()
        {
            dataGridView1.DataSource = ConexionMySQL.EjecutaConsultaSelect("SELECT * FROM ModoDeJuegoJugador ORDER BY idModoDeJuegoJugador");
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string idModoDeJuego = textBox1.Text;
            string idJugador = textBox2.Text;


            consulta = "INSERT INTO ModoDeJuegoJugador(idModoDeJuego, idJugador) VALUES ('" + idModoDeJuego + "', + '" + idJugador + "')";
            ConexionMySQL.EjecutaConsulta(consulta);
            MostrarDatos();

            textBox1.Clear();
            textBox2.Clear();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            string idModoDeJuego = textBox1.Text;
            string idJugador = textBox2.Text;


            int idModoDeJuegoJugador = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE ModoDeJuegoJugador SET idModoDeJuego = '" + idModoDeJuego + "',idJugador = '" + idJugador + "'  WHERE idModoDeJuegoJugador = " + idModoDeJuegoJugador.ToString();
            ConexionMySQL.EjecutaConsulta(consulta);
            MostrarDatos();

            textBox1.Clear();
            textBox2.Clear();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            int idModoDeJuegoJugador = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE ModoDeJuegoJugador SET  estatus = 0 WHERE idModoDeJuegoJugador =  " + idModoDeJuegoJugador.ToString(); ;
            ConexionMySQL.EjecutaConsulta(consulta);
            MostrarDatos();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            Mundo app = new Mundo();
            app.Show();
            this.Hide();
        }
    }
}
