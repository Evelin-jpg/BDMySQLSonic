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
    public partial class GameCenter : Form
    {
        string consulta;
        public GameCenter()
        {
            InitializeComponent();
        }

        private void GameCenter_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }
        private void MostrarDatos()
        {
            dataGridView1.DataSource = ConexionMySQL.EjecutaConsultaSelect("SELECT * FROM GameCenter ORDER BY idGameCenter");
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string Nombre = textBox1.Text;
            string Logro = textBox2.Text;
            string Descripcion = textBox3.Text;
            string idJugador = textBox4.Text;

            consulta = "INSERT INTO GameCenter(Nombre, Logro, Descripcion, idJugador) VALUES ('" + Nombre + "', + '" + Logro + "', '" + Descripcion + "', '" + idJugador + "')";
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
            string Logro = textBox2.Text;
            string Descripcion = textBox3.Text;
            string idJugador = textBox4.Text;
            int idGameCenter = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE GameCenter SET Nombre = '" + Nombre + "',Logro = '" + Logro + "',Descripcion = '" + Descripcion + "',idJugador = '" + idJugador + "'  WHERE idGameCenter = " + idGameCenter.ToString();
            ConexionMySQL.EjecutaConsulta(consulta);
            MostrarDatos();

            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            int idGameCenter = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE GameCenter SET  estatus = 0 WHERE idGameCenter =  " + idGameCenter.ToString(); ;
            ConexionMySQL.EjecutaConsulta(consulta);
            MostrarDatos();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            Gema app = new Gema();
            app.Show();
            this.Hide();
        }
    }
}
