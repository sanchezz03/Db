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
    public class ПерелікВакансійController : Controller
    {
        private readonly ЦентрЗайнятостіContext _context;

        public ПерелікВакансійController(ЦентрЗайнятостіContext context)
        {
            _context = context;
        }

        // GET: ПерелікВакансій
        public async Task<IActionResult> Index()
        {
            var центрЗайнятостіContext = _context.ПерелікВакансійs.Include(п => п.КодВакансіїNavigation).Include(п => п.КодПідприємстваNavigation);
            return View(await центрЗайнятостіContext.ToListAsync());
        }

        // GET: ПерелікВакансій/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ПерелікВакансійs == null)
            {
                return NotFound();
            }

            var перелікВакансій = await _context.ПерелікВакансійs
                .Include(п => п.КодВакансіїNavigation)
                .Include(п => п.КодПідприємстваNavigation)
                .FirstOrDefaultAsync(m => m.КодЗапису == id);
            if (перелікВакансій == null)
            {
                return NotFound();
            }

            return View(перелікВакансій);
        }

        // GET: ПерелікВакансій/Create
        public IActionResult Create()
        {
            ViewData["КодВакансії"] = new SelectList(_context.Вакансіяs, "КодВакансії", "КодВакансії");
            ViewData["КодПідприємства"] = new SelectList(_context.Підприємствоs, "КодПідприємства", "КодПідприємства");
            return View();
        }

        // POST: ПерелікВакансій/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("КодЗапису,КодПідприємства,КодВакансії")] ПерелікВакансій перелікВакансій)
        {
            if (ModelState.IsValid)
            {
                _context.Add(перелікВакансій);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["КодВакансії"] = new SelectList(_context.Вакансіяs, "КодВакансії", "КодВакансії", перелікВакансій.КодВакансії);
            ViewData["КодПідприємства"] = new SelectList(_context.Підприємствоs, "КодПідприємства", "КодПідприємства", перелікВакансій.КодПідприємства);
            return View(перелікВакансій);
        }

        // GET: ПерелікВакансій/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ПерелікВакансійs == null)
            {
                return NotFound();
            }

            var перелікВакансій = await _context.ПерелікВакансійs.FindAsync(id);
            if (перелікВакансій == null)
            {
                return NotFound();
            }
            ViewData["КодВакансії"] = new SelectList(_context.Вакансіяs, "КодВакансії", "КодВакансії", перелікВакансій.КодВакансії);
            ViewData["КодПідприємства"] = new SelectList(_context.Підприємствоs, "КодПідприємства", "КодПідприємства", перелікВакансій.КодПідприємства);
            return View(перелікВакансій);
        }

        // POST: ПерелікВакансій/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("КодЗапису,КодПідприємства,КодВакансії")] ПерелікВакансій перелікВакансій)
        {
            if (id != перелікВакансій.КодЗапису)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(перелікВакансій);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ПерелікВакансійExists(перелікВакансій.КодЗапису))
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
            ViewData["КодВакансії"] = new SelectList(_context.Вакансіяs, "КодВакансії", "КодВакансії", перелікВакансій.КодВакансії);
            ViewData["КодПідприємства"] = new SelectList(_context.Підприємствоs, "КодПідприємства", "КодПідприємства", перелікВакансій.КодПідприємства);
            return View(перелікВакансій);
        }

        // GET: ПерелікВакансій/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ПерелікВакансійs == null)
            {
                return NotFound();
            }

            var перелікВакансій = await _context.ПерелікВакансійs
                .Include(п => п.КодВакансіїNavigation)
                .Include(п => п.КодПідприємстваNavigation)
                .FirstOrDefaultAsync(m => m.КодЗапису == id);
            if (перелікВакансій == null)
            {
                return NotFound();
            }

            return View(перелікВакансій);
        }

        // POST: ПерелікВакансій/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ПерелікВакансійs == null)
            {
                return Problem("Entity set 'ЦентрЗайнятостіContext.ПерелікВакансійs'  is null.");
            }
            var перелікВакансій = await _context.ПерелікВакансійs.FindAsync(id);
            if (перелікВакансій != null)
            {
                _context.ПерелікВакансійs.Remove(перелікВакансій);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ПерелікВакансійExists(int id)
        {
          return (_context.ПерелікВакансійs?.Any(e => e.КодЗапису == id)).GetValueOrDefault();
        }
    }
}
