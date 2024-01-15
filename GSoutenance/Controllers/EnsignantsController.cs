using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GSoutenance.Models;

namespace GSoutenance.Controllers
{
    public class EnsignantsController : Controller
    {
        private readonly SoutenanceContext _context;

        public EnsignantsController(SoutenanceContext context)
        {
            _context = context;
        }

        // GET: Ensignants
        public async Task<IActionResult> Index()
        {
            return View(await _context.Ensignant.ToListAsync());
        }




        public async Task<IActionResult> Search(string searchString)
        {
            var query = _context.Ensignant.AsQueryable();

            if (!string.IsNullOrEmpty(searchString))
            {
                query = query.Where(e => e.Nom.Contains(searchString)
                                      || e.Prenom.Contains(searchString));
            }

            var Ensignants = await query.ToListAsync();
            return View("Index", Ensignants);
        }








        // GET: Ensignants/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ensignant = await _context.Ensignant
                .FirstOrDefaultAsync(m => m.EncadreurID == id);
            if (ensignant == null)
            {
                return NotFound();
            }

            return View(ensignant);
        }

        // GET: Ensignants/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Ensignants/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EncadreurID,Nom,Prenom")] Ensignant ensignant)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ensignant);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ensignant);
        }

        // GET: Ensignants/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ensignant = await _context.Ensignant.FindAsync(id);
            if (ensignant == null)
            {
                return NotFound();
            }
            return View(ensignant);
        }

        // POST: Ensignants/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EncadreurID,Nom,Prenom")] Ensignant ensignant)
        {
            if (id != ensignant.EncadreurID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ensignant);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EnsignantExists(ensignant.EncadreurID))
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
            return View(ensignant);
        }

        // GET: Ensignants/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ensignant = await _context.Ensignant
                .FirstOrDefaultAsync(m => m.EncadreurID == id);
            if (ensignant == null)
            {
                return NotFound();
            }

            return View(ensignant);
        }

        // POST: Ensignants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ensignant = await _context.Ensignant.FindAsync(id);
            if (ensignant != null)
            {
                _context.Ensignant.Remove(ensignant);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EnsignantExists(int id)
        {
            return _context.Ensignant.Any(e => e.EncadreurID == id);
        }
    }
}
