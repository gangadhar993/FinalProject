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
    public class DegreesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DegreesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Degrees
        public async Task<IActionResult> Index(String sortOrder,String searchString)
        {


            ViewData["DegreeAbbrev"] = String.IsNullOrEmpty(sortOrder) ? "DegreeAbbrev" : "";
            ViewData["DegreeName"] = String.IsNullOrEmpty(sortOrder) ? "DegreeName" : "";
            ViewData["NumberOFTerms"] = String.IsNullOrEmpty(sortOrder) ? "NumberOFTerms" : "";
            ViewData["DegreeID"] = String.IsNullOrEmpty(sortOrder) ? "DegreeID" : "";
            ViewData["DateSortParm"] = sortOrder == "Date" ? "date_desc" : "Date";
            ViewData["CurrentFilter"] = searchString;
            var degrees = from d in _context.Degrees
                          select d;
            if (!String.IsNullOrEmpty(searchString))
            {
                degrees = degrees.Where(s => s.DegreeName.Contains(searchString)
                                       || s.DegreeAbbrev.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "DegreeAbbrev":
                    degrees = degrees.OrderByDescending(d => d.DegreeAbbrev);
                    break;
                case "DegreeName":
                    degrees = degrees.OrderByDescending(d => d.DegreeName);
                    break;
                case "NumberOFTerms":
                    degrees = degrees.OrderByDescending(d => d.NumberOFTerms);
                    break;
                case "DegreeID":
                    degrees = degrees.OrderByDescending(d => d.DegreeID);
                    break;
            }
            return View(await degrees.AsNoTracking().ToListAsync());
        }

        // GET: Degrees/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var degree = await _context.Degrees
                .FirstOrDefaultAsync(m => m.DegreeID == id);
            if (degree == null)
            {
                return NotFound();
            }

            return View(degree);
        }

        // GET: Degrees/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Degrees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DegreeID,DegreeAbbrev,DegreeName,NumberOFTerms")] Degree degree)
        {
            if (ModelState.IsValid)
            {
                _context.Add(degree);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(degree);
        }

        // GET: Degrees/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var degree = await _context.Degrees.FindAsync(id);
            if (degree == null)
            {
                return NotFound();
            }
            return View(degree);
        }

        // POST: Degrees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DegreeID,DegreeAbbrev,DegreeName,NumberOFTerms")] Degree degree)
        {
            if (id != degree.DegreeID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(degree);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DegreeExists(degree.DegreeID))
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
            return View(degree);
        }

        // GET: Degrees/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var degree = await _context.Degrees
                .FirstOrDefaultAsync(m => m.DegreeID == id);
            if (degree == null)
            {
                return NotFound();
            }

            return View(degree);
        }

        // POST: Degrees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var degree = await _context.Degrees.FindAsync(id);
            _context.Degrees.Remove(degree);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DegreeExists(int id)
        {
            return _context.Degrees.Any(e => e.DegreeID == id);
        }
    }
}
