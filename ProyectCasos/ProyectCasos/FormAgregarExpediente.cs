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

        private void ListarEstado()
        {
            ListadosCombobox LCombo = new ListadosCombobox();
            cmbEstadoCaso.DataSource = LCombo.ListarComboEstadoCasos();
            cmbEstadoCaso.DisplayMember = "Nombre_Estado";
            cmbEstadoCaso.ValueMember = "Id_Estado";
        }

        private void ListarRango()
        {
            ListadosCombobox LCombo = new ListadosCombobox();
            cmbRango.DataSource = LCombo.ListarComboRango();
            cmbRango.DisplayMember = "Nombre_Rango";
            cmbRango.ValueMember = "Id_Rango";
        }

        private void ListarSegundaCondicionJuridica()
        {
            ListadosCombobox LCombo = new ListadosCombobox();
            cmbSegundaCondicion.DataSource = LCombo.ListarComboCondicionJuridica();
            cmbSegundaCondicion.DisplayMember = "Nombre_Condicion";
            cmbSegundaCondicion.ValueMember = "Id_Condicion";
        }

        /*private void ListarPerfil()
        {
            ListadosCombobox LCombo = new ListadosCombobox();
            cmbNombrePerfil.DataSource = LCombo.ListarComboPerfil();
            cmbNombrePerfil.DisplayMember = "Nombre";
            cmbNombrePerfil.ValueMember = "Id_Perfil";
        }

        private void ListarSegundoPerfil()
        {
            ListadosCombobox LCombo = new ListadosCombobox();
            cmbNombreSegundoPerfil.DataSource = LCombo.ListarComboPerfil();
            cmbNombreSegundoPerfil.DisplayMember = "Nombre";
            cmbNombreSegundoPerfil.ValueMember = "Id_Perfil";
        }*/

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
                SqlCommand com = new SqlCommand("exec dbo.SP_CrearExpediente '" + int.Parse(txtIdExp.Text) + "', '" + Convert.ToInt32(cmbCondicionJuridica.SelectedValue) + "' , '" + Convert.ToInt32(cmbNombrePerfil.SelectedValue) + "','" + Convert.ToInt32(cmbRango.SelectedValue) + "', '" + Convert.ToInt32(cmbDireccionAsignada.SelectedValue) + "', '" + txtLugarHechos.Text + "','" + DateTime.Parse(dtpFechaHechos.Text) + "','" + Convert.ToInt32(cmbDelito.SelectedValue) + "', '" + Convert.ToInt32(cmbMedidas.SelectedItem) + "', '" + Convert.ToInt32(cmbReclucion.SelectedItem) + "', '" + Convert.ToInt32(cmbSegundaCondicion.SelectedValue) + "', '" + Convert.ToInt32(cmbNombreSegundoPerfil.SelectedValue) + "','" + Convert.ToInt32(cmbJuzgadoFiscalia.SelectedValue) + "', '" + txtNum.Text + "', '" + txtCodigo.Text + "', '" + DateTime.Parse(dtpFecha.Text) + "', '" + Convert.ToInt32(cmbEstadoCaso.SelectedValue) + "', '" + Convert.ToInt32(cmbRecursoReposicion.SelectedItem) + "', '" + Convert.ToInt32(cmbRecursoApelacion.SelectedItem) + "', '" + Convert.ToInt32(cmbRecursoAmparo.SelectedItem) + "', '" + Convert.ToInt32(cmbRecursoHabeasCorpus.SelectedItem) + "', '" + txtOtro.Text + "', '" + txtObservaciones.Text + "', '" + VariablesGlobales.status + "'", cn.AbrirConeccion());
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

        public void LitarDelito()
        {
            Conexion con = new Conexion();
            SqlCommand com = new SqlCommand();
            SqlDataReader LeerFilas;
            DataTable Tabla = new DataTable();
            com.Connection = con.AbrirConeccion();
            com.CommandText = "SP_ListarDelito";
            com.CommandType = CommandType.StoredProcedure;
            LeerFilas = com.ExecuteReader();
            Tabla.Load(LeerFilas);
            cmbDelito.DataSource = Tabla;
            cmbDelito.DisplayMember = "Nombre_Delito";
            cmbDelito.ValueMember = "Id_Delito";

            AutoCompleteStringCollection coleccion = new AutoCompleteStringCollection();
            foreach (DataRow row in Tabla.Rows)
            {
                coleccion.Add(Convert.ToString(row["Nombre_Delito"]));
            }
            cmbDelito.AutoCompleteCustomSource = coleccion;
            cmbDelito.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbDelito.AutoCompleteSource = AutoCompleteSource.CustomSource;
            //LeerFilas.Close();
            com.Connection = con.CerrarConeccion();
        }

        public void LitarPerfil()
        {
            Conexion con = new Conexion();
            SqlCommand com = new SqlCommand();
            SqlDataReader LeerFilas;
            DataTable Tabla = new DataTable();
            com.Connection = con.AbrirConeccion();
            com.CommandText = "SP_ListarPerfil";
            com.CommandType = CommandType.StoredProcedure;
            LeerFilas = com.ExecuteReader();
            Tabla.Load(LeerFilas);
            cmbNombrePerfil.DataSource = Tabla;
            cmbNombrePerfil.DisplayMember = "Nombre";
            cmbNombrePerfil.ValueMember = "Id_Perfil";

            AutoCompleteStringCollection coleccion = new AutoCompleteStringCollection();
            foreach (DataRow row in Tabla.Rows)
            {
                coleccion.Add(Convert.ToString(row["Nombre"]));
            }
            cmbNombrePerfil.AutoCompleteCustomSource = coleccion;
            cmbNombrePerfil.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbNombrePerfil.AutoCompleteSource = AutoCompleteSource.CustomSource;
            //LeerFilas.Close();
            com.Connection = con.CerrarConeccion();
        }

        public void ListarSegundoPerfil()
        {
            Conexion con = new Conexion();
            SqlCommand com = new SqlCommand();
            SqlDataReader LeerFilas;
            DataTable Tabla = new DataTable();
            com.Connection = con.AbrirConeccion();
            com.CommandText = "SP_ListarPerfil";
            com.CommandType = CommandType.StoredProcedure;
            LeerFilas = com.ExecuteReader();
            Tabla.Load(LeerFilas);
            cmbNombreSegundoPerfil.DataSource = Tabla;
            cmbNombreSegundoPerfil.DisplayMember = "Nombre";
            cmbNombreSegundoPerfil.ValueMember = "Id_Perfil";

            AutoCompleteStringCollection coleccion = new AutoCompleteStringCollection();
            foreach (DataRow row in Tabla.Rows)
            {
                coleccion.Add(Convert.ToString(row["Nombre"]));
            }
            cmbNombreSegundoPerfil.AutoCompleteCustomSource = coleccion;
            cmbNombreSegundoPerfil.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbNombreSegundoPerfil.AutoCompleteSource = AutoCompleteSource.CustomSource;
            //LeerFilas.Close();
            com.Connection = con.CerrarConeccion();
        }
        private void FormAgregarExpediente_Load(object sender, EventArgs e)
        {
            cmbMedidas.SelectedIndex = 0;
            cmbReclucion.SelectedIndex = 0;
            cmbRecursoReposicion.SelectedIndex = 0;
            cmbRecursoApelacion.SelectedIndex = 0;
            cmbRecursoAmparo.SelectedIndex = 0;
            cmbRecursoHabeasCorpus.SelectedIndex = 0;

            Conexion con = new Conexion();
            SqlCommand com = new SqlCommand();
            SqlDataReader LeerFilas;

            Form1 Fr = new Form1();
            Fr.CargarDatosDataGridView();
            ListarCondicionJuridica();
            ListarDireccionAsignada();
            ListarJuzgadoFiscalia();
            ListarEstado();
            ListarRango();
            ListarSegundaCondicionJuridica();
            LitarDelito();
            LitarPerfil();
            ListarSegundoPerfil();  
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbMedidas_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbReclucion_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbEstadoCaso_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbRecursoReposicion_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbRecursoApelacion_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbRecursoAmparo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbRecursoHabeasCorpus_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
