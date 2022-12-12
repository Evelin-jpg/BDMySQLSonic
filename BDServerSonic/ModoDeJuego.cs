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
    public partial class ModoDeJuego : Form
    {
        string consulta;
        public ModoDeJuego()
        {
            InitializeComponent();
        }

        private void ModoDeJuego_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }
        private void MostrarDatos()
        {
            dataGridView1.DataSource = ConexionMySQL.EjecutaConsultaSelect("SELECT * FROM ModoDeJuego ORDER BY idModoDeJuego");
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string Nombre = textBox1.Text;
            string Descripcion = textBox2.Text;
            string Individual = textBox5.Text;
            string Multijugador = textBox3.Text;
            string idJugador = textBox4.Text;

            consulta = "INSERT INTO ModoDeJuego(Nombre, Descripcion, Individual,Multijugador, idJugador) VALUES ('" + Nombre + "', + '" + Descripcion + "','" + Individual + "', '" + Multijugador + "', '" + idJugador + "')";
            ConexionMySQL.EjecutaConsulta(consulta);
            MostrarDatos();

            textBox1.Clear();
            textBox2.Clear();
            textBox5.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            string Nombre = textBox1.Text;
            string Descripcion = textBox2.Text;
            string Individual = textBox5.Text;
            string Multijugador = textBox3.Text;
            string idJugador = textBox4.Text;
            int idModoDeJuego = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE ModoDeJuego SET Nombre = '" + Nombre + "',Descripcion = '" + Descripcion + "',Individual = '" + Individual + "',Multijugador = '" + Multijugador + "',idJugador = '" + idJugador + "'  WHERE idModoDeJuego = " + idModoDeJuego.ToString();
            ConexionMySQL.EjecutaConsulta(consulta);
            MostrarDatos();

            textBox1.Clear();
            textBox2.Clear();
            textBox5.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            int idModoDeJuego = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE ModoDeJuego SET  estatus = 0 WHERE idModoDeJuego =  " + idModoDeJuego.ToString(); ;
            ConexionMySQL.EjecutaConsulta(consulta);
            MostrarDatos();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            ModoDeJuegoJugador app = new ModoDeJuegoJugador();
            app.Show();
            this.Hide();
        }
    }
}
