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
                    SqlCommand com = new SqlCommand("exec dbo.SP_ActualizarExpediente '" + int.Parse(txtIdExp.Text) + "','" + txtCodigo.Text + "' ,'" + txtNum.Text + "', '" + DateTime.Parse(dtpFecha.Text) + "', '" + cmbRepresentado.Text + "', '" + txtLugarHechos.Text + "', '" + DateTime.Parse(dtpFechaHechos.Text) + "', '" + VariablesGlobales.status + "'", cn.AbrirConeccion());
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

        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
