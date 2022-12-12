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
    public partial class Tiempo : Form
    {
        string consulta;
        public Tiempo()
        {
            InitializeComponent();
        }

        private void Tiempo_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }
        private void MostrarDatos()
        {
            dataGridView1.DataSource = ConexionMySQL.EjecutaConsultaSelect("SELECT * FROM Tiempo ORDER BY idTiempo");
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string Cantidad = textBox1.Text;
            string Descripcion = textBox3.Text;
            string idZona = textBox4.Text;

            consulta = "INSERT INTO Tiempo(Cantidad, Descripcion, idZona) VALUES ('" + Cantidad + "', '" + Descripcion + "', '" + idZona + "')";
            ConexionMySQL.EjecutaConsulta(consulta);
            MostrarDatos();

            textBox1.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            string Cantidad = textBox1.Text;
            string Descripcion = textBox3.Text;
            string idZona = textBox4.Text;
            int idTiempo = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE Tiempo SET Cantidad = '" + Cantidad + "',Descripcion = '" + Descripcion + "',idZona = '" + idZona + "'  WHERE idTiempo = " + idTiempo.ToString();
            ConexionMySQL.EjecutaConsulta(consulta);
            MostrarDatos();

            textBox1.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            int idTiempo = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE Tiempo SET  estatus = 0 WHERE idTiempo =  " + idTiempo.ToString(); ;
            ConexionMySQL.EjecutaConsulta(consulta);
            MostrarDatos();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            Trampa app = new Trampa();
            app.Show();
            this.Hide();
        }
    }
}
