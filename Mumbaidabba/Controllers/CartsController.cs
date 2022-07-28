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
    public class CartsController : Controller
    {
        private readonly DabbaContext _context;

        public CartsController(DabbaContext context)
        {
            _context = context;
        }

        // GET: Carts
        public async Task<IActionResult> Index()
        {
            var dabbaContext = _context.carts.Include(c => c.dabbaCategory).Include(c => c.user);
            return View(await dabbaContext.ToListAsync());
        }

        // GET: Carts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.carts == null)
            {
                return NotFound();
            }

            var carts = await _context.carts
                .Include(c => c.dabbaCategory)
                .Include(c => c.user)
                .FirstOrDefaultAsync(m => m.CartId == id);
            if (carts == null)
            {
                return NotFound();
            }

            return View(carts);
        }

        // GET: Carts/Create
        public IActionResult Create()
        {
            ViewData["DbCtgId"] = new SelectList(_context.dabbaCategory, "DabbaCategoryId", "DabbaCategoryId");
            ViewData["usrid"] = new SelectList(_context.user, "UserId", "UserId");
            return View();
        }

        // POST: Carts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CartId,DbCtgId,Quantity,usrid,Price,timeStamp")] Carts carts)
        {
            if (ModelState.IsValid)
            {
                _context.Add(carts);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DbCtgId"] = new SelectList(_context.dabbaCategory, "DabbaCategoryId", "DabbaCategoryId", carts.DbCtgId);
            ViewData["usrid"] = new SelectList(_context.user, "UserId", "UserId", carts.usrid);
            return View(carts);
        }

        // GET: Carts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.carts == null)
            {
                return NotFound();
            }

            var carts = await _context.carts.FindAsync(id);
            if (carts == null)
            {
                return NotFound();
            }
            ViewData["DbCtgId"] = new SelectList(_context.dabbaCategory, "DabbaCategoryId", "DabbaCategoryId", carts.DbCtgId);
            ViewData["usrid"] = new SelectList(_context.user, "UserId", "UserId", carts.usrid);
            return View(carts);
        }

        // POST: Carts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CartId,DbCtgId,Quantity,usrid,Price,timeStamp")] Carts carts)
        {
            if (id != carts.CartId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(carts);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CartsExists(carts.CartId))
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
            ViewData["DbCtgId"] = new SelectList(_context.dabbaCategory, "DabbaCategoryId", "DabbaCategoryId", carts.DbCtgId);
            ViewData["usrid"] = new SelectList(_context.user, "UserId", "UserId", carts.usrid);
            return View(carts);
        }

        // GET: Carts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.carts == null)
            {
                return NotFound();
            }

            var carts = await _context.carts
                .Include(c => c.dabbaCategory)
                .Include(c => c.user)
                .FirstOrDefaultAsync(m => m.CartId == id);
            if (carts == null)
            {
                return NotFound();
            }

            return View(carts);
        }

        // POST: Carts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.carts == null)
            {
                return Problem("Entity set 'DabbaContext.carts'  is null.");
            }
            var carts = await _context.carts.FindAsync(id);
            if (carts != null)
            {
                _context.carts.Remove(carts);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CartsExists(int id)
        {
          return (_context.carts?.Any(e => e.CartId == id)).GetValueOrDefault();
        }
    }
}
