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
    public partial class Escena : Form
    {
        string consulta;
        public Escena()
        {
            InitializeComponent();
        }

        private void Escena_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }
        private void MostrarDatos()
        {
            dataGridView1.DataSource = ConexionMySQL.EjecutaConsultaSelect("SELECT * FROM Escena ORDER BY idEscena");
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string Nombre = textBox1.Text;
            string Descripcion = textBox2.Text;
            

            consulta = "INSERT INTO Escena(Nombre, Descripcion) VALUES ('" + Nombre + "', + '" + Descripcion + "', '" + "')";
            ConexionMySQL.EjecutaConsulta(consulta);
            MostrarDatos();

            textBox1.Clear();
            textBox2.Clear();
            
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            string Nombre = textBox1.Text;
            string Descripcion = textBox2.Text;
          
            int idEscena = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE Escena SET Nombre = '" + Nombre + "',Descripcion = '" + Descripcion + "'  WHERE idEscena = " + idEscena.ToString();
            ConexionMySQL.EjecutaConsulta(consulta);
            MostrarDatos();

            textBox1.Clear();
            textBox2.Clear();
            
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            int idEscena = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE Escena SET  estatus = 0 WHERE idEscena =  " + idEscena.ToString(); ;
            ConexionMySQL.EjecutaConsulta(consulta);
            MostrarDatos();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            Escenario app = new Escenario();
            app.Show();
            this.Hide();
        }
    }
}
