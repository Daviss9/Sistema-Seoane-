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
    public partial class frmIngreso : Form
    {
        private DataTable dtDetalle = new DataTable(); //Tabla para almacenar detalles de ingreso
        public frmIngreso()
        {
            InitializeComponent();
        }
        private void Formato()
        {
            //Oculta las columnas innecesarias
            dgvListado.Columns[0].Visible = false; //Seleccionar
            dgvListado.Columns[0].HeaderText = "SELECCIONAR"; //Seleccionar
            dgvListado.Columns[1].Visible = false; //IdIngreso
            dgvListado.Columns[2].Visible = false; //IdUsuario

            dgvListado.Columns[3].Width = 150; 
            dgvListado.Columns[3].HeaderText = "USUARIO";
            dgvListado.Columns[4].Width = 150; 
            dgvListado.Columns[4].HeaderText = "PROVEEDOR";
            dgvListado.Columns[5].Width = 100; 
            dgvListado.Columns[5].HeaderText = "TIPO COMPROBANTE";
            dgvListado.Columns[6].Width = 70; 
            dgvListado.Columns[6].HeaderText = "SERIE";
            dgvListado.Columns[7].Width = 70; 
            dgvListado.Columns[7].HeaderText = "NUMERO";
            dgvListado.Columns[8].Width = 60;
            dgvListado.Columns[8].HeaderText = "FECHA";
            dgvListado.Columns[9].Width = 100;
            dgvListado.Columns[9].HeaderText = "IMPUESTO";
            dgvListado.Columns[10].Width = 100;
            dgvListado.Columns[10].HeaderText = "TOTAL";
            dgvListado.Columns[11].Width = 100;
            dgvListado.Columns[11].HeaderText = "ESTADO";

        }

        private void FormatoArticulo()
        {
            dgvArticulo.Columns[0].Visible = false; //IdArticulo
            dgvArticulo.Columns[1].Visible = false; //IdCategoria
            dgvArticulo.Columns[2].Width = 100;
            dgvArticulo.Columns[2].HeaderText = "CATEGORIA";
            dgvArticulo.Columns[3].Width = 100;
            dgvArticulo.Columns[3].HeaderText = "CODIGO";
            dgvArticulo.Columns[4].Width = 150;
            dgvArticulo.Columns[4].HeaderText = "NOMBRE";
            dgvArticulo.Columns[5].Width = 100;
            dgvArticulo.Columns[5].HeaderText = "PRECIO VENTA";
            dgvArticulo.Columns[6].Width = 60;
            dgvArticulo.Columns[6].HeaderText = "STOCK";
            dgvArticulo.Columns[7].Width = 200;
            dgvArticulo.Columns[7].HeaderText = "DESCRIPCION";
            dgvArticulo.Columns[8].Visible = false;
            dgvArticulo.Columns[9].Width = 70;
            dgvArticulo.Columns[9].HeaderText = "ESTADO";

        }
        private void Listar()
        {
            try
            {
                //Carga los datos en la grilla
                dgvListado.DataSource = NIngreso.Listar();
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
                dgvListado.DataSource = NIngreso.Buscar(txtBuscar.Text);
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
        
        private void Limpiar()
        {
            
            errorIcono.Clear(); //Limpia los iconos de error

            dgvListado.Columns[0].Visible = false; //Seleccionar
            btnEliminar.Visible = false; //Boton Eliminar
            chkSeleccionar.Checked = false; //Desmarca el checkbox

            btnInsertar.Visible = true; //Boton Insertar

        }

        private void CrearTabla()
        {
            //Crea una nueva tabla para almacenar los detalles del ingreso
            //Genero las columnas de la tabla
            this.dtDetalle.Columns.Add("idarticulo", System.Type.GetType("System.Int32")); 
            this.dtDetalle.Columns.Add("codigo", System.Type.GetType("System.String"));
            this.dtDetalle.Columns.Add("articulo", System.Type.GetType("System.String"));
            this.dtDetalle.Columns.Add("cantidad", System.Type.GetType("System.Int32"));
            this.dtDetalle.Columns.Add("precio", System.Type.GetType("System.Decimal"));
            this.dtDetalle.Columns.Add("importe", System.Type.GetType("System.Decimal"));

            dgvDetalle.DataSource = this.dtDetalle; //Asigna la tabla al DataGridView

            //Formatea el DataGridView
            dgvDetalle.Columns[0].Visible = false; //Oculta la columna idarticulo
            dgvDetalle.Columns[1].Width = 100; //Ancho de la columna codigo
            dgvDetalle.Columns[1].HeaderText = "CODIGO"; //Titulo de la columna codigo
            dgvDetalle.Columns[2].Width = 250; //Ancho de la columna articulo
            dgvDetalle.Columns[2].HeaderText = "ARTICULO"; //Titulo de la columna articulo
            dgvDetalle.Columns[3].Width = 80; //Ancho de la columna cantidad
            dgvDetalle.Columns[3].HeaderText = "CANTIDAD"; //Titulo de la columna cantidad
            dgvDetalle.Columns[4].Width = 80; //Ancho de la columna precio
            dgvDetalle.Columns[4].HeaderText = "PRECIO"; //Titulo de la columna precio
            dgvDetalle.Columns[5].Width = 80; //Ancho de la columna importe
            dgvDetalle.Columns[5].HeaderText = "IMPORTE"; //Titulo de la columna importe

            // Columnas de solo lectura
            dgvDetalle.Columns[1].ReadOnly = true; //Columna codigo
            dgvDetalle.Columns[2].ReadOnly = true; //Columna articulo
            dgvDetalle.Columns[5].ReadOnly = true; //Columna importe
        }
        private void frmIngreso_Load(object sender, EventArgs e)
        {
            Listar(); //Llama al metodo Listar al cargar el formulario
            CrearTabla(); //Llama al metodo CrearTabla al cargar el formulario
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Buscar(); //Llama al metodo Buscar al hacer clic en el boton Buscar
        }

        private void btnBuscarProveedor_Click(object sender, EventArgs e)
        {
            //Nueva instancia del formulario de proveedor
            frmVista_Proveedor vista = new frmVista_Proveedor();
            vista.ShowDialog(); //Muestra el formulario de proveedor como dialogo
            txtIdProveedor.Text = Variables.IdProveedor.ToString();
            txtNombreProveedor.Text = Variables.NombreProveedor;
        }
        private void CalcularTotales()
        {
            decimal Total = 0;
            decimal Subtotal = 0;
            //Recorrer el DtDetalle
            foreach (DataRow FilaTemp in dtDetalle.Rows)
            {
                //Total es un acumulador +
                Total = Total + Convert.ToDecimal(FilaTemp["importe"]);
            }
            Subtotal = Total / (1 + Convert.ToDecimal(txtIgv.Text));
            txtTotal.Text = Total.ToString("#0.00#"); //Formato 125.00
            txtSubTotal.Text = Subtotal.ToString("#0.00#");
            txtImpuesto.Text = (Total - Subtotal).ToString("#0.00#");
        }

        private void AgregarDetalle(
            int IdArticulo,
            string Codigo,
            string Nombre,
            decimal Precio
            )
        {
            //Declaro una variable booleana para verificar si el articulo ya existe en el detalle
            bool Agregar = true;
            //Recorre todas las filas del detalle buscando el articulo
            foreach (DataRow FilaTemp in dtDetalle.Rows)
            {
                //Si el articulo ya existe en el detalle
                if (Convert.ToInt32(FilaTemp["idarticulo"]) == IdArticulo)
                {
                    Agregar = false; //No se agrega el articulo
                    this.MensajeError("El articulo ya fue agregado al detalle");
                }
            }
            if (Agregar) // Agregar TRUE
            {
                DataRow Fila = dtDetalle.NewRow(); //Crea una nueva fila
                Fila["idarticulo"] = IdArticulo;
                Fila["codigo"] = Codigo;
                Fila["articulo"] = Nombre;
                Fila["cantidad"] = 1;
                Fila["precio"] = Precio;
                Fila["importe"] = Precio;
                this.dtDetalle.Rows.Add(Fila); //Agrega la fila a la tabla
                this.CalcularTotales(); //Actualiza los totales
            }
            
        }
        private void txtCodigo_KeyDown(object sender, KeyEventArgs e)
        {
            try 
            {
                //Presiona la tecla Enter
                if(e.KeyCode == Keys.Enter)
                {
                    DataTable tabla = new DataTable();
                    tabla = NArticulo.BuscarCodigo(txtCodigo.Text.Trim());
                    if(tabla.Rows.Count <= 0)
                    {
                        MensajeError("No existe el articulo con ese codigo");
                    }
                    else
                    { 
                        this.AgregarDetalle(
                            Convert.ToInt32(tabla.Rows[0][0]), //IdArticulo 
                            Convert.ToString(tabla.Rows[0][1]), //Codigo
                            Convert.ToString(tabla.Rows[0][2]), //Nombre
                            Convert.ToDecimal(tabla.Rows[0][3])  //PrecioVenta
                            );
                    }
                    txtCodigo.Clear();
                    txtCodigo.Focus();
                }
            }
            catch (Exception ex)
            {
                MensajeError(ex.Message);
            }
        }

        private void btnBuscarArticulo_Click(object sender, EventArgs e)
        {
            pnlArticulo.Visible = true; //Muestra el panel de articulo
        }

        private void btnCerrarArticulo_Click(object sender, EventArgs e)
        {
            pnlArticulo.Visible = false; //Oculta el panel de articulo
        }

        private void btnBusquedaArticulo_Click(object sender, EventArgs e)
        {
            try
            {
                dgvArticulo.DataSource = NArticulo.Buscar(txtArticuloNombre.Text.Trim());
                this.FormatoArticulo();
            }
            catch(Exception ex)
            {
                MensajeError(ex.Message);
            }
        }

        private void dgvArticulo_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int IdArticulo;
            string Codigo, Nombre;
            decimal Precio;
            IdArticulo = Convert.ToInt32(dgvArticulo.CurrentRow.Cells["ID"].Value);
            Codigo = Convert.ToString(dgvArticulo.CurrentRow.Cells["Codigo"].Value);
            Nombre = Convert.ToString(dgvArticulo.CurrentRow.Cells["Nombre"].Value);
            Precio = Convert.ToDecimal(dgvArticulo.CurrentRow.Cells["Precio_Venta"].Value);
            //Invoco a funcion AgregarDetalle
            this.AgregarDetalle(IdArticulo, Codigo, Nombre, Precio);
            pnlArticulo.Visible = false; //Oculta el panel de articulo
            txtArticuloNombre.Clear();
        }

        private void dgvDetalle_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            //Cuando se termina de editar una celda
            DataRow Fila = (DataRow)dtDetalle.Rows[e.RowIndex];
            decimal Precio = Convert.ToDecimal(Fila["precio"]);
            int Cantidad = Convert.ToInt32(Fila["cantidad"]);
            Fila["importe"] = Precio * Cantidad; //Actualiza el importe
            this.CalcularTotales(); //Actualiza los totales
        }
    }
}
