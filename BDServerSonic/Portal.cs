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
    public partial class Portal : Form
    {
        string consulta;
        public Portal()
        {
            InitializeComponent();
        }

        private void Portal_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }
        private void MostrarDatos()
        {
            dataGridView1.DataSource = ConexionMySQL.EjecutaConsultaSelect("SELECT * FROM Portal ORDER BY idPortal");
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string Nombre = textBox1.Text;
            string Tipo = textBox3.Text;
            string idMundo = textBox4.Text;

            consulta = "INSERT INTO Portal(Nombre, Tipo, idMundo) VALUES ('" + Nombre + "', '" + Tipo + "', '" + idMundo + "')";
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
            int idPortal = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE Portal SET Nombre = '" + Nombre + "',Tipo = '" + Tipo + "',idMundo = '" + idMundo + "'  WHERE idPortal = " + idPortal.ToString();
            ConexionMySQL.EjecutaConsulta(consulta);
            MostrarDatos();

            textBox1.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            int idPortal = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE Portal SET  estatus = 0 WHERE idPortal =  " + idPortal.ToString(); ;
            ConexionMySQL.EjecutaConsulta(consulta);
            MostrarDatos();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            PortalMundo app = new PortalMundo();
            app.Show();
            this.Hide();
        }
    }
}
