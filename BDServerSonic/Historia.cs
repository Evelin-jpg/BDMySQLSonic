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
    
    public partial class Historia : Form
    {
        string consulta;
        public Historia()
        {
            InitializeComponent();
        }

        private void Historia_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }
        private void MostrarDatos()
        {
            dataGridView1.DataSource = ConexionMySQL.EjecutaConsultaSelect("SELECT * FROM Historia ORDER BY idHistoria");
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string Nombre = textBox1.Text;
            string Suceso = textBox3.Text;
            string Descripcion = textBox4.Text;

            consulta = "INSERT INTO Historia(Nombre, Suceso, Descripcion) VALUES ('" + Nombre + "', '" + Suceso + "', '" + Descripcion + "')";
            ConexionMySQL.EjecutaConsulta(consulta);
            MostrarDatos();

            textBox1.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            string Nombre = textBox1.Text;
            string Suceso = textBox3.Text;
            string Descripcion = textBox4.Text;
            int idHistoria = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE Historia SET Nombre = '" + Nombre + "',Suceso = '" + Suceso + "',Descripcion = '" + Descripcion + "'  WHERE idHistoria = " + idHistoria.ToString();
            ConexionMySQL.EjecutaConsulta(consulta);
            MostrarDatos();

            textBox1.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            int idHistoria = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE Historia SET  estatus = 0 WHERE idHistoria =  " + idHistoria.ToString(); ;
            ConexionMySQL.EjecutaConsulta(consulta);
            MostrarDatos();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            Jefe app = new Jefe();
            app.Show();
            this.Hide();
        }
    }
}
