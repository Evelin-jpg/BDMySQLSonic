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
    
    public partial class Defensa : Form
    {
        string consulta;
        public Defensa()
        {
            InitializeComponent();
        }

        private void Defensa_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }
        private void MostrarDatos()
        {
            dataGridView1.DataSource = ConexionMySQL.EjecutaConsultaSelect("SELECT * FROM Defensa ORDER BY idDefensa");
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string Nombre = textBox1.Text;
            string Fuerza = textBox2.Text;
            string Descripcion = textBox3.Text;
            string idPersonaje = textBox4.Text;

            consulta = "INSERT INTO Defensa(Nombre, Fuerza, Descripcion, idPersonaje) VALUES ('" + Nombre + "', + '" + Fuerza + "', '" + Descripcion + "', '" + idPersonaje + "')";
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
            string Fuerza = textBox2.Text;
            string Descripcion = textBox3.Text;
            string idPersonaje = textBox4.Text;
            int idDefensa = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE Defensa SET Nombre = '" + Nombre + "',Fuerza = '" + Fuerza + "',Descripcion = '" + Descripcion + "',idPersonaje = '" + idPersonaje + "'  WHERE idDefensa = " + idDefensa.ToString();
            ConexionMySQL.EjecutaConsulta(consulta);
            MostrarDatos();

            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            int idDefensa = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE Defensa SET  estatus = 0 WHERE idDefensa =  " + idDefensa.ToString(); ;
            ConexionMySQL.EjecutaConsulta(consulta);
            MostrarDatos();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            Dimension app = new Dimension();
            app.Show();
            this.Hide();
        }
    }
}
