using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Mumbaidabba.Models;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace Mumbaidabba.Controllers
{


    public class DabbawalasController : Controller
    {
        private readonly DabbaContext _context;

        public IHostingEnvironment _env;
        public DabbawalasController(DabbaContext context, IHostingEnvironment env)
        {

            _context = context;
            _env = env;

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

        [Authorize(Roles ="dabbawala")]
      //  [Authorize(Roles = "dabbawala")]
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
        public async Task<IActionResult> Create(Dabbawala dabbawala)
        {

            var nam = Path.Combine(_env.WebRootPath + "/Images", Path.GetFileName(dabbawala.IdImage.FileName));
            dabbawala.IdImage.CopyTo(new FileStream(nam, FileMode.Create));
            dabbawala.ImageUrl = "Images/" + dabbawala.IdImage.FileName;
            _context.dabbawala.Add(dabbawala);
            _context.Add(dabbawala);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));


        }


        // GET: Dabbawalas/Edit/5
       [Authorize(Roles = "dabbawala")]
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
        public async Task<IActionResult> Edit(int id,Dabbawala dabbawala)
        {
            if (id != dabbawala.dabbawalaId)
            {
                return NotFound();
            }

            
                try
                {
                    var nam = Path.Combine(_env.WebRootPath + "/Images", Path.GetFileName(dabbawala.IdImage.FileName));
                    dabbawala.IdImage.CopyTo(new FileStream(nam, FileMode.Create));
                    dabbawala.ImageUrl = "Images/" + dabbawala.IdImage.FileName;
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
        [Authorize(Roles = "dabbawala")]
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
