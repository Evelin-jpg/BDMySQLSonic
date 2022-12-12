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
    public partial class RingZona : Form
    {
        string consulta;
        public RingZona()
        {
            InitializeComponent();
        }

        private void RingZona_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }
        private void MostrarDatos()
        {
            dataGridView1.DataSource = ConexionMySQL.EjecutaConsultaSelect("SELECT * FROM RingZona ORDER BY idRingZona");
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string idRing = textBox1.Text;
            string idZona = textBox2.Text;


            consulta = "INSERT INTO RingZona(idRing, idZona) VALUES ('" + idRing + "', + '" + idZona + "')";
            ConexionMySQL.EjecutaConsulta(consulta);
            MostrarDatos();

            textBox1.Clear();
            textBox2.Clear();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            string idRing = textBox1.Text;
            string idZona = textBox2.Text;


            int idRingZona = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE RingZona SET idRing = '" + idRing + "',idZona = '" + idZona + "'  WHERE idRingZona = " + idRingZona.ToString();
            ConexionMySQL.EjecutaConsulta(consulta);
            MostrarDatos();

            textBox1.Clear();
            textBox2.Clear();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            int idRingZona = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE RingZona SET  estatus = 0 WHERE idRingZona =  " + idRingZona.ToString(); ;
            ConexionMySQL.EjecutaConsulta(consulta);
            MostrarDatos();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            Ruta app = new Ruta();
            app.Show();
            this.Hide();
        }
    }
}
