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
    public class DegreePlansController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DegreePlansController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: DegreePlans
        public async Task<IActionResult> Index(String sortOrder,String searchString)
        {


            ViewData["DegreePlanID"] = String.IsNullOrEmpty(sortOrder) ? "DegreePlanID" : "";
            ViewData["StudentID"] = String.IsNullOrEmpty(sortOrder) ? "StudentID" : "";
            ViewData["DegreePlanAbbrev"] = String.IsNullOrEmpty(sortOrder) ? "DegreePlanAbbrev" : "";
            ViewData["DegreePlanName"] = String.IsNullOrEmpty(sortOrder) ? "DegreePlanName" : "";
            ViewData["DegreeID"] = String.IsNullOrEmpty(sortOrder) ? "DegreeID" : "";
            ViewData["DateSortParm"] = sortOrder == "Date" ? "date_desc" : "Date";
            ViewData["CurrentFilter"] = searchString;
            var degreePlan = from dp in _context.DegreePlans
                          select dp;
            if (!String.IsNullOrEmpty(searchString))
            {
                degreePlan = degreePlan.Where(s => s.DegreePlanName.Contains(searchString)
                                       || s.DegreePlanAbbrev.Contains(searchString)||
                                       s.DegreePlanAbbrev.Contains(searchString)
                                       || s.StudentID.ToString().Contains(searchString)
                                       || s.DegreeID.ToString().Contains(searchString));
            }
            switch (sortOrder)
            {
                case "DegreePlanID":
                    degreePlan = degreePlan.OrderByDescending(dp => dp.DegreePlanID);
                    break;
                case "StudentID":
                    degreePlan = degreePlan.OrderByDescending(dp => dp.StudentID);
                    break;
                case "DegreePlanAbbrev":
                    degreePlan = degreePlan.OrderBy(dp => dp.DegreePlanAbbrev);
                    break;
                case "DegreePlanName":
                    degreePlan = degreePlan.OrderByDescending(dp => dp.DegreePlanName);
                    break;
                case "DegreeID":
                    degreePlan = degreePlan.OrderBy(dp => dp.DegreeID);
                    break;
            }
            return View(await degreePlan.AsNoTracking().ToListAsync());
        }

        // GET: DegreePlans/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var degreePlan = await _context.DegreePlans
                .Include(d => d.Degree)
                .Include(d => d.Student)
                .FirstOrDefaultAsync(m => m.DegreePlanID == id);
            if (degreePlan == null)
            {
                return NotFound();
            }

            return View(degreePlan);
        }

        // GET: DegreePlans/Create
        public IActionResult Create()
        {
            ViewData["DegreeID"] = new SelectList(_context.Degrees, "DegreeID", "DegreeID");
            ViewData["StudentID"] = new SelectList(_context.Students, "StudentID", "StudentID");
            return View();
        }

        // POST: DegreePlans/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DegreePlanID,StudentID,DegreePlanAbbrev,DegreePlanName,DegreeID")] DegreePlan degreePlan)
        {
            if (ModelState.IsValid)
            {
                _context.Add(degreePlan);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DegreeID"] = new SelectList(_context.Degrees, "DegreeID", "DegreeID", degreePlan.DegreeID);
            ViewData["StudentID"] = new SelectList(_context.Students, "StudentID", "StudentID", degreePlan.StudentID);
            return View(degreePlan);
        }

        // GET: DegreePlans/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var degreePlan = await _context.DegreePlans
                .Include(p => p.Degree).ThenInclude(pd => pd.DegreeCredits)
                .Include(p => p.Student)
                .Include(p => p.StudentTerms).ThenInclude(pt => pt.Slots)
                .SingleOrDefaultAsync(m => m.DegreePlanID == id);

            if (degreePlan == null)
            {
                return NotFound();
            }
            ViewData["DegreeID"] = new SelectList(_context.Degrees, "DegreeID", "DegreeID", degreePlan.DegreeID);
            ViewData["StudentID"] = new SelectList(_context.Students, "StudentID", "StudentID", degreePlan.StudentID);
            return View(degreePlan);
        }

        // POST: DegreePlans/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DegreePlanID,StudentID,DegreePlanAbbrev,DegreePlanName,DegreeID")] DegreePlan degreePlan)
        {
            if (id != degreePlan.DegreePlanID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(degreePlan);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DegreePlanExists(degreePlan.DegreePlanID))
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
            ViewData["DegreeID"] = new SelectList(_context.Degrees, "DegreeID", "DegreeID", degreePlan.DegreeID);
            ViewData["StudentID"] = new SelectList(_context.Students, "StudentID", "StudentID", degreePlan.StudentID);
            return View(degreePlan);
        }

        // GET: DegreePlans/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var degreePlan = await _context.DegreePlans
                .Include(d => d.Degree)
                .Include(d => d.Student)
                .FirstOrDefaultAsync(m => m.DegreePlanID == id);
            if (degreePlan == null)
            {
                return NotFound();
            }

            return View(degreePlan);
        }

        // POST: DegreePlans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var degreePlan = await _context.DegreePlans.FindAsync(id);
            _context.DegreePlans.Remove(degreePlan);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DegreePlanExists(int id)
        {
            return _context.DegreePlans.Any(e => e.DegreePlanID == id);
        }
    }
}
