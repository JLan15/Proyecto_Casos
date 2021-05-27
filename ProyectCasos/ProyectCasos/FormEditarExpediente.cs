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
    public partial class FormEditarExpediente : Form
    {
        public FormEditarExpediente()
        {
            InitializeComponent();
            ListarCondicionJuridica();
            ListarDireccionAsignada();
            ListarJuzgadoFiscalia();
            ListarEstado();
            ListarRango();
            ListarSegundaCondicionJuridica();
        }
       
        private void btnSalir_Click(object sender, EventArgs e)
        {
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
        /*public void CargarDatosDataGridView()
        {
            Form1 Frm = new Form1();
            SqlConnection cn = new SqlConnection("Data Source=DESKTOP-GBVPD8B;Initial Catalog=ProyectoCasos;User ID=sa;Password=1234");
            cn.Open();
            SqlCommand com = new SqlCommand("exec dbo.SP_VerExpediente", cn);
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            da.Fill(dt);
            Frm.dtgCrearExpediente.DataSource = dt;
        }*/

        private void btnEditar_Click(object sender, EventArgs e)
        {
            Form1 Fr = new Form1();
            Conexion cn = new Conexion();
            //SqlConnection cn = new SqlConnection("Data Source=DESKTOP-KNIF4SO;Initial Catalog=Proyecto_Casos;User ID=sa;Password=123");
            // SqlConnection cn = new SqlConnection("Data Source=DESKTOP-GBVPD8B;Initial Catalog=ProyectoCasos;User ID=sa;Password=1234");
            //SqlConnection cn = new SqlConnection("Data Source=DESKTOP-T0686SL;Initial Catalog=Proyecto_Casos;User ID=sa;Password=lfer");

            try
            { 
                if (int.Parse(txtIdExp.Text) > 0)
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
                    SqlCommand com = new SqlCommand("exec dbo.SP_ActualizarExpediente '" + int.Parse(txtIdExp.Text) + "', '" + txtCodigo.Text + "' ,'" + txtNum.Text + "', '" + DateTime.Parse(dtpFecha.Text) + "', '" + Convert.ToInt32(cmbCondicionJuridica.SelectedValue) + "','" + Convert.ToInt32(cmbDireccionAsignada.SelectedValue) + "','" + Convert.ToInt32(cmbJuzgadoFiscalia.SelectedValue) + "', '" + Convert.ToInt32(cmbEstadoCaso.SelectedValue) + "', '" + Convert.ToInt32(cmbRango.SelectedValue) + "', '" + +Convert.ToInt32(cmbSegundaCondicion.SelectedValue) + "', '" + txtLugarHechos.Text + "', '" + DateTime.Parse(dtpFechaHechos.Text) + "', '" + VariablesGlobales.status + "'", cn.AbrirConeccion());
                    com.ExecuteNonQuery();
                    //cn.Close();
                    MessageBox.Show("Datos Actualizados Con Exito", "Actualizado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //Fr.CargarDatosDataGridView();
                    //CargarDatosDataGridView();
                    cn.CerrarConeccion();
                    this.Close();
                   
                }
                else
                {
                    MessageBox.Show("Selecciona un Expediente para Actualizar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }


        /*public void CargarDatosDataGridView()
        {
            Form1 Fr = new Form1();
            SqlConnection cn = new SqlConnection("Data Source=DESKTOP-GBVPD8B;Initial Catalog=ProyectoCasos;User ID=sa;Password=1234");
            cn.Open();
            SqlCommand com = new SqlCommand("exec dbo.SP_VerExpediente", cn);
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            da.Fill(dt);
            Fr.dtgCrearExpediente.DataSource = dt;
        }*/

        private void FormEditarExpediente_Load(object sender, EventArgs e)
        {
            /*ListarCondicionJuridica();
            ListarDireccionAsignada();
            ListarJuzgadoFiscalia();
            ListarEstado();
            ListarRango();
            ListarSegundaCondicionJuridica();*/
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void cmbSegundaCondicion_Click(object sender, EventArgs e)
        {
            
        }

        private void cmbRango_MouseClick(object sender, MouseEventArgs e)
        {
            //ListarRango();
        }

        private void cmbSegundaCondicion_MouseClick(object sender, MouseEventArgs e)
        {
            //ListarSegundaCondicionJuridica();
        }

        private void cmbSegundaCondicion_KeyPress(object sender, KeyPressEventArgs e)
        {
            //e.Handled = true;
        }

        private void cmbRango_KeyPress(object sender, KeyPressEventArgs e)
        {
            //e.Handled = true;
        }

        private void cmbEstadoCaso_MouseClick(object sender, MouseEventArgs e)
        {
            //ListarEstado();
        }

        private void cmbEstadoCaso_KeyPress(object sender, KeyPressEventArgs e)
        {
            //e.Handled = true;
        }

        private void cmbJuzgadoFiscalia_MouseClick(object sender, MouseEventArgs e)
        {
            //ListarJuzgadoFiscalia();
        }

        private void cmbJuzgadoFiscalia_KeyPress(object sender, KeyPressEventArgs e)
        {
            //e.Handled = true;
        }

        private void cmbDireccionAsignada_MouseClick(object sender, MouseEventArgs e)
        {
            //ListarDireccionAsignada();
        }

        private void cmbDireccionAsignada_KeyPress(object sender, KeyPressEventArgs e)
        {
            //e.Handled = true;
        }

        private void cmbCondicionJuridica_MouseClick(object sender, MouseEventArgs e)
        {
            //ListarCondicionJuridica();
        }

        private void cmbCondicionJuridica_KeyPress(object sender, KeyPressEventArgs e)
        {
            //e.Handled = true;
        }

        private void FormEditarExpediente_FormClosing(object sender, FormClosingEventArgs e)
        {
           
        }

        private void bunifuThinButton21_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        private void cmbCondicionJuridica_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void btnEditar_MouseClick(object sender, MouseEventArgs e)
        {
            VariablesGlobales.btneditarpresionado = true;
                
        }
    }
}
