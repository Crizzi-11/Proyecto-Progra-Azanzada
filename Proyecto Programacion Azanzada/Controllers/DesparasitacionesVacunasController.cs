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
    public class DesparasitacionesVacunasController : Controller
    {
        private readonly ProyectoMascotasContext _context;

        public DesparasitacionesVacunasController(ProyectoMascotasContext context)
        {
            _context = context;
        }

        // GET: DesparasitacionesVacunas
        public async Task<IActionResult> Index()
        {
            var proyectoMascotasContext = _context.DesparasitacionesVacunas.Include(d => d.IdMascotaNavigation);
            return View(await proyectoMascotasContext.ToListAsync());
        }

        // GET: DesparasitacionesVacunas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var desparasitacionesVacuna = await _context.DesparasitacionesVacunas
                .Include(d => d.IdMascotaNavigation)
                .FirstOrDefaultAsync(m => m.IdDesparacitacion == id);
            if (desparasitacionesVacuna == null)
            {
                return NotFound();
            }

            return View(desparasitacionesVacuna);
        }

        // GET: DesparasitacionesVacunas/Create
        public IActionResult Create()
        {
            ViewData["IdMascota"] = new SelectList(_context.Mascotas, "IdMascota", "Genero");
            return View();
        }

        // POST: DesparasitacionesVacunas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdDesparacitacion,IdMascota,Tipo,Fecha,Producto")] DesparasitacionesVacuna desparasitacionesVacuna)
        {
            if (ModelState.IsValid)
            {
                _context.Add(desparasitacionesVacuna);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdMascota"] = new SelectList(_context.Mascotas, "IdMascota", "Genero", desparasitacionesVacuna.IdMascota);
            return View(desparasitacionesVacuna);
        }

        // GET: DesparasitacionesVacunas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var desparasitacionesVacuna = await _context.DesparasitacionesVacunas.FindAsync(id);
            if (desparasitacionesVacuna == null)
            {
                return NotFound();
            }
            ViewData["IdMascota"] = new SelectList(_context.Mascotas, "IdMascota", "Genero", desparasitacionesVacuna.IdMascota);
            return View(desparasitacionesVacuna);
        }

        // POST: DesparasitacionesVacunas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdDesparacitacion,IdMascota,Tipo,Fecha,Producto")] DesparasitacionesVacuna desparasitacionesVacuna)
        {
            if (id != desparasitacionesVacuna.IdDesparacitacion)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(desparasitacionesVacuna);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DesparasitacionesVacunaExists(desparasitacionesVacuna.IdDesparacitacion))
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
            ViewData["IdMascota"] = new SelectList(_context.Mascotas, "IdMascota", "Genero", desparasitacionesVacuna.IdMascota);
            return View(desparasitacionesVacuna);
        }

        // GET: DesparasitacionesVacunas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var desparasitacionesVacuna = await _context.DesparasitacionesVacunas
                .Include(d => d.IdMascotaNavigation)
                .FirstOrDefaultAsync(m => m.IdDesparacitacion == id);
            if (desparasitacionesVacuna == null)
            {
                return NotFound();
            }

            return View(desparasitacionesVacuna);
        }

        // POST: DesparasitacionesVacunas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var desparasitacionesVacuna = await _context.DesparasitacionesVacunas.FindAsync(id);
            if (desparasitacionesVacuna != null)
            {
                _context.DesparasitacionesVacunas.Remove(desparasitacionesVacuna);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DesparasitacionesVacunaExists(int id)
        {
            return _context.DesparasitacionesVacunas.Any(e => e.IdDesparacitacion == id);
        }
    }
}
