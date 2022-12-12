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
    public partial class SerieSaga : Form
    {
        string consulta;
        public SerieSaga()
        {
            InitializeComponent();
        }

        private void SerieSaga_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }
        private void MostrarDatos()
        {
            dataGridView1.DataSource = ConexionMySQL.EjecutaConsultaSelect("SELECT * FROM SerieSaga ORDER BY idSerieSaga");
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string idSerie = textBox1.Text;
            string idSaga = textBox2.Text;


            consulta = "INSERT INTO SerieSaga(idSerie, idSaga) VALUES ('" + idSerie + "', + '" + idSaga + "')";
            ConexionMySQL.EjecutaConsulta(consulta);
            MostrarDatos();

            textBox1.Clear();
            textBox2.Clear();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            string idSerie = textBox1.Text;
            string idSaga = textBox2.Text;


            int idSerieSaga = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE SerieSaga SET idSerie = '" + idSerie + "',idSaga = '" + idSaga + "'  WHERE idSerieSaga = " + idSerieSaga.ToString();
            ConexionMySQL.EjecutaConsulta(consulta);
            MostrarDatos();

            textBox1.Clear();
            textBox2.Clear();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            int idSerieSaga = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE SerieSaga SET  estatus = 0 WHERE idSerieSaga =  " + idSerieSaga.ToString(); ;
            ConexionMySQL.EjecutaConsulta(consulta);
            MostrarDatos();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            Team app = new Team();
            app.Show();
            this.Hide();
        }
    }
}
