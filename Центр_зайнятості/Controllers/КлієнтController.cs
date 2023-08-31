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
    public class КлієнтController : Controller
    {
        private readonly ЦентрЗайнятостіContext _context;

        public КлієнтController(ЦентрЗайнятостіContext context)
        {
            _context = context;
        }

        // GET: Клієнт
        public async Task<IActionResult> Index()
        {
            var центрЗайнятостіContext = _context.Клієнтs.Include(к => к.КодПідприємстваNavigation);
            return View(await центрЗайнятостіContext.ToListAsync());
        }

        // GET: Клієнт/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Клієнтs == null)
            {
                return NotFound();
            }

            var клієнт = await _context.Клієнтs
                .Include(к => к.КодПідприємстваNavigation)
                .FirstOrDefaultAsync(m => m.КодКлієнта == id);
            if (клієнт == null)
            {
                return NotFound();
            }

            return View(клієнт);
        }

        // GET: Клієнт/Create
        public IActionResult Create()
        {
            ViewData["КодПідприємства"] = new SelectList(_context.Підприємствоs, "КодПідприємства", "КодПідприємства");
            return View();
        }

        // POST: Клієнт/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("КодКлієнта,КодПідприємства,Імя,ФормаВласності,НомерТелефону,Email,Адреса,ДатаЗнайденоїРоботи")] Клієнт клієнт)
        {
            if (ModelState.IsValid)
            {
                _context.Add(клієнт);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["КодПідприємства"] = new SelectList(_context.Підприємствоs, "КодПідприємства", "КодПідприємства", клієнт.КодПідприємства);
            return View(клієнт);
        }

        // GET: Клієнт/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Клієнтs == null)
            {
                return NotFound();
            }

            var клієнт = await _context.Клієнтs.FindAsync(id);
            if (клієнт == null)
            {
                return NotFound();
            }
            ViewData["КодПідприємства"] = new SelectList(_context.Підприємствоs, "КодПідприємства", "КодПідприємства", клієнт.КодПідприємства);
            return View(клієнт);
        }

        // POST: Клієнт/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("КодКлієнта,КодПідприємства,Імя,ФормаВласності,НомерТелефону,Email,Адреса,ДатаЗнайденоїРоботи")] Клієнт клієнт)
        {
            if (id != клієнт.КодКлієнта)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(клієнт);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!КлієнтExists(клієнт.КодКлієнта))
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
            ViewData["КодПідприємства"] = new SelectList(_context.Підприємствоs, "КодПідприємства", "КодПідприємства", клієнт.КодПідприємства);
            return View(клієнт);
        }

        // GET: Клієнт/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Клієнтs == null)
            {
                return NotFound();
            }

            var клієнт = await _context.Клієнтs
                .Include(к => к.КодПідприємстваNavigation)
                .FirstOrDefaultAsync(m => m.КодКлієнта == id);
            if (клієнт == null)
            {
                return NotFound();
            }

            return View(клієнт);
        }

        // POST: Клієнт/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Клієнтs == null)
            {
                return Problem("Entity set 'ЦентрЗайнятостіContext.Клієнтs'  is null.");
            }
            var клієнт = await _context.Клієнтs.FindAsync(id);
            if (клієнт != null)
            {
                _context.Клієнтs.Remove(клієнт);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool КлієнтExists(int id)
        {
          return (_context.Клієнтs?.Any(e => e.КодКлієнта == id)).GetValueOrDefault();
        }
    }
}
