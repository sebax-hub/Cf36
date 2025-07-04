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
    public class Table4Controller : Controller
    {
        private readonly MydbContext _context;

        public Table4Controller(MydbContext context)
        {
            _context = context;
        }

        // GET: Table4
        public async Task<IActionResult> Index()
        {
            return View(await _context.Table4s.ToListAsync());
        }

        // GET: Table4/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var table4 = await _context.Table4s
                .FirstOrDefaultAsync(m => m.Id == id);
            if (table4 == null)
            {
                return NotFound();
            }

            return View(table4);
        }

        // GET: Table4/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Table4/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Apellido,Correo")] Table4 table4)
        {
            if (ModelState.IsValid)
            {
                _context.Add(table4);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(table4);
        }

        // GET: Table4/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var table4 = await _context.Table4s.FindAsync(id);
            if (table4 == null)
            {
                return NotFound();
            }
            return View(table4);
        }

        // POST: Table4/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Apellido,Correo")] Table4 table4)
        {
            if (id != table4.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(table4);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Table4Exists(table4.Id))
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
            return View(table4);
        }

        // GET: Table4/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var table4 = await _context.Table4s
                .FirstOrDefaultAsync(m => m.Id == id);
            if (table4 == null)
            {
                return NotFound();
            }

            return View(table4);
        }

        // POST: Table4/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var table4 = await _context.Table4s.FindAsync(id);
            if (table4 != null)
            {
                _context.Table4s.Remove(table4);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Table4Exists(int id)
        {
            return _context.Table4s.Any(e => e.Id == id);
        }
    }
}
