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
    public partial class PortalMundo : Form
    {
        string consulta;
        public PortalMundo()
        {
            InitializeComponent();
        }

        private void PortalMundo_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }
        private void MostrarDatos()
        {
            dataGridView1.DataSource = ConexionMySQL.EjecutaConsultaSelect("SELECT * FROM PortalMundo ORDER BY idPortalMundo");
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string idPortal = textBox1.Text;
            string idMundo = textBox2.Text;


            consulta = "INSERT INTO PortalMundo(idPortal, idMundo) VALUES ('" + idPortal + "', + '" + idMundo + "')";
            ConexionMySQL.EjecutaConsulta(consulta);
            MostrarDatos();

            textBox1.Clear();
            textBox2.Clear();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            string idPortal = textBox1.Text;
            string idMundo = textBox2.Text;


            int idPortalMundo = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE PortalMundo SET idPortal = '" + idPortal + "',idMundo = '" + idMundo + "'  WHERE idPortalMundo = " + idPortalMundo.ToString();
            ConexionMySQL.EjecutaConsulta(consulta);
            MostrarDatos();

            textBox1.Clear();
            textBox2.Clear();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            int idPortalMundo = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE PortalMundo SET  estatus = 0 WHERE idPortalMundo =  " + idPortalMundo.ToString(); ;
            ConexionMySQL.EjecutaConsulta(consulta);
            MostrarDatos();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            PuntoDeControl app = new PuntoDeControl();
            app.Show();
            this.Hide();
        }
    }
}
