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
    public class EqExteriorsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EqExteriorsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: EqExteriors
        public async Task<IActionResult> Index()
        {
            return View(await _context.EqExteriors.ToListAsync());
        }

        // GET: EqExteriors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eqExterior = await _context.EqExteriors
                .FirstOrDefaultAsync(m => m.Id == id);
            if (eqExterior == null)
            {
                return NotFound();
            }

            return View(eqExterior);
        }

        // GET: EqExteriors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EqExteriors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,ImageURL")] EqExterior eqExterior)
        {
            if (ModelState.IsValid)
            {
                _context.Add(eqExterior);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            return View(eqExterior);
        }

        // GET: EqExteriors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eqExterior = await _context.EqExteriors.FindAsync(id);
            if (eqExterior == null)
            {
                return NotFound();
            }
            return View(eqExterior);
        }

        // POST: EqExteriors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,ImageURL")] EqExterior eqExterior)
        {
            if (id != eqExterior.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(eqExterior);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EqExteriorExists(eqExterior.Id))
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
            return View(eqExterior);
        }

        // GET: EqExteriors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eqExterior = await _context.EqExteriors
                .FirstOrDefaultAsync(m => m.Id == id);
            if (eqExterior == null)
            {
                return NotFound();
            }

            return View(eqExterior);
        }

        // POST: EqExteriors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var eqExterior = await _context.EqExteriors.FindAsync(id);
            if (eqExterior != null)
            {
                _context.EqExteriors.Remove(eqExterior);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EqExteriorExists(int id)
        {
            return _context.EqExteriors.Any(e => e.Id == id);
        }
    }
}
