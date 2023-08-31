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
    public class ЗакритаВакансіяController : Controller
    {
        private readonly ЦентрЗайнятостіContext _context;

        public ЗакритаВакансіяController(ЦентрЗайнятостіContext context)
        {
            _context = context;
        }

        // GET: ЗакритаВакансія
        public async Task<IActionResult> Index()
        {
            var центрЗайнятостіContext = _context.ЗакритаВакансіяs.Include(з => з.ВлаштованийNavigation).Include(з => з.КодВакансіїNavigation);
            return View(await центрЗайнятостіContext.ToListAsync());
        }

        // GET: ЗакритаВакансія/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ЗакритаВакансіяs == null)
            {
                return NotFound();
            }

            var закритаВакансія = await _context.ЗакритаВакансіяs
                .Include(з => з.ВлаштованийNavigation)
                .Include(з => з.КодВакансіїNavigation)
                .FirstOrDefaultAsync(m => m.НомерЗапису == id);
            if (закритаВакансія == null)
            {
                return NotFound();
            }

            return View(закритаВакансія);
        }

        // GET: ЗакритаВакансія/Create
        public IActionResult Create()
        {
            ViewData["Влаштований"] = new SelectList(_context.Працівникs, "КодПрацівника", "КодПрацівника");
            ViewData["КодВакансії"] = new SelectList(_context.Вакансіяs, "КодВакансії", "КодВакансії");
            return View();
        }

        // POST: ЗакритаВакансія/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("НомерЗапису,КодВакансії,Влаштований,НазваВакансії,ДатаЗакриття")] ЗакритаВакансія закритаВакансія)
        {
            if (ModelState.IsValid)
            {
                _context.Add(закритаВакансія);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Влаштований"] = new SelectList(_context.Працівникs, "КодПрацівника", "КодПрацівника", закритаВакансія.Влаштований);
            ViewData["КодВакансії"] = new SelectList(_context.Вакансіяs, "КодВакансії", "КодВакансії", закритаВакансія.КодВакансії);
            return View(закритаВакансія);
        }

        // GET: ЗакритаВакансія/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ЗакритаВакансіяs == null)
            {
                return NotFound();
            }

            var закритаВакансія = await _context.ЗакритаВакансіяs.FindAsync(id);
            if (закритаВакансія == null)
            {
                return NotFound();
            }
            ViewData["Влаштований"] = new SelectList(_context.Працівникs, "КодПрацівника", "КодПрацівника", закритаВакансія.Влаштований);
            ViewData["КодВакансії"] = new SelectList(_context.Вакансіяs, "КодВакансії", "КодВакансії", закритаВакансія.КодВакансії);
            return View(закритаВакансія);
        }

        // POST: ЗакритаВакансія/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("НомерЗапису,КодВакансії,Влаштований,НазваВакансії,ДатаЗакриття")] ЗакритаВакансія закритаВакансія)
        {
            if (id != закритаВакансія.НомерЗапису)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(закритаВакансія);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ЗакритаВакансіяExists(закритаВакансія.НомерЗапису))
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
            ViewData["Влаштований"] = new SelectList(_context.Працівникs, "КодПрацівника", "КодПрацівника", закритаВакансія.Влаштований);
            ViewData["КодВакансії"] = new SelectList(_context.Вакансіяs, "КодВакансії", "КодВакансії", закритаВакансія.КодВакансії);
            return View(закритаВакансія);
        }

        // GET: ЗакритаВакансія/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ЗакритаВакансіяs == null)
            {
                return NotFound();
            }

            var закритаВакансія = await _context.ЗакритаВакансіяs
                .Include(з => з.ВлаштованийNavigation)
                .Include(з => з.КодВакансіїNavigation)
                .FirstOrDefaultAsync(m => m.НомерЗапису == id);
            if (закритаВакансія == null)
            {
                return NotFound();
            }

            return View(закритаВакансія);
        }

        // POST: ЗакритаВакансія/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ЗакритаВакансіяs == null)
            {
                return Problem("Entity set 'ЦентрЗайнятостіContext.ЗакритаВакансіяs'  is null.");
            }
            var закритаВакансія = await _context.ЗакритаВакансіяs.FindAsync(id);
            if (закритаВакансія != null)
            {
                _context.ЗакритаВакансіяs.Remove(закритаВакансія);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ЗакритаВакансіяExists(int id)
        {
          return (_context.ЗакритаВакансіяs?.Any(e => e.НомерЗапису == id)).GetValueOrDefault();
        }
    }
}
