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
    public partial class RutaZona : Form
    {
        string consulta;
        public RutaZona()
        {
            InitializeComponent();
        }

        private void RutaZona_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }
        private void MostrarDatos()
        {
            dataGridView1.DataSource = ConexionMySQL.EjecutaConsultaSelect("SELECT * FROM RutaZona ORDER BY idRutaZona");
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string idRuta = textBox1.Text;
            string idZona = textBox2.Text;


            consulta = "INSERT INTO RutaZona(idRuta, idZona) VALUES ('" + idRuta + "', + '" + idZona + "')";
            ConexionMySQL.EjecutaConsulta(consulta);
            MostrarDatos();

            textBox1.Clear();
            textBox2.Clear();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            string idRuta = textBox1.Text;
            string idZona = textBox2.Text;


            int idRutaZona = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE RutaZona SET idRuta = '" + idRuta + "',idZona = '" + idZona + "'  WHERE idRutaZona = " + idRutaZona.ToString();
            ConexionMySQL.EjecutaConsulta(consulta);
            MostrarDatos();

            textBox1.Clear();
            textBox2.Clear();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            int idRutaZona = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE RutaZona SET  estatus = 0 WHERE idRutaZona =  " + idRutaZona.ToString(); ;
            ConexionMySQL.EjecutaConsulta(consulta);
            MostrarDatos();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            Saga app = new Saga();
            app.Show();
            this.Hide();
        }
    }
}
