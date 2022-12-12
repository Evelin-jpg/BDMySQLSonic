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
    public partial class Escudo : Form
    {
        string consulta;
        public Escudo()
        {
            InitializeComponent();
        }

        private void Escudo_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }
        private void MostrarDatos()
        {
            dataGridView1.DataSource = ConexionMySQL.EjecutaConsultaSelect("SELECT * FROM Escudo ORDER BY idEscudo");
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string Nombre = textBox1.Text;
            string Tipo = textBox2.Text;
            string Resistencia = textBox5.Text;
            string Descripcion = textBox3.Text;
            string idPersonaje = textBox4.Text;

            consulta = "INSERT INTO Escudo(Nombre, Tipo, Resistencia,Descripcion, idPersonaje) VALUES ('" + Nombre + "', + '" + Tipo + "','" + Resistencia + "', '" + Descripcion + "', '" + idPersonaje + "')";
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
            string Resistencia = textBox5.Text;
            string Descripcion = textBox3.Text;
            string idPersonaje = textBox4.Text;
            int idEscudo = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE Escudo SET Nombre = '" + Nombre + "',Tipo = '" + Tipo + "',Resistencia = '" + Resistencia + "',Descripcion = '" + Descripcion + "',idPersonaje = '" + idPersonaje + "'  WHERE idEscudo = " + idEscudo.ToString();
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
            int idEscudo = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE Escudo SET  estatus = 0 WHERE idEscudo =  " + idEscudo.ToString(); ;
            ConexionMySQL.EjecutaConsulta(consulta);
            MostrarDatos();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            Esmeralda app = new Esmeralda();
            app.Show();
            this.Hide();
        }
    }
}
