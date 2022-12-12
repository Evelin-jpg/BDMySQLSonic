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
    public partial class Plataforma : Form
    {
        string consulta;
        public Plataforma()
        {
            InitializeComponent();
        }

        private void Plataforma_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }
        private void MostrarDatos()
        {
            dataGridView1.DataSource = ConexionMySQL.EjecutaConsultaSelect("SELECT * FROM Plataforma ORDER BY idPlataforma");
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string Nombre = textBox1.Text;
            string Tipo = textBox3.Text;
            string idMundo = textBox4.Text;

            consulta = "INSERT INTO Plataforma(Nombre, Tipo, idMundo) VALUES ('" + Nombre + "', '" + Tipo + "', '" + idMundo + "')";
            ConexionMySQL.EjecutaConsulta(consulta);
            MostrarDatos();

            textBox1.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            string Nombre = textBox1.Text;
            string Tipo = textBox3.Text;
            string idMundo = textBox4.Text;
            int idPlataforma = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE Plataforma SET Nombre = '" + Nombre + "',Tipo = '" + Tipo + "',idMundo = '" + idMundo + "'  WHERE idPlataforma = " + idPlataforma.ToString();
            ConexionMySQL.EjecutaConsulta(consulta);
            MostrarDatos();

            textBox1.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            int idPlataforma = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE Plataforma SET  estatus = 0 WHERE idPlataforma =  " + idPlataforma.ToString(); ;
            ConexionMySQL.EjecutaConsulta(consulta);
            MostrarDatos();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            Poder app = new Poder();
            app.Show();
            this.Hide();
        }
    }
}
