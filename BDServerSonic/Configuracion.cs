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
    public partial class Configuracion : Form
    {
        string consulta;
        public Configuracion()
        {
            InitializeComponent();
        }

        private void Configuracion_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }
        private void MostrarDatos()
        {
            dataGridView1.DataSource = ConexionMySQL.EjecutaConsultaSelect("SELECT * FROM Configuracion ORDER BY idConfiguracion");
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string Controles = textBox1.Text;
            string Partes = textBox2.Text;
            string Propiedades = textBox3.Text;
            string Descripcion = textBox4.Text;

            consulta = "INSERT INTO Configuracion(Controles, Partes, Propiedades, Descripcion) VALUES ('" + Controles + "', + '" + Partes + "', '" + Propiedades + "', '" + Descripcion + "')";
            ConexionMySQL.EjecutaConsulta(consulta);
            MostrarDatos();

            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            string Controles = textBox1.Text;
            string Partes = textBox2.Text;
            string Propiedades = textBox3.Text;
            string Descripcion = textBox4.Text;
            int idConfiguracion = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE Configuracion SET Controles = '" + Controles + "',Partes = '" + Partes + "',Propiedades = '" + Propiedades + "',Descripcion = '" + Descripcion + "'  WHERE idConfiguracion = " + idConfiguracion.ToString();
            ConexionMySQL.EjecutaConsulta(consulta);
            MostrarDatos();

            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            int idConfiguracion = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE Configuracion SET  estatus = 0 WHERE idConfiguracion =  " + idConfiguracion.ToString(); ;
            ConexionMySQL.EjecutaConsulta(consulta);
            MostrarDatos();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            ConfiguracionJugador app = new ConfiguracionJugador();
            app.Show();
            this.Hide();
        }
    }
}
