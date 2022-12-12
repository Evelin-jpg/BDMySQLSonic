using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace BDServerSonic
{
    public partial class Acto : Form
    {
        
        string consulta;
        public Acto()
        {
            InitializeComponent();
        }

        private void Acto_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }

        private void MostrarDatos()
        {
            dataGridView1.DataSource = ConexionMySQL.EjecutaConsultaSelect("SELECT * FROM Acto ORDER BY idActo");
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string Nombre = textBox1.Text;
            string Nivel = textBox2.Text;
            string Descripcion = textBox3.Text;
            string idZona = textBox4.Text;

            consulta = "INSERT INTO Acto(Nombre, Nivel, Descripcion, idZona) VALUES ('" + Nombre + "', + '" + Nivel + "', '" + Descripcion + "', '" + idZona + "')";
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
            string Nivel = textBox2.Text;
            string Descripcion = textBox3.Text;
            string idZona = textBox4.Text;
            int idActo = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE Acto SET Nombre = '" + Nombre + "',Nivel = '" + Nivel + "',Descripcion = '" + Descripcion + "',idZona = '" + idZona + "'  WHERE idActo = " + idActo.ToString();
            ConexionMySQL.EjecutaConsulta(consulta);
            MostrarDatos();

            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            int idActo = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE Acto SET  estatus = 0 WHERE idActo =  " + idActo.ToString(); ;
            ConexionMySQL.EjecutaConsulta(consulta);
            MostrarDatos();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            Aliado app = new Aliado();
            app.Show();
            this.Hide();
        }

        private void Acto_Load_1(object sender, EventArgs e)
        {
            MostrarDatos();
        }
    }
}
