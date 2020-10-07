using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Practica1.Data;
using Practica1.Models;
using System.Linq;
using System.Threading.Tasks;

namespace Practica1.Controllers
{
    public class DetalleFacturasController : Controller
    {
        private readonly Practica1Context _context;

        public DetalleFacturasController(Practica1Context context)
        {
            _context = context;
        }

        // GET: DetalleFacturas
        public async Task<IActionResult> Index()
        {
            var practica1Context = _context.DetalleFactura.Include(d => d.Cancion).Include(d => d.Factura);
            return View(await practica1Context.ToListAsync());
        }

        // GET: DetalleFacturas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detalleFactura = await _context.DetalleFactura
                .Include(d => d.Cancion)
                .Include(d => d.Factura)
                .FirstOrDefaultAsync(m => m.DetalleFacturaId == id);
            if (detalleFactura == null)
            {
                return NotFound();
            }

            return View(detalleFactura);
        }

        // GET: DetalleFacturas/Create
        public IActionResult Create()
        {
            ViewData["CancionId"] = new SelectList(_context.Cancion, "CancionId", "CancionId");
            ViewData["FacturaId"] = new SelectList(_context.Set<Factura>(), "FacturaId", "FacturaId");
            return View();
        }

        // POST: DetalleFacturas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DetalleFacturaId,FacturaId,CancionId,PrecioUnidad,Cantidad")] DetalleFactura detalleFactura)
        {
            if (ModelState.IsValid)
            {
                _context.Add(detalleFactura);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CancionId"] = new SelectList(_context.Cancion, "CancionId", "CancionId", detalleFactura.CancionId);
            ViewData["FacturaId"] = new SelectList(_context.Set<Factura>(), "FacturaId", "FacturaId", detalleFactura.FacturaId);
            return View(detalleFactura);
        }

        // GET: DetalleFacturas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detalleFactura = await _context.DetalleFactura.FindAsync(id);
            if (detalleFactura == null)
            {
                return NotFound();
            }
            ViewData["CancionId"] = new SelectList(_context.Cancion, "CancionId", "CancionId", detalleFactura.CancionId);
            ViewData["FacturaId"] = new SelectList(_context.Set<Factura>(), "FacturaId", "FacturaId", detalleFactura.FacturaId);
            return View(detalleFactura);
        }

        // POST: DetalleFacturas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DetalleFacturaId,FacturaId,CancionId,PrecioUnidad,Cantidad")] DetalleFactura detalleFactura)
        {
            if (id != detalleFactura.DetalleFacturaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(detalleFactura);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DetalleFacturaExists(detalleFactura.DetalleFacturaId))
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
            ViewData["CancionId"] = new SelectList(_context.Cancion, "CancionId", "CancionId", detalleFactura.CancionId);
            ViewData["FacturaId"] = new SelectList(_context.Set<Factura>(), "FacturaId", "FacturaId", detalleFactura.FacturaId);
            return View(detalleFactura);
        }

        // GET: DetalleFacturas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detalleFactura = await _context.DetalleFactura
                .Include(d => d.Cancion)
                .Include(d => d.Factura)
                .FirstOrDefaultAsync(m => m.DetalleFacturaId == id);
            if (detalleFactura == null)
            {
                return NotFound();
            }

            return View(detalleFactura);
        }

        // POST: DetalleFacturas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var detalleFactura = await _context.DetalleFactura.FindAsync(id);
            _context.DetalleFactura.Remove(detalleFactura);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DetalleFacturaExists(int id)
        {
            return _context.DetalleFactura.Any(e => e.DetalleFacturaId == id);
        }
    }
}
