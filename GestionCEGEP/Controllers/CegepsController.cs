using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GestionCEGEP.Data;
using GestionCEGEP.Models;

namespace GestionCEGEP.Controllers
{
    public class CegepsController : Controller
    {
        private readonly GestionCEGEPContext _context;

        public CegepsController(GestionCEGEPContext context)
        {
            _context = context;
        }

        // GET: Cegeps
        public async Task<IActionResult> Index()
        {
              return View(await _context.Cegep.ToListAsync());
        }

        // GET: Cegeps/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Cegep == null)
            {
                return NotFound();
            }

            var cegep = await _context.Cegep
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cegep == null)
            {
                return NotFound();
            }

            return View(cegep);
        }

        // GET: Cegeps/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cegeps/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nom,CodePostal,Adresse,Ville,Effectif,DateCreation")] Cegep cegep)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cegep);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cegep);
        }

        // GET: Cegeps/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Cegep == null)
            {
                return NotFound();
            }

            var cegep = await _context.Cegep.FindAsync(id);
            if (cegep == null)
            {
                return NotFound();
            }
            return View(cegep);
        }

        // POST: Cegeps/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nom,CodePostal,Adresse,Ville,Effectif,DateCreation")] Cegep cegep)
        {
            if (id != cegep.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cegep);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CegepExists(cegep.Id))
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
            return View(cegep);
        }

        // GET: Cegeps/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Cegep == null)
            {
                return NotFound();
            }

            var cegep = await _context.Cegep
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cegep == null)
            {
                return NotFound();
            }

            return View(cegep);
        }

        // POST: Cegeps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Cegep == null)
            {
                return Problem("Entity set 'GestionCEGEPContext.Cegep'  is null.");
            }
            var cegep = await _context.Cegep.FindAsync(id);
            if (cegep != null)
            {
                _context.Cegep.Remove(cegep);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CegepExists(int id)
        {
          return _context.Cegep.Any(e => e.Id == id);
        }
    }
}
