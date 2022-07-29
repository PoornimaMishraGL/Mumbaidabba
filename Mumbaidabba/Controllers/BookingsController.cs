using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Mumbaidabba.Models;

namespace Mumbaidabba.Controllers
{
   
  //  [Authorize(Roles = "user")]
    public class BookingsController : Controller
    {
        private readonly DabbaContext _context;

        public BookingsController(DabbaContext context)
        {
            _context = context;
        }

        // GET: Bookings
        public async Task<IActionResult> Index()
        {
            var dabbaContext = _context.booking.Include(b => b.dabbaCategory);
            return View(await dabbaContext.ToListAsync());
        }

        // GET: Bookings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.booking == null)
            {
                return NotFound();
            }

            var booking = await _context.booking
                .Include(b => b.dabbaCategory)
                .FirstOrDefaultAsync(m => m.BookingDetailsId == id);
            if (booking == null)
            {
                return NotFound();
            }

            return View(booking);
        }
        [Authorize(Roles = "user")]
        // GET: Bookings/Create
        public IActionResult Create()
        {
            ViewData["DbCtgId"] = new SelectList(_context.dabbaCategory, "DabbaCategoryId", "DabbaCategoryId");
            return View();
        }

        // POST: Bookings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BookingDetailsId,BookingNo,DbCtgId,Quantity,usrid,OrderDate")] Booking booking)
        {
           
                _context.Add(booking);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            
        }
        [Authorize(Roles = "user")]
        // GET: Bookings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.booking == null)
            {
                return NotFound();
            }

            var booking = await _context.booking.FindAsync(id);
            if (booking == null)
            {
                return NotFound();
            }
            ViewData["DbCtgId"] = new SelectList(_context.dabbaCategory, "DabbaCategoryId", "DabbaCategoryId", booking.DbCtgId);
            return View(booking);
        }

        // POST: Bookings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BookingDetailsId,BookingNo,DbCtgId,Quantity,usrid,OrderDate")] Booking booking)
        {
            if (id != booking.BookingDetailsId)
            {
                return NotFound();
            }

           
                try
                {
                    _context.Update(booking);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookingExists(booking.BookingDetailsId))
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
        [Authorize(Roles = "user")]
        // GET: Bookings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.booking == null)
            {
                return NotFound();
            }

            var booking = await _context.booking
                .Include(b => b.dabbaCategory)
                .FirstOrDefaultAsync(m => m.BookingDetailsId == id);
            if (booking == null)
            {
                return NotFound();
            }

            return View(booking);
        }

        // POST: Bookings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.booking == null)
            {
                return Problem("Entity set 'DabbaContext.booking'  is null.");
            }
            var booking = await _context.booking.FindAsync(id);
            if (booking != null)
            {
                _context.booking.Remove(booking);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookingExists(int id)
        {
          return (_context.booking?.Any(e => e.BookingDetailsId == id)).GetValueOrDefault();
        }
    }
}
