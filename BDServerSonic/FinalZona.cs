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
    public partial class FinalZona : Form
    {
        string consulta;
        public FinalZona()
        {
            InitializeComponent();
        }

        private void FinalZona_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }
        private void MostrarDatos()
        {
            dataGridView1.DataSource = ConexionMySQL.EjecutaConsultaSelect("SELECT * FROM FinalZona ORDER BY idFinalZona");
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string idFinal = textBox1.Text;
            string idZona = textBox2.Text;

            consulta = "INSERT INTO FinalZona(idFinal, idZona) VALUES ('" + idFinal + "', + '" + idZona + "')";
            ConexionMySQL.EjecutaConsulta(consulta);
            MostrarDatos();

            textBox1.Clear();
            textBox2.Clear();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            string idFinal = textBox1.Text;
            string idZona = textBox2.Text;

            int idFinalZona = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE FinalZona SET idFinal = '" + idFinal + "',idZona = '" + idZona + "'  WHERE idFinalZona = " + idFinalZona.ToString();
            ConexionMySQL.EjecutaConsulta(consulta);
            MostrarDatos();

            textBox1.Clear();
            textBox2.Clear();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            int idFinalZona = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE FinalZona SET  estatus = 0 WHERE idFinalZona =  " + idFinalZona.ToString();
            ConexionMySQL.EjecutaConsulta(consulta);
            MostrarDatos();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            GameCenter app = new GameCenter();
            app.Show();
            this.Hide();
        }
    }
}
