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
    public partial class Extra : Form
    {
        string consulta;
        public Extra()
        {
            InitializeComponent();
        }

        private void Extra_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }
        private void MostrarDatos()
        {
            dataGridView1.DataSource = ConexionMySQL.EjecutaConsultaSelect("SELECT * FROM Extra ORDER BY idExtra");
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string Nombre = textBox1.Text;
            string Codigo = textBox2.Text;
            string Descripcion = textBox3.Text;
            string idJugador = textBox4.Text;

            consulta = "INSERT INTO Extra(Nombre, Codigo, Descripcion, idJugador) VALUES ('" + Nombre + "', + '" + Codigo + "', '" + Descripcion + "', '" + idJugador + "')";
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
            string Codigo = textBox2.Text;
            string Descripcion = textBox3.Text;
            string idJugador = textBox4.Text;
            int idExtra = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE Extra SET Nombre = '" + Nombre + "',Codigo = '" + Codigo + "',Descripcion = '" + Descripcion + "',idJugador = '" + idJugador + "'  WHERE idExtra = " + idExtra.ToString();
            ConexionMySQL.EjecutaConsulta(consulta);
            MostrarDatos();

            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            int idExtra = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE Extra SET  estatus = 0 WHERE idExtra =  " + idExtra.ToString(); ;
            ConexionMySQL.EjecutaConsulta(consulta);
            MostrarDatos();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            Final app = new Final();
            app.Show();
            this.Hide();
        }
    }
}
