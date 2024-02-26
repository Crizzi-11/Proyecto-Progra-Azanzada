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
    public class VeterinariosSController : Controller
    {
        private readonly ProyectoMascotasContext _context;

        public VeterinariosSController(ProyectoMascotasContext context)
        {
            _context = context;
        }

        // GET: VeterinariosS
        public async Task<IActionResult> Index()
        {
            return View(await _context.Veterinarios.ToListAsync());
        }

        // GET: VeterinariosS/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var veterinarioS = await _context.Veterinarios
                .FirstOrDefaultAsync(m => m.IdVeterinarioS == id);
            if (veterinarioS == null)
            {
                return NotFound();
            }

            return View(veterinarioS);
        }

        // GET: VeterinariosS/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: VeterinariosS/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdVeterinarioS,NombreVet,PrimApellido,SegApellido,Telefono,Correo")] VeterinarioS veterinarioS)
        {
            if (ModelState.IsValid)
            {
                _context.Add(veterinarioS);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(veterinarioS);
        }

        // GET: VeterinariosS/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var veterinarioS = await _context.Veterinarios.FindAsync(id);
            if (veterinarioS == null)
            {
                return NotFound();
            }
            return View(veterinarioS);
        }

        // POST: VeterinariosS/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdVeterinarioS,NombreVet,PrimApellido,SegApellido,Telefono,Correo")] VeterinarioS veterinarioS)
        {
            if (id != veterinarioS.IdVeterinarioS)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(veterinarioS);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VeterinarioSExists(veterinarioS.IdVeterinarioS))
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
            return View(veterinarioS);
        }

        // GET: VeterinariosS/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var veterinarioS = await _context.Veterinarios
                .FirstOrDefaultAsync(m => m.IdVeterinarioS == id);
            if (veterinarioS == null)
            {
                return NotFound();
            }

            return View(veterinarioS);
        }

        // POST: VeterinariosS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var veterinarioS = await _context.Veterinarios.FindAsync(id);
            if (veterinarioS != null)
            {
                _context.Veterinarios.Remove(veterinarioS);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VeterinarioSExists(int id)
        {
            return _context.Veterinarios.Any(e => e.IdVeterinarioS == id);
        }
    }
}
