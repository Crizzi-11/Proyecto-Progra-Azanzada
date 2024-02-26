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
    public class PadecimientosController : Controller
    {
        private readonly ProyectoMascotasContext _context;

        public PadecimientosController(ProyectoMascotasContext context)
        {
            _context = context;
        }

        // GET: Padecimientos
        public async Task<IActionResult> Index()
        {
            var proyectoMascotasContext = _context.Padecimientos.Include(p => p.IdMascotaNavigation);
            return View(await proyectoMascotasContext.ToListAsync());
        }

        // GET: Padecimientos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var padecimiento = await _context.Padecimientos
                .Include(p => p.IdMascotaNavigation)
                .FirstOrDefaultAsync(m => m.IdPadecimiento == id);
            if (padecimiento == null)
            {
                return NotFound();
            }

            return View(padecimiento);
        }

        // GET: Padecimientos/Create
        public IActionResult Create()
        {
            ViewData["IdMascota"] = new SelectList(_context.Mascotas, "IdMascota", "Genero");
            return View();
        }

        // POST: Padecimientos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPadecimiento,IdMascota,Padecimiento1")] Padecimiento padecimiento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(padecimiento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdMascota"] = new SelectList(_context.Mascotas, "IdMascota", "Genero", padecimiento.IdMascota);
            return View(padecimiento);
        }

        // GET: Padecimientos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var padecimiento = await _context.Padecimientos.FindAsync(id);
            if (padecimiento == null)
            {
                return NotFound();
            }
            ViewData["IdMascota"] = new SelectList(_context.Mascotas, "IdMascota", "Genero", padecimiento.IdMascota);
            return View(padecimiento);
        }

        // POST: Padecimientos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPadecimiento,IdMascota,Padecimiento1")] Padecimiento padecimiento)
        {
            if (id != padecimiento.IdPadecimiento)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(padecimiento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PadecimientoExists(padecimiento.IdPadecimiento))
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
            ViewData["IdMascota"] = new SelectList(_context.Mascotas, "IdMascota", "Genero", padecimiento.IdMascota);
            return View(padecimiento);
        }

        // GET: Padecimientos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var padecimiento = await _context.Padecimientos
                .Include(p => p.IdMascotaNavigation)
                .FirstOrDefaultAsync(m => m.IdPadecimiento == id);
            if (padecimiento == null)
            {
                return NotFound();
            }

            return View(padecimiento);
        }

        // POST: Padecimientos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var padecimiento = await _context.Padecimientos.FindAsync(id);
            if (padecimiento != null)
            {
                _context.Padecimientos.Remove(padecimiento);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PadecimientoExists(int id)
        {
            return _context.Padecimientos.Any(e => e.IdPadecimiento == id);
        }
    }
}
