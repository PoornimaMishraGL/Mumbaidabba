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
    public class DabbaCategoriesController : Controller
    {
        private readonly DabbaContext _context;

        public DabbaCategoriesController(DabbaContext context)
        {
            _context = context;
        }

        // GET: DabbaCategories
        public async Task<IActionResult> Index()
        {
              return _context.dabbaCategory != null ? 
                          View(await _context.dabbaCategory.ToListAsync()) :
                          Problem("Entity set 'DabbaContext.dabbaCategory'  is null.");
        }

        // GET: DabbaCategories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.dabbaCategory == null)
            {
                return NotFound();
            }

            var dabbaCategory = await _context.dabbaCategory
                .FirstOrDefaultAsync(m => m.DabbaCategoryId == id);
            if (dabbaCategory == null)
            {
                return NotFound();
            }

            return View(dabbaCategory);
        }

        // GET: DabbaCategories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DabbaCategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DabbaCategoryId,DabbaCategoryName,DabbaCategoryDesc")] DabbaCategory dabbaCategory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dabbaCategory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dabbaCategory);
        }

        // GET: DabbaCategories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.dabbaCategory == null)
            {
                return NotFound();
            }

            var dabbaCategory = await _context.dabbaCategory.FindAsync(id);
            if (dabbaCategory == null)
            {
                return NotFound();
            }
            return View(dabbaCategory);
        }

        // POST: DabbaCategories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DabbaCategoryId,DabbaCategoryName,DabbaCategoryDesc")] DabbaCategory dabbaCategory)
        {
            if (id != dabbaCategory.DabbaCategoryId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dabbaCategory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DabbaCategoryExists(dabbaCategory.DabbaCategoryId))
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
            return View(dabbaCategory);
        }

        // GET: DabbaCategories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.dabbaCategory == null)
            {
                return NotFound();
            }

            var dabbaCategory = await _context.dabbaCategory
                .FirstOrDefaultAsync(m => m.DabbaCategoryId == id);
            if (dabbaCategory == null)
            {
                return NotFound();
            }

            return View(dabbaCategory);
        }

        // POST: DabbaCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.dabbaCategory == null)
            {
                return Problem("Entity set 'DabbaContext.dabbaCategory'  is null.");
            }
            var dabbaCategory = await _context.dabbaCategory.FindAsync(id);
            if (dabbaCategory != null)
            {
                _context.dabbaCategory.Remove(dabbaCategory);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DabbaCategoryExists(int id)
        {
          return (_context.dabbaCategory?.Any(e => e.DabbaCategoryId == id)).GetValueOrDefault();
        }
    }
}
