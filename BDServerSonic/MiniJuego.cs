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
    public partial class MiniJuego : Form
    {
        string consulta;
        public MiniJuego()
        {
            InitializeComponent();
        }

        private void MiniJuego_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }
        private void MostrarDatos()
        {
            dataGridView1.DataSource = ConexionMySQL.EjecutaConsultaSelect("SELECT * FROM MiniJuego ORDER BY idMiniJuego");
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string Nombre = textBox1.Text;
            string Arcade = textBox2.Text;
            string Descripcion = textBox5.Text;
            string idJugador = textBox3.Text;
            string idContrareloj = textBox4.Text;

            consulta = "INSERT INTO MiniJuego(Nombre, Arcade, Descripcion,idJugador, idContrareloj) VALUES ('" + Nombre + "', + '" + Arcade + "','" + Descripcion + "', '" + idJugador + "', '" + idContrareloj + "')";
            ConexionMySQL.EjecutaConsulta(consulta);
            MostrarDatos();

            textBox1.Clear();
            textBox2.Clear();
            textBox5.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            string Nombre = textBox1.Text;
            string Arcade = textBox2.Text;
            string Descripcion = textBox5.Text;
            string idJugador = textBox3.Text;
            string idContrareloj = textBox4.Text;
            int idMiniJuego = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE MiniJuego SET Nombre = '" + Nombre + "',Arcade = '" + Arcade + "',Descripcion = '" + Descripcion + "',idJugador = '" + idJugador + "',idContrareloj = '" + idContrareloj + "'  WHERE idMiniJuego = " + idMiniJuego.ToString();
            ConexionMySQL.EjecutaConsulta(consulta);
            MostrarDatos();

            textBox1.Clear();
            textBox2.Clear();
            textBox5.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            int idMiniJuego = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE MiniJuego SET  estatus = 0 WHERE idMiniJuego =  " + idMiniJuego.ToString(); ;
            ConexionMySQL.EjecutaConsulta(consulta);
            MostrarDatos();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            ModoDeJuego app = new ModoDeJuego();
            app.Show();
            this.Hide();
        }
    }
}
