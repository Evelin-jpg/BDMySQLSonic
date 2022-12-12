using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace BDServerSonic
{
    public partial class Colaboracion : Form
    {
        string consulta;
        public Colaboracion()
        {
            InitializeComponent();
        }

        private void Colaboracion_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }
        private void MostrarDatos()
        {
            dataGridView1.DataSource = ConexionMySQL.EjecutaConsultaSelect("SELECT * FROM Colaboracion ORDER BY idColaboracion");
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string Nombre = textBox1.Text;
            string Descripcion = textBox2.Text;
            string idPersonaje = textBox4.Text;

            consulta = "INSERT INTO Colaboracion(Nombre, Descripcion, idPersonaje) VALUES ('" + Nombre + "', + '" + Descripcion + "', '" + idPersonaje + "')";
            ConexionMySQL.EjecutaConsulta(consulta);
            MostrarDatos();

            textBox1.Clear();
            textBox2.Clear();
            textBox4.Clear();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            string Nombre = textBox1.Text;
            string Descripcion = textBox2.Text;
            string idPersonaje = textBox4.Text;
            int idColaboracion = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE Colaboracion SET Nombre = '" + Nombre + "',Descripcion = '" + Descripcion + "',idPersonaje = '" + idPersonaje + "'  WHERE idColaboracion = " + idColaboracion.ToString();
            ConexionMySQL.EjecutaConsulta(consulta);
            MostrarDatos();

            textBox1.Clear();
            textBox2.Clear();
            textBox4.Clear();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            int idColaboracion = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE Colaboracion SET  estatus = 0 WHERE idColaboracion =  " + idColaboracion.ToString(); ;
            ConexionMySQL.EjecutaConsulta(consulta);
            MostrarDatos();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            Comic app = new Comic();
            app.Show();
            this.Hide();
        }
    }
}
