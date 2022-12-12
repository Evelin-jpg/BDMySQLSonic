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
    public partial class Mundo : Form
    {
        string consulta;
        public Mundo()
        {
            InitializeComponent();
        }

        private void Mundo_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }
        private void MostrarDatos()
        {
            dataGridView1.DataSource = ConexionMySQL.EjecutaConsultaSelect("SELECT * FROM Mundo ORDER BY idMundo");
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string Nombre = textBox1.Text;
            string Epoca = textBox2.Text;
            string Descripcion = textBox5.Text;
            string idJugador = textBox3.Text;
            string idMenu = textBox4.Text;

            consulta = "INSERT INTO Mundo(Nombre, Epoca, Descripcion,idJugador, idMenu) VALUES ('" + Nombre + "', + '" + Epoca + "','" + Descripcion + "', '" + idJugador + "', '" + idMenu + "')";
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
            string Epoca = textBox2.Text;
            string Descripcion = textBox5.Text;
            string idJugador = textBox3.Text;
            string idMenu = textBox4.Text;
            int idMundo = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE Mundo SET Nombre = '" + Nombre + "',Epoca = '" + Epoca + "',Descripcion = '" + Descripcion + "',idJugador = '" + idJugador + "',idMenu = '" + idMenu + "'  WHERE idMundo = " + idMundo.ToString();
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
            int idMundo = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE Mundo SET  estatus = 0 WHERE idMundo =  " + idMundo.ToString(); ;
            ConexionMySQL.EjecutaConsulta(consulta);
            MostrarDatos();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            Musica app = new Musica();
            app.Show();
            this.Hide();
        }
    }
}
