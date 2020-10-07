using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Practica1.Data;
using Practica1.Models;
using System.Linq;
using System.Threading.Tasks;

namespace Practica1.Controllers
{
    public class CancionsController : Controller
    {
        private readonly Practica1Context _context;

        public CancionsController(Practica1Context context)
        {
            _context = context;
        }

        // GET: Cancions
        public async Task<IActionResult> Index()
        {
            var practica1Context = _context.Cancion.Include(c => c.Album).Include(c => c.Genero);
            return View(await practica1Context.ToListAsync());
        }

        // GET: Cancions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cancion = await _context.Cancion
                .Include(c => c.Album)
                .Include(c => c.Genero)
                .FirstOrDefaultAsync(m => m.CancionId == id);
            if (cancion == null)
            {
                return NotFound();
            }

            return View(cancion);
        }

        // GET: Cancions/Create
        public IActionResult Create()
        {
            ViewData["AlbumId"] = new SelectList(_context.Album, "AlbumId", "AlbumId");
            ViewData["GeneroId"] = new SelectList(_context.Set<Genero>(), "GeneroId", "GeneroId");
            return View();
        }

        // POST: Cancions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CancionId,Nombre,AlbumId,GeneroId")] Cancion cancion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cancion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AlbumId"] = new SelectList(_context.Album, "AlbumId", "AlbumId", cancion.AlbumId);
            ViewData["GeneroId"] = new SelectList(_context.Set<Genero>(), "GeneroId", "GeneroId", cancion.GeneroId);
            return View(cancion);
        }

        // GET: Cancions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cancion = await _context.Cancion.FindAsync(id);
            if (cancion == null)
            {
                return NotFound();
            }
            ViewData["AlbumId"] = new SelectList(_context.Album, "AlbumId", "AlbumId", cancion.AlbumId);
            ViewData["GeneroId"] = new SelectList(_context.Set<Genero>(), "GeneroId", "GeneroId", cancion.GeneroId);
            return View(cancion);
        }

        // POST: Cancions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CancionId,Nombre,AlbumId,GeneroId")] Cancion cancion)
        {
            if (id != cancion.CancionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cancion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CancionExists(cancion.CancionId))
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
            ViewData["AlbumId"] = new SelectList(_context.Album, "AlbumId", "AlbumId", cancion.AlbumId);
            ViewData["GeneroId"] = new SelectList(_context.Set<Genero>(), "GeneroId", "GeneroId", cancion.GeneroId);
            return View(cancion);
        }

        // GET: Cancions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cancion = await _context.Cancion
                .Include(c => c.Album)
                .Include(c => c.Genero)
                .FirstOrDefaultAsync(m => m.CancionId == id);
            if (cancion == null)
            {
                return NotFound();
            }

            return View(cancion);
        }

        // POST: Cancions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cancion = await _context.Cancion.FindAsync(id);
            _context.Cancion.Remove(cancion);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CancionExists(int id)
        {
            return _context.Cancion.Any(e => e.CancionId == id);
        }
    }
}
