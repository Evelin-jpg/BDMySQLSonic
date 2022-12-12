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
    public partial class MercanciaPersonaje : Form
    {
        string consulta;
        public MercanciaPersonaje()
        {
            InitializeComponent();
        }

        private void MercanciaPersonaje_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }
        private void MostrarDatos()
        {
            dataGridView1.DataSource = ConexionMySQL.EjecutaConsultaSelect("SELECT * FROM MercanciaPersonaje ORDER BY idMercanciaPersonaje");
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string idMercancia = textBox1.Text;
            string idPersonaje = textBox2.Text;


            consulta = "INSERT INTO MercanciaPersonaje(idMercancia, idPersonaje) VALUES ('" + idMercancia + "', + '" + idPersonaje + "')";
            ConexionMySQL.EjecutaConsulta(consulta);
            MostrarDatos();

            textBox1.Clear();
            textBox2.Clear();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            string idMercancia = textBox1.Text;
            string idPersonaje = textBox2.Text;


            int idMercanciaPersonaje = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE MercanciaPersonaje SET idMercancia = '" + idMercancia + "',idPersonaje = '" + idPersonaje + "'  WHERE idMercanciaPersonaje = " + idMercanciaPersonaje.ToString();
            ConexionMySQL.EjecutaConsulta(consulta);
            MostrarDatos();

            textBox1.Clear();
            textBox2.Clear();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            int idMercanciaPersonaje = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE MercanciaPersonaje SET  estatus = 0 WHERE idMercanciaPersonaje =  " + idMercanciaPersonaje.ToString(); ;
            ConexionMySQL.EjecutaConsulta(consulta);
            MostrarDatos();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            MiniJuego app = new MiniJuego();
            app.Show();
            this.Hide();
        }
    }
}
