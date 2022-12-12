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
    public partial class Poder : Form
    {
        string consulta;
        public Poder()
        {
            InitializeComponent();
        }

        private void Poder_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }
        private void MostrarDatos()
        {
            dataGridView1.DataSource = ConexionMySQL.EjecutaConsultaSelect("SELECT * FROM Poder ORDER BY idPoder");
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string Nombre = textBox1.Text;
            string Tipo = textBox2.Text;
            string Descripcion = textBox3.Text;
            string idPersonaje = textBox4.Text;

            consulta = "INSERT INTO Poder(Nombre, Tipo, Descripcion, idPersonaje) VALUES ('" + Nombre + "', + '" + Tipo + "', '" + Descripcion + "', '" + idPersonaje + "')";
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
            string idPersonaje = textBox4.Text;
            int idPoder = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE Poder SET Nombre = '" + Nombre + "',Tipo = '" + Tipo + "',Descripcion = '" + Descripcion + "',idPersonaje = '" + idPersonaje + "'  WHERE idPoder = " + idPoder.ToString();
            ConexionMySQL.EjecutaConsulta(consulta);
            MostrarDatos();

            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            int idPoder = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE Poder SET  estatus = 0 WHERE idPoder =  " + idPoder.ToString(); ;
            ConexionMySQL.EjecutaConsulta(consulta);
            MostrarDatos();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            Portal app = new Portal();
            app.Show();
            this.Hide();
        }
    }
}
