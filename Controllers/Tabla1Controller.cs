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
    public class Tabla1Controller : Controller
    {
        private readonly MydbContext _context;

        public Tabla1Controller(MydbContext context)
        {
            _context = context;
        }

        // GET: Tabla1
        public async Task<IActionResult> Index()
        {
            return View(await _context.Tabla1s.ToListAsync());
        }

        // GET: Tabla1/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tabla1 = await _context.Tabla1s
                .FirstOrDefaultAsync(m => m.Idtabla1 == id);
            if (tabla1 == null)
            {
                return NotFound();
            }

            return View(tabla1);
        }

        // GET: Tabla1/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tabla1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idtabla1,Regristrar,ListarTabla1,Editar")] Tabla1 tabla1)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tabla1);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tabla1);
        }

        // GET: Tabla1/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tabla1 = await _context.Tabla1s.FindAsync(id);
            if (tabla1 == null)
            {
                return NotFound();
            }
            return View(tabla1);
        }

        // POST: Tabla1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Idtabla1,Regristrar,ListarTabla1,Editar")] Tabla1 tabla1)
        {
            if (id != tabla1.Idtabla1)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tabla1);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Tabla1Exists(tabla1.Idtabla1))
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
            return View(tabla1);
        }

        // GET: Tabla1/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tabla1 = await _context.Tabla1s
                .FirstOrDefaultAsync(m => m.Idtabla1 == id);
            if (tabla1 == null)
            {
                return NotFound();
            }

            return View(tabla1);
        }

        // POST: Tabla1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tabla1 = await _context.Tabla1s.FindAsync(id);
            if (tabla1 != null)
            {
                _context.Tabla1s.Remove(tabla1);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Tabla1Exists(int id)
        {
            return _context.Tabla1s.Any(e => e.Idtabla1 == id);
        }
    }
}
