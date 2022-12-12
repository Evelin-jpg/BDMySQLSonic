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
    public partial class CajaDeObjeto : Form
    {
        string consulta;
        public CajaDeObjeto()
        {
            InitializeComponent();
        }

        private void CajaDeObjeto_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }
        private void MostrarDatos()
        {
            dataGridView1.DataSource = ConexionMySQL.EjecutaConsultaSelect("SELECT * FROM CajaDeObjeto ORDER BY idCajaDeObjeto");
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string Nombre = textBox1.Text;
            string Tipo = textBox2.Text;
            string Descripcion = textBox3.Text;
            string idZona = textBox4.Text;

            consulta = "INSERT INTO CajaDeObjeto(Nombre, Tipo, Descripcion, idZona) VALUES ('" + Nombre + "', + '" + Tipo + "', '" + Descripcion + "', '" + idZona + "')";
            ConexionMySQL.EjecutaConsulta(consulta);
            MostrarDatos();

            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            string Nombre = textBox1.Text;
            string Tipo = textBox2.Text;
            string Descripcion = textBox3.Text;
            string idZona = textBox4.Text;
            int idCajaDeObjeto = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE CajaDeObjeto SET Nombre = '" + Nombre + "',Tipo = '" + Tipo + "',Descripcion = '" + Descripcion + "',idZona = '" + idZona + "'  WHERE idCajaDeObjeto = " + idCajaDeObjeto.ToString();
            ConexionMySQL.EjecutaConsulta(consulta);
            MostrarDatos();

            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            int idCajaDeObjeto = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE CajaDeObjeto SET  estatus = 0 WHERE idCajaDeObjeto =  " + idCajaDeObjeto.ToString(); ;
            ConexionMySQL.EjecutaConsulta(consulta);
            MostrarDatos();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            Colaboracion app = new Colaboracion();
            app.Show();
            this.Hide();
        }
    }
}
