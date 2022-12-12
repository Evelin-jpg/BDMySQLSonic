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
    public partial class Vida : Form
    {
        string consulta;
        public Vida()
        {
            InitializeComponent();
        }

        private void Vida_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }
        private void MostrarDatos()
        {
            dataGridView1.DataSource = ConexionMySQL.EjecutaConsultaSelect("SELECT * FROM Vida ORDER BY idVida");
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string Nombre = textBox1.Text;
            string Cantidad = textBox3.Text;
            string Descripcion = textBox4.Text;

            consulta = "INSERT INTO Vida(Nombre, Cantidad, Descripcion) VALUES ('" + Nombre + "', '" + Cantidad + "', '" + Descripcion + "')";
            ConexionMySQL.EjecutaConsulta(consulta);
            MostrarDatos();

            textBox1.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            string Nombre = textBox1.Text;
            string Cantidad = textBox3.Text;
            string Descripcion = textBox4.Text;
            int idVida = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE Vida SET Nombre = '" + Nombre + "',Cantidad = '" + Cantidad + "',Descripcion = '" + Descripcion + "'  WHERE idVida = " + idVida.ToString();
            ConexionMySQL.EjecutaConsulta(consulta);
            MostrarDatos();

            textBox1.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            int idVida = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE Vida SET  estatus = 0 WHERE idVida =  " + idVida.ToString(); ;
            ConexionMySQL.EjecutaConsulta(consulta);
            MostrarDatos();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            VidaPersonaje app = new VidaPersonaje();
            app.Show();
            this.Hide();
        }
    }
}
