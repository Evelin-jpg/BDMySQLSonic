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
    public partial class Team : Form
    {
        string consulta;
        public Team()
        {
            InitializeComponent();
        }

        private void Team_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }
        private void MostrarDatos()
        {
            dataGridView1.DataSource = ConexionMySQL.EjecutaConsultaSelect("SELECT * FROM Team ORDER BY idTeam");
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string Nombre = textBox1.Text;
            string Descripcion = textBox3.Text;
            string idPersonaje = textBox4.Text;

            consulta = "INSERT INTO Team(Nombre, Descripcion, idPersonaje) VALUES ('" + Nombre + "', '" + Descripcion + "', '" + idPersonaje + "')";
            ConexionMySQL.EjecutaConsulta(consulta);
            MostrarDatos();

            textBox1.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            string Nombre = textBox1.Text;
            string Descripcion = textBox3.Text;
            string idPersonaje = textBox4.Text;
            int idTeam = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE Team SET Nombre = '" + Nombre + "',Descripcion = '" + Descripcion + "',idPersonaje = '" + idPersonaje + "'  WHERE idTeam = " + idTeam.ToString();
            ConexionMySQL.EjecutaConsulta(consulta);
            MostrarDatos();

            textBox1.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            int idTeam = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE Team SET  estatus = 0 WHERE idTeam =  " + idTeam.ToString(); ;
            ConexionMySQL.EjecutaConsulta(consulta);
            MostrarDatos();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            TeamPersonaje app = new TeamPersonaje();
            app.Show();
            this.Hide();
        }
    }
}
