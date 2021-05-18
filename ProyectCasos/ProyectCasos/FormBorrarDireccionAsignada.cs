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
    public partial class FormBorrarDireccionAsignada : Form
    {
        public FormBorrarDireccionAsignada()
        {
            InitializeComponent();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Conexion cn = new Conexion();
            FormVerCondicionJuridica FrmVer = new FormVerCondicionJuridica();
            //SqlConnection cn = new SqlConnection("Data Source=DESKTOP-KNIF4SO;Initial Catalog=Proyecto_Casos;User ID=sa;Password=123");
            //SqlConnection cn = new SqlConnection("Data Source=DESKTOP-GBVPD8B;Initial Catalog=ProyectoCasos;User ID=sa;Password=1234");
            //SqlConnection cn = new SqlConnection("Data Source=DESKTOP-T0686SL;Initial Catalog=Proyecto_Casos;User ID=sa;Password=lfer");

            try
            {
                cn.AbrirConeccion();
                SqlCommand com = new SqlCommand("exec dbo.SP_BorrarDireccionAsignada'" + int.Parse(txtIdDireccion.Text) + "'", cn.AbrirConeccion());
                com.ExecuteNonQuery();
                FrmVer.CargarDatosDataGridViewCondicion();
                MessageBox.Show("Datos Eliminados Con Exito", "Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                FrmVer.CargarDatosDataGridViewCondicion();
                cn.CerrarConeccion();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
