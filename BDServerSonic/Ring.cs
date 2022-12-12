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
    public partial class Ring : Form
    {
        string consulta;
        public Ring()
        {
            InitializeComponent();
        }

        private void Ring_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }
        private void MostrarDatos()
        {
            dataGridView1.DataSource = ConexionMySQL.EjecutaConsultaSelect("SELECT * FROM Ring ORDER BY idRing");
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string Nombre = textBox1.Text;
            string Color = textBox2.Text;
            string Tipo = textBox3.Text;
            

            consulta = "INSERT INTO Ring(Nombre, Color, Tipo, Descripcion) VALUES ('" + Nombre + "', + '" + Color + "', '" + Tipo + "')";
            ConexionMySQL.EjecutaConsulta(consulta);
            MostrarDatos();

            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            string Nombre = textBox1.Text;
            string Color = textBox2.Text;
            string Tipo = textBox3.Text;
            
            int idRing = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE Ring SET Nombre = '" + Nombre + "',Color = '" + Color + "',Tipo = '" + Tipo + "'  WHERE idRing = " + idRing.ToString();
            ConexionMySQL.EjecutaConsulta(consulta);
            MostrarDatos();

            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            int idRing = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE Ring SET  estatus = 0 WHERE idRing =  " + idRing.ToString(); ;
            ConexionMySQL.EjecutaConsulta(consulta);
            MostrarDatos();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            RingZona app = new RingZona();
            app.Show();
            this.Hide();
        }
    }
}
