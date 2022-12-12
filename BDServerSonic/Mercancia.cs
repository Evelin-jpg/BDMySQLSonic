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
    public partial class Mercancia : Form
    {
        string consulta;
        public Mercancia()
        {
            InitializeComponent();
        }

        private void Mercancia_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }
        private void MostrarDatos()
        {
            dataGridView1.DataSource = ConexionMySQL.EjecutaConsultaSelect("SELECT * FROM Mercancia ORDER BY idMercancia");
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string Nombre = textBox1.Text;
            string Tipo = textBox3.Text;
            string Descripcion = textBox4.Text;

            consulta = "INSERT INTO Mercancia(Nombre, Tipo, Descripcion) VALUES ('" + Nombre + "', '" + Tipo + "', '" + Descripcion + "')";
            ConexionMySQL.EjecutaConsulta(consulta);
            MostrarDatos();

            textBox1.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            string Nombre = textBox1.Text;
            string Tipo = textBox3.Text;
            string Descripcion = textBox4.Text;
            int idMercancia = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE Mercancia SET Nombre = '" + Nombre + "',Tipo = '" + Tipo + "',Descripcion = '" + Descripcion + "'  WHERE idMercancia = " + idMercancia.ToString();
            ConexionMySQL.EjecutaConsulta(consulta);
            MostrarDatos();

            textBox1.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            int idMercancia = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE Mercancia SET  estatus = 0 WHERE idMercancia =  " + idMercancia.ToString(); ;
            ConexionMySQL.EjecutaConsulta(consulta);
            MostrarDatos();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            MercanciaPersonaje app = new MercanciaPersonaje();
            app.Show();
            this.Hide();
        }
    }
}
