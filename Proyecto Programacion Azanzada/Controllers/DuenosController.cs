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
    public class DuenosController : Controller
    {
        private readonly ProyectoMascotasContext _context;

        public DuenosController(ProyectoMascotasContext context)
        {
            _context = context;
        }

        // GET: Duenos
        public async Task<IActionResult> Index()
        {
            return View(await _context.Duenos.ToListAsync());
        }

        // GET: Duenos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dueno = await _context.Duenos
                .FirstOrDefaultAsync(m => m.CodigoUsuario == id);
            if (dueno == null)
            {
                return NotFound();
            }

            return View(dueno);
        }

        // GET: Duenos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Duenos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CodigoUsuario,NombreDueno,PrimApellido,SegApellido,Telefono,FechaCreacion,FechaModificacion,ListaCitas")] Dueno dueno)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dueno);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dueno);
        }

        // GET: Duenos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dueno = await _context.Duenos.FindAsync(id);
            if (dueno == null)
            {
                return NotFound();
            }
            return View(dueno);
        }

        // POST: Duenos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CodigoUsuario,NombreDueno,PrimApellido,SegApellido,Telefono,FechaCreacion,FechaModificacion,ListaCitas")] Dueno dueno)
        {
            if (id != dueno.CodigoUsuario)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dueno);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DuenoExists(dueno.CodigoUsuario))
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
            return View(dueno);
        }

        // GET: Duenos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dueno = await _context.Duenos
                .FirstOrDefaultAsync(m => m.CodigoUsuario == id);
            if (dueno == null)
            {
                return NotFound();
            }

            return View(dueno);
        }

        // POST: Duenos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dueno = await _context.Duenos.FindAsync(id);
            if (dueno != null)
            {
                _context.Duenos.Remove(dueno);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DuenoExists(int id)
        {
            return _context.Duenos.Any(e => e.CodigoUsuario == id);
        }
    }
}
