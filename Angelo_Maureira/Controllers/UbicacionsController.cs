using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Angelo_Maureira.Data;
using Angelo_Maureira.Models;

namespace Angelo_Maureira.Controllers
{
    public class UbicacionsController : Controller
    {
        private readonly ComercialSantaClaraContext _context;

        public UbicacionsController(ComercialSantaClaraContext context)
        {
            _context = context;
        }

        // GET: Ubicacions
        public async Task<IActionResult> Index()
        {
              return _context.Ubicaciones != null ? 
                          View(await _context.Ubicaciones.ToListAsync()) :
                          Problem("Entity set 'ComercialSantaClaraContext.Ubicaciones'  is null.");
        }

        // GET: Ubicacions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Ubicaciones == null)
            {
                return NotFound();
            }

            var ubicacion = await _context.Ubicaciones
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ubicacion == null)
            {
                return NotFound();
            }

            return View(ubicacion);
        }

        // GET: Ubicacions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Ubicacions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre")] Ubicacion ubicacion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ubicacion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ubicacion);
        }

        // GET: Ubicacions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Ubicaciones == null)
            {
                return NotFound();
            }

            var ubicacion = await _context.Ubicaciones.FindAsync(id);
            if (ubicacion == null)
            {
                return NotFound();
            }
            return View(ubicacion);
        }

        // POST: Ubicacions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre")] Ubicacion ubicacion)
        {
            if (id != ubicacion.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ubicacion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UbicacionExists(ubicacion.Id))
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
            return View(ubicacion);
        }

        // GET: Ubicacions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Ubicaciones == null)
            {
                return NotFound();
            }

            var ubicacion = await _context.Ubicaciones
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ubicacion == null)
            {
                return NotFound();
            }

            return View(ubicacion);
        }

        // POST: Ubicacions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Ubicaciones == null)
            {
                return Problem("Entity set 'ComercialSantaClaraContext.Ubicaciones'  is null.");
            }
            var ubicacion = await _context.Ubicaciones.FindAsync(id);
            if (ubicacion != null)
            {
                _context.Ubicaciones.Remove(ubicacion);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UbicacionExists(int id)
        {
          return (_context.Ubicaciones?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
