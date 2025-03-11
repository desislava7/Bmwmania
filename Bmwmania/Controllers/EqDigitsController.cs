using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Bmwmania.Data;

namespace Bmwmania.Controllers
{
    public class EqDigitsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EqDigitsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: EqDigits
        public async Task<IActionResult> Index()
        {
            return View(await _context.EqDigits.ToListAsync());
        }

        // GET: EqDigits/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eqDigit = await _context.EqDigits
                .FirstOrDefaultAsync(m => m.Id == id);
            if (eqDigit == null)
            {
                return NotFound();
            }

            return View(eqDigit);
        }

        // GET: EqDigits/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EqDigits/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,ImageURL")] EqDigit eqDigit)
        {
            eqDigit.DateReg = DateTime.Now;
            if (ModelState.IsValid)
            {
                _context.Add(eqDigit);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(eqDigit);
        }

        // GET: EqDigits/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eqDigit = await _context.EqDigits.FindAsync(id);
            if (eqDigit == null)
            {
                return NotFound();
            }
            return View(eqDigit);
        }

        // POST: EqDigits/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,ImageURL")] EqDigit eqDigit)
        {
            if (id != eqDigit.Id)
            {
                return NotFound();
            }
            eqDigit.DateReg = DateTime.Now;

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(eqDigit);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EqDigitExists(eqDigit.Id))
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
            return View(eqDigit);
        }

        // GET: EqDigits/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eqDigit = await _context.EqDigits
                .FirstOrDefaultAsync(m => m.Id == id);
            if (eqDigit == null)
            {
                return NotFound();
            }

            return View(eqDigit);
        }

        // POST: EqDigits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var eqDigit = await _context.EqDigits.FindAsync(id);
            if (eqDigit != null)
            {
                _context.EqDigits.Remove(eqDigit);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EqDigitExists(int id)
        {
            return _context.EqDigits.Any(e => e.Id == id);
        }
    }
}
