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
    public class ВакансіяController : Controller
    {
        private readonly ЦентрЗайнятостіContext _context;

        public ВакансіяController(ЦентрЗайнятостіContext context)
        {
            _context = context;
        }

        // GET: Вакансія
        public async Task<IActionResult> Index()
        {
              return _context.Вакансіяs != null ? 
                          View(await _context.Вакансіяs.ToListAsync()) :
                          Problem("Entity set 'ЦентрЗайнятостіContext.Вакансіяs'  is null.");
        }

        // GET: Вакансія/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Вакансіяs == null)
            {
                return NotFound();
            }

            var вакансія = await _context.Вакансіяs
                .FirstOrDefaultAsync(m => m.КодВакансії == id);
            if (вакансія == null)
            {
                return NotFound();
            }

            return View(вакансія);
        }

        // GET: Вакансія/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Вакансія/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("КодВакансії,КодПідприємства,Вік,Стать,Освіта,СоцПакет,ТривалістьРобочогоДняГодини,НазваВакансії,ДатаСтворення,ДосвідРоботиРоки")] Вакансія вакансія)
        {
            if (ModelState.IsValid)
            {
                _context.Add(вакансія);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(вакансія);
        }

        // GET: Вакансія/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Вакансіяs == null)
            {
                return NotFound();
            }

            var вакансія = await _context.Вакансіяs.FindAsync(id);
            if (вакансія == null)
            {
                return NotFound();
            }
            return View(вакансія);
        }

        // POST: Вакансія/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("КодВакансії,КодПідприємства,Вік,Стать,Освіта,СоцПакет,ТривалістьРобочогоДняГодини,НазваВакансії,ДатаСтворення,ДосвідРоботиРоки")] Вакансія вакансія)
        {
            if (id != вакансія.КодВакансії)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(вакансія);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ВакансіяExists(вакансія.КодВакансії))
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
            return View(вакансія);
        }

        // GET: Вакансія/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Вакансіяs == null)
            {
                return NotFound();
            }

            var вакансія = await _context.Вакансіяs
                .FirstOrDefaultAsync(m => m.КодВакансії == id);
            if (вакансія == null)
            {
                return NotFound();
            }

            return View(вакансія);
        }

        // POST: Вакансія/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Вакансіяs == null)
            {
                return Problem("Entity set 'ЦентрЗайнятостіContext.Вакансіяs'  is null.");
            }
            var вакансія = await _context.Вакансіяs.FindAsync(id);
            if (вакансія != null)
            {
                _context.Вакансіяs.Remove(вакансія);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ВакансіяExists(int id)
        {
          return (_context.Вакансіяs?.Any(e => e.КодВакансії == id)).GetValueOrDefault();
        }
    }
}
