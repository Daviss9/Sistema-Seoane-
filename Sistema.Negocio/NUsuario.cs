using Sistema.Datos;
using Sistema.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.Negocio
{
    public class NUsuario
    {
        public static DataTable Listar()
        {
            DUsuario Datos = new DUsuario();
            return Datos.Listar();
        }
        
        public static DataTable Buscar(string Valor)
        {
            DUsuario Datos = new DUsuario();
            return Datos.Buscar(Valor);
        }
        public static DataTable Login(string Email, string Clave)
        {
            DUsuario Datos = new DUsuario();
            return Datos.Login(Email,Clave);
        }
        public static string Insertar(
            int IdRol, string Nombre, string TipoDocumento, string NumDocumento,
            string Direccion,string Telefono,string Email,string Clave )
        {
            DUsuario Datos = new DUsuario();
            //Usuario validamos por el Email
            string Existe = Datos.Existe(Email);
            if (Existe.Equals("1"))
            {
                //La categoria Existe
                return "DUPLICIDAD: El email ya se encuentra registrado";
            }
            else
            {
                // La Categoria NO Existe
                Usuario Obj = new Usuario();
                Obj.IdRol = IdRol;
                Obj.Nombre = Nombre;
                Obj.TipoDocumento = TipoDocumento;
                Obj.NumDocumento = NumDocumento;
                Obj.Direccion = Direccion;
                Obj.Telefono = Telefono;
                Obj.Email = Email;
                Obj.Clave = Clave;
                return Datos.Insertar(Obj);
            }
        }
        public static string Actualizar(int IdUsuario, int IdRol, string Nombre, string TipoDocumento, 
            string NumDocumento,
            string Direccion, string Telefono,string EmailAnt, string Email, string Clave)
        {
            DUsuario Datos = new DUsuario();
            Usuario Obj = new Usuario();

            //Verificamos que si el nombre Anterior es igual al Nombre Actual
            if (EmailAnt.Equals(Email))
            {
                Obj.IdUsuario = IdUsuario;
                Obj.IdRol = IdRol;
                Obj.Nombre = Nombre;
                Obj.TipoDocumento = TipoDocumento;
                Obj.NumDocumento = NumDocumento;
                Obj.Direccion = Direccion;
                Obj.Telefono = Telefono;
                Obj.Email = Email;
                Obj.Clave = Clave;
                return Datos.Actualizar(Obj);
            }
            else
            //Verificamos si el nombre anterior ya existe en la tabla
            {
                string Existe = Datos.Existe(Email);
                if (Existe.Equals("1"))
                {
                    //La categoria Existe
                    return "El usuario que desea Actualizar ya existe";
                }
                else
                {
                    // La Categoria NO Existe
                    Obj.IdUsuario = IdUsuario;
                    Obj.IdRol = IdRol;
                    Obj.Nombre = Nombre;
                    Obj.TipoDocumento = TipoDocumento;
                    Obj.NumDocumento = NumDocumento;
                    Obj.Direccion = Direccion;
                    Obj.Telefono = Telefono;
                    Obj.Email = Email;
                    Obj.Clave = Clave;
                    return Datos.Actualizar(Obj);
                }
            }
            

        }
        public static string Eliminar(int Id)
        {
            DUsuario Datos = new DUsuario();
            return Datos.Eliminar(Id);
        }
        public static string Activar(int Id)
        {
            DUsuario Datos = new DUsuario();
            return Datos.Activar(Id);
        }
        public static string Desactivar(int Id)
        {
            DUsuario Datos = new DUsuario();
            return Datos.Desactivar(Id);
        }
    }
}
