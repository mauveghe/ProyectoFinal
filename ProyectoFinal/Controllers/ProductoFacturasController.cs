using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProyectoFinal.Models;

namespace ProyectoFinal.Controllers
{
    [Authorize]
    public class ProductoFacturasController : Controller
    {
        private readonly DBPagina2Context _context;

        public ProductoFacturasController(DBPagina2Context context)
        {
            _context = context;
        }

        // GET: ProductoFacturas
        public async Task<IActionResult> Index()
        {
            var dBPagina2Context = _context.ProductoFacturas.Include(p => p.IdClienteNavigation).Include(p => p.IdFacturaNavigation).Include(p => p.IdProductoNavigation).Include(p => p.IdClienteNavigation);
            return View(await dBPagina2Context.ToListAsync());
        }

        // GET: ProductoFacturas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ProductoFacturas == null)
            {
                return NotFound();
            }

            var productoFactura = await _context.ProductoFacturas
                .Include(p => p.IdClienteNavigation)
                .Include(p => p.IdFacturaNavigation)
                .Include(p => p.IdProductoNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (productoFactura == null)
            {
                return NotFound();
            }

            return View(productoFactura);
        }

        // GET: ProductoFacturas/Create
        public IActionResult Create()
        {
            ViewData["IdCliente"] = new SelectList(_context.Clientes, "Id", "Id");
            ViewData["IdFactura"] = new SelectList(_context.Facturas, "Id", "Id");
            ViewData["IdProducto"] = new SelectList(_context.Productos, "Id", "Id");
            return View();
        }

        // POST: ProductoFacturas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdProducto,IdFactura,IdCliente")] ProductoFactura productoFactura)
        {
            if (ModelState.IsValid)
            {
                _context.Add(productoFactura);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCliente"] = new SelectList(_context.Clientes, "Id", "Id", productoFactura.IdCliente);
            ViewData["IdFactura"] = new SelectList(_context.Facturas, "Id", "Id", productoFactura.IdFactura);
            ViewData["IdProducto"] = new SelectList(_context.Productos, "Id", "Id", productoFactura.IdProducto);
            return View(productoFactura);
        }

        // GET: ProductoFacturas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ProductoFacturas == null)
            {
                return NotFound();
            }

            var productoFactura = await _context.ProductoFacturas.FindAsync(id);
            if (productoFactura == null)
            {
                return NotFound();
            }
            ViewData["IdCliente"] = new SelectList(_context.Clientes, "Id", "Id", productoFactura.IdCliente);
            ViewData["IdFactura"] = new SelectList(_context.Facturas, "Id", "Id", productoFactura.IdFactura);
            ViewData["IdProducto"] = new SelectList(_context.Productos, "Id", "Id", productoFactura.IdProducto);
            return View(productoFactura);
        }

        // POST: ProductoFacturas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdProducto,IdFactura,IdCliente")] ProductoFactura productoFactura)
        {
            if (id != productoFactura.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(productoFactura);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductoFacturaExists(productoFactura.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCliente"] = new SelectList(_context.Clientes, "Id", "Id", productoFactura.IdCliente);
            ViewData["IdFactura"] = new SelectList(_context.Facturas, "Id", "Id", productoFactura.IdFactura);
            ViewData["IdProducto"] = new SelectList(_context.Productos, "Id", "Id", productoFactura.IdProducto);
            return View(productoFactura);
        }

        // GET: ProductoFacturas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ProductoFacturas == null)
            {
                return NotFound();
            }

            var productoFactura = await _context.ProductoFacturas
                .Include(p => p.IdClienteNavigation)
                .Include(p => p.IdFacturaNavigation)
                .Include(p => p.IdProductoNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (productoFactura == null)
            {
                return NotFound();
            }

            return View(productoFactura);
        }

        // POST: ProductoFacturas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ProductoFacturas == null)
            {
                return Problem("Entity set 'DBPagina2Context.ProductoFacturas'  is null.");
            }
            var productoFactura = await _context.ProductoFacturas.FindAsync(id);
            if (productoFactura != null)
            {
                _context.ProductoFacturas.Remove(productoFactura);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductoFacturaExists(int id)
        {
          return _context.ProductoFacturas.Any(e => e.Id == id);
        }
    }
}
