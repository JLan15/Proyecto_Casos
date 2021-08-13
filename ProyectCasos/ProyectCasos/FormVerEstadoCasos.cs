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
    public partial class FormVerEstadoCasos : Form
    {
        public FormVerEstadoCasos()
        {
            InitializeComponent();
        }

        public void CargarDatosDataGridViewEstado()
        {
            Conexion cn = new Conexion();
            //SqlConnection cn = new SqlConnection("Data Source=DESKTOP-KNIF4SO;Initial Catalog=Proyecto_Casos;User ID=sa;Password=123");
            //SqlConnection cn = new SqlConnection("Data Source=DESKTOP-GBVPD8B;Initial Catalog=ProyectoCasos;User ID=sa;Password=1234");
            //SqlConnection cn = new SqlConnection("Data Source=DESKTOP-T0686SL;Initial Catalog=Proyecto_Casos;User ID=sa;Password=lfer");

            cn.AbrirConeccion();
            SqlCommand com = new SqlCommand("exec dbo.SP_VerEstadoCasos", cn.AbrirConeccion());
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dtgCrearEstadoCasos.DataSource = dt;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormVerEstadoCasos_Load(object sender, EventArgs e)
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

            CargarDatosDataGridViewEstado();
        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            CargarDatosDataGridViewEstado();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            FormAgregarEstadoCasos FrmAgregar = new FormAgregarEstadoCasos();
            FrmAgregar.Show();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            FormBorrarEstadoCasos FrmBorrar = new FormBorrarEstadoCasos();
            FrmBorrar.Show();
        }

        private void dtgCrearEstadoCasos_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            FormEditarEstadoCasos FrmEditar = new FormEditarEstadoCasos();

            FrmEditar.txtIdEstado.Text = dtgCrearEstadoCasos.CurrentRow.Cells[0].Value.ToString();
            FrmEditar.txtNombreEstadoCasos.Text = dtgCrearEstadoCasos.CurrentRow.Cells[1].Value.ToString();

            FrmEditar.Show();
        }
    }
}
