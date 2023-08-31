using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Центр_зайнятості.Models;

namespace Центр_зайнятості.Controllers
{
    public class ПідприємствоController : Controller
    {
        private readonly ЦентрЗайнятостіContext _context;

        public ПідприємствоController(ЦентрЗайнятостіContext context)
        {
            _context = context;
        }

        // GET: Підприємство
        public async Task<IActionResult> Index()
        {
              return _context.Підприємствоs != null ? 
                          View(await _context.Підприємствоs.ToListAsync()) :
                          Problem("Entity set 'ЦентрЗайнятостіContext.Підприємствоs'  is null.");
        }

        // GET: Підприємство/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Підприємствоs == null)
            {
                return NotFound();
            }

            var підприємство = await _context.Підприємствоs
                .FirstOrDefaultAsync(m => m.КодПідприємства == id);
            if (підприємство == null)
            {
                return NotFound();
            }

            return View(підприємство);
        }

        // GET: Підприємство/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Підприємство/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("КодПідприємства,Назва,РозташуванняОфісу,ПредставникПіб")] Підприємство підприємство)
        {
            if (ModelState.IsValid)
            {
                _context.Add(підприємство);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(підприємство);
        }

        // GET: Підприємство/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Підприємствоs == null)
            {
                return NotFound();
            }

            var підприємство = await _context.Підприємствоs.FindAsync(id);
            if (підприємство == null)
            {
                return NotFound();
            }
            return View(підприємство);
        }

        // POST: Підприємство/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("КодПідприємства,Назва,РозташуванняОфісу,ПредставникПіб")] Підприємство підприємство)
        {
            if (id != підприємство.КодПідприємства)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(підприємство);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ПідприємствоExists(підприємство.КодПідприємства))
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
            return View(підприємство);
        }

        // GET: Підприємство/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Підприємствоs == null)
            {
                return NotFound();
            }

            var підприємство = await _context.Підприємствоs
                .FirstOrDefaultAsync(m => m.КодПідприємства == id);
            if (підприємство == null)
            {
                return NotFound();
            }

            return View(підприємство);
        }

        // POST: Підприємство/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Підприємствоs == null)
            {
                return Problem("Entity set 'ЦентрЗайнятостіContext.Підприємствоs'  is null.");
            }
            var підприємство = await _context.Підприємствоs.FindAsync(id);
            if (підприємство != null)
            {
                _context.Підприємствоs.Remove(підприємство);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ПідприємствоExists(int id)
        {
          return (_context.Підприємствоs?.Any(e => e.КодПідприємства == id)).GetValueOrDefault();
        }
    }
}
