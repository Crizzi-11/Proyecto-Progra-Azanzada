using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProyectoMascotas.DAL.Models;

namespace Proyecto_Programacion_Azanzada.Controllers
{
    public class TiposMascotasController : Controller
    {
        private readonly ProyectoMascotasContext _context;

        public TiposMascotasController(ProyectoMascotasContext context)
        {
            _context = context;
        }

        // GET: TiposMascotas
        public async Task<IActionResult> Index()
        {
            return View(await _context.TiposMascota.ToListAsync());
        }

        // GET: TiposMascotas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tiposMascota = await _context.TiposMascota
                .FirstOrDefaultAsync(m => m.IdTipoMascota == id);
            if (tiposMascota == null)
            {
                return NotFound();
            }

            return View(tiposMascota);
        }

        // GET: TiposMascotas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TiposMascotas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdTipoMascota,Tipo")] TiposMascota tiposMascota)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tiposMascota);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tiposMascota);
        }

        // GET: TiposMascotas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tiposMascota = await _context.TiposMascota.FindAsync(id);
            if (tiposMascota == null)
            {
                return NotFound();
            }
            return View(tiposMascota);
        }

        // POST: TiposMascotas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdTipoMascota,Tipo")] TiposMascota tiposMascota)
        {
            if (id != tiposMascota.IdTipoMascota)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tiposMascota);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TiposMascotaExists(tiposMascota.IdTipoMascota))
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
            return View(tiposMascota);
        }

        // GET: TiposMascotas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tiposMascota = await _context.TiposMascota
                .FirstOrDefaultAsync(m => m.IdTipoMascota == id);
            if (tiposMascota == null)
            {
                return NotFound();
            }

            return View(tiposMascota);
        }

        // POST: TiposMascotas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tiposMascota = await _context.TiposMascota.FindAsync(id);
            if (tiposMascota != null)
            {
                _context.TiposMascota.Remove(tiposMascota);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TiposMascotaExists(int id)
        {
            return _context.TiposMascota.Any(e => e.IdTipoMascota == id);
        }
    }
}
