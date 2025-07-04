using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Cf36.Models;

namespace Cf36.Controllers
{
    public class Tabla2Controller : Controller
    {
        private readonly MydbContext _context;

        public Tabla2Controller(MydbContext context)
        {
            _context = context;
        }

        // GET: Tabla2
        public async Task<IActionResult> Index()
        {
            return View(await _context.Tabla2s.ToListAsync());
        }

        // GET: Tabla2/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tabla2 = await _context.Tabla2s
                .FirstOrDefaultAsync(m => m.IdTabla2 == id);
            if (tabla2 == null)
            {
                return NotFound();
            }

            return View(tabla2);
        }

        // GET: Tabla2/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tabla2/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdTabla2,Registrar,ListarTabla2,Editar")] Tabla2 tabla2)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tabla2);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tabla2);
        }

        // GET: Tabla2/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tabla2 = await _context.Tabla2s.FindAsync(id);
            if (tabla2 == null)
            {
                return NotFound();
            }
            return View(tabla2);
        }

        // POST: Tabla2/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdTabla2,Registrar,ListarTabla2,Editar")] Tabla2 tabla2)
        {
            if (id != tabla2.IdTabla2)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tabla2);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Tabla2Exists(tabla2.IdTabla2))
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
            return View(tabla2);
        }

        // GET: Tabla2/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tabla2 = await _context.Tabla2s
                .FirstOrDefaultAsync(m => m.IdTabla2 == id);
            if (tabla2 == null)
            {
                return NotFound();
            }

            return View(tabla2);
        }

        // POST: Tabla2/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tabla2 = await _context.Tabla2s.FindAsync(id);
            if (tabla2 != null)
            {
                _context.Tabla2s.Remove(tabla2);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Tabla2Exists(int id)
        {
            return _context.Tabla2s.Any(e => e.IdTabla2 == id);
        }
    }
}
