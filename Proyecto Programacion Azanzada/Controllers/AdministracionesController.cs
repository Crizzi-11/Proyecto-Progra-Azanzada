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
    public class AdministracionesController : Controller
    {
        private readonly ProyectoMascotasContext _context;

        public AdministracionesController(ProyectoMascotasContext context)
        {
            _context = context;
        }

        // GET: Administraciones
        public async Task<IActionResult> Index()
        {
            return View(await _context.Administracions.ToListAsync());
        }

        // GET: Administraciones/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var administracion = await _context.Administracions
                .FirstOrDefaultAsync(m => m.IdAdm == id);
            if (administracion == null)
            {
                return NotFound();
            }

            return View(administracion);
        }

        // GET: Administraciones/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Administraciones/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdAdm,NombreAdm,Contrasena,Rol,ImagenUsuario,UltimaConexion,EstadoUsuario")] Administracion administracion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(administracion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(administracion);
        }

        // GET: Administraciones/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var administracion = await _context.Administracions.FindAsync(id);
            if (administracion == null)
            {
                return NotFound();
            }
            return View(administracion);
        }

        // POST: Administraciones/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdAdm,NombreAdm,Contrasena,Rol,ImagenUsuario,UltimaConexion,EstadoUsuario")] Administracion administracion)
        {
            if (id != administracion.IdAdm)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(administracion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AdministracionExists(administracion.IdAdm))
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
            return View(administracion);
        }

        // GET: Administraciones/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var administracion = await _context.Administracions
                .FirstOrDefaultAsync(m => m.IdAdm == id);
            if (administracion == null)
            {
                return NotFound();
            }

            return View(administracion);
        }

        // POST: Administraciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var administracion = await _context.Administracions.FindAsync(id);
            if (administracion != null)
            {
                _context.Administracions.Remove(administracion);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AdministracionExists(int id)
        {
            return _context.Administracions.Any(e => e.IdAdm == id);
        }
    }
}
