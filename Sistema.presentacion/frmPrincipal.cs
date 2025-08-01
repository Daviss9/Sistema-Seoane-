using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema.presentacion
{
    public partial class frmPrincipal : Form
    {
        private int childFormNumber = 0;
        public int IdUsuario;
        public int IdRol;
        public string Nombre;
        public string Rol;
        public string Estado;
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Ventana " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStrip.Visible = toolBarToolStripMenuItem.Checked;
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            statusStrip.Visible = statusBarToolStripMenuItem.Checked;
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void categoriasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Formularios.frmCategoria frm = new Formularios.frmCategoria();
            //Formulario Padre va a ser frm Principal
            frm.MdiParent = this;
            frm.Show();
        }
        private void AccesoRoles()
        {
            if (this.Rol.Equals("ADMINISTRADOR"))
            {
                //Opciones de Administrador
                mnuAlmacen.Enabled = true;
                mnuIngreso.Enabled = true;
                mnuVenta.Enabled = true;
                mnuAcceso.Enabled = true;
                mnuConsulta.Enabled = true;
            }
            else 
            {
                if (this.Rol.Equals("VENDEDOR"))
                {
                    mnuAlmacen.Enabled = false;
                    mnuIngreso.Enabled = false;
                    mnuVenta.Enabled = true;
                    mnuAcceso.Enabled = false;
                    mnuConsulta.Enabled = true;
                }
                else
                {
                    if (this.Rol.Equals("ALMACENERO"))
                    {
                        mnuAlmacen.Enabled = true;
                        mnuIngreso.Enabled = true;
                        mnuVenta.Enabled = false;
                        mnuAcceso.Enabled = false;
                        mnuConsulta.Enabled = true;
                    }
                    else
                    {
                        //Si el Rol no es ninguno de los anteriores, deshabilitar todo
                        mnuAlmacen.Enabled = false;
                        mnuIngreso.Enabled = false;
                        mnuVenta.Enabled = false;
                        mnuAcceso.Enabled = false;
                        mnuConsulta.Enabled = false;
                    }
                }
            }
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            stBarraInferior.Text = "Desarrollado por: Seoane Software - Usuario: "
                + this.Nombre;
            //Enviar mensaje de Bienvenida
            MessageBox.Show("Bienvenido " + this.Nombre + " al Sistema de Ventas", 
                "Bienvenido", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //Accesos de Roles
            this.AccesoRoles();
        }

        private void articulosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Formularios.frmArticulo frm = new Formularios.frmArticulo();
            //Formulario Padre va a ser frm Principal
            frm.MdiParent = this;
            frm.Show();
        }

        private void rolesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Formularios.frmRol frm = new Formularios.frmRol();
            //Formulario Padre va a ser frm Principal
            frm.MdiParent = this;
            frm.Show();
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Formularios.frmUsuario frm = new Formularios.frmUsuario();
            //Formulario Padre va a ser frm Principal
            frm.MdiParent = this;
            frm.Show();
        }

        private void mnuSalir_Click(object sender, EventArgs e)
        {
            DialogResult Opcion;
            Opcion = MessageBox.Show("¿Está seguro de salir del Sistema?",
                "Salir del Sistema", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (Opcion == DialogResult.OK)
            {
                Application.Exit();
            }
        }

        private void smnuProveedores_Click(object sender, EventArgs e)
        {
            Formularios.frmProveedores frm = new Formularios.frmProveedores();
            //Formulario Padre va a ser frm Principal
            frm.MdiParent = this;
            frm.Show();
        }
    }
}
