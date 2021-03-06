﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComiqueriaLogic
{
    public class Comiqueria
    {
        private List<Producto> productos;
        private List<Venta> ventas;
        public Comiqueria()
        {
            productos = new List<Producto>();
            ventas = new List<Venta>();
        }
        public Producto this[Guid codigo]
        {
            get
            {
                Producto r = null;
                foreach (Producto producto in productos)
                {
                    if ((Guid)producto == codigo)
                    {
                        r = producto;
                    }
                }
                return r;
            }
        }
        /// <summary>
        /// verificara dos objetos para ver si son iguales
        /// </summary>
        /// <param name="comiqueria">Comiqueria con todos los productos</param>
        /// <param name="producto">producto a verificar </param>
        /// <returns>bool</returns>
        public static bool operator ==(Comiqueria comiqueria , Producto producto)
        {
            foreach (Producto p in comiqueria.productos)
            {
                if (p.Descripcion == producto.Descripcion)
                    return true;
            }
            return false;
        }
        /// <summary>
        /// verificara dos objetos para ver si son iguales
        /// </summary>
        /// <param name="comiqueria">Comiqueria con todos los productos</param>
        /// <param name="producto">producto a verificar </param>
        /// <returns>bool</returns>
        public static bool operator !=(Comiqueria comiqueria, Producto producto)
        {
            return !(comiqueria == producto);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="comiqueria"></param>
        /// <param name="producto"></param>
        /// <returns></returns>
        public static Comiqueria operator +(Comiqueria comiqueria, Producto producto)
        {
            if ( comiqueria != producto)
            {
                comiqueria.productos.Add(producto);
            }
            return comiqueria;
        }
        
        public void Vender(Producto producto,int  cantidad)
        {
            Venta v = new Venta(producto, cantidad);
            ventas.Add(v);

        }
        public void Vender(Producto producto)
        {
            Vender(producto, 1);
        }

        public string ListarVentas()
        {
            StringBuilder cadena = new StringBuilder();
            ventas = ventas.OrderBy(ventas => ventas.Fecha).ToList();
            foreach (Venta v in ventas)
            {
                cadena.AppendFormat(v.ObtenerDescripcionBreve());
            }
            return cadena.ToString();
        }

        public Dictionary<Guid, string> ListarProductos()
        {
            Dictionary<Guid, string> dProductos = new Dictionary<Guid, string>();
            foreach (Producto producto in productos)
            {
                dProductos.Add((Guid)producto, producto.Descripcion);
            }

            return dProductos;
        }

    }
}
