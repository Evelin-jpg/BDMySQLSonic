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
    public partial class ZonaEspecial : Form
    {
        string consulta;
        public ZonaEspecial()
        {
            InitializeComponent();
        }

        private void ZonaEspecial_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }
        private void MostrarDatos()
        {
            dataGridView1.DataSource = ConexionMySQL.EjecutaConsultaSelect("SELECT * FROM ZonaEspecial ORDER BY idZonaEspecial");
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string Nombre = textBox1.Text;
            string Tipo = textBox2.Text;
            string Nivel = textBox5.Text;
            string Descripcion = textBox3.Text;
            string idMundo = textBox4.Text;

            consulta = "INSERT INTO ZonaEspecial(Nombre, Tipo, Nivel,Descripcion, idMundo) VALUES ('" + Nombre + "', + '" + Tipo + "','" + Nivel + "', '" + Descripcion + "', '" + idMundo + "')";
            ConexionMySQL.EjecutaConsulta(consulta);
            MostrarDatos();

            textBox1.Clear();
            textBox2.Clear();
            textBox5.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            string Nombre = textBox1.Text;
            string Tipo = textBox2.Text;
            string Nivel = textBox5.Text;
            string Descripcion = textBox3.Text;
            string idMundo = textBox4.Text;
            int idZonaEspecial = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE ZonaEspecial SET Nombre = '" + Nombre + "',Tipo = '" + Tipo + "',Nivel = '" + Nivel + "',Descripcion = '" + Descripcion + "',idMundo = '" + idMundo + "'  WHERE idZonaEspecial = " + idZonaEspecial.ToString();
            ConexionMySQL.EjecutaConsulta(consulta);
            MostrarDatos();

            textBox1.Clear();
            textBox2.Clear();
            textBox5.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            int idZonaEspecial = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE ZonaEspecial SET  estatus = 0 WHERE idZonaEspecial =  " + idZonaEspecial.ToString(); ;
            ConexionMySQL.EjecutaConsulta(consulta);
            MostrarDatos();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            ZonaEspecialMundo app = new ZonaEspecialMundo();
            app.Show();
            this.Hide();
        }
    }
}
