using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace BDServerSonic
{
    public partial class Avatar : Form
    {
        string consulta;
        public Avatar()
        {
            InitializeComponent();
        }

        private void Avatar_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }
        private void MostrarDatos()
        {
            dataGridView1.DataSource = ConexionMySQL.EjecutaConsultaSelect("SELECT * FROM Avatar ORDER BY idAvatar");
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string Nombre = textBox1.Text;
            string Especie = textBox2.Text;
            string idJugador = textBox4.Text;

            consulta = "INSERT INTO Avatar(Nombre, Especie, Descripcion, idJugador) VALUES ('" + Nombre + "', + '" + Especie + "', '" + "', '" + idJugador + "')";
            ConexionMySQL.EjecutaConsulta(consulta);
            MostrarDatos();

            textBox1.Clear();
            textBox2.Clear();
            textBox4.Clear();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            string Nombre = textBox1.Text;
            string Especie = textBox2.Text;
            string idJugador = textBox4.Text;
            int idAvatar = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE Avatar SET Nombre = '" + Nombre + "',Especie = '" + Especie + "',idJugador = '" + idJugador + "'  WHERE idAvatar = " + idAvatar.ToString();
            ConexionMySQL.EjecutaConsulta(consulta);
            MostrarDatos();

            textBox1.Clear();
            textBox2.Clear();

            textBox4.Clear();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            int idAvatar = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE Avatar SET  estatus = 0 WHERE idAvatar =  " + idAvatar.ToString(); ;
            ConexionMySQL.EjecutaConsulta(consulta);
            MostrarDatos();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            BandaSonora app = new BandaSonora();
            app.Show();
            this.Hide();
        }
    }
}
