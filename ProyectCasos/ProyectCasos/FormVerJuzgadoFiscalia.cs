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
    public partial class FormVerJuzgadoFiscalia : Form
    {
        public FormVerJuzgadoFiscalia()
        {
            InitializeComponent();
        }

        public void CargarDatosDataGridViewJuzgado()
        {
            Conexion cn = new Conexion();
            //SqlConnection cn = new SqlConnection("Data Source=DESKTOP-KNIF4SO;Initial Catalog=Proyecto_Casos;User ID=sa;Password=123");
            //SqlConnection cn = new SqlConnection("Data Source=DESKTOP-GBVPD8B;Initial Catalog=ProyectoCasos;User ID=sa;Password=1234");
            //SqlConnection cn = new SqlConnection("Data Source=DESKTOP-T0686SL;Initial Catalog=Proyecto_Casos;User ID=sa;Password=lfer");

            cn.AbrirConeccion();
            SqlCommand com = new SqlCommand("exec dbo.SP_VerJuzgadoFiscalia", cn.AbrirConeccion());
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dtgCrearJuzgadoFiscalia.DataSource = dt;
        }

        private void FormVerJuzgadoFiscalia_Load(object sender, EventArgs e)
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

            CargarDatosDataGridViewJuzgado();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            FormAgregarJuzgadoFiscalia FrmAgregar = new FormAgregarJuzgadoFiscalia();
            FrmAgregar.Show();
        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            CargarDatosDataGridViewJuzgado();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            FormBorrarJuzgadoFiscalia FrmBorrar = new FormBorrarJuzgadoFiscalia();
            FrmBorrar.Show();
        }

        private void dtgCrearJuzgadoFiscalia_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            FormEditarJuzgadoFiscalia FrmEditar = new FormEditarJuzgadoFiscalia();

            FrmEditar.txtIdJuzgado.Text = dtgCrearJuzgadoFiscalia.CurrentRow.Cells[0].Value.ToString();
            FrmEditar.txtNombreJuzgadoFiscalia.Text = dtgCrearJuzgadoFiscalia.CurrentRow.Cells[1].Value.ToString();

            FrmEditar.Show();
        }
    }
}
