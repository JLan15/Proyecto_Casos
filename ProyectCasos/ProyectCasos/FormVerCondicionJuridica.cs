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
    public partial class FormVerCondicionJuridica : Form
    {
        public FormVerCondicionJuridica()
        {
            InitializeComponent();
        }


      

        public void CargarDatosDataGridViewCondicion()
        {
            Conexion cn = new Conexion();
            //SqlConnection cn = new SqlConnection("Data Source=DESKTOP-KNIF4SO;Initial Catalog=Proyecto_Casos;User ID=sa;Password=123");
            //SqlConnection cn = new SqlConnection("Data Source=DESKTOP-GBVPD8B;Initial Catalog=ProyectoCasos;User ID=sa;Password=1234");
            //SqlConnection cn = new SqlConnection("Data Source=DESKTOP-T0686SL;Initial Catalog=Proyecto_Casos;User ID=sa;Password=lfer");

            cn.AbrirConeccion();
            SqlCommand com = new SqlCommand("exec dbo.SP_VerCondicionJuridica", cn.AbrirConeccion());
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dtgCrearCondicion.DataSource = dt;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PanelPrincipal_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FormVerCondicionJuridica_Load(object sender, EventArgs e)
        {
            try
            {
                Conexion cn = new Conexion();
                //SqlConnection cn = new SqlConnection("Data Source=DESKTOP-KNIF4SO;Initial Catalog=Proyecto_Casos;User ID=sa;Password=123");
                //SqlConnection cn = new SqlConnection("Data Source=DESKTOP-GBVPD8B;Initial Catalog=ProyectoCasos;User ID=sa;Password=1234");
                //SqlConnection cn = new SqlConnection("Data Source=DESKTOP-T0686SL;Initial Catalog=Proyecto_Casos;User ID=sa;Password=lfer");

                cn.AbrirConeccion();
                MessageBox.Show("Conexion Exitosa");

            }
            catch (Exception)
            {
                MessageBox.Show("Conexion Erronea");
            }

            CargarDatosDataGridViewCondicion();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            FormAgregarCondicionJuridica FrmAgregarCondicion = new FormAgregarCondicionJuridica();
            FrmAgregarCondicion.Show();
        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            CargarDatosDataGridViewCondicion();
        }

        private void dtgCrearCondicion_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dtgCrearCondicion_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            FormEditarCondicionJuridica FrmEditar = new FormEditarCondicionJuridica();

            FrmEditar.txtIdCondicionJuridica.Text= dtgCrearCondicion.CurrentRow.Cells[0].Value.ToString();
            FrmEditar.txtNombreCondicionJuridica.Text= dtgCrearCondicion.CurrentRow.Cells[1].Value.ToString();
        
            FrmEditar.Show();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            FormBorrarCondicionJuridica FrmBorrar = new FormBorrarCondicionJuridica();
            FrmBorrar.Show();
        }
    }
}
