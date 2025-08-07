using Sistema.Datos;
using Sistema.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.Negocio
{
    public class NPersona
    {
        public static DataTable Listar()
        {
            DPersona Datos = new DPersona();
            return Datos.Listar();
        }
        public static DataTable ListarProveedores()
        {
            DPersona Datos = new DPersona();
            return Datos.ListarProveedores();
        }

        public static DataTable ListarClientes()
        {
            DPersona Datos = new DPersona();
            return Datos.ListarClientes();
        }
        public static DataTable Buscar(string Valor)
        {
            DPersona Datos = new DPersona();
            return Datos.Buscar(Valor);
        }
        public static DataTable BuscarClientes(string Valor)
        {
            DPersona Datos = new DPersona();
            return Datos.BuscarClientes(Valor);
        }
        public static DataTable BuscarProvedores(string Valor)
        {
            DPersona Datos = new DPersona();
            return Datos.BuscarProveedores(Valor);
        }
        
        public static string Insertar(
            string TipoPersona, string Nombre, string TipoDocumento, string NumDocumento,
            string Direccion, string Telefono, string Email)
        {
            DPersona Datos = new DPersona();
            //Usuario validamos por el Email
            string Existe = Datos.Existe(Nombre);
            if (Existe.Equals("1"))
            {
                //La categoria Existe
                return "DUPLICIDAD: El nombre ya se encuentra registrado";
            }
            else
            {
                // La Categoria NO Existe
                Persona Obj = new Persona();
                Obj.TipoPersona = TipoPersona;
                Obj.Nombre = Nombre;
                Obj.TipoDocumento = TipoDocumento;
                Obj.NumDocumento = NumDocumento;
                Obj.Direccion = Direccion;
                Obj.Telefono = Telefono;
                Obj.Email = Email;
                return Datos.Insertar(Obj);
            }
        }
        public static string Actualizar(int IdPersona, string TipoPersona,string NombreAnt ,string Nombre, 
            string TipoDocumento, string NumDocumento,
            string Direccion, string Telefono, string Email)
        {
            DPersona Datos = new DPersona();
            Persona Obj = new Persona();

            //Verificamos que si el nombre Anterior es igual al Nombre Actual
            if (NombreAnt.Equals(Nombre))
            {
                Obj.IdPersona = IdPersona;
                Obj.TipoPersona = TipoPersona;
                Obj.Nombre = Nombre;
                Obj.TipoDocumento = TipoDocumento;
                Obj.NumDocumento = NumDocumento;
                Obj.Direccion = Direccion;
                Obj.Telefono = Telefono;
                Obj.Email = Email;
  
                return Datos.Actualizar(Obj);
            }
            else
            //Verificamos si el nombre anterior ya existe en la tabla
            {
                string Existe = Datos.Existe(Nombre);
                if (Existe.Equals("1"))
                {
                    //La persona Existe
                    return "La persona que desea Actualizar ya existe";
                }
                else
                {
                    // La Persona NO Existe
                    Obj.IdPersona = IdPersona;
                    Obj.TipoPersona = TipoPersona;
                    Obj.Nombre = Nombre;
                    Obj.TipoDocumento = TipoDocumento;
                    Obj.NumDocumento = NumDocumento;
                    Obj.Direccion = Direccion;
                    Obj.Telefono = Telefono;
                    Obj.Email = Email;
                    return Datos.Actualizar(Obj);
                }
            }


        }
        public static string Eliminar(int Id)
        {
            DPersona Datos = new DPersona();
            return Datos.Eliminar(Id);
        }
    }
}
