using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Agrego el namespace
using System.Data.SqlClient;
using Sistema.Entidades;

namespace Sistema.Datos
{
    public class DCategoria
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
                SqlCommand Comando = new SqlCommand("categoria_listar",SqlCon);
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
        public DataTable Seleccionar()
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
                SqlCommand Comando = new SqlCommand("categoria_seleccionar", SqlCon);
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
                SqlCommand Comando = new SqlCommand("categoria_buscar", SqlCon);
                //Que tipo de objeto estoy usando
                Comando.CommandType = CommandType.StoredProcedure;
                //Agrego los parametros VALOR String
                Comando.Parameters.Add("@valor",SqlDbType.VarChar).Value = Valor;
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
                SqlCommand Comando = new SqlCommand("categoria_existe", SqlCon);
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
        public String Insertar(Categoria Obj)
        {
            string Rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                //Instacio mi conexion
                SqlCon = Conexion.getInstancia().CrearConexion();
                // Instancio mi objeto SP
                SqlCommand Comando = new SqlCommand("categoria_insertar", SqlCon);
                //Que tipo de objeto estoy usando
                Comando.CommandType = CommandType.StoredProcedure;
                //Agrego los parametros VALOR String
                Comando.Parameters.Add("@nombre", SqlDbType.VarChar).Value = Obj.Nombre;
                Comando.Parameters.Add("@descripcion", SqlDbType.VarChar).Value = Obj.Descripcion;
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
        public string Actualizar(Categoria Obj)
        {
            string Rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                //Instacio mi conexion
                SqlCon = Conexion.getInstancia().CrearConexion();
                // Instancio mi objeto SP
                SqlCommand Comando = new SqlCommand("categoria_actualizar", SqlCon);
                //Que tipo de objeto estoy usando
                Comando.CommandType = CommandType.StoredProcedure;
                //Agrego los parametros VALOR String
                Comando.Parameters.Add("@idcategoria", SqlDbType.Int).Value = Obj.IdCategoria;
                Comando.Parameters.Add("@nombre", SqlDbType.VarChar).Value = Obj.Nombre;
                Comando.Parameters.Add("@descripcion", SqlDbType.VarChar).Value = Obj.Descripcion;
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
                SqlCommand Comando = new SqlCommand("categoria_eliminar", SqlCon);
                //Que tipo de objeto estoy usando
                Comando.CommandType = CommandType.StoredProcedure;
                //Agrego los parametros VALOR String
                Comando.Parameters.Add("@idcategoria", SqlDbType.Int).Value = Id;
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
                SqlCommand Comando = new SqlCommand("categoria_activar", SqlCon);
                //Que tipo de objeto estoy usando
                Comando.CommandType = CommandType.StoredProcedure;
                //Agrego los parametros VALOR String
                Comando.Parameters.Add("@idcategoria", SqlDbType.Int).Value = Id;
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
                SqlCommand Comando = new SqlCommand("categoria_desactivar", SqlCon);
                //Que tipo de objeto estoy usando
                Comando.CommandType = CommandType.StoredProcedure;
                //Agrego los parametros VALOR String
                Comando.Parameters.Add("@idcategoria", SqlDbType.Int).Value = Id;
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
