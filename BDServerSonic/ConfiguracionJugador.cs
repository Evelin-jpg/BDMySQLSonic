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
    public partial class ConfiguracionJugador : Form
    {
        string consulta;
        public ConfiguracionJugador()
        {
            InitializeComponent();
        }

        private void ConfiguracionJugador_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }
        private void MostrarDatos()
        {
            dataGridView1.DataSource = ConexionMySQL.EjecutaConsultaSelect("SELECT * FROM ConfiguracionJugador ORDER BY idConfiguracionJugador");
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string idConfiguracion = textBox1.Text;
            string idJugador = textBox2.Text;


            consulta = "INSERT INTO ConfiguracionJugador(idConfiguracion, idJugador) VALUES ('" + idConfiguracion + "', + '" + idJugador + "')";
            ConexionMySQL.EjecutaConsulta(consulta);
            MostrarDatos();

            textBox1.Clear();
            textBox2.Clear();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            string idConfiguracion = textBox1.Text;
            string idJugador = textBox2.Text;


            int idConfiguracionJugador = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE ConfiguracionJugador SET idConfiguracion = '" + idConfiguracion + "',idJugador = '" + idJugador + "'  WHERE idConfiguracionJugador = " + idConfiguracionJugador.ToString();
            ConexionMySQL.EjecutaConsulta(consulta);
            MostrarDatos();

            textBox1.Clear();
            textBox2.Clear();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            int idConfiguracionJugador = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE ConfiguracionJugador SET  estatus = 0 WHERE idConfiguracionJugador =  " + idConfiguracionJugador.ToString(); ;
            ConexionMySQL.EjecutaConsulta(consulta);
            MostrarDatos();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            Contrareloj app = new Contrareloj();
            app.Show();
            this.Hide();
        }
    }
}
