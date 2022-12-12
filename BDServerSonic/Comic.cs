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
    public partial class Comic : Form
    {
        string consulta;
        public Comic()
        {
            InitializeComponent();
        }

        private void Comic_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }
        private void MostrarDatos()
        {
            dataGridView1.DataSource = ConexionMySQL.EjecutaConsultaSelect("SELECT * FROM Comic ORDER BY idComic");
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string Nombre = textBox1.Text;
            string Editorial = textBox2.Text;
            string Descripcion = textBox3.Text;
            string idSaga = textBox4.Text;

            consulta = "INSERT INTO CajaDeObjeto(Nombre, Editorial, Descripcion, idSaga) VALUES ('" + Nombre + "', + '" + Editorial + "', '" + Descripcion + "', '" + idSaga + "')";
            ConexionMySQL.EjecutaConsulta(consulta);
            MostrarDatos();

            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            string Nombre = textBox1.Text;
            string Editorial = textBox2.Text;
            string Descripcion = textBox3.Text;
            string idSaga = textBox4.Text;
            int idComic = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE CajaDeObjeto SET Nombre = '" + Nombre + "',Editorial = '" + Editorial + "',Descripcion = '" + Descripcion + "',idSaga = '" + idSaga + "'  WHERE idComic = " + idComic.ToString();
            ConexionMySQL.EjecutaConsulta(consulta);
            MostrarDatos();

            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            int idComic = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE Comic SET  estatus = 0 WHERE idComic =  " + idComic.ToString(); ;
            ConexionMySQL.EjecutaConsulta(consulta);
            MostrarDatos();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            Competencia app = new Competencia();
            app.Show();
            this.Hide();
        }
    }
}
