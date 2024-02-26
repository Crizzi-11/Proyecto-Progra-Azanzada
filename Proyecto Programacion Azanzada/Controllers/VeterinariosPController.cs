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
    public class VeterinariosPController : Controller
    {
        private readonly ProyectoMascotasContext _context;

        public VeterinariosPController(ProyectoMascotasContext context)
        {
            _context = context;
        }

        // GET: VeterinariosP
        public async Task<IActionResult> Index()
        {
            return View(await _context.VeterinarioPs.ToListAsync());
        }

        // GET: VeterinariosP/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var veterinarioP = await _context.VeterinarioPs
                .FirstOrDefaultAsync(m => m.IdVeterinarioP == id);
            if (veterinarioP == null)
            {
                return NotFound();
            }

            return View(veterinarioP);
        }

        // GET: VeterinariosP/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: VeterinariosP/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdVeterinarioP,NombreVet,PrimApellido,SegApellido,Telefono,Correo")] VeterinarioP veterinarioP)
        {
            if (ModelState.IsValid)
            {
                _context.Add(veterinarioP);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(veterinarioP);
        }

        // GET: VeterinariosP/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var veterinarioP = await _context.VeterinarioPs.FindAsync(id);
            if (veterinarioP == null)
            {
                return NotFound();
            }
            return View(veterinarioP);
        }

        // POST: VeterinariosP/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdVeterinarioP,NombreVet,PrimApellido,SegApellido,Telefono,Correo")] VeterinarioP veterinarioP)
        {
            if (id != veterinarioP.IdVeterinarioP)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(veterinarioP);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VeterinarioPExists(veterinarioP.IdVeterinarioP))
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
            return View(veterinarioP);
        }

        // GET: VeterinariosP/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var veterinarioP = await _context.VeterinarioPs
                .FirstOrDefaultAsync(m => m.IdVeterinarioP == id);
            if (veterinarioP == null)
            {
                return NotFound();
            }

            return View(veterinarioP);
        }

        // POST: VeterinariosP/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var veterinarioP = await _context.VeterinarioPs.FindAsync(id);
            if (veterinarioP != null)
            {
                _context.VeterinarioPs.Remove(veterinarioP);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VeterinarioPExists(int id)
        {
            return _context.VeterinarioPs.Any(e => e.IdVeterinarioP == id);
        }
    }
}
