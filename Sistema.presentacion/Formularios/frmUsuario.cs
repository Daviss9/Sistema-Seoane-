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
    public partial class frmUsuario : Form
    {
        private string EmailAnt = ""; //Variable para almacenar el email anterior
        public frmUsuario()
        {
            InitializeComponent();
        }
        private void Formato()
        {
            //Oculta las columnas innecesarias
            dgvListado.Columns[0].Visible = false; //IdUsuario
            dgvListado.Columns[0].HeaderText = "USUARIO_ID"; //IdUsuario
            dgvListado.Columns[1].Visible = false; //IdRol
            dgvListado.Columns[1].HeaderText = "ROL_ID"; //IdRol
            //Formatea las columnas
            dgvListado.Columns[2].Width = 150; //Nombre
            dgvListado.Columns[2].HeaderText = "NOMBRE"; 
            dgvListado.Columns[3].Width = 100; //TipoDocumento
            dgvListado.Columns[3].HeaderText = "TIPO DOC"; 
            dgvListado.Columns[4].Width = 100; //NumDocumento
            dgvListado.Columns[4].HeaderText = "NRO DOC"; 
            dgvListado.Columns[5].Width = 200; //Direccion
            dgvListado.Columns[5].HeaderText = "DIRECCION"; 
            dgvListado.Columns[6].Width = 100; //Telefono
            dgvListado.Columns[6].HeaderText = "TELEFONO"; 
            dgvListado.Columns[7].Width = 150; //Email
            dgvListado.Columns[7].HeaderText = "EMAIL";
            dgvListado.Columns[8].Width = 100; //Clave
            dgvListado.Columns[8].HeaderText = "PASSWORD";
            dgvListado.Columns[9].Width = 80; //Estado
            dgvListado.Columns[9].HeaderText = "ESTADO";
        }
        private void Listar()
        {
            try
            {
                //Carga los datos en la grilla
                dgvListado.DataSource = NUsuario.Listar();
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
                dgvListado.DataSource = NUsuario.Buscar(txtBuscar.Text);
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
        private void CargarRol()
        {
            cboRol.DataSource = NRol.Listar();
            cboRol.ValueMember = "idrol";
            cboRol.DisplayMember = "nombre";
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
            btnActivar.Visible = false; //Boton Activar
            btnDesactivar.Visible = false; //Boton Desactivar
            btnEliminar.Visible = false; //Boton Eliminar
            chkSeleccionar.Checked = false; //Desmarca el checkbox

            btnActualizar.Visible = false; //Boton Actualizar
            btnInsertar.Visible = true; //Boton Insertar

        }
        private void frmUsuario_Load(object sender, EventArgs e)
        {
            this.Listar();
            this.CargarRol();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.Buscar();
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
                    Rpta = NUsuario.Insertar(
                        //Selected Value devuelve el idCategoria Seleccionado
                        Convert.ToInt32(cboRol.SelectedValue),
                        txtNombre.Text.Trim(),
                        cboTipoDoc.Text, // DNI o RUC
                        txtNroDoc.Text.Trim(),
                        txtDireccion.Text.Trim(),
                        txtTelefono.Text.Trim(),
                        txtEmail.Text.Trim(),
                        txtClave.Text.Trim()
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

        private void txtDireccion_TextChanged(object sender, EventArgs e)
        {
            txtDireccion.CharacterCasing = CharacterCasing.Upper; //Convierte a mayusculas
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            txtNombre.CharacterCasing = CharacterCasing.Upper; //Convierte a mayusculas
        }

        private void txtNroDoc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                //MessageBox.Show("Solo números", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
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
                cboRol.SelectedValue = dgvListado.CurrentRow.Cells["idrol"].Value.ToString();
                txtNombre.Text = dgvListado.CurrentRow.Cells["Nombre"].Value.ToString();
                cboTipoDoc.Text = dgvListado.CurrentRow.Cells["Tipo_Documento"].Value.ToString();
                txtNroDoc.Text = dgvListado.CurrentRow.Cells["Num_Documento"].Value.ToString();
                txtDireccion.Text = dgvListado.CurrentRow.Cells["Direccion"].Value.ToString();
                txtTelefono.Text = dgvListado.CurrentRow.Cells["Telefono"].Value.ToString();
                this.EmailAnt = dgvListado.CurrentRow.Cells["Email"].Value.ToString();
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
                    Rpta = NUsuario.Actualizar(
                        Convert.ToInt32(txtId.Text),
                        //Selected Value devuelve el idCategoria Seleccionado
                        Convert.ToInt32(cboRol.SelectedValue),
                        txtNombre.Text.Trim(),
                        cboTipoDoc.Text, // DNI o RUC
                        txtNroDoc.Text.Trim(),
                        txtDireccion.Text.Trim(),
                        txtTelefono.Text.Trim(),
                        this.EmailAnt, //Email Anterior
                        txtEmail.Text.Trim(),
                        txtClave.Text.Trim()
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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Limpiar();
            tabGeneral.SelectedIndex = 0; //Vuelve a la pestaña de listado
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
                            Rpta = NUsuario.Eliminar(Codigo);

                            if (Rpta.Equals("OK"))
                            {
                                //Cells[5] = Columna Nombre de Usuario
                                this.MensajeOk("Se elimino el registro :" + Convert.ToString(row.Cells[4].Value));
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

        private void chkSeleccionar_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSeleccionar.Checked)
            {
                //El Check Seleccionar esta Activo
                //Esta columna corresponde a Seleccionar
                dgvListado.Columns[0].Visible = true;
                btnActivar.Visible = true;
                btnDesactivar.Visible = true;
                btnEliminar.Visible = true;
            }
            else

            {
                //El check Seleccionar esta INACTIVO
                dgvListado.Columns[0].Visible = false;
                btnActivar.Visible = false;
                btnDesactivar.Visible = false;
                btnEliminar.Visible = false;
            }
        }

        private void btnActivar_Click(object sender, EventArgs e)
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
                            Rpta = NUsuario.Activar(Codigo);

                            if (Rpta.Equals("OK"))
                            {
                                //Cells[5] = Columna Nombre de Usuario
                                this.MensajeOk("Se activo el registro :" + Convert.ToString(row.Cells[4].Value));
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

        private void btnDesactivar_Click(object sender, EventArgs e)
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
                            Rpta = NUsuario.Desactivar(Codigo);

                            if (Rpta.Equals("OK"))
                            {
                                //Cells[5] = Columna Nombre de Usuario
                                this.MensajeOk("Se desactivo el registro :" + Convert.ToString(row.Cells[4].Value));
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
                    chkSeleccionar.Checked = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " - " + ex.StackTrace);
            }
        }
    }
}
