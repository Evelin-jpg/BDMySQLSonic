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
    public partial class Era : Form
    {
        string consulta;
        public Era()
        {
            InitializeComponent();
        }

        private void Era_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }
        private void MostrarDatos()
        {
            dataGridView1.DataSource = ConexionMySQL.EjecutaConsultaSelect("SELECT * FROM Era ORDER BY idEra");
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string Nombre = textBox1.Text;
            string Tipo = textBox2.Text;
            string Descripcion = textBox3.Text;
            

            consulta = "INSERT INTO Era(Nombre, Tipo, Descripcion) VALUES ('" + Nombre + "', + '" + Tipo + "', '" + Descripcion + "', '" + "')";
            ConexionMySQL.EjecutaConsulta(consulta);
            MostrarDatos();

            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
           
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            string Nombre = textBox1.Text;
            string Tipo = textBox2.Text;
            string Descripcion = textBox3.Text;
           
            int idEra = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE Era SET Nombre = '" + Nombre + "',Tipo = '" + Tipo + "',Descripcion = '" + Descripcion + "'  WHERE idEra = " + idEra.ToString();
            ConexionMySQL.EjecutaConsulta(consulta);
            MostrarDatos();

            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            int idEra = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE Era SET  estatus = 0 WHERE idEra =  " + idEra.ToString(); ;
            ConexionMySQL.EjecutaConsulta(consulta);
            MostrarDatos();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            Escena app = new Escena();
            app.Show();
            this.Hide();
        }
    }
}
