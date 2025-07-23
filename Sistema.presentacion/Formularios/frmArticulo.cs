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
//Importamos namespace para gestionar archivos de imagen
using System.Drawing.Imaging;
using System.IO;

namespace Sistema.presentacion.Formularios
{
    public partial class frmArticulo : Form
    {
        //Declaro las variables
        private string nombreAnt;
        private string RutaOrigen; 
        private string RutaDestino; 
        //Ruta del directorio donde se almacenan mi imagenes alt+92 = \\
        private string Directorio = "C:\\Sistema Seoane\\imagenes\\";


        public frmArticulo()
        {
            InitializeComponent();
        }
        // Metodos Inicial
        public void Formato()
        {
            //Columna 0 = Seleccionar
            dgvListado.Columns[0].Visible = false;
            dgvListado.Columns[0].HeaderText = "SELECCIONAR";
            dgvListado.Columns[0].Width = 100;
            //Columna 1 = IdArticulo
            dgvListado.Columns[1].Width = 50;
            dgvListado.Columns[1].HeaderText = "ID";
            //Columna 2 = IdCategoria
            dgvListado.Columns[2].Visible = false;
            //Columna 3 = Categoria
            dgvListado.Columns[3].Width = 100;
            dgvListado.Columns[3].HeaderText = "Categoria";
            //Columna 4 = Codigo
            dgvListado.Columns[4].Width = 100;
            dgvListado.Columns[4].HeaderText = "Codigo";
            //Columna 5 = Nombre
            dgvListado.Columns[5].Width = 150;
            dgvListado.Columns[5].HeaderText = "Nombre";
            //Columna 6 = Precio Venta
            dgvListado.Columns[6].Width = 100;
            dgvListado.Columns[6].HeaderText = "Precio Venta";
            //Columna 7 = Stock -> Propiedad Width : Ancho de la columna
            dgvListado.Columns[7].Width = 100;
            dgvListado.Columns[7].HeaderText = "Stock";
            //Columna 8 = Descripcion
            dgvListado.Columns[8].Width = 200;
            dgvListado.Columns[8].HeaderText = "Descripcion";
            //Columna 9 = Imagen
            dgvListado.Columns[9].Width = 100;
            dgvListado.Columns[9].HeaderText = "Imagen";
            //Columna 10 = Estado
            dgvListado.Columns[10].Width = 100;
            dgvListado.Columns[10].HeaderText = "Estado";
        }
        private void Listar()
        {
            try
            {
                //Carga los datos en la grilla
                dgvListado.DataSource = NArticulo.Listar();
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

        private void CargarCategoria()
        {
            cboCategoria.DataSource = NCategoria.Selecionar();
            cboCategoria.ValueMember = "idcategoria";
            cboCategoria.DisplayMember = "nombre";
        }

        private void Buscar()
        {
            try
            {
                //Carga los datos en la grilla
                dgvListado.DataSource = NArticulo.Buscar(txtBuscar.Text);
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
        private void Limpiar()
        {
            //Limpiar Cajas de Texto
            txtBuscar.Clear();
            txtNombre.Clear();
            txtId.Clear();
            txtCodigo.Clear();
            panelCodigo.BackgroundImage = null;
            btnGuardarCodigo.Enabled = false;
            txtPrecioVenta.Clear();
            txtStock.Clear();
            txtImagen.Clear();
            picImagen.Image = null;
            txtDescripcion.Clear();
            // Muestra el boton Insertar
            btnInsertar.Visible = true;
            btnActualizar.Visible = false;
            errorIcono.Clear();

            dgvListado.Columns[0].Visible = false;
            btnActivar.Visible = false;
            btnDesactivar.Visible = false;
            btnEliminar.Visible = false;
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
            if (cboCategoria.Text == String.Empty)
            { 
                OK = false;
                errorIcono.SetError(cboCategoria, "Seleccione una Categoria");
            }
            if (txtNombre.Text == String.Empty)
            {
                OK = false;
                errorIcono.SetError(txtNombre, "Ingrese un nombre");
            }
            if (txtPrecioVenta.Text == String.Empty)
            {
                OK = false;
                errorIcono.SetError(txtPrecioVenta, "Ingrese un precio de venta");
            }
            if (txtStock.Text == String.Empty)
            {
                OK = false;
                errorIcono.SetError(txtStock, "Ingrese un stock");
            }
            return OK;
        }
        // Metodos Final
        private void frmArticulo_Load(object sender, EventArgs e)
        {
            this.Listar();
            this.CargarCategoria();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.Buscar();
        }

        private void btnCargarImagen_Click(object sender, EventArgs e)
        {
            //Objeto OpenDialog Cuadro de Dialogo ->Seleccionar el archivo de imagen
            OpenFileDialog file = new OpenFileDialog();
            file.Filter = "Archivo de Imagen (*.jpg,*.jpeg,*.png)|*.jpg;*.jpeg;*.png";
            if (file.ShowDialog() == DialogResult.OK)
            {
                picImagen.Image = Image.FromFile(file.FileName);
                txtImagen.Text = file.FileName.Substring(file.FileName.LastIndexOf("\\")+1);
                this.RutaOrigen = file.FileName;
            }
        }

        private void btnGenerarCodigo_Click(object sender, EventArgs e)
        {
            if (txtCodigo.Text == String.Empty)
            {
                MensajeError("Ingrese codigo de barras");
            }
            else
            {
                BarcodeLib.Barcode Codigo = new BarcodeLib.Barcode();
                //Incliur la etiqueta
                Codigo.IncludeLabel = true;
                //Codigo de Barra tipo 128 Fondo blanco y codigo color negro.
                panelCodigo.BackgroundImage =
                    Codigo.Encode(BarcodeLib.TYPE.CODE128, txtCodigo.Text, Color.Black, Color.White, 400, 100);
                //Habilitamos el boton guardar codigo
                btnGuardarCodigo.Enabled = true;
            }
        }

        private void btnGuardarCodigo_Click(object sender, EventArgs e)
        {
            //Clono la imagen del control panel
            Image imgFinal = (Image)panelCodigo.BackgroundImage.Clone();
            //invoco al cuadro de dialogo guardar
            SaveFileDialog DialogoGuardar = new SaveFileDialog();
            DialogoGuardar.AddExtension = true;
            //Asignamos a la imagen el nombre de control txtCodigo
            DialogoGuardar.FileName = txtCodigo.Text.Trim();
            //Le damos el formato PNG por defecto
            DialogoGuardar.Filter = "Imagen PNG (*.png)|*.png";
            DialogoGuardar.ShowDialog();
            //Si el nombre de la imagen es diferente a Vacio lo formatea a PNG
            if (!string.IsNullOrEmpty(DialogoGuardar.FileName))
            {
                imgFinal.Save(DialogoGuardar.FileName, ImageFormat.Png);
            }
            //Copia la imagen en el directorio
            imgFinal.Dispose();
        }

        private void txtStock_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                //MessageBox.Show("Solo números", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtPrecioVenta_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permite solo dígitos, el punto decimal y las teclas de control (backspace, etc.)
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true; // Evita que el carácter se escriba en el TextBox
            }

            // Solo permite un punto decimal
            if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
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
                    Rpta = NArticulo.Insertar(
                        //Selected Value devuelve el idCategoria Seleccionado
                        Convert.ToInt32(cboCategoria.SelectedValue),
                        txtCodigo.Text.Trim(),
                        txtNombre.Text.Trim(),
                        Convert.ToDecimal(txtPrecioVenta.Text),
                        Convert.ToInt32(txtStock.Text),
                        txtDescripcion.Text.Trim(),
                        txtImagen.Text.Trim());

                    if (Rpta.Equals("OK"))
                    {
                        this.MensajeOk("Se inserto el registro de forma correcta");
                        //Guardamos la imagen - INICIO
                        //Validar si hay un nombre de imagen
                        if(txtImagen.Text != string.Empty)
                        {
                            this.RutaDestino = this.Directorio+txtImagen.Text;
                            File.Copy(this.RutaOrigen, this.RutaDestino);
                        }
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

        private void cboCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void dgvListado_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //Evento CellDoubleClikc: Doble en dgv Listado
                this.Limpiar();
                btnInsertar.Visible = false;
                btnActualizar .Visible = true;
                txtId.Text = Convert.ToString(dgvListado.CurrentRow.Cells["ID"].Value);
                //Seleccionar el Id Categoria
                cboCategoria.SelectedValue = Convert.ToString(dgvListado.CurrentRow.Cells["idcategoria"].Value);
                txtCodigo.Text = Convert.ToString(dgvListado.CurrentRow.Cells["Codigo"].Value);
                this.nombreAnt = Convert.ToString(dgvListado.CurrentRow.Cells["Nombre"].Value);
                txtNombre.Text = Convert.ToString(dgvListado.CurrentRow.Cells["Nombre"].Value);
                txtPrecioVenta.Text = Convert.ToString(dgvListado.CurrentRow.Cells["Precio_Venta"].Value);
                txtStock.Text = Convert.ToString(dgvListado.CurrentRow.Cells["Stock"].Value);
                txtDescripcion.Text = Convert.ToString(dgvListado.CurrentRow.Cells["Descripcion"].Value);
                string Imagen ="";
                Imagen = Convert.ToString(dgvListado.CurrentRow.Cells["Imagen"].Value);
                if (Imagen != string.Empty)
                {
                    picImagen.Image = Image.FromFile(this.Directorio + Imagen);
                    txtImagen.Text = Imagen;
                }
                else
                { 
                    picImagen.Image = null;
                    txtImagen.Text = "";
                }
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
                    Rpta = NArticulo.Actualizar(
                        Convert.ToInt32(txtId.Text),
                        //Selected Value devuelve el idCategoria Seleccionado
                        Convert.ToInt32(cboCategoria.SelectedValue),
                        txtCodigo.Text.Trim(),
                        this.nombreAnt,
                        txtNombre.Text.Trim(),
                        Convert.ToDecimal(txtPrecioVenta.Text),
                        Convert.ToInt32(txtStock.Text),
                        txtDescripcion.Text.Trim(),
                        txtImagen.Text.Trim()); 

                    if (Rpta.Equals("OK"))
                    {
                        this.MensajeOk("Se inserto el registro de forma correcta");
                        //Guardamos la imagen - INICIO
                        //Validar si hay un nombre de imagen
                        //Verificamos si selecciono una nueva imagen
                        if (txtImagen.Text != string.Empty && this.RutaOrigen != null)
                        {
                            this.RutaDestino = this.Directorio + txtImagen.Text;
                            File.Copy(this.RutaOrigen, this.RutaDestino);
                        }
                        //Guardamos la imagen - FIN
                        this.Limpiar();
                        //Actualizamos la grilla con los nuevos datos
                        this.Listar();
                        // Muestra la lista
                        tabGeneral.SelectedIndex = 0;
                        btnInsertar.Visible = true;
                        btnActualizar.Visible = false;

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

        private void dgvListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvListado.Columns["Seleccionar"].Index)
            {
                DataGridViewCheckBoxCell chkEliminar =
                    (DataGridViewCheckBoxCell)dgvListado.Rows[e.RowIndex].Cells["Seleccionar"];

                chkEliminar.Value = !Convert.ToBoolean(chkEliminar.Value);
            }
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
                    string Imagen = "";

                    //Recorro todo el grid con FOREACH
                    foreach (DataGridViewRow row in dgvListado.Rows)
                    {
                        //Recorrer todos los registros que esten marcados Chechek Cells[0] = Seleccionar
                        if (Convert.ToBoolean(row.Cells[0].Value))
                        {
                            //Cells[1] = Columna ID
                            Codigo = Convert.ToInt32(row.Cells[1].Value);
                            Imagen = Convert.ToString(row.Cells[9].Value);
                            Rpta = NArticulo.Eliminar(Codigo);

                            if (Rpta.Equals("OK"))
                            {
                                //Cells[5] = Columna Nombre 
                                this.MensajeOk("Se elimino el registro :" + Convert.ToString(row.Cells[5].Value));
                                //Eliminar la Imagen del Directorio
                                File.Delete(this.Directorio+Imagen);
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
        }

        private void btnActivar_Click(object sender, EventArgs e)
        {
            try
            {
                //Resultado de MessageBox
                DialogResult Opcion;
                Opcion = MessageBox.Show(
                    "Realmente deseas activar el(los) registros :",
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
                            Rpta = NArticulo.Activar(Codigo);

                            if (Rpta.Equals("OK"))
                            {
                                //Cells[5] = Columna Nombre
                                this.MensajeOk("Se activo el registro :" + Convert.ToString(row.Cells[5].Value));
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
        }

        private void btnDesactivar_Click(object sender, EventArgs e)
        {
            try
            {
                //Resultado de MessageBox
                DialogResult Opcion;
                Opcion = MessageBox.Show(
                    "Realmente deseas desactivar el(los) registros :",
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
                            Rpta = NArticulo.Desactivar(Codigo);

                            if (Rpta.Equals("OK"))
                            {
                                //Cells[5] = Columna Nombre
                                this.MensajeOk("Se desactivo el registro :" + Convert.ToString(row.Cells[5].Value));
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
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Limpiar();
            tabGeneral.SelectedIndex = 0; //Vuelve a la pestaña de listado
        }
    }
}
