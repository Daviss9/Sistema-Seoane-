using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Utilizar SQL CLient conectarme a SQL Server
using System.Data.SqlClient;

namespace Sistema.Datos
{
    internal class Conexion
    {
        // Creo mis 4 variables de conexion
        private string Base;
        private string Servidor;
        private string Usuario;
        private string Clave;
        private bool Seguridad;

        //Declaramos el objeto conexion instanciar a la clase conexion
        private static Conexion Con = null;
        private Conexion()
        {
            // Indicar los valores de cada variable en modo privado
            this.Base = "dbventas_dss";
            this.Servidor = "DAVISSLP";
            this.Usuario = "sa";
            this.Clave = "1234569";
            this.Seguridad = false; //FALSO: Aunteticacion de SQL / TRUE: Auth WINDOWS
        }
        public SqlConnection CrearConexion()
        {
            SqlConnection cadena = new SqlConnection();
            try
            {
                //Crear la cadena de conexion a la BD
                cadena.ConnectionString =
                    "Server =" + this.Servidor + ";" +
                    "Database =" + this.Base + ";";
                // Consultamos si Seguridad es TRUE O FALSE
                if (this.Seguridad)
                {
                    //TRUE : Autenticacion Windows
                    cadena.ConnectionString = cadena.ConnectionString +
                        "Integrated Security = SSPI";
                }
                else 
                {
                    //FALSE : Auth SQL Server
                    cadena.ConnectionString = cadena.ConnectionString +
                        "User Id ="+ this.Usuario+";"+
                        "Password ="+ this.Clave+";";
                }

            }
            catch(Exception ex) 
            { 
                cadena = null;
                throw ex;
            }
            return cadena;
        }
        public static Conexion getInstancia()
        {
            if (Con == null)
            {
                Con = new Conexion();
            }
            return Con;
        }

    }
}
