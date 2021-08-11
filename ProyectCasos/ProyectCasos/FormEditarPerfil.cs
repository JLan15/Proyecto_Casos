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
    public partial class FormEditarPerfil : Form
    {
        public FormEditarPerfil()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (int.Parse(txtIdPerfil.Text) > 0)
                {
                    Conexion cn = new Conexion();

                    cn.AbrirConeccion();
                    SqlCommand com = new SqlCommand("exec dbo.SP_ActualizarPerfil '" + int.Parse(txtIdPerfil.Text) + "', '" + txtNumIdentidad.Text + "' ,'" + txtNombre.Text + "', '" + cmbSexo.Text + "','" + int.Parse(txtEdad.Text) + "','" + cmbEstadoCivil.Text + "', '" + DateTime.Parse(dtpFechaNacimiento.Text) + "', '" + txtDomicilio.Text + "', '" + txtTelefono.Text + "', '" + txtCelular.Text + "'", cn.AbrirConeccion());
                    com.ExecuteNonQuery();
                    MessageBox.Show("Datos Actualizados Con Exito", "Actualizado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //Fr.CargarDatosDataGridView();
                    cn.CerrarConeccion();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Selecciona un Perfil para Actualizar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
             }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
