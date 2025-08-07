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
    public partial class frmClientes : Form
    {
        private string NombreAnt;
        public frmClientes()
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
                dgvListado.DataSource = NPersona.ListarClientes();
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
                dgvListado.DataSource = NPersona.BuscarClientes(txtBuscar.Text);
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
          
            cboTipoDoc.SelectedIndex = 0; //Selecciona el primer elemento
            errorIcono.Clear(); //Limpia los iconos de error

            dgvListado.Columns[0].Visible = false; //Seleccionar
            btnEliminar.Visible = false; //Boton Eliminar
            chkSeleccionar.Checked = false; //Desmarca el checkbox

            btnActualizar.Visible = false; //Boton Actualizar
            btnInsertar.Visible = true; //Boton Insertar

        }
        

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.Buscar(); //Llama al metodo Buscar
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            if (ValidarTexto()) //Esta funcion es de tipo BOOL por defecto devuelte TRUE
            {
                // MensajeOk("Verificacion Completa OK");
                //OK Validacion Exitosa!!
                try
                {
                    string Rpta = "";
                    Rpta = NPersona.Insertar(
                        //Selected Value devuelve el idCategoria Seleccionado
                        "CLIENTE",
                        txtNombre.Text.Trim(),
                        cboTipoDoc.Text, // DNI o RUC
                        txtNroDoc.Text.Trim(),
                        txtDireccion.Text.Trim(),
                        txtTelefono.Text.Trim(),
                        txtEmail.Text.Trim()
                        );

                    if (Rpta.Equals("OK"))
                    {
                        this.MensajeOk("Se inserto el registro de forma correcta");
                        //Guardamos la imagen - INICIO
                        //Guardamos la imagen - FIN
                        this.Limpiar();
                        //Actualizamos la grilla con los nuevos datos
                        this.Listar();
                    }
                    else
                    {
                        this.MensajeError(Rpta);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + " - " + ex.StackTrace);
                }
            }
            else //Falso -> hay errores de validacion
            {
                MensajeError("Faltan datos");
            }
        }

        private void dgvListado_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                this.Limpiar();
                btnActualizar.Visible = true;
                btnInsertar.Visible = false;
                txtId.Text = dgvListado.CurrentRow.Cells["ID"].Value.ToString();
                this.NombreAnt = dgvListado.CurrentRow.Cells["Nombre"].Value.ToString();
                txtNombre.Text = dgvListado.CurrentRow.Cells["Nombre"].Value.ToString();
                cboTipoDoc.Text = dgvListado.CurrentRow.Cells["Tipo_Documento"].Value.ToString();
                txtNroDoc.Text = dgvListado.CurrentRow.Cells["Num_Documento"].Value.ToString();
                txtDireccion.Text = dgvListado.CurrentRow.Cells["Direccion"].Value.ToString();
                txtTelefono.Text = dgvListado.CurrentRow.Cells["Telefono"].Value.ToString();
                txtEmail.Text = dgvListado.CurrentRow.Cells["Email"].Value.ToString();
                tabGeneral.SelectedIndex = 1;

            }
            catch (Exception ex)
            {
                //Excepcion
                MessageBox.Show("Seleccione desde la celda nombre. " + "| Error: " + ex.Message);
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (ValidarTexto()) //Esta funcion es de tipo BOOL por defecto devuelte TRUE
            {
                // MensajeOk("Verificacion Completa OK");
                //OK Validacion Exitosa!!
                try
                {
                    string Rpta = "";
                    Rpta = NPersona.Actualizar(
                        Convert.ToInt32(txtId.Text),
                        "CLIENTE",
                        //Selected Value devuelve el idCategoria Seleccionado
                        this.NombreAnt,
                        txtNombre.Text.Trim(),
                        cboTipoDoc.Text, // DNI o RUC
                        txtNroDoc.Text.Trim(),
                        txtDireccion.Text.Trim(),
                        txtTelefono.Text.Trim(),
                        txtEmail.Text.Trim()
                        );

                    if (Rpta.Equals("OK"))
                    {
                        this.MensajeOk("Se Actualizo el registro de forma correcta");
                        //Guardamos la imagen - INICIO
                        //Guardamos la imagen - FIN
                        this.Limpiar();
                        //Actualizamos la grilla con los nuevos datos
                        this.Listar();
                    }
                    else
                    {
                        this.MensajeError(Rpta);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + " - " + ex.StackTrace);
                }
            }
            else //Falso -> hay errores de validacion
            {
                MensajeError("Faltan datos");
            }
            this.Limpiar();
        }

        private void chkSeleccionar_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSeleccionar.Checked)
            {
                //El Check Seleccionar esta Activo
                //Esta columna corresponde a Seleccionar
                dgvListado.Columns[0].Visible = true;
                btnEliminar.Visible = true;
            }
            else

            {
                //El check Seleccionar esta INACTIVO
                dgvListado.Columns[0].Visible = false;
                btnEliminar.Visible = false;
            }
        }

        private void dgvListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvListado.Columns["Seleccionar"].Index)
            {
                DataGridViewCheckBoxCell chkEliminar =
                    (DataGridViewCheckBoxCell)dgvListado.Rows[e.RowIndex].Cells["Seleccionar"];

                chkEliminar.Value = !Convert.ToBoolean(chkEliminar.Value);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                //Resultado de MessageBox
                DialogResult Opcion;
                Opcion = MessageBox.Show(
                    "Realmente deseas eliminar los registros :",
                    "Sistema Seoane",
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Question
                    );
                //Si la opcion es OK
                if (Opcion == DialogResult.OK)
                {
                    int Codigo;
                    string Rpta = "";

                    //Recorro todo el grid con FOREACH
                    foreach (DataGridViewRow row in dgvListado.Rows)
                    {
                        //Recorrer todos los registros que esten marcados Chechek Cells[0] = Seleccionar
                        if (Convert.ToBoolean(row.Cells[0].Value))
                        {
                            //Cells[1] = Columna ID
                            Codigo = Convert.ToInt32(row.Cells[1].Value);
                            Rpta = NPersona.Eliminar(Codigo);

                            if (Rpta.Equals("OK"))
                            {
                                //Cells[5] = Columna Nombre del Proveedor
                                this.MensajeOk("Se elimino el registro :" + Convert.ToString(row.Cells[3].Value));
                                //Eliminar la Imagen del Directorio
                            }
                            else
                            {
                                this.MensajeError(Rpta);
                            }
                        }
                    }
                    //Al final actualizo la grilla
                    this.Listar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " - " + ex.StackTrace);
            }
            chkSeleccionar.Checked = false;
        }

        private void frmClientes_Load(object sender, EventArgs e)
        {
            this.Listar(); //Llama al metodo Listar
        }
    }
}
