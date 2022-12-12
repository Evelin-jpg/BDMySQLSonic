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
    public partial class Gema : Form
    {
        string consulta;
        public Gema()
        {
            InitializeComponent();
        }

        private void Gema_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }
        private void MostrarDatos()
        {
            dataGridView1.DataSource = ConexionMySQL.EjecutaConsultaSelect("SELECT * FROM Gema ORDER BY idGema");
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string Nombre = textBox1.Text;
            string Color = textBox2.Text;
            string Tipo = textBox3.Text;
            string idZona = textBox4.Text;

            consulta = "INSERT INTO Gema(Nombre, Color, Tipo, idZona) VALUES ('" + Nombre + "', + '" + Color + "', '" + Tipo + "', '" + idZona + "')";
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
            string Color = textBox2.Text;
            string Tipo = textBox3.Text;
            string idZona = textBox4.Text;
            int idGema = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE Gema SET Nombre = '" + Nombre + "',Color = '" + Color + "',Tipo = '" + Tipo + "',idZona = '" + idZona + "'  WHERE idGema = " + idGema.ToString();
            ConexionMySQL.EjecutaConsulta(consulta);
            MostrarDatos();

            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            int idGema = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE Gema SET  estatus = 0 WHERE idGema =  " + idGema.ToString(); ;
            ConexionMySQL.EjecutaConsulta(consulta);
            MostrarDatos();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            GemaZona app = new GemaZona();
            app.Show();
            this.Hide();
        }
    }
}
