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
    public partial class BandaSonora : Form
    {
        string consulta;
        public BandaSonora()
        {
            InitializeComponent();
        }

        private void BandaSonora_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }
        private void MostrarDatos()
        {
            dataGridView1.DataSource = ConexionMySQL.EjecutaConsultaSelect("SELECT * FROM BandaSonora ORDER BY idBandaSonora");
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string Nombre = textBox1.Text;
            string Tipo = textBox2.Text;
            string Descripcion = textBox3.Text;
           

            consulta = "INSERT INTO BandaSonora(Nombre, Especie, Descripcion) VALUES ('" + Nombre + "', + '" + Tipo + "', '" + Descripcion +  "')";
            ConexionMySQL.EjecutaConsulta(consulta);
            MostrarDatos();

            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
          
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            string Nombre = textBox1.Text;
            string Tipo = textBox2.Text;
            string Descripcion = textBox3.Text;
     
            int idBandaSonora = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE BandaSonora SET Nombre = '" + Nombre + "',Tipo = '" + Tipo + "',Descripcion = '" + Descripcion +  "'  WHERE idBandaSonora = " + idBandaSonora.ToString();
            ConexionMySQL.EjecutaConsulta(consulta);
            MostrarDatos();

            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
          
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            int idBandaSonora = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE BandaSonora SET  estatus = 0 WHERE idBandaSonora =  " + idBandaSonora.ToString(); ;
            ConexionMySQL.EjecutaConsulta(consulta);
            MostrarDatos();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            BandaSonoraZona app = new BandaSonoraZona();
            app.Show();
            this.Hide();
        }
    }
}
