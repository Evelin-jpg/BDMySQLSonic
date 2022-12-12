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
    public partial class Saga : Form
    {
        string consulta;
        public Saga()
        {
            InitializeComponent();
        }

        private void Saga_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }
        private void MostrarDatos()
        {
            dataGridView1.DataSource = ConexionMySQL.EjecutaConsultaSelect("SELECT * FROM Saga ORDER BY idSaga");
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string Nombre = textBox1.Text;
            string Descripcion = textBox3.Text;
            string idJugador = textBox4.Text;

            consulta = "INSERT INTO Saga(Nombre, Descripcion, idJugador) VALUES ('" + Nombre + "', '" + Descripcion + "', '" + idJugador + "')";
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
            string idJugador = textBox4.Text;
            int idSaga = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE Saga SET Nombre = '" + Nombre + "',Descripcion = '" + Descripcion + "',idJugador = '" + idJugador + "'  WHERE idSaga = " + idSaga.ToString();
            ConexionMySQL.EjecutaConsulta(consulta);
            MostrarDatos();

            textBox1.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            int idSaga = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE Saga SET  estatus = 0 WHERE idSaga =  " + idSaga.ToString(); ;
            ConexionMySQL.EjecutaConsulta(consulta);
            MostrarDatos();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            SagaJugador app = new SagaJugador();
            app.Show();
            this.Hide();
        }
    }
}
