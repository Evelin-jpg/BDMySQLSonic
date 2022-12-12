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
    public partial class Esmeralda : Form
    {
        string consulta;
        public Esmeralda()
        {
            InitializeComponent();
        }

        private void Esmeralda_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }
        private void MostrarDatos()
        {
            dataGridView1.DataSource = ConexionMySQL.EjecutaConsultaSelect("SELECT * FROM Esmeralda ORDER BY idEsmeralda");
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string Nombre = textBox1.Text;
            string Color = textBox2.Text;
            string Tipo = textBox3.Text;
            string Descripcion = textBox4.Text;

            consulta = "INSERT INTO Esmeralda(Nombre, Color, Tipo, Descripcion) VALUES ('" + Nombre + "', + '" + Color + "', '" + Tipo + "', '" + Descripcion + "')";
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
            string Descripcion = textBox4.Text;
            int idEsmeralda = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE Esmeralda SET Nombre = '" + Nombre + "',Color = '" + Color + "',Tipo = '" + Tipo + "',Descripcion = '" + Descripcion + "'  WHERE idEsmeralda = " + idEsmeralda.ToString();
            ConexionMySQL.EjecutaConsulta(consulta);
            MostrarDatos();

            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            int idEsmeralda = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE Esmeralda SET  estatus = 0 WHERE idEsmeralda =  " + idEsmeralda.ToString(); ;
            ConexionMySQL.EjecutaConsulta(consulta);
            MostrarDatos();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            EsmeraldaZona app = new EsmeraldaZona();
            app.Show();
            this.Hide();
        }
    }
}
