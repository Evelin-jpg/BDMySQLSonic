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
    public partial class BandaSonoraZona : Form
    {
        string consulta;
        public BandaSonoraZona()
        {
            InitializeComponent();
        }

        private void BandaSonoraZona_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }
        private void MostrarDatos()
        {
            dataGridView1.DataSource = ConexionMySQL.EjecutaConsultaSelect("SELECT * FROM BandaSonoraZona ORDER BY idBandaSonoraZona");
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string idBandaSonora = textBox1.Text;
            string idZona = textBox2.Text;
            

            consulta = "INSERT INTO BandaSonoraZona(idBandaSonora, idZona) VALUES ('" + idBandaSonora+ "', + '" + idZona  + "')";
            ConexionMySQL.EjecutaConsulta(consulta);
            MostrarDatos();

            textBox1.Clear();
            textBox2.Clear();
        
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            string idBandaSonora = textBox1.Text;
            string idZona = textBox2.Text;
            

            int idBandaSonoraZona = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE BandaSonoraZona SET idBandaSonora = '" + idBandaSonora + "',idZona = '" + idZona + "'  WHERE idBandaSonoraZona = " + idBandaSonoraZona.ToString();
            ConexionMySQL.EjecutaConsulta(consulta);
            MostrarDatos();

            textBox1.Clear();
            textBox2.Clear();
          
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            int idBandaSonoraZona = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE BandaSonoraZona SET  estatus = 0 WHERE idBandaSonoraZona =  " + idBandaSonoraZona.ToString(); ;
            ConexionMySQL.EjecutaConsulta(consulta);
            MostrarDatos();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            Bucle app = new Bucle();
            app.Show();
            this.Hide();
        }
    }
}
