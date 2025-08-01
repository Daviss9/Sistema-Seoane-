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
    public partial class frmProveedores : Form
    {
        public frmProveedores()
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
        private void MensajeError(string Mensaje)
        {
            MessageBox.Show(
                Mensaje, "Sistema de Ventas Seoane",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
                );
        }
        private void MensajeOk(string Mensaje)
        {
            MessageBox.Show(
                Mensaje, "Sistema de Ventas Seoane",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
                );
        }
        private bool ValidarTexto()
        {
            //Limpio todo los iconos de error
            errorIcono.Clear();
            //Verificar la validacion de textbox en blanco
            bool OK = true;
            if (cboRol.Text == String.Empty)
            {
                OK = false;
                errorIcono.SetError(cboRol, "Seleccione un Rol de Usuario");
            }
            if (cboTipoDoc.Text == String.Empty)
            {
                OK = false;
                errorIcono.SetError(cboTipoDoc, "Seleccione tipo de documento");
            }
            if (txtNombre.Text == String.Empty)
            {
                OK = false;
                errorIcono.SetError(txtNombre, "Ingrese un nombre");
            }
            if (txtNroDoc.Text == String.Empty)
            {
                OK = false;
                errorIcono.SetError(txtNroDoc, "Ingrese numero de documento");
            }
            if (txtDireccion.Text == String.Empty)
            {
                OK = false;
                errorIcono.SetError(txtDireccion, "Ingrese un stock");
            }
            if (txtDireccion.Text == String.Empty)
            {
                OK = false;
                errorIcono.SetError(txtDireccion, "Ingrese un stock");
            }
            if (txtTelefono.Text == String.Empty)
            {
                OK = false;
                errorIcono.SetError(txtTelefono, "Ingrese un stock");
            }
            if (txtEmail.Text == String.Empty)
            {
                OK = false;
                errorIcono.SetError(txtEmail, "Ingrese un stock");
            }
            return OK;
        }
        private void Limpiar()
        {
            //Limpia los campos de texto
            txtNombre.Text = string.Empty;
            txtNroDoc.Text = string.Empty;
            txtDireccion.Text = string.Empty;
            txtTelefono.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtClave.Text = string.Empty;
            cboRol.SelectedIndex = 0; //Selecciona el primer elemento
            cboTipoDoc.SelectedIndex = 0; //Selecciona el primer elemento
            errorIcono.Clear(); //Limpia los iconos de error

            dgvListado.Columns[0].Visible = false; //Seleccionar
            btnEliminar.Visible = false; //Boton Eliminar
            chkSeleccionar.Checked = false; //Desmarca el checkbox

            btnActualizar.Visible = false; //Boton Actualizar
            btnInsertar.Visible = true; //Boton Insertar

        }
        private void frmProveedores_Load(object sender, EventArgs e)
        {
               this.Listar(); //Llama al metodo Listar
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.Buscar(); //Llama al metodo Buscar
        }
    }
}
