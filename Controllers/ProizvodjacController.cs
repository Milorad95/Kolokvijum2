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
    public class ProizvodjacController : Controller
    {
        private readonly DataContext _context;

        public ProizvodjacController(DataContext context)
        {
            _context = context;
        }

        // GET: Proizvodjac
        public async Task<IActionResult> Index()
        {
              return _context.Proizvodjaci != null ? 
                          View(await _context.Proizvodjaci.ToListAsync()) :
                          Problem("Entity set 'DataContext.Proizvodjaci'  is null.");
        }

        // GET: Proizvodjac/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Proizvodjaci == null)
            {
                return NotFound();
            }

            var proizvodjac = await _context.Proizvodjaci
                .FirstOrDefaultAsync(m => m.ProizvodjacID == id);
            if (proizvodjac == null)
            {
                return NotFound();
            }

            return View(proizvodjac);
        }

        // GET: Proizvodjac/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Proizvodjac/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProizvodjacID,NazivProizvodjaca")] Proizvodjac proizvodjac)
        {
            if (ModelState.IsValid)
            {
                _context.Add(proizvodjac);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(proizvodjac);
        }

        // GET: Proizvodjac/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Proizvodjaci == null)
            {
                return NotFound();
            }

            var proizvodjac = await _context.Proizvodjaci.FindAsync(id);
            if (proizvodjac == null)
            {
                return NotFound();
            }
            return View(proizvodjac);
        }

        // POST: Proizvodjac/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProizvodjacID,NazivProizvodjaca")] Proizvodjac proizvodjac)
        {
            if (id != proizvodjac.ProizvodjacID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(proizvodjac);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProizvodjacExists(proizvodjac.ProizvodjacID))
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
            return View(proizvodjac);
        }

        // GET: Proizvodjac/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Proizvodjaci == null)
            {
                return NotFound();
            }

            var proizvodjac = await _context.Proizvodjaci
                .FirstOrDefaultAsync(m => m.ProizvodjacID == id);
            if (proizvodjac == null)
            {
                return NotFound();
            }

            return View(proizvodjac);
        }

        // POST: Proizvodjac/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Proizvodjaci == null)
            {
                return Problem("Entity set 'DataContext.Proizvodjaci'  is null.");
            }
            var proizvodjac = await _context.Proizvodjaci.FindAsync(id);
            if (proizvodjac != null)
            {
                _context.Proizvodjaci.Remove(proizvodjac);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProizvodjacExists(int id)
        {
          return (_context.Proizvodjaci?.Any(e => e.ProizvodjacID == id)).GetValueOrDefault();
        }
    }
}
