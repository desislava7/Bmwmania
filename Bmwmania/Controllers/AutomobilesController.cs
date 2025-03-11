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
    public class AutomobilesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AutomobilesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Automobiles
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Automobiles.Include(a => a.EqDigits).Include(a => a.EqExteriors).Include(a => a.EqInteriors).Include(a => a.EqLights).Include(a => a.Fuels).Include(a => a.Models);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Automobiles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var automobile = await _context.Automobiles
                .Include(a => a.EqDigits)
                .Include(a => a.EqExteriors)
                .Include(a => a.EqInteriors)
                .Include(a => a.EqLights)
                .Include(a => a.Fuels)
                .Include(a => a.Models)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (automobile == null)
            {
                return NotFound();
            }

            return View(automobile);
        }

        // GET: Automobiles/Create
        public IActionResult Create()
        {
            ViewData["EqDigitId"] = new SelectList(_context.EqDigits, "Id", "Id");
            ViewData["EqExteriorId"] = new SelectList(_context.EqExteriors, "Id", "Id");
            ViewData["EqInteriorsId"] = new SelectList(_context.EqInteriors, "Id", "Id");
            ViewData["EqLightId"] = new SelectList(_context.EqLights, "Id", "Id");
            ViewData["FuelId"] = new SelectList(_context.Fuels, "Id", "Id");
            ViewData["ModelId"] = new SelectList(_context.Models, "Id", "Id");
            return View();
        }

        // POST: Automobiles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,RegNumber,ModelId,Type,FuelId,EqExteriorId,EqInteriorsId,EqDigitId,EqLightId,Power,ImageURL,Price,DateReg")] Automobile automobile)
        {
            if (ModelState.IsValid)
            {
                _context.Add(automobile);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EqDigitId"] = new SelectList(_context.EqDigits, "Id", "Id", automobile.EqDigitId);
            ViewData["EqExteriorId"] = new SelectList(_context.EqExteriors, "Id", "Id", automobile.EqExteriorId);
            ViewData["EqInteriorsId"] = new SelectList(_context.EqInteriors, "Id", "Id", automobile.EqInteriorsId);
            ViewData["EqLightId"] = new SelectList(_context.EqLights, "Id", "Id", automobile.EqLightId);
            ViewData["FuelId"] = new SelectList(_context.Fuels, "Id", "Id", automobile.FuelId);
            ViewData["ModelId"] = new SelectList(_context.Models, "Id", "Id", automobile.ModelId);
            return View(automobile);
        }

        // GET: Automobiles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var automobile = await _context.Automobiles.FindAsync(id);
            if (automobile == null)
            {
                return NotFound();
            }
            ViewData["EqDigitId"] = new SelectList(_context.EqDigits, "Id", "Id", automobile.EqDigitId);
            ViewData["EqExteriorId"] = new SelectList(_context.EqExteriors, "Id", "Id", automobile.EqExteriorId);
            ViewData["EqInteriorsId"] = new SelectList(_context.EqInteriors, "Id", "Id", automobile.EqInteriorsId);
            ViewData["EqLightId"] = new SelectList(_context.EqLights, "Id", "Id", automobile.EqLightId);
            ViewData["FuelId"] = new SelectList(_context.Fuels, "Id", "Id", automobile.FuelId);
            ViewData["ModelId"] = new SelectList(_context.Models, "Id", "Id", automobile.ModelId);
            return View(automobile);
        }

        // POST: Automobiles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,RegNumber,ModelId,Type,FuelId,EqExteriorId,EqInteriorsId,EqDigitId,EqLightId,Power,ImageURL,Price,DateReg")] Automobile automobile)
        {
            if (id != automobile.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(automobile);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AutomobileExists(automobile.Id))
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
            ViewData["EqDigitId"] = new SelectList(_context.EqDigits, "Id", "Id", automobile.EqDigitId);
            ViewData["EqExteriorId"] = new SelectList(_context.EqExteriors, "Id", "Id", automobile.EqExteriorId);
            ViewData["EqInteriorsId"] = new SelectList(_context.EqInteriors, "Id", "Id", automobile.EqInteriorsId);
            ViewData["EqLightId"] = new SelectList(_context.EqLights, "Id", "Id", automobile.EqLightId);
            ViewData["FuelId"] = new SelectList(_context.Fuels, "Id", "Id", automobile.FuelId);
            ViewData["ModelId"] = new SelectList(_context.Models, "Id", "Id", automobile.ModelId);
            return View(automobile);
        }

        // GET: Automobiles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var automobile = await _context.Automobiles
                .Include(a => a.EqDigits)
                .Include(a => a.EqExteriors)
                .Include(a => a.EqInteriors)
                .Include(a => a.EqLights)
                .Include(a => a.Fuels)
                .Include(a => a.Models)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (automobile == null)
            {
                return NotFound();
            }

            return View(automobile);
        }

        // POST: Automobiles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var automobile = await _context.Automobiles.FindAsync(id);
            if (automobile != null)
            {
                _context.Automobiles.Remove(automobile);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AutomobileExists(int id)
        {
            return _context.Automobiles.Any(e => e.Id == id);
        }
    }
}
