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
    public partial class Animal : Form
    {
        string consulta;
        public Animal()
        {
            InitializeComponent();
        }

        private void Animal_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }
        private void MostrarDatos()
        {
            dataGridView1.DataSource = ConexionMySQL.EjecutaConsultaSelect("SELECT * FROM Animal ORDER BY idAnimal");
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string Nombre = textBox1.Text;
            string Especie = textBox2.Text;
            string Descripcion = textBox3.Text;
            string idZona = textBox4.Text;

            consulta = "INSERT INTO Animal(Nombre, Especie, Descripcion, idZona) VALUES ('" + Nombre + "', + '" + Especie + "', '" + Descripcion + "', '" + idZona + "')";
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
            string idZona = textBox4.Text;
            int idAnimal = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE Animal SET Nombre = '" + Nombre + "',Especie = '" + Especie + "',Descripcion = '" + Descripcion + "',idZona = '" + idZona + "'  WHERE idAnimal = " + idAnimal.ToString();
            ConexionMySQL.EjecutaConsulta(consulta);
            MostrarDatos();

            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            int idAnimal = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE Animal SET  estatus = 0 WHERE idAnimal =  " + idAnimal.ToString(); ;
            ConexionMySQL.EjecutaConsulta(consulta);
            MostrarDatos();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            Avatar app = new Avatar();
            app.Show();
            this.Hide();
        }
    }
}
