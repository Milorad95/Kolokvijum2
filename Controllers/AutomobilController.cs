using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Kolokvijum2.Data;
using Kolokvijum2.Models;

namespace Kolokvijum2.Controllers
{
    public class AutomobilController : Controller
    {
        private readonly DataContext _context;

        public AutomobilController(DataContext context)
        {
            _context = context;
        }

        // GET: Automobil
        public async Task<IActionResult> Index([FromQuery] string filter)
        {
            ViewData["filter"] = filter;
            IEnumerable<Proizvodjac> Proizvodjaci = _context.Proizvodjaci.ToList();
            if (string.IsNullOrEmpty(filter))
            {
                return _context.Automobili != null ?
                          View(await _context.Automobili.ToListAsync()) :
                          Problem("Entity set 'DataContext.Automobili'  is null.");
            }
            else
            {
                var automobil = _context.Automobili.Where(a => a.NazivAutomobila.Contains(filter.ToLower())).ToList();
                return View(automobil.ToList());
            }
              
        }

        // GET: Automobil/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Automobili == null)
            {
                return NotFound();
            }

            var automobil = await _context.Automobili
                .FirstOrDefaultAsync(m => m.AutomobilID == id);
            if (automobil == null)
            {
                return NotFound();
            }

            return View(automobil);
        }

        // GET: Automobil/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Automobil/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Automobil automobil)
        {
            if(automobil.NazivAutomobila != null)
            {
                _context.Add(automobil);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View("Index");

        }

        // GET: Automobil/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Automobili == null)
            {
                return NotFound();
            }

            var automobil = await _context.Automobili.FindAsync(id);
            if (automobil == null)
            {
                return NotFound();
            }
            return View(automobil);
        }

        // POST: Automobil/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Automobil automobil)
        {
            if (id != automobil.AutomobilID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(automobil);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AutomobilExists(automobil.AutomobilID))
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
            return RedirectToAction(nameof(Index));
        }

        // GET: Automobil/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            /*if (id == null || _context.Automobili == null)
            {
                return NotFound();
            }

            var automobil = await _context.Automobili
                .FirstOrDefaultAsync(m => m.AutomobilID == id);
            if (automobil == null)
            {
                return NotFound();
            }
            */
            var aut = _context.Automobili.SingleOrDefault(a => a.AutomobilID == id);
            _context.Automobili.Remove(aut);
            _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

            // return View(automobil);
        }

        // POST: Automobil/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Automobili == null)
            {
                return Problem("Entity set 'DataContext.Automobili'  is null.");
            }
            var automobil = await _context.Automobili.FindAsync(id);
            if (automobil != null)
            {
                _context.Automobili.Remove(automobil);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AutomobilExists(int id)
        {
          return (_context.Automobili?.Any(e => e.AutomobilID == id)).GetValueOrDefault();
        }
    }
}
