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
    public partial class Jefe : Form
    {
        string consulta;
        public Jefe()
        {
            InitializeComponent();
        }

        private void Jefe_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }
        private void MostrarDatos()
        {
            dataGridView1.DataSource = ConexionMySQL.EjecutaConsultaSelect("SELECT * FROM Jefe ORDER BY idJefe");
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string Nombre = textBox1.Text;
            string Descripcion = textBox2.Text;
            string Especie = textBox3.Text;
            string idZona = textBox4.Text;

            consulta = "INSERT INTO Jefe(Nombre, Descripcion, Especie, idZona) VALUES ('" + Nombre + "', + '" + Descripcion + "', '" + Especie + "', '" + idZona + "')";
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
            string Descripcion = textBox2.Text;
            string Especie = textBox3.Text;
            string idZona = textBox4.Text;
            int idJefe = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE Jefe SET Nombre = '" + Nombre + "',Descripcion = '" + Descripcion + "',Especie = '" + Especie + "',idZona = '" + idZona + "'  WHERE idJefe = " + idJefe.ToString();
            ConexionMySQL.EjecutaConsulta(consulta);
            MostrarDatos();

            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            int idJefe = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE Jefe SET  estatus = 0 WHERE idJefe =  " + idJefe.ToString(); ;
            ConexionMySQL.EjecutaConsulta(consulta);
            MostrarDatos();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            JefeZona app = new JefeZona();
            app.Show();
            this.Hide();
        }
    }
}
