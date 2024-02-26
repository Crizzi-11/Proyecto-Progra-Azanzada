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
    public class CitasController : Controller
    {
        private readonly ProyectoMascotasContext _context;

        public CitasController(ProyectoMascotasContext context)
        {
            _context = context;
        }

        // GET: Citas
        public async Task<IActionResult> Index()
        {
            var proyectoMascotasContext = _context.Citas.Include(c => c.CodigoUsuarioNavigation).Include(c => c.IdMascotaNavigation).Include(c => c.IdVeterinarioPNavigation).Include(c => c.IdVeterinarioSNavigation);
            return View(await proyectoMascotasContext.ToListAsync());
        }

        // GET: Citas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cita = await _context.Citas
                .Include(c => c.CodigoUsuarioNavigation)
                .Include(c => c.IdMascotaNavigation)
                .Include(c => c.IdVeterinarioPNavigation)
                .Include(c => c.IdVeterinarioSNavigation)
                .FirstOrDefaultAsync(m => m.CitaId == id);
            if (cita == null)
            {
                return NotFound();
            }

            return View(cita);
        }

        // GET: Citas/Create
        public IActionResult Create()
        {
            ViewData["CodigoUsuario"] = new SelectList(_context.Duenos, "CodigoUsuario", "ListaCitas");
            ViewData["IdMascota"] = new SelectList(_context.Mascotas, "IdMascota", "Genero");
            ViewData["IdVeterinarioP"] = new SelectList(_context.VeterinarioPs, "IdVeterinarioP", "Correo");
            ViewData["IdVeterinarioS"] = new SelectList(_context.Veterinarios, "IdVeterinarioS", "Correo");
            return View();
        }

        // POST: Citas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CitaId,FechaHora,Detalle,Diagnostico,ListaMedicamentos,Estado,CodigoUsuario,IdMascota,IdVeterinarioP,IdVeterinarioS")] Cita cita)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cita);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CodigoUsuario"] = new SelectList(_context.Duenos, "CodigoUsuario", "ListaCitas", cita.CodigoUsuario);
            ViewData["IdMascota"] = new SelectList(_context.Mascotas, "IdMascota", "Genero", cita.IdMascota);
            ViewData["IdVeterinarioP"] = new SelectList(_context.VeterinarioPs, "IdVeterinarioP", "Correo", cita.IdVeterinarioP);
            ViewData["IdVeterinarioS"] = new SelectList(_context.Veterinarios, "IdVeterinarioS", "Correo", cita.IdVeterinarioS);
            return View(cita);
        }

        // GET: Citas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cita = await _context.Citas.FindAsync(id);
            if (cita == null)
            {
                return NotFound();
            }
            ViewData["CodigoUsuario"] = new SelectList(_context.Duenos, "CodigoUsuario", "ListaCitas", cita.CodigoUsuario);
            ViewData["IdMascota"] = new SelectList(_context.Mascotas, "IdMascota", "Genero", cita.IdMascota);
            ViewData["IdVeterinarioP"] = new SelectList(_context.VeterinarioPs, "IdVeterinarioP", "Correo", cita.IdVeterinarioP);
            ViewData["IdVeterinarioS"] = new SelectList(_context.Veterinarios, "IdVeterinarioS", "Correo", cita.IdVeterinarioS);
            return View(cita);
        }

        // POST: Citas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CitaId,FechaHora,Detalle,Diagnostico,ListaMedicamentos,Estado,CodigoUsuario,IdMascota,IdVeterinarioP,IdVeterinarioS")] Cita cita)
        {
            if (id != cita.CitaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cita);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CitaExists(cita.CitaId))
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
            ViewData["CodigoUsuario"] = new SelectList(_context.Duenos, "CodigoUsuario", "ListaCitas", cita.CodigoUsuario);
            ViewData["IdMascota"] = new SelectList(_context.Mascotas, "IdMascota", "Genero", cita.IdMascota);
            ViewData["IdVeterinarioP"] = new SelectList(_context.VeterinarioPs, "IdVeterinarioP", "Correo", cita.IdVeterinarioP);
            ViewData["IdVeterinarioS"] = new SelectList(_context.Veterinarios, "IdVeterinarioS", "Correo", cita.IdVeterinarioS);
            return View(cita);
        }

        // GET: Citas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cita = await _context.Citas
                .Include(c => c.CodigoUsuarioNavigation)
                .Include(c => c.IdMascotaNavigation)
                .Include(c => c.IdVeterinarioPNavigation)
                .Include(c => c.IdVeterinarioSNavigation)
                .FirstOrDefaultAsync(m => m.CitaId == id);
            if (cita == null)
            {
                return NotFound();
            }

            return View(cita);
        }

        // POST: Citas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cita = await _context.Citas.FindAsync(id);
            if (cita != null)
            {
                _context.Citas.Remove(cita);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CitaExists(int id)
        {
            return _context.Citas.Any(e => e.CitaId == id);
        }
    }
}
