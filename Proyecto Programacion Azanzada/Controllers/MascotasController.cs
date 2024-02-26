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
    public class MascotasController : Controller
    {
        private readonly ProyectoMascotasContext _context;

        public MascotasController(ProyectoMascotasContext context)
        {
            _context = context;
        }

        // GET: Mascotas
        public async Task<IActionResult> Index()
        {
            var proyectoMascotasContext = _context.Mascotas.Include(m => m.CodigoUsuarioNavigation).Include(m => m.IdRazaNavigation).Include(m => m.IdTipoMascotaNavigation);
            return View(await proyectoMascotasContext.ToListAsync());
        }

        // GET: Mascotas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mascota = await _context.Mascotas
                .Include(m => m.CodigoUsuarioNavigation)
                .Include(m => m.IdRazaNavigation)
                .Include(m => m.IdTipoMascotaNavigation)
                .FirstOrDefaultAsync(m => m.IdMascota == id);
            if (mascota == null)
            {
                return NotFound();
            }

            return View(mascota);
        }

        // GET: Mascotas/Create
        public IActionResult Create()
        {
            ViewData["CodigoUsuario"] = new SelectList(_context.Duenos, "CodigoUsuario", "ListaCitas");
            ViewData["IdRaza"] = new SelectList(_context.Razas, "IdRaza", "Raza1");
            ViewData["IdTipoMascota"] = new SelectList(_context.TiposMascota, "IdTipoMascota", "Tipo");
            return View();
        }

        // POST: Mascotas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdMascota,Nombre,IdTipoMascota,IdRaza,Genero,Edad,Peso,Imagen,CodigoUsuario,CodigoUsuarioCreacion,FechaCreacion,CodigoUsuarioModificacion,FechaModificacion")] Mascota mascota)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mascota);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CodigoUsuario"] = new SelectList(_context.Duenos, "CodigoUsuario", "ListaCitas", mascota.CodigoUsuario);
            ViewData["IdRaza"] = new SelectList(_context.Razas, "IdRaza", "Raza1", mascota.IdRaza);
            ViewData["IdTipoMascota"] = new SelectList(_context.TiposMascota, "IdTipoMascota", "Tipo", mascota.IdTipoMascota);
            return View(mascota);
        }

        // GET: Mascotas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mascota = await _context.Mascotas.FindAsync(id);
            if (mascota == null)
            {
                return NotFound();
            }
            ViewData["CodigoUsuario"] = new SelectList(_context.Duenos, "CodigoUsuario", "ListaCitas", mascota.CodigoUsuario);
            ViewData["IdRaza"] = new SelectList(_context.Razas, "IdRaza", "Raza1", mascota.IdRaza);
            ViewData["IdTipoMascota"] = new SelectList(_context.TiposMascota, "IdTipoMascota", "Tipo", mascota.IdTipoMascota);
            return View(mascota);
        }

        // POST: Mascotas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdMascota,Nombre,IdTipoMascota,IdRaza,Genero,Edad,Peso,Imagen,CodigoUsuario,CodigoUsuarioCreacion,FechaCreacion,CodigoUsuarioModificacion,FechaModificacion")] Mascota mascota)
        {
            if (id != mascota.IdMascota)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mascota);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MascotaExists(mascota.IdMascota))
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
            ViewData["CodigoUsuario"] = new SelectList(_context.Duenos, "CodigoUsuario", "ListaCitas", mascota.CodigoUsuario);
            ViewData["IdRaza"] = new SelectList(_context.Razas, "IdRaza", "Raza1", mascota.IdRaza);
            ViewData["IdTipoMascota"] = new SelectList(_context.TiposMascota, "IdTipoMascota", "Tipo", mascota.IdTipoMascota);
            return View(mascota);
        }

        // GET: Mascotas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mascota = await _context.Mascotas
                .Include(m => m.CodigoUsuarioNavigation)
                .Include(m => m.IdRazaNavigation)
                .Include(m => m.IdTipoMascotaNavigation)
                .FirstOrDefaultAsync(m => m.IdMascota == id);
            if (mascota == null)
            {
                return NotFound();
            }

            return View(mascota);
        }

        // POST: Mascotas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mascota = await _context.Mascotas.FindAsync(id);
            if (mascota != null)
            {
                _context.Mascotas.Remove(mascota);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MascotaExists(int id)
        {
            return _context.Mascotas.Any(e => e.IdMascota == id);
        }
    }
}
