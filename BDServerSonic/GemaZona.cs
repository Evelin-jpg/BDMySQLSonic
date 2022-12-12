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
    public partial class GemaZona : Form
    {
        string consulta;
        public GemaZona()
        {
            InitializeComponent();
        }

        private void GemaZona_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }
        private void MostrarDatos()
        {
            dataGridView1.DataSource = ConexionMySQL.EjecutaConsultaSelect("SELECT * FROM GemaZona ORDER BY idGemaZona");
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string idGema = textBox1.Text;
            string idZona = textBox2.Text;

            consulta = "INSERT INTO GemaZona(idGema, idZona) VALUES ('" + idGema + "', + '" + idZona + "')";
            ConexionMySQL.EjecutaConsulta(consulta);
            MostrarDatos();

            textBox1.Clear();
            textBox2.Clear();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            string idGema = textBox1.Text;
            string idZona = textBox2.Text;

            int idGemaZona = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE GemaZona SET idGema = '" + idGema + "',idZona = '" + idZona + "'  WHERE idGemaZona = " + idGemaZona.ToString();
            ConexionMySQL.EjecutaConsulta(consulta);
            MostrarDatos();

            textBox1.Clear();
            textBox2.Clear();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            int idGemaZona = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE GemaZona SET  estatus = 0 WHERE idGemaZona =  " + idGemaZona.ToString();
            ConexionMySQL.EjecutaConsulta(consulta);
            MostrarDatos();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            Habilidad app = new Habilidad();
            app.Show();
            this.Hide();
        }
    }
}
