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
    public partial class FormEditarEstadoCasos : Form
    {
        public FormEditarEstadoCasos()
        {
            InitializeComponent();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            Conexion cn = new Conexion();
            //SqlConnection cn = new SqlConnection("Data Source=DESKTOP-KNIF4SO;Initial Catalog=Proyecto_Casos;User ID=sa;Password=123");
            //SqlConnection cn = new SqlConnection("Data Source=DESKTOP-GBVPD8B;Initial Catalog=ProyectoCasos;User ID=sa;Password=1234");
            //SqlConnection cn = new SqlConnection("Data Source=DESKTOP-T0686SL;Initial Catalog=Proyecto_Casos;User ID=sa;Password=lfer");

            try
            {

                if (int.Parse(txtIdEstado.Text) > 0)
                {

                    cn.AbrirConeccion();
                    SqlCommand com = new SqlCommand("exec dbo.SP_ActualizarEstadoCasos '" + int.Parse(txtIdEstado.Text) + "','" + txtNombreEstadoCasos.Text + "'", cn.AbrirConeccion());
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
                    MessageBox.Show("Selecciona ID para Actualizar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
