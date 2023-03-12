using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Lab1.Models;

namespace Lab1.Controllers
{
    public class EmpleadoHabilidadsController : Controller
    {
        private readonly Laboratorio1Context _context;

        public EmpleadoHabilidadsController(Laboratorio1Context context)
        {
            _context = context;
        }

        // GET: EmpleadoHabilidads
        public async Task<IActionResult> Index()
        {
            var laboratorio1Context = _context.EmpleadoHabilidads.Include(e => e.IdEmpleadoNavigation);
            return View(await laboratorio1Context.ToListAsync());
        }

        // GET: EmpleadoHabilidads/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.EmpleadoHabilidads == null)
            {
                return NotFound();
            }

            var empleadoHabilidad = await _context.EmpleadoHabilidads
                .Include(e => e.IdEmpleadoNavigation)
                .FirstOrDefaultAsync(m => m.IdHabilidad == id);
            if (empleadoHabilidad == null)
            {
                return NotFound();
            }

            return View(empleadoHabilidad);
        }

        // GET: EmpleadoHabilidads/Create
        public IActionResult Create()
        {
            ViewData["IdEmpleado"] = new SelectList(_context.Empleados, "IdEmpleado", "IdEmpleado");
            return View();
        }

        // POST: EmpleadoHabilidads/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdHabilidad,IdEmpleado,NombreHabilidad")] EmpleadoHabilidad empleadoHabilidad)
        {
            if (ModelState.IsValid)
            {
                _context.Add(empleadoHabilidad);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdEmpleado"] = new SelectList(_context.Empleados, "IdEmpleado", "IdEmpleado", empleadoHabilidad.IdEmpleado);
            return View(empleadoHabilidad);
        }

        // GET: EmpleadoHabilidads/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.EmpleadoHabilidads == null)
            {
                return NotFound();
            }

            var empleadoHabilidad = await _context.EmpleadoHabilidads.FindAsync(id);
            if (empleadoHabilidad == null)
            {
                return NotFound();
            }
            ViewData["IdEmpleado"] = new SelectList(_context.Empleados, "IdEmpleado", "IdEmpleado", empleadoHabilidad.IdEmpleado);
            return View(empleadoHabilidad);
        }

        // POST: EmpleadoHabilidads/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdHabilidad,IdEmpleado,NombreHabilidad")] EmpleadoHabilidad empleadoHabilidad)
        {
            if (id != empleadoHabilidad.IdHabilidad)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(empleadoHabilidad);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmpleadoHabilidadExists(empleadoHabilidad.IdHabilidad))
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
            ViewData["IdEmpleado"] = new SelectList(_context.Empleados, "IdEmpleado", "IdEmpleado", empleadoHabilidad.IdEmpleado);
            return View(empleadoHabilidad);
        }

        // GET: EmpleadoHabilidads/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.EmpleadoHabilidads == null)
            {
                return NotFound();
            }

            var empleadoHabilidad = await _context.EmpleadoHabilidads
                .Include(e => e.IdEmpleadoNavigation)
                .FirstOrDefaultAsync(m => m.IdHabilidad == id);
            if (empleadoHabilidad == null)
            {
                return NotFound();
            }

            return View(empleadoHabilidad);
        }

        // POST: EmpleadoHabilidads/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.EmpleadoHabilidads == null)
            {
                return Problem("Entity set 'Laboratorio1Context.EmpleadoHabilidads'  is null.");
            }
            var empleadoHabilidad = await _context.EmpleadoHabilidads.FindAsync(id);
            if (empleadoHabilidad != null)
            {
                _context.EmpleadoHabilidads.Remove(empleadoHabilidad);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmpleadoHabilidadExists(int id)
        {
          return _context.EmpleadoHabilidads.Any(e => e.IdHabilidad == id);
        }
    }
}
