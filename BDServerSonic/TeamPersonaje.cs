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
    public partial class TeamPersonaje : Form
    {
        string consulta;
        public TeamPersonaje()
        {
            InitializeComponent();
        }

        private void TeamPersonaje_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }
        private void MostrarDatos()
        {
            dataGridView1.DataSource = ConexionMySQL.EjecutaConsultaSelect("SELECT * FROM TeamPersonaje ORDER BY idTeamPersonaje");
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string idTeam = textBox1.Text;
            string idPersonaje = textBox2.Text;


            consulta = "INSERT INTO TeamPersonaje(idTeam, idPersonaje) VALUES ('" + idTeam + "', + '" + idPersonaje + "')";
            ConexionMySQL.EjecutaConsulta(consulta);
            MostrarDatos();

            textBox1.Clear();
            textBox2.Clear();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            string idTeam = textBox1.Text;
            string idPersonaje = textBox2.Text;


            int idTeamPersonaje = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE TeamPersonaje SET idTeam = '" + idTeam + "',idPersonaje = '" + idPersonaje + "'  WHERE idTeamPersonaje = " + idTeamPersonaje.ToString();
            ConexionMySQL.EjecutaConsulta(consulta);
            MostrarDatos();

            textBox1.Clear();
            textBox2.Clear();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            int idTeamPersonaje = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE TeamPersonaje SET  estatus = 0 WHERE idTeamPersonaje =  " + idTeamPersonaje.ToString(); ;
            ConexionMySQL.EjecutaConsulta(consulta);
            MostrarDatos();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            Tiempo app = new Tiempo();
            app.Show();
            this.Hide();
        }
    }
}
