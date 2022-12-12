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
    public partial class JefeZona : Form
    {
        string consulta;
        public JefeZona()
        {
            InitializeComponent();
        }

        private void JefeZona_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }
        private void MostrarDatos()
        {
            dataGridView1.DataSource = ConexionMySQL.EjecutaConsultaSelect("SELECT * FROM JefeZona ORDER BY idJefeZona");
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string idJefe = textBox1.Text;
            string idZona = textBox2.Text;

            consulta = "INSERT INTO JefeZona(idJefe, idZona) VALUES ('" + idJefe + "', + '" + idZona + "')";
            ConexionMySQL.EjecutaConsulta(consulta);
            MostrarDatos();

            textBox1.Clear();
            textBox2.Clear();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            string idJefe = textBox1.Text;
            string idZona = textBox2.Text;

            int idJefeZona = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE JefeZona SET idJefe = '" + idJefe + "',idZona = '" + idZona + "'  WHERE idJefeZona = " + idJefeZona.ToString();
            ConexionMySQL.EjecutaConsulta(consulta);
            MostrarDatos();

            textBox1.Clear();
            textBox2.Clear();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            int idJefeZona = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE JefeZona SET  estatus = 0 WHERE idJefeZona =  " + idJefeZona.ToString();
            ConexionMySQL.EjecutaConsulta(consulta);
            MostrarDatos();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            Jugador app = new Jugador();
            app.Show();
            this.Hide();
        }
    }
}
