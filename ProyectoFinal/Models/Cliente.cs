using System;
using System.Collections.Generic;

namespace ProyectoFinal.Models
{
    public partial class Cliente
    {
        public Cliente()
        {
            Facturas = new HashSet<Factura>();
            ProductoFacturas = new HashSet<ProductoFactura>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Cedula { get; set; } = null!;

        public virtual ICollection<Factura> Facturas { get; set; }
        public virtual ICollection<ProductoFactura> ProductoFacturas { get; set; }
    }
}
