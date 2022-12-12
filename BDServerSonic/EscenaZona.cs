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
    public partial class EscenaZona : Form
    {
        string consulta;
        public EscenaZona()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string idEscena = textBox1.Text;
            string idZona = textBox2.Text;

            consulta = "INSERT INTO EscenaZona(idEscena, idZona) VALUES ('" + idEscena + "', + '" + idZona + "')";
            ConexionMySQL.EjecutaConsulta(consulta);
            MostrarDatos();

            textBox1.Clear();
            textBox2.Clear();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            string idEscena = textBox1.Text;
            string idZona = textBox2.Text;

            int idEscenaZona = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE EscenaZona SET idEscena = '" + idEscena + "',idZona = '" + idZona + "'  WHERE idEscenaZona = " + idEscenaZona.ToString();
            ConexionMySQL.EjecutaConsulta(consulta);
            MostrarDatos();

            textBox1.Clear();
            textBox2.Clear();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            int idEscenaZona = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE EscenaZona SET  estatus = 0 WHERE idEscenaZona =  " + idEscenaZona.ToString(); 
            ConexionMySQL.EjecutaConsulta(consulta);
            MostrarDatos();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            Escudo app = new Escudo();
            app.Show();
            this.Hide();
        }

        private void EscenaZona_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }
        private void MostrarDatos()
        {
            dataGridView1.DataSource = ConexionMySQL.EjecutaConsultaSelect("SELECT * FROM EscenaZona ORDER BY idEscenaZona");
        }
    }
}
