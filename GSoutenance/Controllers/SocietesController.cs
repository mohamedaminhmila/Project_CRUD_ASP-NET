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
    public class SocietesController : Controller
    {
        private readonly SoutenanceContext _context;

        public SocietesController(SoutenanceContext context)
        {
            _context = context;
        }

        // GET: Societes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Societe.ToListAsync());
        }




        public async Task<IActionResult> Search(string searchString)
        {
            var query = _context.Societe.AsQueryable();

            if (!string.IsNullOrEmpty(searchString))
            {
                query = query.Where(e => e.LibSociete.Contains(searchString)
                                      || e.Adresse.Contains(searchString));
            }

            var Societes = await query.ToListAsync();
            return View("Index", Societes);
        }










        // GET: Societes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var societe = await _context.Societe
                .FirstOrDefaultAsync(m => m.SocieteID == id);
            if (societe == null)
            {
                return NotFound();
            }

            return View(societe);
        }

        // GET: Societes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Societes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SocieteID,LibSociete,Adresse,Tel")] Societe societe)
        {
            if (ModelState.IsValid)
            {
                _context.Add(societe);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(societe);
        }

        // GET: Societes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var societe = await _context.Societe.FindAsync(id);
            if (societe == null)
            {
                return NotFound();
            }
            return View(societe);
        }

        // POST: Societes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SocieteID,LibSociete,Adresse,Tel")] Societe societe)
        {
            if (id != societe.SocieteID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(societe);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SocieteExists(societe.SocieteID))
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
            return View(societe);
        }

        // GET: Societes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var societe = await _context.Societe
                .FirstOrDefaultAsync(m => m.SocieteID == id);
            if (societe == null)
            {
                return NotFound();
            }

            return View(societe);
        }

        // POST: Societes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var societe = await _context.Societe.FindAsync(id);
            if (societe != null)
            {
                _context.Societe.Remove(societe);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SocieteExists(int id)
        {
            return _context.Societe.Any(e => e.SocieteID == id);
        }
    }
}
