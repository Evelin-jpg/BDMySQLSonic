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
    public partial class SagaJugador : Form
    {
        string consulta;
        public SagaJugador()
        {
            InitializeComponent();
        }

        private void SagaJugador_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }
        private void MostrarDatos()
        {
            dataGridView1.DataSource = ConexionMySQL.EjecutaConsultaSelect("SELECT * FROM SagaJugador ORDER BY idSagaJugador");
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string idSaga = textBox1.Text;
            string idJugador = textBox2.Text;


            consulta = "INSERT INTO SagaJugador(idSaga, idJugador) VALUES ('" + idSaga + "', + '" + idJugador + "')";
            ConexionMySQL.EjecutaConsulta(consulta);
            MostrarDatos();

            textBox1.Clear();
            textBox2.Clear();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            string idSaga = textBox1.Text;
            string idJugador = textBox2.Text;


            int idSagaJugador = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE SagaJugador SET idSaga = '" + idSaga + "',idJugador = '" + idJugador + "'  WHERE idSagaJugador = " + idSagaJugador.ToString();
            ConexionMySQL.EjecutaConsulta(consulta);
            MostrarDatos();

            textBox1.Clear();
            textBox2.Clear();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            int idSagaJugador = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE SagaJugador SET  estatus = 0 WHERE idSagaJugador =  " + idSagaJugador.ToString(); ;
            ConexionMySQL.EjecutaConsulta(consulta);
            MostrarDatos();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            Serie app = new Serie();
            app.Show();
            this.Hide();
        }
    }
}
