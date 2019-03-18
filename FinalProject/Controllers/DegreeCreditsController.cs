using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FinalProject.Data;

namespace FinalProject.Controllers
{
    public class DegreeCreditsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DegreeCreditsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: DegreeCredits
        public async Task<IActionResult> Index(String sortOrder, String searchString)
        {


            ViewData["DegreeCreditID"] = String.IsNullOrEmpty(sortOrder) ? "DegreeCreditID" : "";
            ViewData["CreditID"] = String.IsNullOrEmpty(sortOrder) ? "CreditID" : "";
            ViewData["DegreeID"] = String.IsNullOrEmpty(sortOrder) ? "DegreeID" : "";
            ViewData["DateSortParm"] = sortOrder == "Date" ? "date_desc" : "Date";
            var DegreeCredits = from c in _context.DegreeCredit
                          select c;
            if (!String.IsNullOrEmpty(searchString))
            {
                DegreeCredits = DegreeCredits.Where(s => s.CreditID.ToString().Contains(searchString)
                                       || s.DegreeCreditID.ToString().Contains(searchString)|| s.DegreeID.ToString().Contains(searchString));
            }
            switch (sortOrder)
            {
                case "DegreeCreditID":
                    DegreeCredits = DegreeCredits.OrderBy(c => c.DegreeCreditID);
                    break;
                case "CreditID":
                    DegreeCredits = DegreeCredits.OrderByDescending(c => c.CreditID);
                    break;
                case "DegreeID":
                    DegreeCredits = DegreeCredits.OrderByDescending(c => c.DegreeID);
                    break;
         
            }
            return View(await DegreeCredits.AsNoTracking().ToListAsync());
        }

        // GET: DegreeCredits/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var degreeCredit = await _context.DegreeCredit
                .Include(d => d.Credit)
                .Include(d => d.Degree)
                .FirstOrDefaultAsync(m => m.DegreeCreditID == id);
            if (degreeCredit == null)
            {
                return NotFound();
            }

            return View(degreeCredit);
        }

        // GET: DegreeCredits/Create
        public IActionResult Create()
        {
            ViewData["CreditID"] = new SelectList(_context.Credits, "CreditID", "CreditID");
            ViewData["DegreeID"] = new SelectList(_context.Degrees, "DegreeID", "DegreeID");
            return View();
        }

        // POST: DegreeCredits/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DegreeCreditID,DegreeID,CreditID")] DegreeCredit degreeCredit)
        {
            if (ModelState.IsValid)
            {
                _context.Add(degreeCredit);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CreditID"] = new SelectList(_context.Credits, "CreditID", "CreditID", degreeCredit.CreditID);
            ViewData["DegreeID"] = new SelectList(_context.Degrees, "DegreeID", "DegreeID", degreeCredit.DegreeID);
            return View(degreeCredit);
        }

        // GET: DegreeCredits/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var degreeCredit = await _context.DegreeCredit.FindAsync(id);
            if (degreeCredit == null)
            {
                return NotFound();
            }
            ViewData["CreditID"] = new SelectList(_context.Credits, "CreditID", "CreditID", degreeCredit.CreditID);
            ViewData["DegreeID"] = new SelectList(_context.Degrees, "DegreeID", "DegreeID", degreeCredit.DegreeID);
            return View(degreeCredit);
        }

        // POST: DegreeCredits/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DegreeCreditID,DegreeID,CreditID")] DegreeCredit degreeCredit)
        {
            if (id != degreeCredit.DegreeCreditID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(degreeCredit);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DegreeCreditExists(degreeCredit.DegreeCreditID))
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
            ViewData["CreditID"] = new SelectList(_context.Credits, "CreditID", "CreditID", degreeCredit.CreditID);
            ViewData["DegreeID"] = new SelectList(_context.Degrees, "DegreeID", "DegreeID", degreeCredit.DegreeID);
            return View(degreeCredit);
        }

        // GET: DegreeCredits/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var degreeCredit = await _context.DegreeCredit
                .Include(d => d.Credit)
                .Include(d => d.Degree)
                .FirstOrDefaultAsync(m => m.DegreeCreditID == id);
            if (degreeCredit == null)
            {
                return NotFound();
            }

            return View(degreeCredit);
        }

        // POST: DegreeCredits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var degreeCredit = await _context.DegreeCredit.FindAsync(id);
            _context.DegreeCredit.Remove(degreeCredit);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DegreeCreditExists(int id)
        {
            return _context.DegreeCredit.Any(e => e.DegreeCreditID == id);
        }
    }
}
