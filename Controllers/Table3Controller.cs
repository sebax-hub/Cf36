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
    public class Table3Controller : Controller
    {
        private readonly MydbContext _context;

        public Table3Controller(MydbContext context)
        {
            _context = context;
        }

        // GET: Table3
        public async Task<IActionResult> Index()
        {
            return View(await _context.Table3s.ToListAsync());
        }

        // GET: Table3/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var table3 = await _context.Table3s
                .FirstOrDefaultAsync(m => m.Id == id);
            if (table3 == null)
            {
                return NotFound();
            }

            return View(table3);
        }

        // GET: Table3/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Table3/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Marca,Talla,Color")] Table3 table3)
        {
            if (ModelState.IsValid)
            {
                _context.Add(table3);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(table3);
        }

        // GET: Table3/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var table3 = await _context.Table3s.FindAsync(id);
            if (table3 == null)
            {
                return NotFound();
            }
            return View(table3);
        }

        // POST: Table3/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Marca,Talla,Color")] Table3 table3)
        {
            if (id != table3.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(table3);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Table3Exists(table3.Id))
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
            return View(table3);
        }

        // GET: Table3/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var table3 = await _context.Table3s
                .FirstOrDefaultAsync(m => m.Id == id);
            if (table3 == null)
            {
                return NotFound();
            }

            return View(table3);
        }

        // POST: Table3/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var table3 = await _context.Table3s.FindAsync(id);
            if (table3 != null)
            {
                _context.Table3s.Remove(table3);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Table3Exists(int id)
        {
            return _context.Table3s.Any(e => e.Id == id);
        }
    }
}
