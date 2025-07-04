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
    public class Table5Controller : Controller
    {
        private readonly MydbContext _context;

        public Table5Controller(MydbContext context)
        {
            _context = context;
        }

        // GET: Table5
        public async Task<IActionResult> Index()
        {
            return View(await _context.Table5s.ToListAsync());
        }

        // GET: Table5/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var table5 = await _context.Table5s
                .FirstOrDefaultAsync(m => m.Id == id);
            if (table5 == null)
            {
                return NotFound();
            }

            return View(table5);
        }

        // GET: Table5/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Table5/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Pais,Ciudad")] Table5 table5)
        {
            if (ModelState.IsValid)
            {
                _context.Add(table5);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(table5);
        }

        // GET: Table5/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var table5 = await _context.Table5s.FindAsync(id);
            if (table5 == null)
            {
                return NotFound();
            }
            return View(table5);
        }

        // POST: Table5/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Pais,Ciudad")] Table5 table5)
        {
            if (id != table5.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(table5);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Table5Exists(table5.Id))
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
            return View(table5);
        }

        // GET: Table5/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var table5 = await _context.Table5s
                .FirstOrDefaultAsync(m => m.Id == id);
            if (table5 == null)
            {
                return NotFound();
            }

            return View(table5);
        }

        // POST: Table5/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var table5 = await _context.Table5s.FindAsync(id);
            if (table5 != null)
            {
                _context.Table5s.Remove(table5);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Table5Exists(int id)
        {
            return _context.Table5s.Any(e => e.Id == id);
        }
    }
}
