using System;
using System.Collections.Generic;

namespace ProyectoFinal.Models
{
    public partial class ProductoFactura
    {
        public int Id { get; set; }
        public int IdProducto { get; set; }
        public int IdFactura { get; set; }
        public int IdCliente { get; set; }

        public virtual Cliente IdClienteNavigation { get; set; } = null!;
        public virtual Factura IdFacturaNavigation { get; set; } = null!;
        public virtual Producto IdProductoNavigation { get; set; } = null!;
    }
}
