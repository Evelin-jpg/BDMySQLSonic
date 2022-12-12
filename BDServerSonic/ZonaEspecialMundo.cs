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
    public partial class ZonaEspecialMundo : Form
    {
        string consulta;
        public ZonaEspecialMundo()
        {
            InitializeComponent();
        }

        private void ZonaEspecialMundo_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }
        private void MostrarDatos()
        {
            dataGridView1.DataSource = ConexionMySQL.EjecutaConsultaSelect("SELECT * FROM ZonaEspecialMundo ORDER BY idZonaEspecialMundo");
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string idZonaEspecial = textBox1.Text;
            string idMundo = textBox2.Text;


            consulta = "INSERT INTO ZonaEspecialMundo(idZonaEspecial, idMundo) VALUES ('" + idZonaEspecial + "', + '" + idMundo + "')";
            ConexionMySQL.EjecutaConsulta(consulta);
            MostrarDatos();

            textBox1.Clear();
            textBox2.Clear();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            string idZonaEspecial = textBox1.Text;
            string idMundo = textBox2.Text;


            int idZonaEspecialMundo = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE ZonaEspecialMundo SET idZonaEspecial = '" + idZonaEspecial + "',idMundo = '" + idMundo + "'  WHERE idZonaEspecialMundo = " + idZonaEspecialMundo.ToString();
            ConexionMySQL.EjecutaConsulta(consulta);
            MostrarDatos();

            textBox1.Clear();
            textBox2.Clear();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            int idZonaEspecialMundo = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE ZonaEspecialMundo SET  estatus = 0 WHERE idZonaEspecialMundo =  " + idZonaEspecialMundo.ToString(); ;
            ConexionMySQL.EjecutaConsulta(consulta);
            MostrarDatos();
        }
    }
}
