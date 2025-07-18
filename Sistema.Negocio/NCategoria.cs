﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sistema.Datos;
using Sistema.Entidades;

namespace Sistema.Negocio
{
    public class NCategoria
    {
        public static DataTable Listar()
        { 
            DCategoria Datos = new DCategoria();
            return Datos.Listar();
        }
        public static DataTable Selecionar()
        {
            DCategoria Datos = new DCategoria();
            return Datos.Seleccionar();
        }
        public static DataTable Buscar(string Valor)
        {
            DCategoria Datos = new DCategoria();
            return Datos.Buscar(Valor);
        }
        public static string Insertar(string Nombre, string Descripcion)
        {
            DCategoria Datos = new DCategoria();
            string Existe = Datos.Existe(Nombre);
            if (Existe.Equals("1"))
            {
                //La categoria Existe
                return "La Categoria ya existe";
            }
            else
            {
                // La Categoria NO Existe
                Categoria Obj = new Categoria();
                Obj.Nombre = Nombre;
                Obj.Descripcion = Descripcion;
                return Datos.Insertar(Obj);
            }
        }
        public static string Actualizar(int Id, string NombreAnt, string Nombre, string Descripcion)
        {
            DCategoria Datos = new DCategoria();
            Categoria Obj = new Categoria();
            
            //Verificamos que si el nombre Anterior es igual al Nombre Actual
            if (NombreAnt.Equals(Nombre))
            {
                Obj.IdCategoria = Id;
                Obj.Nombre = Nombre;
                Obj.Descripcion = Descripcion;
                return Datos.Actualizar(Obj);

            }
            else
            //Verificamos si el nombre anterior ya existe en la tabla
            {
                string Existe = Datos.Existe(Nombre);
                if (Existe.Equals("1"))
                {
                    //La categoria Existe
                    return "La Categoria que desea Actualizar ya existe";
                }
                else
                {
                    // La Categoria NO Existe
                    Obj.IdCategoria = Id;
                    Obj.Nombre = Nombre;
                    Obj.Descripcion = Descripcion;
                    return Datos.Actualizar(Obj);
                }
            }
            
        }
        public static string Eliminar(int Id)
        {
            DCategoria Datos = new DCategoria();
            return Datos.Eliminar(Id);
        }
        public static string Activar(int Id)
        {
            DCategoria Datos = new DCategoria();
            return Datos.Activar(Id);
        }
        public static string Desactivar(int Id)
        {
            DCategoria Datos = new DCategoria();
            return Datos.Desactivar(Id);
        }


    }
}
