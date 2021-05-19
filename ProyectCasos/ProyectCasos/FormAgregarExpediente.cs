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
    public partial class FormAgregarExpediente : Form
    {

        public FormAgregarExpediente()
        {
            InitializeComponent();
        }


        private void btnSalir_Click(object sender, EventArgs e)
        {
            Form1 Fr = new Form1();
            Fr.CargarDatosDataGridView();
            this.Close();
        }

        private void btnSalir_MouseHover(object sender, EventArgs e)
        {
            
        }

        private void btnSalir_MouseLeave(object sender, EventArgs e)
        {
            
        }

        private void ListarCondicionJuridica()
        {
            ListadosCombobox LCombo = new ListadosCombobox();
            cmbCondicionJuridica.DataSource = LCombo.ListarComboCondicionJuridica();
            cmbCondicionJuridica.DisplayMember = "Nombre_Condicion";
            cmbCondicionJuridica.ValueMember = "Id_Condicion";
        }

        private void ListarDireccionAsignada()
        {
            ListadosCombobox LCombo = new ListadosCombobox();
            cmbDireccionAsignada.DataSource = LCombo.ListarComboDireccionAsignada();
            cmbDireccionAsignada.DisplayMember = "Nombre_Direccion";
            cmbDireccionAsignada.ValueMember = "Id_Direccion";
        }

        private void ListarJuzgadoFiscalia()
        {
            ListadosCombobox LCombo = new ListadosCombobox();
            cmbJuzgadoFiscalia.DataSource = LCombo.ListarComboJuzgadoFiscalia();
            cmbJuzgadoFiscalia.DisplayMember = "Nombre_Juzgado";
            cmbJuzgadoFiscalia.ValueMember = "Id_Juzgado";
        }
        public void btnGuardar_Click(object sender, EventArgs e)
        {
            Form1 Fr = new Form1();
            Conexion cn = new Conexion();
            //SqlConnection cn = new SqlConnection("Data Source=DESKTOP-KNIF4SO;Initial Catalog=Proyecto_Casos;User ID=sa;Password=123");
            // SqlConnection cn = new SqlConnection("Data Source=DESKTOP-GBVPD8B;Initial Catalog=ProyectoCasos;User ID=sa;Password=1234");
            //SqlConnection cn = new SqlConnection("Data Source=DESKTOP-T0686SL;Initial Catalog=Proyecto_Casos;User ID=sa;Password=lfer");

            try
            {        
                if (rdbActivo.Checked == true)
                {
                    VariablesGlobales.status = rdbActivo.Text;
                }
                else
                {
                    VariablesGlobales.status = rdbInactivo.Text;
                }
               

                cn.AbrirConeccion();
                SqlCommand com = new SqlCommand("exec dbo.SP_CrearExpediente '" + int.Parse(txtIdExp.Text) + "', '" + txtCodigo.Text + "' ,'" + txtNum.Text + "', '" + DateTime.Parse(dtpFecha.Text) + "', '" + Convert.ToInt32(cmbCondicionJuridica.SelectedValue) + "','" + Convert.ToInt32(cmbDireccionAsignada.SelectedValue) + "','" + Convert.ToInt32(cmbJuzgadoFiscalia.SelectedValue) + "', '" + txtLugarHechos.Text + "', '" + DateTime.Parse(dtpFechaHechos.Text) + "', '" + VariablesGlobales.status + "'", cn.AbrirConeccion());
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
            SqlCommand com = new SqlCommand("exec dbo.SP_VerExpediente", cn.AbrirConeccion());
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            da.Fill(dt);
            //dtgCrearExpediente.DataSource = dt;
        }

        private void FormAgregarExpediente_Load(object sender, EventArgs e)
        {
            Form1 Fr = new Form1();
            Fr.CargarDatosDataGridView();
            ListarCondicionJuridica();
            ListarDireccionAsignada();
            ListarJuzgadoFiscalia();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
    }
}
