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
    public partial class Zona : Form
    {
        string consulta;
        public Zona()
        {
            InitializeComponent();
        }

        private void Zona_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }
        private void MostrarDatos()
        {
            dataGridView1.DataSource = ConexionMySQL.EjecutaConsultaSelect("SELECT * FROM Zona ORDER BY idZona");
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string Nombre = textBox1.Text;
            string Tipo = textBox2.Text;
            string Nivel = textBox5.Text;
            string Descripcion = textBox3.Text;
            string idMundo = textBox4.Text;
            string idFinal = textBox6.Text;
            string idRing = textBox7.Text;
            string idEra = textBox8.Text;
            string idEscena = textBox9.Text;
            string idBandaSonora = textBox10.Text;
            string idEsmeralda = textBox11.Text;


            consulta = "INSERT INTO Zona(Nombre, Tipo, Nivel,Descripcion, idMundo) VALUES ('" + Nombre + "', + '" + Tipo + "','" + Nivel + "', '" + Descripcion + "', '" + idMundo + "', '" + idFinal + "', '" + idRing + "', '" + idEra + "', '" + idEscena + "', '" + idBandaSonora + "', '" + idEsmeralda + "')";
            ConexionMySQL.EjecutaConsulta(consulta);
            MostrarDatos();

            textBox1.Clear();
            textBox2.Clear();
            textBox5.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();
            textBox10.Clear();
            textBox11.Clear();

        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            string Nombre = textBox1.Text;
            string Tipo = textBox2.Text;
            string Nivel = textBox5.Text;
            string Descripcion = textBox3.Text;
            string idMundo = textBox4.Text;
            string idFinal = textBox6.Text;
            string idRing = textBox7.Text;
            string idEra = textBox8.Text;
            string idEscena = textBox9.Text;
            string idBandaSonora = textBox10.Text;
            string idEsmeralda = textBox11.Text;
            int idZona = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE Zona SET Nombre = '" + Nombre + "',Tipo = '" + Tipo + "',Nivel = '" + Nivel + "',Descripcion = '" + Descripcion + "',idMundo = '" + idMundo + "',idFinal = '" + idFinal + "',idRing = '" + idRing + "',idEra = '" + idEra + "',idEscena = '" + idEscena + "',idBandaSonora = '" + idBandaSonora + "',idEsmeralda = '" + idEsmeralda + "'  WHERE idZona = " + idZona.ToString();
            ConexionMySQL.EjecutaConsulta(consulta);
            MostrarDatos();

            textBox1.Clear();
            textBox2.Clear();
            textBox5.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();
            textBox10.Clear();
            textBox11.Clear();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            int idZona = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE Zona SET  estatus = 0 WHERE idZona =  " + idZona.ToString(); ;
            ConexionMySQL.EjecutaConsulta(consulta);
            MostrarDatos();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            ZonaMundo app = new ZonaMundo();
            app.Show();
            this.Hide();
        }
    }
}
