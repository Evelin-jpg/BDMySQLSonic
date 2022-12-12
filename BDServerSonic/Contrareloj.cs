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
    public partial class Contrareloj : Form
    {
        string consulta;
        public Contrareloj()
        {
            InitializeComponent();
        }

        private void Contrareloj_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }
        private void MostrarDatos()
        {
            dataGridView1.DataSource = ConexionMySQL.EjecutaConsultaSelect("SELECT * FROM Contrareloj ORDER BY idContrareloj");
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string Limite = textBox1.Text;
            string Nombre = textBox3.Text;
            string Descripcion = textBox4.Text;

            consulta = "INSERT INTO Contrareloj(Limite, Nombre, Descripcion) VALUES ('" + Limite + "', '" + Nombre + "', '" + Descripcion + "')";
            ConexionMySQL.EjecutaConsulta(consulta);
            MostrarDatos();

            textBox1.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            string Limite = textBox1.Text;
            string Nombre = textBox3.Text;
            string Descripcion = textBox4.Text;
            int idContrareloj = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE Contrareloj SET Limite = '" + Limite + "',Nombre = '" + Nombre + "',Descripcion = '" + Descripcion + "'  WHERE idContrareloj = " + idContrareloj.ToString();
            ConexionMySQL.EjecutaConsulta(consulta);
            MostrarDatos();

            textBox1.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            int idContrareloj = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE Contrareloj SET  estatus = 0 WHERE idContrareloj =  " + idContrareloj.ToString(); ;
            ConexionMySQL.EjecutaConsulta(consulta);
            MostrarDatos();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            Defensa app = new Defensa();
            app.Show();
            this.Hide();
        }
    }
}
