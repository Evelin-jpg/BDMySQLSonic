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
    public partial class DispositivoDeEntrada : Form
    {
        string consulta;
        public DispositivoDeEntrada()
        {
            InitializeComponent();
        }

        private void DispositivoDeEntrada_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }
        private void MostrarDatos()
        {
            dataGridView1.DataSource = ConexionMySQL.EjecutaConsultaSelect("SELECT * FROM DispositivoDeEntrada ORDER BY idDispositivoDeEntrada");
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string Nombre = textBox1.Text;
            string Modelo = textBox2.Text;
            string Descripcion = textBox3.Text;
            string idJugador = textBox4.Text;

            consulta = "INSERT INTO DispositivoDeEntrada(Nombre, Modelo, Descripcion, idJugador) VALUES ('" + Nombre + "', + '" + Modelo + "', '" + Descripcion + "', '" + idJugador + "')";
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
            string Modelo = textBox2.Text;
            string Descripcion = textBox3.Text;
            string idJugador = textBox4.Text;
            int idDispositivoDeEntrada = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE DispositivoDeEntrada SET Nombre = '" + Nombre + "',Modelo = '" + Modelo + "',Descripcion = '" + Descripcion + "',idJugador = '" + idJugador + "'  WHERE idDispositivoDeEntrada = " + idDispositivoDeEntrada.ToString();
            ConexionMySQL.EjecutaConsulta(consulta);
            MostrarDatos();

            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            int idDispositivoDeEntrada = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE DispositivoDeEntrada SET  estatus = 0 WHERE idDispositivoDeEntrada =  " + idDispositivoDeEntrada.ToString(); ;
            ConexionMySQL.EjecutaConsulta(consulta);
            MostrarDatos();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            Enemigo app = new Enemigo();
            app.Show();
            this.Hide();
        }
    }
}
