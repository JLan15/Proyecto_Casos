using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectCasos
{
    public partial class FormMenuPrincipal : Form
    {
        public FormMenuPrincipal()
        {
            InitializeComponent();
        }

        private const int tamañogrid = 10;
        private const int areamouse = 132;
        private const int botonizquierdo = 17;
        private Rectangle rectangulogrid;

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);

            var region = new Region(new Rectangle(0, 0, ClientRectangle.Width, ClientRectangle.Height));

            rectangulogrid = new Rectangle(ClientRectangle.Width - tamañogrid, ClientRectangle.Height - tamañogrid, tamañogrid, tamañogrid);

            region.Exclude(rectangulogrid);

            PanelPrincipal.Region = region;
            Invalidate();
        }

        protected override void WndProc(ref Message sms)
        {
            switch(sms.Msg)
            {
                case areamouse:
                    base.WndProc(ref sms);
                    var RefPoint = PointToClient(new Point(sms.LParam.ToInt32() & 0xffff, sms.LParam.ToInt32() >> 16));

                    if(!rectangulogrid.Contains(RefPoint))
                    {
                        break;
                    }

                    sms.Result = new IntPtr(botonizquierdo);
                    break;

                default:
                    base.WndProc(ref sms);
                    break;
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            SolidBrush solidBrush = new SolidBrush(Color.FromArgb(36, 97, 175));

            e.Graphics.FillRectangle(solidBrush, rectangulogrid);

            base.OnPaint(e);

            ControlPaint.DrawSizeGrip(e.Graphics, Color.Transparent, rectangulogrid);
        }

        int lx, ly;

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void btnMaximizar_Click(object sender, EventArgs e)
        {
            lx = Location.X;
            ly = Location.Y;
            sw = Size.Width;
            sh = Size.Height;

            Size = Screen.PrimaryScreen.WorkingArea.Size;
            Location = Screen.PrimaryScreen.WorkingArea.Location;

            btnRestaurar.Visible = true;
            btnMaximizar.Visible = false;
        }

        private void btnRestaurar_Click(object sender, EventArgs e)
        {
            Size = new Size(sw, sh);
            Location = new Point(lx, ly);

            btnRestaurar.Visible = false;
            btnMaximizar.Visible = true;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Estas Seguro de Cerrar el Programa?","Alerta", MessageBoxButtons.YesNo)== DialogResult.Yes);
            Application.Exit();
        }

        int sw, sh;

        private void bunifuFlatButton6_Click(object sender, EventArgs e)
        {
            AbrirFormularios<FormVerCondicionJuridica>();
        }

        private void PanelContenedor_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bunifuFlatButton4_Click(object sender, EventArgs e)
        {
            AbrirFormularios<FormVerDireccionAsignada>();
            
        }

        private void bunifuFlatButton5_Click(object sender, EventArgs e)
        {
            AbrirFormularios<FormVerJuzgadoFiscalia>();
        }

        private void btnExpedientes_Click(object sender, EventArgs e)
        {
            AbrirFormularios<Form1>();
        }

        private void AbrirFormularios<FormularioAbrir>() where FormularioAbrir:Form, new()
        {
            Form Formularios;

            Formularios = PanelContenedor.Controls.OfType<FormularioAbrir>().FirstOrDefault();

            if(Formularios == null)
            {
                Formularios = new FormularioAbrir
                {
                    TopLevel = false,
                    Dock = DockStyle.Fill
                };

                PanelContenedor.Controls.Add(Formularios);

                PanelContenedor.Tag = (Formularios);

                Formularios.Show();

                Formularios.BringToFront();
            }
            else
            {
                Formularios.BringToFront();
            }
           
        }
    }
}
