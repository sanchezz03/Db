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
    public class ВідмовиController : Controller
    {
        private readonly ЦентрЗайнятостіContext _context;

        public ВідмовиController(ЦентрЗайнятостіContext context)
        {
            _context = context;
        }

        // GET: Відмови
        public async Task<IActionResult> Index()
        {
            var центрЗайнятостіContext = _context.Відмовиs.Include(в => в.КодКлієнтаNavigation);
            return View(await центрЗайнятостіContext.ToListAsync());
        }

        // GET: Відмови/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Відмовиs == null)
            {
                return NotFound();
            }

            var відмови = await _context.Відмовиs
                .Include(в => в.КодКлієнтаNavigation)
                .FirstOrDefaultAsync(m => m.КодВідмови == id);
            if (відмови == null)
            {
                return NotFound();
            }

            return View(відмови);
        }

        // GET: Відмови/Create
        public IActionResult Create()
        {
            ViewData["КодКлієнта"] = new SelectList(_context.Клієнтs, "КодКлієнта", "КодКлієнта");
            return View();
        }

        // POST: Відмови/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("КодВідмови,КодКлієнта,ДатаВідмови")] Відмови відмови)
        {
            if (ModelState.IsValid)
            {
                _context.Add(відмови);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["КодКлієнта"] = new SelectList(_context.Клієнтs, "КодКлієнта", "КодКлієнта", відмови.КодКлієнта);
            return View(відмови);
        }

        // GET: Відмови/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Відмовиs == null)
            {
                return NotFound();
            }

            var відмови = await _context.Відмовиs.FindAsync(id);
            if (відмови == null)
            {
                return NotFound();
            }
            ViewData["КодКлієнта"] = new SelectList(_context.Клієнтs, "КодКлієнта", "КодКлієнта", відмови.КодКлієнта);
            return View(відмови);
        }

        // POST: Відмови/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("КодВідмови,КодКлієнта,ДатаВідмови")] Відмови відмови)
        {
            if (id != відмови.КодВідмови)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(відмови);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ВідмовиExists(відмови.КодВідмови))
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
            ViewData["КодКлієнта"] = new SelectList(_context.Клієнтs, "КодКлієнта", "КодКлієнта", відмови.КодКлієнта);
            return View(відмови);
        }

        // GET: Відмови/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Відмовиs == null)
            {
                return NotFound();
            }

            var відмови = await _context.Відмовиs
                .Include(в => в.КодКлієнтаNavigation)
                .FirstOrDefaultAsync(m => m.КодВідмови == id);
            if (відмови == null)
            {
                return NotFound();
            }

            return View(відмови);
        }

        // POST: Відмови/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Відмовиs == null)
            {
                return Problem("Entity set 'ЦентрЗайнятостіContext.Відмовиs'  is null.");
            }
            var відмови = await _context.Відмовиs.FindAsync(id);
            if (відмови != null)
            {
                _context.Відмовиs.Remove(відмови);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ВідмовиExists(int id)
        {
          return (_context.Відмовиs?.Any(e => e.КодВідмови == id)).GetValueOrDefault();
        }
    }
}
