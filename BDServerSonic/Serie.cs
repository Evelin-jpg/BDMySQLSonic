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
    public partial class Serie : Form
    {
        string consulta;
        public Serie()
        {
            InitializeComponent();
        }

        private void Serie_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }
        private void MostrarDatos()
        {
            dataGridView1.DataSource = ConexionMySQL.EjecutaConsultaSelect("SELECT * FROM Serie ORDER BY idSerie");
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string Nombre = textBox1.Text;
            string Descripcion = textBox3.Text;
            string idSaga = textBox4.Text;

            consulta = "INSERT INTO Serie(Nombre, Descripcion, idSaga) VALUES ('" + Nombre + "', '" + Descripcion + "', '" + idSaga + "')";
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
            string idSaga = textBox4.Text;
            int idSerie = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE Serie SET Nombre = '" + Nombre + "',Descripcion = '" + Descripcion + "',idSaga = '" + idSaga + "'  WHERE idSerie = " + idSerie.ToString();
            ConexionMySQL.EjecutaConsulta(consulta);
            MostrarDatos();

            textBox1.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            int idSerie = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE Serie SET  estatus = 0 WHERE idSerie =  " + idSerie.ToString(); ;
            ConexionMySQL.EjecutaConsulta(consulta);
            MostrarDatos();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            SerieSaga app = new SerieSaga();
            app.Show();
            this.Hide();
        }
    }
}
