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
    public partial class FormVerDireccionAsignada : Form
    {
        public FormVerDireccionAsignada()
        {
            InitializeComponent();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void CargarDatosDataGridViewDireccion()
        {
            Conexion cn = new Conexion();
            //SqlConnection cn = new SqlConnection("Data Source=DESKTOP-KNIF4SO;Initial Catalog=Proyecto_Casos;User ID=sa;Password=123");
            //SqlConnection cn = new SqlConnection("Data Source=DESKTOP-GBVPD8B;Initial Catalog=ProyectoCasos;User ID=sa;Password=1234");
            //SqlConnection cn = new SqlConnection("Data Source=DESKTOP-T0686SL;Initial Catalog=Proyecto_Casos;User ID=sa;Password=lfer");

            cn.AbrirConeccion();
            SqlCommand com = new SqlCommand("exec dbo.SP_VerDireccionAsignada", cn.AbrirConeccion());
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dtgCrearDireccion.DataSource = dt;
        }

        private void FormVerDireccionAsignada_Load(object sender, EventArgs e)
        {
           
        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            CargarDatosDataGridViewDireccion();

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            FormAgregarDireccionAsignada FrmAgregar = new FormAgregarDireccionAsignada();
            FrmAgregar.Show();
        }

        private void PanelPrincipal_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FormVerDireccionAsignada_Load_1(object sender, EventArgs e)
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

            CargarDatosDataGridViewDireccion();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            FormBorrarDireccionAsignada FrmBorrar = new FormBorrarDireccionAsignada();
            FrmBorrar.Show();
        }

        private void dtgCrearDireccion_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            FormEditarDireccionAsignada FrmEditar = new FormEditarDireccionAsignada();

            FrmEditar.txtIdDireccion.Text = dtgCrearDireccion.CurrentRow.Cells[0].Value.ToString();
            FrmEditar.txtNombreDireccionAsignada.Text = dtgCrearDireccion.CurrentRow.Cells[1].Value.ToString();

            FrmEditar.Show();
        }
    }
}
