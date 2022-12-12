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
    public partial class Ruta : Form
    {
        string consulta;
        public Ruta()
        {
            InitializeComponent();
        }

        private void Ruta_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }
        private void MostrarDatos()
        {
            dataGridView1.DataSource = ConexionMySQL.EjecutaConsultaSelect("SELECT * FROM Ruta ORDER BY idRuta");
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string Tipo = textBox1.Text;
            string idZona = textBox2.Text;


            consulta = "INSERT INTO Ruta(Tipo, idZona) VALUES ('" + Tipo + "', + '" + idZona + "')";
            ConexionMySQL.EjecutaConsulta(consulta);
            MostrarDatos();

            textBox1.Clear();
            textBox2.Clear();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            string Tipo = textBox1.Text;
            string idZona = textBox2.Text;


            int idRuta = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE Ruta SET Tipo = '" + Tipo + "',idZona = '" + idZona + "'  WHERE idRuta = " + idRuta.ToString();
            ConexionMySQL.EjecutaConsulta(consulta);
            MostrarDatos();

            textBox1.Clear();
            textBox2.Clear();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            int idRuta = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE Ruta SET  estatus = 0 WHERE idRuta =  " + idRuta.ToString(); ;
            ConexionMySQL.EjecutaConsulta(consulta);
            MostrarDatos();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            RutaZona app = new RutaZona();
            app.Show();
            this.Hide();
        }
    }
}
