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
    public class TipoProductoesController : Controller
    {
        private readonly ComercialSantaClaraContext _context;

        public TipoProductoesController(ComercialSantaClaraContext context)
        {
            _context = context;
        }

        // GET: TipoProductoes
        public async Task<IActionResult> Index()
        {
              return _context.TiposProducto != null ? 
                          View(await _context.TiposProducto.ToListAsync()) :
                          Problem("Entity set 'ComercialSantaClaraContext.TiposProducto'  is null.");
        }

        // GET: TipoProductoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TiposProducto == null)
            {
                return NotFound();
            }

            var tipoProducto = await _context.TiposProducto
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipoProducto == null)
            {
                return NotFound();
            }

            return View(tipoProducto);
        }

        // GET: TipoProductoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoProductoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Descripcion,Estado")] TipoProducto tipoProducto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoProducto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoProducto);
        }

        // GET: TipoProductoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TiposProducto == null)
            {
                return NotFound();
            }

            var tipoProducto = await _context.TiposProducto.FindAsync(id);
            if (tipoProducto == null)
            {
                return NotFound();
            }
            return View(tipoProducto);
        }

        // POST: TipoProductoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Descripcion,Estado")] TipoProducto tipoProducto)
        {
            if (id != tipoProducto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoProducto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoProductoExists(tipoProducto.Id))
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
            return View(tipoProducto);
        }

        // GET: TipoProductoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TiposProducto == null)
            {
                return NotFound();
            }

            var tipoProducto = await _context.TiposProducto
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipoProducto == null)
            {
                return NotFound();
            }

            return View(tipoProducto);
        }

        // POST: TipoProductoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TiposProducto == null)
            {
                return Problem("Entity set 'ComercialSantaClaraContext.TiposProducto'  is null.");
            }
            var tipoProducto = await _context.TiposProducto.FindAsync(id);
            if (tipoProducto != null)
            {
                _context.TiposProducto.Remove(tipoProducto);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoProductoExists(int id)
        {
          return (_context.TiposProducto?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
