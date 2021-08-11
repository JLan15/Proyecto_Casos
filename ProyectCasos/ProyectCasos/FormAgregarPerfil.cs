using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectCasos
{
    public partial class FormAgregarPerfil : Form
    {
        public FormAgregarPerfil()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Form1 Fr = new Form1();
            Conexion cn = new Conexion();
            //SqlConnection cn = new SqlConnection("Data Source=DESKTOP-KNIF4SO;Initial Catalog=Proyecto_Casos;User ID=sa;Password=123");
            //SqlConnection cn = new SqlConnection("Data Source=DESKTOP-GBVPD8B;Initial Catalog=ProyectoCasos;User ID=sa;Password=1234");
            //SqlConnection cn = new SqlConnection("Data Source=DESKTOP-T0686SL;Initial Catalog=Proyecto_Casos;User ID=sa;Password=lfer");

            try
            {
                cn.AbrirConeccion();
                SqlCommand com = new SqlCommand("exec dbo.SP_CrearPerfil '" + int.Parse(txtIdPerfil.Text) + "', '" + txtNumIdentidad.Text + "' ,'" + txtNombre.Text + "', '" + cmbSexo.Text + "','" + int.Parse(txtEdad.Text) + "','" + cmbEstadoCivil.Text + "', '" + DateTime.Parse(dtpFechaNacimiento.Text) + "', '" + txtDomicilio.Text + "', '" + txtTelefono.Text + "', '" + txtCelular.Text + "'", cn.AbrirConeccion());
                com.ExecuteNonQuery();
                Fr.CargarDatosDataGridView();
                MessageBox.Show("Datos Guardados Con Exito", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //Fr.CargarDatosDataGridView();
                cn.CerrarConeccion();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void VerDatosDataGridView()
        {
            Conexion cn = new Conexion();
            FormAgregarExpediente Ag = new FormAgregarExpediente();
            //SqlConnection cn = new SqlConnection("Data Source=DESKTOP-KNIF4SO;Initial Catalog=Proyecto_Casos;User ID=sa;Password=123");
            // SqlConnection cn = new SqlConnection("Data Source=DESKTOP-GBVPD8B;Initial Catalog=ProyectoCasos;User ID=sa;Password=1234");
            //SqlConnection cn = new SqlConnection("Data Source=DESKTOP-T0686SL;Initial Catalog=Proyecto_Casos;User ID=sa;Password=lfer");

            cn.AbrirConeccion();
            SqlCommand com = new SqlCommand("exec dbo.SP_VerPerfil", cn.AbrirConeccion());
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            da.Fill(dt);
            //dtgCrearExpediente.DataSource = dt;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
