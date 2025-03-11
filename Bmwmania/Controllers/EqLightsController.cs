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
    public class EqLightsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EqLightsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: EqLights
        public async Task<IActionResult> Index()
        {
            return View(await _context.EqLights.ToListAsync());
        }

        // GET: EqLights/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eqLight = await _context.EqLights
                .FirstOrDefaultAsync(m => m.Id == id);
            if (eqLight == null)
            {
                return NotFound();
            }

            return View(eqLight);
        }

        // GET: EqLights/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EqLights/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,ImageURL,DateReg")] EqLight eqLight)
        {
            if (ModelState.IsValid)
            {
                _context.Add(eqLight);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(eqLight);
        }

        // GET: EqLights/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eqLight = await _context.EqLights.FindAsync(id);
            if (eqLight == null)
            {
                return NotFound();
            }
            return View(eqLight);
        }

        // POST: EqLights/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,ImageURL,DateReg")] EqLight eqLight)
        {
            if (id != eqLight.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(eqLight);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EqLightExists(eqLight.Id))
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
            return View(eqLight);
        }

        // GET: EqLights/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eqLight = await _context.EqLights
                .FirstOrDefaultAsync(m => m.Id == id);
            if (eqLight == null)
            {
                return NotFound();
            }

            return View(eqLight);
        }

        // POST: EqLights/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var eqLight = await _context.EqLights.FindAsync(id);
            if (eqLight != null)
            {
                _context.EqLights.Remove(eqLight);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EqLightExists(int id)
        {
            return _context.EqLights.Any(e => e.Id == id);
        }
    }
}
