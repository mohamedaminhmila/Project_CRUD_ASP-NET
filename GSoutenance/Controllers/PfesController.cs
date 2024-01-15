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
    public class PfesController : Controller
    {
        private readonly SoutenanceContext _context;

        public PfesController(SoutenanceContext context)
        {
            _context = context;
        }

        // GET: Pfes
        public async Task<IActionResult> Index()
        {
            var soutenanceContext = _context.Pfe.Include(p => p.Encadrant).Include(p => p.Societe);
            return View(await soutenanceContext.ToListAsync());
        }





        public async Task<IActionResult> Search(string searchString)
        {
            var query = _context.Pfe
                .Include(pe => pe.Encadrant)
                .Include(pe => pe.Societe)
            
                .Where(pe => pe.Encadrant != null); // Assurez-vous que l'étudiant n'est pas null

            if (!string.IsNullOrEmpty(searchString))
            {
                // Modifiez la condition pour rechercher à la fois le nom et le prénom
                query = query.Where(pe =>
                    pe.Encadrant.Nom.Contains(searchString) ||
                    pe.Societe.LibSociete.Contains(searchString));
            }

            var pfeEtudiants = await query.ToListAsync();
            return View("Index", pfeEtudiants);
        }








        // GET: Pfes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pfe = await _context.Pfe
                .Include(p => p.Encadrant)
                .Include(p => p.Societe)
                .FirstOrDefaultAsync(m => m.PFEID == id);
            if (pfe == null)
            {
                return NotFound();
            }

            return View(pfe);
        }

        // GET: Pfes/Create
        public IActionResult Create()
        {
            ViewData["EncadrantID"] = new SelectList(_context.Ensignant, "EncadreurID", "Nom");
            ViewData["SocieteID"] = new SelectList(_context.Set<Societe>(), "SocieteID", "Adresse");
            return View();
        }

        // POST: Pfes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PFEID,titre,desc,Dated,DateF,EncadrantID,SocieteID")] Pfe pfe)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pfe);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EncadrantID"] = new SelectList(_context.Ensignant, "EncadreurID", "Nom", pfe.EncadrantID);
            ViewData["SocieteID"] = new SelectList(_context.Set<Societe>(), "SocieteID", "Adresse", pfe.SocieteID);
            return View(pfe);
        }

        // GET: Pfes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pfe = await _context.Pfe.FindAsync(id);
            if (pfe == null)
            {
                return NotFound();
            }
            ViewData["EncadrantID"] = new SelectList(_context.Ensignant, "EncadreurID", "Nom", pfe.EncadrantID);
            ViewData["SocieteID"] = new SelectList(_context.Set<Societe>(), "SocieteID", "Adresse", pfe.SocieteID);
            return View(pfe);
        }

        // POST: Pfes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PFEID,titre,desc,Dated,DateF,EncadrantID,SocieteID")] Pfe pfe)
        {
            if (id != pfe.PFEID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pfe);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PfeExists(pfe.PFEID))
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
            ViewData["EncadrantID"] = new SelectList(_context.Ensignant, "EncadreurID", "Nom", pfe.EncadrantID);
            ViewData["SocieteID"] = new SelectList(_context.Set<Societe>(), "SocieteID", "Adresse", pfe.SocieteID);
            return View(pfe);
        }

        // GET: Pfes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pfe = await _context.Pfe
                .Include(p => p.Encadrant)
                .Include(p => p.Societe)
                .FirstOrDefaultAsync(m => m.PFEID == id);
            if (pfe == null)
            {
                return NotFound();
            }

            return View(pfe);
        }

        // POST: Pfes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pfe = await _context.Pfe.FindAsync(id);
            if (pfe != null)
            {
                _context.Pfe.Remove(pfe);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PfeExists(int id)
        {
            return _context.Pfe.Any(e => e.PFEID == id);
        }
    }
}
