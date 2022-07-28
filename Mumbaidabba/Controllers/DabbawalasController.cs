using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Mumbaidabba.Models;

namespace Mumbaidabba.Controllers
{
    public class DabbawalasController : Controller
    {
        private readonly DabbaContext _context;

        public DabbawalasController(DabbaContext context)
        {
            _context = context;
        }

        // GET: Dabbawalas
        public async Task<IActionResult> Index()
        {
              return _context.dabbawala != null ? 
                          View(await _context.dabbawala.ToListAsync()) :
                          Problem("Entity set 'DabbaContext.dabbawala'  is null.");
        }

        // GET: Dabbawalas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.dabbawala == null)
            {
                return NotFound();
            }

            var dabbawala = await _context.dabbawala
                .FirstOrDefaultAsync(m => m.dabbawalaId == id);
            if (dabbawala == null)
            {
                return NotFound();
            }

            return View(dabbawala);
        }

        // GET: Dabbawalas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Dabbawalas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("dabbawalaId,IdProof,IdNumber,ImageUrl,dabbawalaName,location,dabbawalaDesc")] Dabbawala dabbawala)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dabbawala);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dabbawala);
        }

        // GET: Dabbawalas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.dabbawala == null)
            {
                return NotFound();
            }

            var dabbawala = await _context.dabbawala.FindAsync(id);
            if (dabbawala == null)
            {
                return NotFound();
            }
            return View(dabbawala);
        }

        // POST: Dabbawalas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("dabbawalaId,IdProof,IdNumber,ImageUrl,dabbawalaName,location,dabbawalaDesc")] Dabbawala dabbawala)
        {
            if (id != dabbawala.dabbawalaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dabbawala);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DabbawalaExists(dabbawala.dabbawalaId))
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
            return View(dabbawala);
        }

        // GET: Dabbawalas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.dabbawala == null)
            {
                return NotFound();
            }

            var dabbawala = await _context.dabbawala
                .FirstOrDefaultAsync(m => m.dabbawalaId == id);
            if (dabbawala == null)
            {
                return NotFound();
            }

            return View(dabbawala);
        }

        // POST: Dabbawalas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.dabbawala == null)
            {
                return Problem("Entity set 'DabbaContext.dabbawala'  is null.");
            }
            var dabbawala = await _context.dabbawala.FindAsync(id);
            if (dabbawala != null)
            {
                _context.dabbawala.Remove(dabbawala);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DabbawalaExists(int id)
        {
          return (_context.dabbawala?.Any(e => e.dabbawalaId == id)).GetValueOrDefault();
        }
    }
}
