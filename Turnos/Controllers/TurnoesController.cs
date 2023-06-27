using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Turnos.Context;
using Turnos.Models;

namespace Turnos.Controllers
{
    public class TurnoesController : Controller
    {
        private readonly TurnosDbContext _context;

        public TurnoesController(TurnosDbContext context)
        {
            _context = context;
        }

        // GET: Turnoes
        public async Task<IActionResult> Index()
        {
              return _context.Turnos != null ? 
                          View(await _context.Turnos.ToListAsync()) :
                          Problem("Entity set 'TurnosDbContext.Turnos'  is null.");
        }

        // GET: Turnoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Turnos == null)
            {
                return NotFound();
            }

            var turno = await _context.Turnos
                .FirstOrDefaultAsync(m => m.IdTurno == id);
            if (turno == null)
            {
                return NotFound();
            }

            return View(turno);
        }

        // GET: Turnoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Turnoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdTurno,Fecha")] Turno turno)
        {
            if (ModelState.IsValid)
            {
                DateTime f = turno.Fecha;
                Console.WriteLine("Se crea un turno para esta fecha" + turno.Fecha);

                Turno? t = await _context.Turnos.Select(turno => turno).Where(t => t.Fecha == f).FirstOrDefaultAsync();
                if(t != null)
                {
                    return UnprocessableEntity();
                }
                _context.Add(turno);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(turno);
        }

        // GET: Turnoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Turnos == null)
            {
                return NotFound();
            }

            var turno = await _context.Turnos.FindAsync(id);
            if (turno == null)
            {
                return NotFound();
            }
            return View(turno);
        }

        // POST: Turnoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdTurno,Fecha")] Turno turno)
        {
            if (id != turno.IdTurno)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(turno);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TurnoExists(turno.IdTurno))
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
            return View(turno);
        }

        // GET: Turnoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Turnos == null)
            {
                return NotFound();
            }

            var turno = await _context.Turnos
                .FirstOrDefaultAsync(m => m.IdTurno == id);
            if (turno == null)
            {
                return NotFound();
            }

            return View(turno);
        }

        // POST: Turnoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Turnos == null)
            {
                return Problem("Entity set 'TurnosDbContext.Turnos'  is null.");
            }
            var turno = await _context.Turnos.FindAsync(id);
            if (turno != null)
            {
                _context.Turnos.Remove(turno);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TurnoExists(int id)
        {
          return (_context.Turnos?.Any(e => e.IdTurno == id)).GetValueOrDefault();
        }

    }
}
