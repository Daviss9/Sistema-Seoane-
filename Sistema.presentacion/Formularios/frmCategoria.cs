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
    public partial class frmCategoria : Form
    {
        private string nombreAnt;
        public frmCategoria()
        {
            InitializeComponent();
        }
        public void Formato()
        {
            //Columna Seleccionar
            dgvListado.Columns[0].Visible = false;
            //Columna ID
            dgvListado.Columns[1].Visible = false;
            //Columna Nombre
            dgvListado.Columns[2].HeaderText = "NOMBRE";
            //Columna Descripcion
            dgvListado.Columns[3].HeaderText = "DESCRIPCION";
            dgvListado.Columns[3].Width = 280;
            //Columna Estado
            dgvListado.Columns[4].HeaderText = "ESTADO";
        }
        private void Listar()
        {
            try
            {
                //Carga los datos en la grilla
                dgvListado.DataSource = NCategoria.Listar();
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

        private void frmCategoria_Load(object sender, EventArgs e)
        {
            this.Listar();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                //Carga los datos en la grilla
                dgvListado.DataSource = NCategoria.Buscar(txtBuscar.Text);
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

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            try
            {
                string Rpta = "";
                if (txtNombre.Text == string.Empty)
                {
                    this.MensajeError("Faltan ingresar algunos datos, seran remarcados");
                    errorIcono.SetError(txtNombre, "Ingrese un Nombre");
                }
                else 
                {
                    Rpta = NCategoria.Insertar(txtNombre.Text.Trim(),
                        txtDescripcion.Text.Trim());
                    if (Rpta.Equals("OK"))
                    {
                        this.MensajeOk("Se inserto el registro de forma correcta");
                        this.Limpiar();
                        //Actualizamos la grilla con los nuevos datos
                        this.Listar();
                    }
                    else 
                    {
                        this.MensajeError(Rpta);
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message + " - " + ex.StackTrace);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Limpiar();
            tabGeneral.SelectedIndex = 0;
        }

        private void dgvListado_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try 
            {
                //Limpiar las cajas de texto
                this.Limpiar();
                //Mostramos el boton actualizar
                btnActualizar.Visible = true;
                btnInsertar.Visible = false;
                txtId.Text = Convert.ToString(dgvListado.CurrentRow.Cells["ID"].Value);
                txtNombre.Text = Convert.ToString(dgvListado.CurrentRow.Cells["Nombre"].Value);
                this.nombreAnt = Convert.ToString(dgvListado.CurrentRow.Cells["Nombre"].Value);
                txtDescripcion.Text = Convert.ToString(dgvListado.CurrentRow.Cells["Descripcion"].Value);
                //Visualizo de manera automatica el tabPage Mantenimiento
                tabGeneral.SelectedIndex = 1;
            }
            catch(Exception)
            {
                MessageBox.Show("Seleccione desde la celda Nombre");
            }

            
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                // || alt + 124
                string Rpta = "";
                if (txtNombre.Text == string.Empty || txtId.Text == string.Empty )
                {
                    this.MensajeError("Faltan ingresar algunos datos, seran remarcados");
                    errorIcono.SetError(txtNombre, "Ingrese un Nombre");
                }
                else
                {
                    Rpta = NCategoria.Actualizar(
                        Convert.ToInt32(txtId.Text),
                        this.nombreAnt,
                        txtNombre.Text.Trim(),
                        txtDescripcion.Text.Trim());
                    if (Rpta.Equals("OK"))
                    {
                        this.MensajeOk("Se inserto el registro de forma correcta");
                        this.Limpiar();


                        //Actualizamos la grilla con los nuevos datos
                        this.Listar();
                    }
                    else
                    {
                        this.MensajeError(Rpta);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " - " + ex.StackTrace);
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
                            Rpta = NCategoria.Eliminar(Codigo);

                            if (Rpta.Equals("OK"))
                            {
                                //Cells[2] = Columna Nombre
                                this.MensajeOk("Se elimino el registro :" + Convert.ToString(row.Cells[2].Value));
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
            catch(Exception ex) 
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
                            Rpta = NCategoria.Activar(Codigo);

                            if (Rpta.Equals("OK"))
                            {
                                //Cells[2] = Columna Nombre
                                this.MensajeOk("Se activo el registro :" + Convert.ToString(row.Cells[2].Value));
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
                            Rpta = NCategoria.Desactivar(Codigo);

                            if (Rpta.Equals("OK"))
                            {
                                //Cells[2] = Columna Nombre
                                this.MensajeOk("Se desactivo el registro :" + Convert.ToString(row.Cells[2].Value));
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
    }
}
