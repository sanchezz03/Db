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
    public class ІсторіяЗверненьДоБюроController : Controller
    {
        private readonly ЦентрЗайнятостіContext _context;

        public ІсторіяЗверненьДоБюроController(ЦентрЗайнятостіContext context)
        {
            _context = context;
        }

        // GET: ІсторіяЗверненьДоБюро
        public async Task<IActionResult> Index()
        {
            var центрЗайнятостіContext = _context.ІсторіяЗверненьДоБюроs.Include(і => і.КодПрацівникаNavigation);
            return View(await центрЗайнятостіContext.ToListAsync());
        }

        // GET: ІсторіяЗверненьДоБюро/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ІсторіяЗверненьДоБюроs == null)
            {
                return NotFound();
            }

            var історіяЗверненьДоБюро = await _context.ІсторіяЗверненьДоБюроs
                .Include(і => і.КодПрацівникаNavigation)
                .FirstOrDefaultAsync(m => m.КодЗапису == id);
            if (історіяЗверненьДоБюро == null)
            {
                return NotFound();
            }

            return View(історіяЗверненьДоБюро);
        }

        // GET: ІсторіяЗверненьДоБюро/Create
        public IActionResult Create()
        {
            ViewData["КодПрацівника"] = new SelectList(_context.Працівникs, "КодПрацівника", "КодПрацівника");
            return View();
        }

        // POST: ІсторіяЗверненьДоБюро/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("КодЗапису,КодПрацівника,ДатаЗвернення,Перекваліфікація,ДатаПерекваліфікації,ДатаВлаштування,ВідмоваВідЗапропонованихВакансій,КількістьВідмов")] ІсторіяЗверненьДоБюро історіяЗверненьДоБюро)
        {
            if (ModelState.IsValid)
            {
                _context.Add(історіяЗверненьДоБюро);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["КодПрацівника"] = new SelectList(_context.Працівникs, "КодПрацівника", "КодПрацівника", історіяЗверненьДоБюро.КодПрацівника);
            return View(історіяЗверненьДоБюро);
        }

        // GET: ІсторіяЗверненьДоБюро/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ІсторіяЗверненьДоБюроs == null)
            {
                return NotFound();
            }

            var історіяЗверненьДоБюро = await _context.ІсторіяЗверненьДоБюроs.FindAsync(id);
            if (історіяЗверненьДоБюро == null)
            {
                return NotFound();
            }
            ViewData["КодПрацівника"] = new SelectList(_context.Працівникs, "КодПрацівника", "КодПрацівника", історіяЗверненьДоБюро.КодПрацівника);
            return View(історіяЗверненьДоБюро);
        }

        // POST: ІсторіяЗверненьДоБюро/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("КодЗапису,КодПрацівника,ДатаЗвернення,Перекваліфікація,ДатаПерекваліфікації,ДатаВлаштування,ВідмоваВідЗапропонованихВакансій,КількістьВідмов")] ІсторіяЗверненьДоБюро історіяЗверненьДоБюро)
        {
            if (id != історіяЗверненьДоБюро.КодЗапису)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(історіяЗверненьДоБюро);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ІсторіяЗверненьДоБюроExists(історіяЗверненьДоБюро.КодЗапису))
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
            ViewData["КодПрацівника"] = new SelectList(_context.Працівникs, "КодПрацівника", "КодПрацівника", історіяЗверненьДоБюро.КодПрацівника);
            return View(історіяЗверненьДоБюро);
        }

        // GET: ІсторіяЗверненьДоБюро/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ІсторіяЗверненьДоБюроs == null)
            {
                return NotFound();
            }

            var історіяЗверненьДоБюро = await _context.ІсторіяЗверненьДоБюроs
                .Include(і => і.КодПрацівникаNavigation)
                .FirstOrDefaultAsync(m => m.КодЗапису == id);
            if (історіяЗверненьДоБюро == null)
            {
                return NotFound();
            }

            return View(історіяЗверненьДоБюро);
        }

        // POST: ІсторіяЗверненьДоБюро/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ІсторіяЗверненьДоБюроs == null)
            {
                return Problem("Entity set 'ЦентрЗайнятостіContext.ІсторіяЗверненьДоБюроs'  is null.");
            }
            var історіяЗверненьДоБюро = await _context.ІсторіяЗверненьДоБюроs.FindAsync(id);
            if (історіяЗверненьДоБюро != null)
            {
                _context.ІсторіяЗверненьДоБюроs.Remove(історіяЗверненьДоБюро);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ІсторіяЗверненьДоБюроExists(int id)
        {
          return (_context.ІсторіяЗверненьДоБюроs?.Any(e => e.КодЗапису == id)).GetValueOrDefault();
        }
    }
}
