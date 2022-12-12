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
    public partial class EstiloVisual : Form
    {
        string consulta;
        public EstiloVisual()
        {
            InitializeComponent();
        }

        private void EstiloVisual_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }
        private void MostrarDatos()
        {
            dataGridView1.DataSource = ConexionMySQL.EjecutaConsultaSelect("SELECT * FROM EstiloVisual ORDER BY idEstiloVisual");
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string Nombre = textBox1.Text;
            string Detalles = textBox3.Text;
            string idMundo = textBox4.Text;

            consulta = "INSERT INTO EstiloVisual(Nombre, Detalles, idMundo) VALUES ('" + Nombre + "', '" + Detalles + "', '" + idMundo + "')";
            ConexionMySQL.EjecutaConsulta(consulta);
            MostrarDatos();

            textBox1.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            string Nombre = textBox1.Text;
            string Detalles = textBox3.Text;
            string idMundo = textBox4.Text;
            int idEstiloVisual = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE EstiloVisual SET Nombre = '" + Nombre + "',Detalles = '" + Detalles + "',idMundo = '" + idMundo + "'  WHERE idEstiloVisual = " + idEstiloVisual.ToString();
            ConexionMySQL.EjecutaConsulta(consulta);
            MostrarDatos();

            textBox1.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            int idEstiloVisual = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE EstiloVisual SET  estatus = 0 WHERE idEstiloVisual =  " + idEstiloVisual.ToString(); ;
            ConexionMySQL.EjecutaConsulta(consulta);
            MostrarDatos();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            Extra app = new Extra();
            app.Show();
            this.Hide();
        }
    }
}
