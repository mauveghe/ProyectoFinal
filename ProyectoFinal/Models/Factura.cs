using System;
using System.Collections.Generic;

namespace ProyectoFinal.Models
{
    public partial class Factura
    {
        public Factura()
        {
            ProductoFacturas = new HashSet<ProductoFactura>();
        }

        public int Id { get; set; }
        public int IdCliente { get; set; }
        public DateTime Fecha { get; set; }
        public double MontoTotal { get; set; }
        public string Producto { get; set; } = null!;

        public virtual Cliente IdClienteNavigation { get; set; } = null!;
        public virtual ICollection<ProductoFactura> ProductoFacturas { get; set; }
    }
}
