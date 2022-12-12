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
    public partial class Competencia : Form
    {
        string consulta;
        public Competencia()
        {
            InitializeComponent();
        }

        private void Competencia_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }
        private void MostrarDatos()
        {
            dataGridView1.DataSource = ConexionMySQL.EjecutaConsultaSelect("SELECT * FROM Competencia ORDER BY idCompetencia");
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string Nombre = textBox1.Text;
            string Actividad = textBox2.Text;
            string Reto = textBox5.Text;
            string Descripcion = textBox3.Text;
            string idJugador = textBox4.Text;

            consulta = "INSERT INTO Competencia(Nombre, Actividad, Reto,Descripcion, idJugador) VALUES ('" + Nombre + "', + '" + Actividad + "','" + Reto + "', '" + Descripcion + "', '" + idJugador + "')";
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
            string Actividad = textBox2.Text;
            string Reto = textBox5.Text;
            string Descripcion = textBox3.Text;
            string idJugador = textBox4.Text;
            int idCompetencia = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE Competencia SET Nombre = '" + Nombre + "',Actividad = '" + Actividad + "',Reto = '" + Reto + "',Descripcion = '" + Descripcion + "',idJugador = '" + idJugador + "'  WHERE idCompetencia = " + idCompetencia.ToString();
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
            int idCompetencia = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE Competencia SET  estatus = 0 WHERE idCompetencia =  " + idCompetencia.ToString(); ;
            ConexionMySQL.EjecutaConsulta(consulta);
            MostrarDatos();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            Configuracion app = new Configuracion();
            app.Show();
            this.Hide();
        }
    }
}
