using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.Datos
{
    public class DRol
    {
        public DataTable Listar()
        {
            SqlDataReader Resultado;
            //Generamos la tabla temporal
            DataTable Tabla = new DataTable();
            //Genero mi variable de conexion
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                //Instacio mi conexion
                SqlCon = Conexion.getInstancia().CrearConexion();
                // Instancio mi objeto SP
                SqlCommand Comando = new SqlCommand("rol_listar", SqlCon);
                //Que tipo de objeto estoy usando
                Comando.CommandType = CommandType.StoredProcedure;
                //Abrimos la conexion
                SqlCon.Open();
                //Ejecutamos el SP
                Resultado = Comando.ExecuteReader();
                //Almacenamos los registros devueltos en tabla temporal Tabla
                Tabla.Load(Resultado);
                return Tabla;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }

        }
    }
}
