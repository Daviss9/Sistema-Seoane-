using Sistema.Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema.presentacion.Formularios
{
    public partial class frmVista_Proveedor : Form
    {
        public frmVista_Proveedor()
        {
            InitializeComponent();
        }

        private void Formato()
        {
            //Oculta las columnas innecesarias
            dgvListado.Columns[0].Visible = false; //IdUsuario
            dgvListado.Columns[0].HeaderText = "SELECCIONAR"; //IdUsuario
            dgvListado.Columns[1].Width = 100; //Nombre
            dgvListado.Columns[1].HeaderText = "PROVEEDOR_ID"; //IdRol
            dgvListado.Columns[2].Width = 150; //Nombre
            dgvListado.Columns[2].HeaderText = "TIPO PERSONA";
            dgvListado.Columns[3].Width = 150; //Nombre
            dgvListado.Columns[3].HeaderText = "NOMBRE";
            dgvListado.Columns[4].Width = 100; //TipoDocumento
            dgvListado.Columns[4].HeaderText = "TIPO DOC";
            dgvListado.Columns[5].Width = 100; //NumDocumento
            dgvListado.Columns[5].HeaderText = "NRO DOC";
            dgvListado.Columns[6].Width = 200; //Direccion
            dgvListado.Columns[6].HeaderText = "DIRECCION";
            dgvListado.Columns[7].Width = 100; //Telefono
            dgvListado.Columns[7].HeaderText = "TELEFONO";
            dgvListado.Columns[8].Width = 150; //Email
            dgvListado.Columns[8].HeaderText = "EMAIL";

        }
        private void Listar()
        {
            try
            {
                //Carga los datos en la grilla
                dgvListado.DataSource = NPersona.ListarProveedores();
                //Formatea la grilla
                this.Formato();
                // Cuenta los registros y muestra en lblTotal
                lblTotal.Text = "Cantidad de Registros :" +
                dgvListado.Rows.Count;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " - " + ex.StackTrace);
            }
        }
        private void Buscar()
        {
            try
            {
                //Carga los datos en la grilla
                dgvListado.DataSource = NPersona.BuscarProvedores(txtBuscar.Text);
                //Formatea la grilla
                this.Formato();
                // Cuenta los registros y muestra en lblTotal
                lblTotal.Text = "Cantidad de Registros :" +
                dgvListado.Rows.Count;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " - " + ex.StackTrace);
            }
        }
        private void frmVista_Proveedor_Load(object sender, EventArgs e)
        {
            this.Listar();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.Buscar();
        }

        private void dgvListado_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Variables.IdProveedor = Convert.ToInt32(dgvListado.CurrentRow.Cells["ID"].Value);
            Variables.NombreProveedor = Convert.ToString(dgvListado.CurrentRow.Cells["Nombre"].Value);
            this.Close(); //Cierra el formulario
        }
    }
}
