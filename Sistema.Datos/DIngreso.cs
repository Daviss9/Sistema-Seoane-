using Sistema.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.Datos
{
    public class DIngreso
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
                SqlCommand Comando = new SqlCommand("ingreso_listar", SqlCon);
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
        public DataTable Buscar(string Valor)
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
                SqlCommand Comando = new SqlCommand("ingreso_buscar", SqlCon);
                //Que tipo de objeto estoy usando
                Comando.CommandType = CommandType.StoredProcedure;
                //Agrego los parametros VALOR String
                Comando.Parameters.Add("@valor", SqlDbType.VarChar).Value = Valor;
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
        public String Insertar(Ingreso Obj)
        {
            string Rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                //Instacio mi conexion
                SqlCon = Conexion.getInstancia().CrearConexion();
                // Instancio mi objeto SP
                SqlCommand Comando = new SqlCommand("ingreso_insertar", SqlCon);
                //Que tipo de objeto estoy usando
                Comando.CommandType = CommandType.StoredProcedure;
                //Agrego los parametros VALOR String
                Comando.Parameters.Add("@idproveedor", SqlDbType.Int).Value = Obj.IdProveedor;
                Comando.Parameters.Add("@idusuario", SqlDbType.Int).Value = Obj.IdUsuario;
                Comando.Parameters.Add("@tipo_comprobante", SqlDbType.VarChar).Value = Obj.TipoComprobante;
                Comando.Parameters.Add("@serie_comprobante", SqlDbType.VarChar).Value = Obj.SerieComprobante;
                Comando.Parameters.Add("@num_comprobante", SqlDbType.VarChar).Value = Obj.NumComprobante;
                Comando.Parameters.Add("@impuesto", SqlDbType.Decimal).Value = Obj.Impuesto;
                Comando.Parameters.Add("@total", SqlDbType.Decimal).Value = Obj.Total;
                Comando.Parameters.Add("@detalles", SqlDbType.Structured).Value = Obj.Detalles;
                //Abrimos la conexion
                SqlCon.Open();
                //Ejecutamos el SP
                Rpta = Comando.ExecuteNonQuery() == 1 ? "OK" : "No se puedo ingresar el registro";

            }
            catch (Exception ex)
            {
                Rpta = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return Rpta;
        }
        public string Anular(int Id)
        {
            string Rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                //Instacio mi conexion
                SqlCon = Conexion.getInstancia().CrearConexion();
                // Instancio mi objeto SP
                SqlCommand Comando = new SqlCommand("ingreso_anular", SqlCon);
                //Que tipo de objeto estoy usando
                Comando.CommandType = CommandType.StoredProcedure;
                //Agrego los parametros VALOR String
                Comando.Parameters.Add("@idingreso", SqlDbType.Int).Value = Id;
                //Abrimos la conexion
                SqlCon.Open();
                //Ejecutamos el SP
                Rpta = Comando.ExecuteNonQuery() == 1 ? "OK" : "No se puedo anular el registro";

            }
            catch (Exception ex)
            {
                Rpta = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return Rpta;
        }

    }
}
