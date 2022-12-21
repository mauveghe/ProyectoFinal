using System;
using System.Collections.Generic;

namespace ProyectoFinal.Models
{
    public partial class Producto
    {
        public Producto()
        {
            ProductoFacturas = new HashSet<ProductoFactura>();
        }

        public int Id { get; set; }
        public string NomProducto { get; set; } = null!;
        public string? Descripcion { get; set; }
        public double Precio { get; set; }
        public string? Imagen { get; set; }

        public virtual ICollection<ProductoFactura> ProductoFacturas { get; set; }
    }
}
