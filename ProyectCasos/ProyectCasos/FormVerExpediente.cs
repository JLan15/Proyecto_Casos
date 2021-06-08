using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using excel = Microsoft.Office.Interop.Excel;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ProyectCasos
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public void CargarDatosDataGridView()
        {
            //SqlConnection cn = new SqlConnection("Data Source=DESKTOP-KNIF4SO;Initial Catalog=Proyecto_Casos;User ID=sa;Password=123");
            //SqlConnection cn = new SqlConnection("Data Source=DESKTOP-GBVPD8B;Initial Catalog=ProyectoCasos;User ID=sa;Password=1234");
            //SqlConnection cn = new SqlConnection("Data Source=DESKTOP-T0686SL;Initial Catalog=Proyecto_Casos;User ID=sa;Password=lfer");
            Conexion cn = new Conexion();

            cn.AbrirConeccion();
            SqlCommand com = new SqlCommand("exec dbo.SP_VerExpediente", cn.AbrirConeccion());
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dtgCrearExpediente.DataSource = dt;
        }

        public void dtgCrearExpediente_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            /*FormEditarExpediente FrmEditar = new FormEditarExpediente();
            DataGridViewRow Rellenar = dtgCrearExpediente.Rows[e.RowIndex];
            FrmEditar.txtIdExp.Text = Rellenar.Cells[0].Value.ToString();
            FrmEditar.txtCodigo.Text = Rellenar.Cells[1].Value.ToString();
            FrmEditar.txtNum.Text = Rellenar.Cells[2].Value.ToString();
            FrmEditar.dtpFecha.Text = Rellenar.Cells[3].Value.ToString();
            FrmEditar.cmbRepresentado.Text = Rellenar.Cells[4].Value.ToString();
            FrmEditar.txtLugarHechos.Text = Rellenar.Cells[5].Value.ToString();
            FrmEditar.dtpFechaHechos.Text = Rellenar.Cells[6].Value.ToString();
            VariablesGlobales.status = Rellenar.Cells[7].Value.ToString();*/

            
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {

        }


        public void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                //SqlConnection cn = new SqlConnection("Data Source=DESKTOP-KNIF4SO;Initial Catalog=Proyecto_Casos;User ID=sa;Password=123");
                //SqlConnection cn = new SqlConnection("Data Source=DESKTOP-GBVPD8B;Initial Catalog=ProyectoCasos;User ID=sa;Password=1234");
                //SqlConnection cn = new SqlConnection("Data Source=DESKTOP-T0686SL;Initial Catalog=Proyecto_Casos;User ID=sa;Password=lfer");
                Conexion cn = new Conexion();

                cn.AbrirConeccion();
                MessageBox.Show("Conexion Exitosa");

            }
            catch(Exception)
            {
                MessageBox.Show("Conexion Erronea");
            }
            
            CargarDatosDataGridView();

            FormEditarExpediente FrmEditar = new FormEditarExpediente();
            if(VariablesGlobales.btneditarpresionado)
            {
                CargarDatosDataGridView();
            }
        }

        private void btnNuevo_Click_1(object sender, EventArgs e)
        {
            FormAgregarExpediente FrmAgregar = new FormAgregarExpediente();
            FrmAgregar.Show();
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

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            CargarDatosDataGridView();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            /*FormEditarExpediente FrmEditar = new FormEditarExpediente();
            FrmEditar.Show();*/
        }

        private void dtgCrearExpediente_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void dtgCrearExpediente_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            /*FormEditarExpediente FrmEditar = new FormEditarExpediente();

            string Fecha;
            string FechaHechos;

            Fecha = Convert.ToString(FrmEditar.dtpFecha.Text);
            FechaHechos = Convert.ToString(FrmEditar.dtpFechaHechos.Text);

            FrmEditar.txtIdExp.Text = dtgCrearExpediente.CurrentRow.Cells[0].Value.ToString();
            FrmEditar.txtCodigo.Text = dtgCrearExpediente.CurrentRow.Cells[1].Value.ToString();
            FrmEditar.txtNum.Text = dtgCrearExpediente.CurrentRow.Cells[2].Value.ToString();
            //Fecha = dtgCrearExpediente.CurrentRow.Cells[3].Value.ToString();
            FrmEditar.dtpFecha.Text = dtgCrearExpediente.CurrentRow.Cells[3].Value.ToString();
            FrmEditar.cmbCondicionJuridica.Text = dtgCrearExpediente.CurrentRow.Cells[4].Value.ToString();
            FrmEditar.cmbDireccionAsignada.Text = dtgCrearExpediente.CurrentRow.Cells[5].Value.ToString();
            FrmEditar.cmbJuzgadoFiscalia.Text = dtgCrearExpediente.CurrentRow.Cells[6].Value.ToString();
            FrmEditar.cmbEstadoCaso.Text = dtgCrearExpediente.CurrentRow.Cells[7].Value.ToString();
            FrmEditar.txtLugarHechos.Text = dtgCrearExpediente.CurrentRow.Cells[8].Value.ToString();
            FrmEditar.dtpFechaHechos.Text = dtgCrearExpediente.CurrentRow.Cells[9].Value.ToString();
            //FechaHechos = dtgCrearExpediente.CurrentRow.Cells[9].Value.ToString();
            VariablesGlobales.status = dtgCrearExpediente.CurrentRow.Cells[10].Value.ToString();

            if (VariablesGlobales.status == "Activo")
            {
                FrmEditar.rdbActivo.Checked = true;
            }
            if (VariablesGlobales.status == "Inactivo")
            {
                FrmEditar.rdbInactivo.Checked = true;
            }

            FrmEditar.Show();*/
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            FormBorrarExpediente FrmBorrar = new FormBorrarExpediente();
            FrmBorrar.Show();
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            dtgCrearExpediente.SelectAll();
            DataObject copydata = dtgCrearExpediente.GetClipboardContent();
            if (copydata != null) Clipboard.SetDataObject(copydata);
            Microsoft.Office.Interop.Excel.Application xlapp = new Microsoft.Office.Interop.Excel.Application();
            xlapp.Visible = true;
            Microsoft.Office.Interop.Excel.Workbook xlWbook;
            Microsoft.Office.Interop.Excel.Worksheet xlsheet;
            object miseddata = System.Reflection.Missing.Value;
            xlWbook = xlapp.Workbooks.Add(miseddata);

            xlsheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWbook.Worksheets.get_Item(1);
            Microsoft.Office.Interop.Excel.Range xlr = (Microsoft.Office.Interop.Excel.Range)xlsheet.Cells[1, 1];
            xlr.Select();

            xlsheet.PasteSpecial(xlr, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, true);
            xlsheet.Columns.AutoFit();
                          

            /*excel.Application App = new excel.Application();
            excel.Workbook workbook = App.Workbooks.Add();
            excel.Worksheet worksheet = null;

            App.Visible = true;

            worksheet = workbook.Sheets["Hoja1"];
            worksheet = workbook.ActiveSheet;

            for(int i = 0; i < dtgCrearExpediente.Columns.Count; i++)
            {
                worksheet.Cells[1, i + 1] = dtgCrearExpediente.Columns[i].HeaderText;
            }


            for (int j = 0; j < dtgCrearExpediente.Columns.Count-1; j++)
            {
                for (int i = 0; i < dtgCrearExpediente.Columns.Count; i++)
                {            
                  worksheet.Cells[j + 2, i + 1] = dtgCrearExpediente.Rows[j].Cells[i].Value.ToString();          
                } 
            }/*

            worksheet.Columns.AutoFit();
            //worksheet.Cells.AutoFit();

            /*if(dtgCrearExpediente.Rows.Count > 0)
            {
                Microsoft.Office.Interop.Excel.Application xcelApp = new Microsoft.Office.Interop.Excel.Application();
                xcelApp.Application.Workbooks.Add(Type.Missing);

                for (int i = 1; i < dtgCrearExpediente.Columns.Count + 1; i++)
                {
                    xcelApp.Cells[1, i] = dtgCrearExpediente.Columns[i - 1].HeaderText;
                }

                for (int i = 0; i < dtgCrearExpediente.Rows.Count; i++)
                {
                    for (int j = 0; j < dtgCrearExpediente.Columns.Count; i++)
                    {
                        xcelApp.Cells[i + 2, j + 1] = dtgCrearExpediente.Rows[i].Cells[j].Value.ToString();
                    }
                }
                xcelApp.Columns.AutoFit();
                xcelApp.Visible = true;
            }*/
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void bunifuSeparator2_Load(object sender, EventArgs e)
        {

        }

        private void bunifuCustomLabel1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuSeparator3_Load(object sender, EventArgs e)
        {

        }

        private void PanelPrincipal_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bunifuSeparator1_Load(object sender, EventArgs e)
        {

        }

        private void dtgCrearExpediente_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            FormEditarExpediente FrmEditar = new FormEditarExpediente();

            string Fecha;
            string FechaHechos;

            Fecha = Convert.ToString(FrmEditar.dtpFecha.Text);
            FechaHechos = Convert.ToString(FrmEditar.dtpFechaHechos.Text);

            FrmEditar.txtIdExp.Text = dtgCrearExpediente.CurrentRow.Cells[0].Value.ToString();
            FrmEditar.cmbCondicionJuridica.Text = dtgCrearExpediente.CurrentRow.Cells[1].Value.ToString();
            FrmEditar.cmbRango.Text = dtgCrearExpediente.CurrentRow.Cells[2].Value.ToString();
            FrmEditar.cmbDireccionAsignada.Text = dtgCrearExpediente.CurrentRow.Cells[3].Value.ToString();
            FrmEditar.txtLugarHechos.Text = dtgCrearExpediente.CurrentRow.Cells[4].Value.ToString();
            FrmEditar.dtpFechaHechos.Text = dtgCrearExpediente.CurrentRow.Cells[5].Value.ToString();
            FrmEditar.cmbDelito.Text = dtgCrearExpediente.CurrentRow.Cells[6].Value.ToString();
            FrmEditar.cmbMedidas.Text = dtgCrearExpediente.CurrentRow.Cells[7].Value.ToString();
            FrmEditar.cmbReclucion.Text = dtgCrearExpediente.CurrentRow.Cells[8].Value.ToString();
            FrmEditar.cmbSegundaCondicion.Text = dtgCrearExpediente.CurrentRow.Cells[9].Value.ToString();
            FrmEditar.cmbJuzgadoFiscalia.Text = dtgCrearExpediente.CurrentRow.Cells[10].Value.ToString();
            FrmEditar.txtNum.Text = dtgCrearExpediente.CurrentRow.Cells[11].Value.ToString();
            FrmEditar.txtCodigo.Text = dtgCrearExpediente.CurrentRow.Cells[12].Value.ToString();
            FrmEditar.dtpFecha.Text = dtgCrearExpediente.CurrentRow.Cells[13].Value.ToString();
            FrmEditar.cmbEstadoCaso.Text = dtgCrearExpediente.CurrentRow.Cells[14].Value.ToString();
            FrmEditar.cmbRecursoReposicion.Text = dtgCrearExpediente.CurrentRow.Cells[15].Value.ToString();
            FrmEditar.cmbRecursoApelacion.Text = dtgCrearExpediente.CurrentRow.Cells[16].Value.ToString();
            FrmEditar.cmbRecursoAmparo.Text = dtgCrearExpediente.CurrentRow.Cells[17].Value.ToString();
            FrmEditar.cmbRecursoHabeasCorpus.Text = dtgCrearExpediente.CurrentRow.Cells[18].Value.ToString();
            FrmEditar.txtOtro.Text = dtgCrearExpediente.CurrentRow.Cells[19].Value.ToString();
            FrmEditar.rtxtObservaciones.Text = dtgCrearExpediente.CurrentRow.Cells[20].Value.ToString();
            VariablesGlobales.status = dtgCrearExpediente.CurrentRow.Cells[21].Value.ToString();

            if (VariablesGlobales.status == "Activo")
            {
                FrmEditar.rdbActivo.Checked = true;
            }
            if (VariablesGlobales.status == "Inactivo")
            {
                FrmEditar.rdbInactivo.Checked = true;
            }

            FrmEditar.Show();
        }
    }
}
