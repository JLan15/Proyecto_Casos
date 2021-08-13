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
    public partial class FormVerRango : Form
    {
        public FormVerRango()
        {
            InitializeComponent();
        }

        public void CargarDatosDataGridViewRango()
        {
            Conexion cn = new Conexion();
            //SqlConnection cn = new SqlConnection("Data Source=DESKTOP-KNIF4SO;Initial Catalog=Proyecto_Casos;User ID=sa;Password=123");
            //SqlConnection cn = new SqlConnection("Data Source=DESKTOP-GBVPD8B;Initial Catalog=ProyectoCasos;User ID=sa;Password=1234");
            //SqlConnection cn = new SqlConnection("Data Source=DESKTOP-T0686SL;Initial Catalog=Proyecto_Casos;User ID=sa;Password=lfer");

            cn.AbrirConeccion();
            SqlCommand com = new SqlCommand("exec dbo.SP_VerRango", cn.AbrirConeccion());
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dtgCrearRango.DataSource = dt;
        }

        private void FormVerRango_Load(object sender, EventArgs e)
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

            CargarDatosDataGridViewRango();
        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            CargarDatosDataGridViewRango();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            FormAgregarRango FrmAgregar = new FormAgregarRango();
            FrmAgregar.Show();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            FormBorrarRango FrmBorrar = new FormBorrarRango();
            FrmBorrar.Show();
        }

        private void dtgCrearRango_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            FormEditarRango FrmEditar = new FormEditarRango();

            FrmEditar.txtIdRango.Text = dtgCrearRango.CurrentRow.Cells[0].Value.ToString();
            FrmEditar.txtNombreRango.Text = dtgCrearRango.CurrentRow.Cells[1].Value.ToString();

            FrmEditar.Show();
        }
    }
}
