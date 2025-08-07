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
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            try 
            {
                DataTable Tabla = new DataTable();
                Tabla = NUsuario.Login(txtEmail.Text.Trim(), txtClave.Text.Trim());
                if (Tabla.Rows.Count <= 0)
                {
                    //Si no existe coincidencia
                    MessageBox.Show("Email o Clave incorrectos", "Error", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    //Si existe coincidencia, pero el usuario no está activo
                    if (Convert.ToBoolean(Tabla.Rows[0][4]) == false)
                    {
                        MessageBox.Show("El Usuario no se encuentra ACTIVO", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        //Si existe coincidencia y el usuario está activo
                        frmPrincipal frm = new frmPrincipal();
                        frm.IdUsuario = Convert.ToInt32(Tabla.Rows[0][0]);
                        frm.IdRol = Convert.ToInt32(Tabla.Rows[0][1]);
                        frm.Rol = Tabla.Rows[0][2].ToString();
                        frm.Nombre = Tabla.Rows[0][3].ToString();
                        frm.Estado = Tabla.Rows[0][4].ToString();
                        frm.Show();
                        this.Hide();

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            GenerarNumero();
        }

        List<Button> botones = new List<Button>();

        private void GenerarNumero()
        {
           botones = new List<Button> {button1, button2, button3, button4, button5, button6, button7, button8, button9,button10};
           List<int> numAleatorios = Enumerable.Range(0, 10).ToList();
           Random rand = new Random();
           numAleatorios = numAleatorios.OrderBy(x => rand.Next()).ToList();

            for (int i = 0; i < botones.Count; i++)
            {
                botones[i].Text = numAleatorios[i].ToString();
            }

            foreach (Button boton in botones)
            {
                boton.Click += BotonNumerico_Click;
            }
        }
        private void BotonNumerico_Click(object sender, EventArgs e)
        {
            Button boton = (Button)sender;
            txtClave.Text += boton.Text;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtClave.Clear();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if (txtClave.Text.Length > 0)
            {
                txtClave.Text = txtClave.Text.Substring(0, txtClave.Text.Length - 1);
            }
        }
    }
}
