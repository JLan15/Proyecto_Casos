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
    public partial class FormVerDelito : Form
    {
        public FormVerDelito()
        {
            InitializeComponent();
        }

        public void CargarDatosDataGridViewDelito()
        {
            Conexion cn = new Conexion();
            //SqlConnection cn = new SqlConnection("Data Source=DESKTOP-KNIF4SO;Initial Catalog=Proyecto_Casos;User ID=sa;Password=123");
            //SqlConnection cn = new SqlConnection("Data Source=DESKTOP-GBVPD8B;Initial Catalog=ProyectoCasos;User ID=sa;Password=1234");
            //SqlConnection cn = new SqlConnection("Data Source=DESKTOP-T0686SL;Initial Catalog=Proyecto_Casos;User ID=sa;Password=lfer");

            cn.AbrirConeccion();
            SqlCommand com = new SqlCommand("exec dbo.SP_VerDelito", cn.AbrirConeccion());
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dtgCrearDelito.DataSource = dt;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormVerDelito_Load(object sender, EventArgs e)
        {
          
        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {

            CargarDatosDataGridViewDelito();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            FormAgregarDelito FrmAgregar = new FormAgregarDelito();
            FrmAgregar.Show();
        }

        private void FormVerDelito_Load_1(object sender, EventArgs e)
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

            CargarDatosDataGridViewDelito();
        }

        private void dtgCrearDelito_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            FormEditarDelito FrmEditar = new FormEditarDelito();

            FrmEditar.txtIdDelito.Text = dtgCrearDelito.CurrentRow.Cells[0].Value.ToString();
            FrmEditar.txtNombreDelito.Text = dtgCrearDelito.CurrentRow.Cells[1].Value.ToString();

            FrmEditar.Show();
        }

        private void btnRefrescar_Click_1(object sender, EventArgs e)
        {
            CargarDatosDataGridViewDelito();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            FormBorrarDelito FrmBorrar = new FormBorrarDelito();
            FrmBorrar.Show();
        }

        private void dtgCrearDelito_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
    
}
