using Org.BouncyCastle.Bcpg.OpenPgp;
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
    public partial class PuntoDeControlZona : Form
    {
        string consulta;
        public PuntoDeControlZona()
        {
            InitializeComponent();
        }

        private void PuntoDeControlZona_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }
        private void MostrarDatos()
        {
            dataGridView1.DataSource = ConexionMySQL.EjecutaConsultaSelect("SELECT * FROM PuntoDeControlZona ORDER BY idPuntoDeControlZona");
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string idPuntoDeControl = textBox1.Text;
            string idZona = textBox2.Text;


            consulta = "INSERT INTO PuntoDeControlZona(idPuntoDeControl, idZona) VALUES ('" + idPuntoDeControl + "', + '" + idZona + "')";
            ConexionMySQL.EjecutaConsulta(consulta);
            MostrarDatos();

            textBox1.Clear();
            textBox2.Clear();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            string idPuntoDeControl = textBox1.Text;
            string idZona = textBox2.Text;


            int idPuntoDeControlZona = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE PuntoDeControlZona SET idPuntoDeControl = '" + idPuntoDeControl + "',idZona = '" + idZona + "'  WHERE idPuntoDeControlZona = " + idPuntoDeControlZona.ToString();
            ConexionMySQL.EjecutaConsulta(consulta);
            MostrarDatos();

            textBox1.Clear();
            textBox2.Clear();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            int idPuntoDeControlZona = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE PuntoDeControlZona SET  estatus = 0 WHERE idPuntoDeControlZona =  " + idPuntoDeControlZona.ToString(); ;
            ConexionMySQL.EjecutaConsulta(consulta);
            MostrarDatos();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            Ring app = new Ring();
            app.Show();
            this.Hide();
        }
    }
}
