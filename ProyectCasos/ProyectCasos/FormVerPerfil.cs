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
    public partial class FormVerPerfil : Form
    {
        public FormVerPerfil()
        {
            InitializeComponent();
        }

        public void CargarDatosDataGridViewPerfil()
        {
            Conexion cn = new Conexion();
            //SqlConnection cn = new SqlConnection("Data Source=DESKTOP-KNIF4SO;Initial Catalog=Proyecto_Casos;User ID=sa;Password=123");
            //SqlConnection cn = new SqlConnection("Data Source=DESKTOP-GBVPD8B;Initial Catalog=ProyectoCasos;User ID=sa;Password=1234");
            //SqlConnection cn = new SqlConnection("Data Source=DESKTOP-T0686SL;Initial Catalog=Proyecto_Casos;User ID=sa;Password=lfer");

            cn.AbrirConeccion();
            SqlCommand com = new SqlCommand("exec dbo.SP_VerPerfil", cn.AbrirConeccion());
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dtgCrearPerfil.DataSource = dt;
        }

        private void bunifuCustomLabel1_Click(object sender, EventArgs e)
        {

        }

        private void dtgCrearPerfil_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void PanelPrincipal_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FormVerPerfil_Load(object sender, EventArgs e)
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

            CargarDatosDataGridViewPerfil();
        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            CargarDatosDataGridViewPerfil();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            FormAgregarPerfil FrmAgregar = new FormAgregarPerfil();
            FrmAgregar.Show();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dtgCrearPerfil_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            
        }

        private void dtgCrearPerfil_CellMouseDoubleClick_1(object sender, DataGridViewCellMouseEventArgs e)
        {
            FormEditarPerfil FrmEditar = new FormEditarPerfil();

            FrmEditar.txtIdPerfil.Text = dtgCrearPerfil.CurrentRow.Cells[0].Value.ToString();
            FrmEditar.txtNumIdentidad.Text = dtgCrearPerfil.CurrentRow.Cells[1].Value.ToString();
            FrmEditar.txtNombre.Text = dtgCrearPerfil.CurrentRow.Cells[2].Value.ToString();
            FrmEditar.cmbSexo.Text = dtgCrearPerfil.CurrentRow.Cells[3].Value.ToString();
            FrmEditar.txtEdad.Text = dtgCrearPerfil.CurrentRow.Cells[4].Value.ToString();
            FrmEditar.cmbEstadoCivil.Text = dtgCrearPerfil.CurrentRow.Cells[5].Value.ToString();
            FrmEditar.dtpFechaNacimiento.Text = dtgCrearPerfil.CurrentRow.Cells[6].Value.ToString();
            FrmEditar.txtDomicilio.Text = dtgCrearPerfil.CurrentRow.Cells[7].Value.ToString();
            FrmEditar.txtTelefono.Text = dtgCrearPerfil.CurrentRow.Cells[8].Value.ToString();
            FrmEditar.txtCelular.Text = dtgCrearPerfil.CurrentRow.Cells[9].Value.ToString();

            FrmEditar.Show();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            FormBorrarPerfil FrBorrar = new FormBorrarPerfil();
            FrBorrar.Show();
        }

        /*FormEditarPerfil FrmEditar = new FormEditarPerfil();

        FrmEditar.txtIdPerfil.Text = dtgCrearPerfil.CurrentRow.Cells[0].Value.ToString();
            FrmEditar.txtNumIdentidad.Text = dtgCrearPerfil.CurrentRow.Cells[1].Value.ToString();
            FrmEditar.txtNombres.Text = dtgCrearPerfil.CurrentRow.Cells[2].Value.ToString();
            FrmEditar.txtApellidos.Text = dtgCrearPerfil.CurrentRow.Cells[3].Value.ToString();
            FrmEditar.cmbSexo.Text = dtgCrearPerfil.CurrentRow.Cells[4].Value.ToString();
            FrmEditar.txtEdad.Text = dtgCrearPerfil.CurrentRow.Cells[5].Value.ToString();
            FrmEditar.cmbEstadoCivil.Text = dtgCrearPerfil.CurrentRow.Cells[6].Value.ToString();
            FrmEditar.dtpFechaNacimiento.Text = dtgCrearPerfil.CurrentRow.Cells[7].Value.ToString();
            FrmEditar.txtDomicilio.Text = dtgCrearPerfil.CurrentRow.Cells[8].Value.ToString();
            FrmEditar.txtTelefono.Text = dtgCrearPerfil.CurrentRow.Cells[9].Value.ToString();
            FrmEditar.txtCelular.Text = dtgCrearPerfil.CurrentRow.Cells[10].Value.ToString();

            FrmEditar.Show()*/
    }
}
