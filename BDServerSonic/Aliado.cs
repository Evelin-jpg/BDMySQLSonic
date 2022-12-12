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
    public partial class Aliado : Form
    {
        string consulta;
        public Aliado()
        {
            InitializeComponent();
        }

        private void Aliado_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }
        private void MostrarDatos()
        {
            dataGridView1.DataSource = ConexionMySQL.EjecutaConsultaSelect("SELECT * FROM Aliado ORDER BY idAliado");
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string Nombre = textBox1.Text;
            string Especie = textBox2.Text;
            string Descripcion = textBox3.Text;
            string idPersonaje = textBox4.Text;

            consulta = "INSERT INTO Aliado(Nombre, Especie, Descripcion, idPersonaje) VALUES ('" + Nombre + "', + '" + Especie + "', '" + Descripcion + "', '" + idPersonaje + "')";
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
            string Especie = textBox2.Text;
            string Descripcion = textBox3.Text;
            string idPersonaje = textBox4.Text;
            int idAliado = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE Aliado SET Nombre = '" + Nombre + "',Especie = '" + Especie + "',Descripcion = '" + Descripcion + "',idPersonaje = '" + idPersonaje + "'  WHERE idAliado = " + idAliado.ToString();
            ConexionMySQL.EjecutaConsulta(consulta);
            MostrarDatos();

            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            int idAliado = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE Aliado SET  estatus = 0 WHERE idAliado =  " + idAliado.ToString(); ;
            ConexionMySQL.EjecutaConsulta(consulta);
            MostrarDatos();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            Amigo app = new Amigo();
            app.Show();
            this.Hide();
        }
    }
}

