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
    public class ПрацівникController : Controller
    {
        private readonly ЦентрЗайнятостіContext _context;

        public ПрацівникController(ЦентрЗайнятостіContext context)
        {
            _context = context;
        }

        // GET: Працівник
        public async Task<IActionResult> Index()
        {
              return _context.Працівникs != null ? 
                          View(await _context.Працівникs.ToListAsync()) :
                          Problem("Entity set 'ЦентрЗайнятостіContext.Працівникs'  is null.");
        }

        // GET: Працівник/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Працівникs == null)
            {
                return NotFound();
            }

            var працівник = await _context.Працівникs
                .FirstOrDefaultAsync(m => m.КодПрацівника == id);
            if (працівник == null)
            {
                return NotFound();
            }

            return View(працівник);
        }

        // GET: Працівник/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Працівник/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("КодПрацівника,Імя,Прізвище,ПоБатькові,ДатаНародження,ДосвідРоботиРоки,Навички,Освіта,АдресаПроживання,СеріяПаспорта,НомерПаспорта,ДодатковіВміння")] Працівник працівник)
        {
            if (ModelState.IsValid)
            {
                _context.Add(працівник);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(працівник);
        }

        // GET: Працівник/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Працівникs == null)
            {
                return NotFound();
            }

            var працівник = await _context.Працівникs.FindAsync(id);
            if (працівник == null)
            {
                return NotFound();
            }
            return View(працівник);
        }

        // POST: Працівник/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("КодПрацівника,Імя,Прізвище,ПоБатькові,ДатаНародження,ДосвідРоботиРоки,Навички,Освіта,АдресаПроживання,СеріяПаспорта,НомерПаспорта,ДодатковіВміння")] Працівник працівник)
        {
            if (id != працівник.КодПрацівника)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(працівник);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ПрацівникExists(працівник.КодПрацівника))
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
            return View(працівник);
        }

        // GET: Працівник/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Працівникs == null)
            {
                return NotFound();
            }

            var працівник = await _context.Працівникs
                .FirstOrDefaultAsync(m => m.КодПрацівника == id);
            if (працівник == null)
            {
                return NotFound();
            }

            return View(працівник);
        }

        // POST: Працівник/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Працівникs == null)
            {
                return Problem("Entity set 'ЦентрЗайнятостіContext.Працівникs'  is null.");
            }
            var працівник = await _context.Працівникs.FindAsync(id);
            if (працівник != null)
            {
                _context.Працівникs.Remove(працівник);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ПрацівникExists(int id)
        {
          return (_context.Працівникs?.Any(e => e.КодПрацівника == id)).GetValueOrDefault();
        }
    }
}
