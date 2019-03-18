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
    public class CreditsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CreditsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Credits
        public async Task<IActionResult> Index(String sortOrder, String searchString)
        {


            ViewData["CreditName"] = String.IsNullOrEmpty(sortOrder) ? "CreditName" : "";
            ViewData["CreditAbbrev"] = String.IsNullOrEmpty(sortOrder) ? "CreditAbbrev" : "";
            ViewData["CreditID"] = String.IsNullOrEmpty(sortOrder) ? "CreditID" : "";
            ViewData["IsSummer"] = String.IsNullOrEmpty(sortOrder) ? "IsSummer" : "";
            ViewData["IsSpring"] = String.IsNullOrEmpty(sortOrder) ? "IsSpring" : "";
            ViewData["IsFall"] = String.IsNullOrEmpty(sortOrder) ? "IsFall" : "";

            ViewData["CurrentFilter"] = searchString;
            var credits = from c in _context.Credits
                           select c;
            if (!String.IsNullOrEmpty(searchString))
            {
                credits = credits.Where(s => s.CreditName.Contains(searchString)
                                       || s.CreditAbbrev.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "CreditName":
                    credits = credits.OrderByDescending(c => c.CreditName);
                    break;
                case "IsFall":
                    credits = credits.OrderByDescending(c =>c.IsFall );
                    break;
                case "IsSpring":
                    credits = credits.OrderByDescending(c=>c.IsSpring);
                    break;
                case "IsSummer":
                    credits = credits.OrderByDescending(c => c.IsSummer);
                    break;
                case "CreditAbbrev":
                    credits = credits.OrderByDescending(c => c.CreditAbbrev);
                    break;
                case "CreditID":
                    credits = credits.OrderByDescending(c => c.CreditID);
                    break;
            }
            return View(await credits.AsNoTracking().ToListAsync());
        }

        // GET: Credits/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var credit = await _context.Credits
                .FirstOrDefaultAsync(m => m.CreditID == id);
            if (credit == null)
            {
                return NotFound();
            }

            return View(credit);
        }

        // GET: Credits/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Credits/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CreditID,CreditAbbrev,CreditName,IsSummer,IsSpring,IsFall")] Credit credit)
        {
            if (ModelState.IsValid)
            {
                _context.Add(credit);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(credit);
        }

        // GET: Credits/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var credit = await _context.Credits.FindAsync(id);
            if (credit == null)
            {
                return NotFound();
            }
            return View(credit);
        }

        // POST: Credits/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CreditID,CreditAbbrev,CreditName,IsSummer,IsSpring,IsFall")] Credit credit)
        {
            if (id != credit.CreditID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(credit);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CreditExists(credit.CreditID))
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
            return View(credit);
        }

        // GET: Credits/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var credit = await _context.Credits
                .FirstOrDefaultAsync(m => m.CreditID == id);
            if (credit == null)
            {
                return NotFound();
            }

            return View(credit);
        }

        // POST: Credits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var credit = await _context.Credits.FindAsync(id);
            _context.Credits.Remove(credit);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CreditExists(int id)
        {
            return _context.Credits.Any(e => e.CreditID == id);
        }
    }
}
