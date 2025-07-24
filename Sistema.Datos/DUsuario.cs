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
    public class DUsuario
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
                SqlCommand Comando = new SqlCommand("usuario_listar", SqlCon);
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
                SqlCommand Comando = new SqlCommand("usuario_buscar", SqlCon);
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
        public DataTable Login(string Email,string Clave)
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
                SqlCommand Comando = new SqlCommand("usuario_login", SqlCon);
                //Que tipo de objeto estoy usando
                Comando.CommandType = CommandType.StoredProcedure;
                //Agrego los parametros VALOR String
                Comando.Parameters.Add("@email", SqlDbType.VarChar).Value = Email;
                Comando.Parameters.Add("@clave", SqlDbType.VarChar).Value = Clave;
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
                //Si no hay ninguna coincidencia no retorna un nulo
                return null;
                throw ex;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
        }
        public string Existe(string Valor)
        {
            string Rpta = "";
            //Genero mi variable de conexion
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                //Instacio mi conexion
                SqlCon = Conexion.getInstancia().CrearConexion();
                // Instancio mi objeto SP
                SqlCommand Comando = new SqlCommand("usuario_existe", SqlCon);
                //Que tipo de objeto estoy usando
                Comando.CommandType = CommandType.StoredProcedure;
                //Agrego los parametros VALOR String
                Comando.Parameters.Add("@valor", SqlDbType.VarChar).Value = Valor;
                // RECIBIR PARAMETRO DE SALIDA
                SqlParameter ParExiste = new SqlParameter();
                ParExiste.ParameterName = "@existe";
                ParExiste.SqlDbType = SqlDbType.Int;
                ParExiste.Direction = ParameterDirection.Output;
                Comando.Parameters.Add(ParExiste);
                //Abrimos la conexion
                SqlCon.Open();
                //Ejecutamos el SP
                Comando.ExecuteNonQuery();
                Rpta = Convert.ToString(ParExiste.Value);
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
        public String Insertar(Usuario Obj)
        {
            string Rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                //Instacio mi conexion
                SqlCon = Conexion.getInstancia().CrearConexion();
                // Instancio mi objeto SP
                SqlCommand Comando = new SqlCommand("usuario_insertar", SqlCon);
                //Que tipo de objeto estoy usando
                Comando.CommandType = CommandType.StoredProcedure;
                //Agrego los parametros VALOR String
                Comando.Parameters.Add("@idrol", SqlDbType.Int).Value = Obj.IdRol;
                Comando.Parameters.Add("@nombre", SqlDbType.VarChar).Value = Obj.Nombre;
                Comando.Parameters.Add("@tipo_documento", SqlDbType.VarChar).Value = Obj.TipoDocumento;
                Comando.Parameters.Add("@num_documento", SqlDbType.VarChar).Value = Obj.NumDocumento;
                Comando.Parameters.Add("@direccion", SqlDbType.VarChar).Value = Obj.Direccion;
                Comando.Parameters.Add("@telefono", SqlDbType.VarChar).Value = Obj.Telefono;
                Comando.Parameters.Add("@email", SqlDbType.VarChar).Value = Obj.Email;
                Comando.Parameters.Add("@clave", SqlDbType.VarChar).Value = Obj.Clave;
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
        public string Actualizar(Usuario Obj)
        {
            string Rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                //Instacio mi conexion
                SqlCon = Conexion.getInstancia().CrearConexion();
                // Instancio mi objeto SP
                SqlCommand Comando = new SqlCommand("usuario_actualizar", SqlCon);
                //Que tipo de objeto estoy usando
                Comando.CommandType = CommandType.StoredProcedure;
                //Agrego los parametros VALOR String
                Comando.Parameters.Add("@idusuario", SqlDbType.Int).Value = Obj.IdUsuario;
                Comando.Parameters.Add("@idrol", SqlDbType.Int).Value = Obj.IdRol;
                Comando.Parameters.Add("@nombre", SqlDbType.VarChar).Value = Obj.Nombre;
                Comando.Parameters.Add("@tipo_documento", SqlDbType.VarChar).Value = Obj.TipoDocumento;
                Comando.Parameters.Add("@num_documento", SqlDbType.VarChar).Value = Obj.NumDocumento;
                Comando.Parameters.Add("@direccion", SqlDbType.VarChar).Value = Obj.Direccion;
                Comando.Parameters.Add("@telefono", SqlDbType.VarChar).Value = Obj.Telefono;
                Comando.Parameters.Add("@email", SqlDbType.VarChar).Value = Obj.Email;
                Comando.Parameters.Add("@clave", SqlDbType.VarChar).Value = Obj.Clave;
                //Abrimos la conexion
                SqlCon.Open();
                //Ejecutamos el SP
                Rpta = Comando.ExecuteNonQuery() == 1 ? "OK" : "No se puedo actualizar el registro";

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
        public string Eliminar(int Id)
        {
            string Rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                //Instacio mi conexion
                SqlCon = Conexion.getInstancia().CrearConexion();
                // Instancio mi objeto SP
                SqlCommand Comando = new SqlCommand("usuario_eliminar", SqlCon);
                //Que tipo de objeto estoy usando
                Comando.CommandType = CommandType.StoredProcedure;
                //Agrego los parametros VALOR String
                Comando.Parameters.Add("@idusuario", SqlDbType.Int).Value = Id;
                //Abrimos la conexion
                SqlCon.Open();
                //Ejecutamos el SP
                Rpta = Comando.ExecuteNonQuery() == 1 ? "OK" : "No se puedo eliminar el registro";

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
        public string Activar(int Id)
        {
            string Rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                //Instacio mi conexion
                SqlCon = Conexion.getInstancia().CrearConexion();
                // Instancio mi objeto SP
                SqlCommand Comando = new SqlCommand("usuario_activar", SqlCon);
                //Que tipo de objeto estoy usando
                Comando.CommandType = CommandType.StoredProcedure;
                //Agrego los parametros VALOR String
                Comando.Parameters.Add("@idusuario", SqlDbType.Int).Value = Id;
                //Abrimos la conexion
                SqlCon.Open();
                //Ejecutamos el SP
                Rpta = Comando.ExecuteNonQuery() == 1 ? "OK" : "No se puedo activar el registro";

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
        public string Desactivar(int Id)
        {
            string Rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                //Instacio mi conexion
                SqlCon = Conexion.getInstancia().CrearConexion();
                // Instancio mi objeto SP
                SqlCommand Comando = new SqlCommand("usuario_desactivar", SqlCon);
                //Que tipo de objeto estoy usando
                Comando.CommandType = CommandType.StoredProcedure;
                //Agrego los parametros VALOR String
                Comando.Parameters.Add("@idusuario", SqlDbType.Int).Value = Id;
                //Abrimos la conexion
                SqlCon.Open();
                //Ejecutamos el SP
                Rpta = Comando.ExecuteNonQuery() == 1 ? "OK" : "No se puedo eliminar el registro";

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
