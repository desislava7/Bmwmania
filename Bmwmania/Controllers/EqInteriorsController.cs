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
    public class EqInteriorsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EqInteriorsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: EqInteriors
        public async Task<IActionResult> Index()
        {
            return View(await _context.EqInteriors.ToListAsync());
        }

        // GET: EqInteriors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eqInterior = await _context.EqInteriors
                .FirstOrDefaultAsync(m => m.Id == id);
            if (eqInterior == null)
            {
                return NotFound();
            }

            return View(eqInterior);
        }

        // GET: EqInteriors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EqInteriors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,ImageURL,DateReg")] EqInterior eqInterior)
        {
            if (ModelState.IsValid)
            {
                _context.Add(eqInterior);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(eqInterior);
        }

        // GET: EqInteriors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eqInterior = await _context.EqInteriors.FindAsync(id);
            if (eqInterior == null)
            {
                return NotFound();
            }
            return View(eqInterior);
        }

        // POST: EqInteriors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,ImageURL,DateReg")] EqInterior eqInterior)
        {
            if (id != eqInterior.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(eqInterior);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EqInteriorExists(eqInterior.Id))
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
            return View(eqInterior);
        }

        // GET: EqInteriors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eqInterior = await _context.EqInteriors
                .FirstOrDefaultAsync(m => m.Id == id);
            if (eqInterior == null)
            {
                return NotFound();
            }

            return View(eqInterior);
        }

        // POST: EqInteriors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var eqInterior = await _context.EqInteriors.FindAsync(id);
            if (eqInterior != null)
            {
                _context.EqInteriors.Remove(eqInterior);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EqInteriorExists(int id)
        {
            return _context.EqInteriors.Any(e => e.Id == id);
        }
    }
}
