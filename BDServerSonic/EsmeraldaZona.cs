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
    public partial class EsmeraldaZona : Form
    {
        string consulta;
        public EsmeraldaZona()
        {
            InitializeComponent();
        }

        private void EsmeraldaZona_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }
        private void MostrarDatos()
        {
            dataGridView1.DataSource = ConexionMySQL.EjecutaConsultaSelect("SELECT * FROM EsmeraldaZona ORDER BY idEsmeraldaZona");
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string idEsmeralda = textBox1.Text;
            string idZona = textBox2.Text;

            consulta = "INSERT INTO EsmeraldaZona(idEsmeralda, idZona) VALUES ('" + idEsmeralda + "', + '" + idZona + "')";
            ConexionMySQL.EjecutaConsulta(consulta);
            MostrarDatos();

            textBox1.Clear();
            textBox2.Clear();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            string idEsmeralda = textBox1.Text;
            string idZona = textBox2.Text;

            int idEsmeraldaZona = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE EsmeraldaZona SET idEsmeralda = '" + idEsmeralda + "',idZona = '" + idZona + "'  WHERE idEsmeraldaZona = " + idEsmeraldaZona.ToString();
            ConexionMySQL.EjecutaConsulta(consulta);
            MostrarDatos();

            textBox1.Clear();
            textBox2.Clear();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            int idEsmeraldaZona = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE EsmeraldaZona SET  estatus = 0 WHERE idEsmeraldaZona =  " + idEsmeraldaZona.ToString();
            ConexionMySQL.EjecutaConsulta(consulta);
            MostrarDatos();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            EstiloVisual app = new EstiloVisual();
            app.Show();
            this.Hide();
        }
    }
}
