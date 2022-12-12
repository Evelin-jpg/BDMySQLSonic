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
    public partial class Dimension : Form
    {
        string consulta;
        public Dimension()
        {
            InitializeComponent();
        }

        private void Dimension_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }
        private void MostrarDatos()
        {
            dataGridView1.DataSource = ConexionMySQL.EjecutaConsultaSelect("SELECT * FROM Dimension ORDER BY idDimension");
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string Nombre = textBox1.Text;
            string Descripcion = textBox2.Text;
            string idMundo = textBox3.Text;
            

            consulta = "INSERT INTO Dimension(Nombre, Descripcion, idMundo) VALUES ('" + Nombre + "', + '" + Descripcion + "', '" + idMundo + "')";
            ConexionMySQL.EjecutaConsulta(consulta);
            MostrarDatos();

            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            string Nombre = textBox1.Text;
            string Descripcion = textBox2.Text;
            string idMundo = textBox3.Text;
      
            int idDimension = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE Dimension SET Nombre = '" + Nombre + "',Descripcion = '" + Descripcion + "',idMundo = '" + idMundo + "'  WHERE idDimension = " + idDimension.ToString();
            ConexionMySQL.EjecutaConsulta(consulta);
            MostrarDatos();

            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
           
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            int idDimension = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE Dimension SET  estatus = 0 WHERE idDimension =  " + idDimension.ToString(); ;
            ConexionMySQL.EjecutaConsulta(consulta);
            MostrarDatos();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            DispositivoDeEntrada app = new DispositivoDeEntrada();
            app.Show();
            this.Hide();
        }
    }
}
