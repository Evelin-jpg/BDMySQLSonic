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
    public partial class Bucle : Form
    {
        string consulta;
        public Bucle()
        {
            InitializeComponent();
        }

        private void Bucle_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }
        private void MostrarDatos()
        {
            dataGridView1.DataSource = ConexionMySQL.EjecutaConsultaSelect("SELECT * FROM Bucle ORDER BY idBucle");
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string Nombre = textBox1.Text;
            string Tamaño = textBox2.Text;
            string Tipo = textBox3.Text;
            string idZona = textBox4.Text;

            consulta = "INSERT INTO Bucle(Nombre, Tamaño, Tipo, idZona) VALUES ('" + Nombre + "', + '" + Tamaño + "', '" + Tipo + "', '" + idZona + "')";
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
            string Tamaño = textBox2.Text;
            string Tipo = textBox3.Text;
            string idZona = textBox4.Text;
            int idBucle = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE Bucle SET Nombre = '" + Nombre + "',Tamaño = '" + Tamaño + "',Tipo = '" + Tipo + "',idZona = '" + idZona + "'  WHERE idBucle = " + idBucle.ToString();
            ConexionMySQL.EjecutaConsulta(consulta);
            MostrarDatos();

            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            int idBucle = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE Bucle SET  estatus = 0 WHERE idBucle =  " + idBucle.ToString(); ;
            ConexionMySQL.EjecutaConsulta(consulta);
            MostrarDatos();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            CajaDeObjeto app = new CajaDeObjeto();
            app.Show();
            this.Hide();
        }
    }
}
