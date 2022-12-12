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
    public partial class Amigo : Form
    {
        string consulta;
        public Amigo()
        {
            InitializeComponent();
        }

        private void Amigo_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }

        private void MostrarDatos()
        {
            dataGridView1.DataSource = ConexionMySQL.EjecutaConsultaSelect("SELECT * FROM Amigo ORDER BY idAmigo");
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string Nombre = textBox1.Text;
            string Descripcion = textBox3.Text;
            string idJugador = textBox4.Text;

            consulta = "INSERT INTO Amigo(Nombre, Descripcion, idJugador) VALUES ('" + Nombre + "', '" + Descripcion + "', '" + idJugador + "')";
            ConexionMySQL.EjecutaConsulta(consulta);
            MostrarDatos();

            textBox1.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            string Nombre = textBox1.Text;
            string Descripcion = textBox3.Text;
            string idJugador = textBox4.Text;
            int idAmigo = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE Amigo SET Nombre = '" + Nombre  + "',Descripcion = '" + Descripcion + "',idJugador = '" + idJugador + "'  WHERE idAmigo = " + idAmigo.ToString();
            ConexionMySQL.EjecutaConsulta(consulta);
            MostrarDatos();

            textBox1.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            int idAmigo = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE Amigo SET  estatus = 0 WHERE idAmigo =  " + idAmigo.ToString(); ;
            ConexionMySQL.EjecutaConsulta(consulta);
            MostrarDatos();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            Animal app = new Animal();
            app.Show();
            this.Hide();
        }
    }
}
