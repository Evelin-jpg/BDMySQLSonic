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
    public partial class PuntoDeControl : Form
    {
        string consulta;
        public PuntoDeControl()
        {
            InitializeComponent();
        }

        private void PuntoDeControl_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }
        private void MostrarDatos()
        {
            dataGridView1.DataSource = ConexionMySQL.EjecutaConsultaSelect("SELECT * FROM PuntoDeControl ORDER BY idPuntoDeControl");
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string Nombre = textBox1.Text;
            string Guardado = textBox2.Text;
            string Descripcion = textBox3.Text;
            string idZona = textBox4.Text;

            consulta = "INSERT INTO PuntoDeControl(Nombre, Guardado, Descripcion, idZona) VALUES ('" + Nombre + "', + '" + Guardado + "', '" + Descripcion + "', '" + idZona + "')";
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
            string Guardado = textBox2.Text;
            string Descripcion = textBox3.Text;
            string idZona = textBox4.Text;
            int idPuntoDeControl = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE PuntoDeControl SET Nombre = '" + Nombre + "',Guardado = '" + Guardado + "',Descripcion = '" + Descripcion + "',idZona = '" + idZona + "'  WHERE idPuntoDeControl = " + idPuntoDeControl.ToString();
            ConexionMySQL.EjecutaConsulta(consulta);
            MostrarDatos();

            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            int idPuntoDeControl = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE PuntoDeControl SET  estatus = 0 WHERE idPuntoDeControl =  " + idPuntoDeControl.ToString(); ;
            ConexionMySQL.EjecutaConsulta(consulta);
            MostrarDatos();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            PuntoDeControlZona app = new PuntoDeControlZona();
            app.Show();
            this.Hide();
        }
    }
}
