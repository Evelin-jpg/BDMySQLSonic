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
    public partial class ZonaMundo : Form
    {
        string consulta;
        public ZonaMundo()
        {
            InitializeComponent();
        }

        private void ZonaMundo_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }
        private void MostrarDatos()
        {
            dataGridView1.DataSource = ConexionMySQL.EjecutaConsultaSelect("SELECT * FROM ZonaMundo ORDER BY idZonaMundo");
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string idZona = textBox1.Text;
            string idMundo = textBox2.Text;


            consulta = "INSERT INTO ZonaMundo(idZona, idMundo) VALUES ('" + idZona + "', + '" + idMundo + "')";
            ConexionMySQL.EjecutaConsulta(consulta);
            MostrarDatos();

            textBox1.Clear();
            textBox2.Clear();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            string idZona = textBox1.Text;
            string idMundo = textBox2.Text;


            int idZonaMundo = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE ZonaMundo SET idZona = '" + idZona + "',idMundo = '" + idMundo + "'  WHERE idZonaMundo = " + idZonaMundo.ToString();
            ConexionMySQL.EjecutaConsulta(consulta);
            MostrarDatos();

            textBox1.Clear();
            textBox2.Clear();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            int idZonaMundo = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE ZonaMundo SET  estatus = 0 WHERE idZonaMundo =  " + idZonaMundo.ToString(); ;
            ConexionMySQL.EjecutaConsulta(consulta);
            MostrarDatos();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            ZonaEspecial app = new ZonaEspecial();
            app.Show();
            this.Hide();
        }
    }
}
