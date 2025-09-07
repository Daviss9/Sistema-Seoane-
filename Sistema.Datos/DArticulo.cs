using Sistema.Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.Datos
{
    public class DArticulo
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
                SqlCommand Comando = new SqlCommand("articulo_listar", SqlCon);
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
                SqlCommand Comando = new SqlCommand("articulo_buscar", SqlCon);
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

        public DataTable BuscarCodigo(string Valor)
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
                SqlCommand Comando = new SqlCommand("articulo_buscar_codigo", SqlCon);
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
                SqlCommand Comando = new SqlCommand("articulo_existe", SqlCon);
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
        public String Insertar(Articulo Obj)
        {
            string Rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                //Instacio mi conexion
                SqlCon = Conexion.getInstancia().CrearConexion();
                // Instancio mi objeto SP
                SqlCommand Comando = new SqlCommand("articulo_insertar", SqlCon);
                //Que tipo de objeto estoy usando
                Comando.CommandType = CommandType.StoredProcedure;
                //Agrego los parametros VALOR String
                Comando.Parameters.Add("@idcategoria", SqlDbType.Int).Value = Obj.IdCategoria;
                Comando.Parameters.Add("@codigo", SqlDbType.VarChar).Value = Obj.Codigo;
                Comando.Parameters.Add("@nombre", SqlDbType.VarChar).Value = Obj.Nombre;
                Comando.Parameters.Add("@precio_venta", SqlDbType.Decimal).Value = Obj.PrecioVenta;
                Comando.Parameters.Add("@stock", SqlDbType.Int).Value = Obj.Stock;
                Comando.Parameters.Add("@descripcion", SqlDbType.VarChar).Value = Obj.Descripcion;
                Comando.Parameters.Add("@imagen", SqlDbType.VarChar).Value = Obj.Imagen;
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
        public string Actualizar(Articulo Obj)
        {
            string Rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                //Instacio mi conexion
                SqlCon = Conexion.getInstancia().CrearConexion();
                // Instancio mi objeto SP
                SqlCommand Comando = new SqlCommand("articulo_actualizar", SqlCon);
                //Que tipo de objeto estoy usando
                Comando.CommandType = CommandType.StoredProcedure;
                //Agrego los parametros VALOR String
                Comando.Parameters.Add("@idarticulo", SqlDbType.Int).Value = Obj.IdArticulo;
                Comando.Parameters.Add("@idcategoria", SqlDbType.Int).Value = Obj.IdCategoria;
                Comando.Parameters.Add("@codigo", SqlDbType.VarChar).Value = Obj.Codigo;
                Comando.Parameters.Add("@nombre", SqlDbType.VarChar).Value = Obj.Nombre;
                Comando.Parameters.Add("@precio_venta", SqlDbType.Decimal).Value = Obj.PrecioVenta;
                Comando.Parameters.Add("@stock", SqlDbType.Int).Value = Obj.Stock;
                Comando.Parameters.Add("@descripcion", SqlDbType.VarChar).Value = Obj.Descripcion;
                Comando.Parameters.Add("@imagen", SqlDbType.VarChar).Value = Obj.Imagen;
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
                SqlCommand Comando = new SqlCommand("articulo_eliminar", SqlCon);
                //Que tipo de objeto estoy usando
                Comando.CommandType = CommandType.StoredProcedure;
                //Agrego los parametros VALOR String
                Comando.Parameters.Add("@idarticulo", SqlDbType.Int).Value = Id;
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
                SqlCommand Comando = new SqlCommand("articulo_activar", SqlCon);
                //Que tipo de objeto estoy usando
                Comando.CommandType = CommandType.StoredProcedure;
                //Agrego los parametros VALOR String
                Comando.Parameters.Add("@idarticulo", SqlDbType.Int).Value = Id;
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
                SqlCommand Comando = new SqlCommand("articulo_desactivar", SqlCon);
                //Que tipo de objeto estoy usando
                Comando.CommandType = CommandType.StoredProcedure;
                //Agrego los parametros VALOR String
                Comando.Parameters.Add("@idarticulo", SqlDbType.Int).Value = Id;
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
