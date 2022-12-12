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
    public partial class Final : Form
    {
        string consulta;
        public Final()
        {
            InitializeComponent();
        }

        private void Final_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }
        private void MostrarDatos()
        {
            dataGridView1.DataSource = ConexionMySQL.EjecutaConsultaSelect("SELECT * FROM Final ORDER BY idFinal");
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string Nombre = textBox1.Text;
            string Descripcion = textBox2.Text;

            consulta = "INSERT INTO Final(Nombre, Descripcion) VALUES ('" + Nombre + "', + '" + Descripcion + "')";
            ConexionMySQL.EjecutaConsulta(consulta);
            MostrarDatos();

            textBox1.Clear();
            textBox2.Clear();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            string Nombre = textBox1.Text;
            string Descripcion = textBox2.Text;

            int idFinal = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE Final SET Nombre = '" + Nombre + "',Descripcion = '" + Descripcion + "'  WHERE idFinal = " + idFinal.ToString();
            ConexionMySQL.EjecutaConsulta(consulta);
            MostrarDatos();

            textBox1.Clear();
            textBox2.Clear();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            int idFinal = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE Final SET  estatus = 0 WHERE idFinal =  " + idFinal.ToString();
            ConexionMySQL.EjecutaConsulta(consulta);
            MostrarDatos();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            FinalZona app = new FinalZona();
            app.Show();
            this.Hide();
        }
    }
}
