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
    public class NIngreso
    {
        public static DataTable Listar() 
        { 
            DIngreso Datos = new DIngreso();
            return Datos.Listar();
        }
        public static DataTable Buscar(string Valor)
        {
            DIngreso Datos = new DIngreso();
            return Datos.Buscar(Valor);
        }
        public static string Insertar(
            int IdProveedor, int IdUsuario, string TipoComprobante,
            string SerieComprobante, string NumComprobante,
            decimal Impuesto, decimal Total,DataTable Detalles
            )
        {
            DIngreso Datos = new DIngreso(); // Capa Datos
            Ingreso Objeto = new Ingreso(); // Capa Entidades
            Objeto.IdProveedor = IdProveedor;
            Objeto.IdUsuario = IdUsuario;
            Objeto.TipoComprobante = TipoComprobante;
            Objeto.SerieComprobante = SerieComprobante;
            Objeto.NumComprobante = NumComprobante;
            Objeto.Impuesto = Impuesto;
            Objeto.Total = Total;
            Objeto.Detalles = Detalles;
            return Datos.Insertar(Objeto);
        }
        public static string Anular(int IdIngreso)
        {
            DIngreso Datos = new DIngreso();
            return Datos.Anular(IdIngreso);
        }
    }
}
