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
    public partial class Escenario : Form
    {
        string consulta;
        public Escenario()
        {
            InitializeComponent();
        }

        private void Escenario_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }
        private void MostrarDatos()
        {
            dataGridView1.DataSource = ConexionMySQL.EjecutaConsultaSelect("SELECT * FROM Escenario ORDER BY idEscenario");
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string Nombre = textBox1.Text;
            string Descripcion = textBox2.Text;
            string idMundo = textBox3.Text;


            consulta = "INSERT INTO Escenario(Nombre, Descripcion, idMundo) VALUES ('" + Nombre + "', + '" + Descripcion + "', '" + idMundo + "', '" + "')";
            ConexionMySQL.EjecutaConsulta(consulta);
            MostrarDatos();

            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            string Nombre = textBox1.Text;
            string Descripcion = textBox2.Text;
            string idMundo = textBox3.Text;

            int idEscenario = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE Escenario SET Nombre = '" + Nombre + "',Descripcion = '" + Descripcion + "',idMundo = '" + idMundo + "'  WHERE idEscenario = " + idEscenario.ToString();
            ConexionMySQL.EjecutaConsulta(consulta);
            MostrarDatos();

            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            int idEscenario = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE Escenario SET  estatus = 0 WHERE idEscenario =  " + idEscenario.ToString(); ;
            ConexionMySQL.EjecutaConsulta(consulta);
            MostrarDatos();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            EscenaZona app = new EscenaZona();
            app.Show();
            this.Hide();
        }
    }
}
