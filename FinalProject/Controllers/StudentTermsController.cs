﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FinalProject.Data;


namespace FinalProject.Controllers
{
    public class StudentTermsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StudentTermsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: StudentTerms
        public async Task<IActionResult> Index(String sortOrder, String searchString)
        {


            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "DegreePlanId" : "";
            ViewData["TermSortParm"] = String.IsNullOrEmpty(sortOrder) ? "Term" : "";
            ViewData["StudentTermID"] = String.IsNullOrEmpty(sortOrder) ? "StudentTermID" : "";
            ViewData["TermAbbrev"] = String.IsNullOrEmpty(sortOrder) ? "TermAbbrev" : "";
            ViewData["TermName"] = String.IsNullOrEmpty(sortOrder) ? "TermName" : "";
            ViewData["CurrentFilter"] = searchString;
            var studentTerms = from st in _context.StudentTerms
                          select st;
            if (!String.IsNullOrEmpty(searchString))
            {
                studentTerms = studentTerms.Where(s => s.TermName.Contains(searchString)
                                       || s.TermAbbrev.Contains(searchString)|| s.StudentTermID.ToString().Contains(searchString)|| s.Term.ToString().Contains(searchString));
            }
            switch (sortOrder)
            {
                case "DegreePlanId":
                    studentTerms = studentTerms.OrderByDescending(st => st.DegreePlanId);
                    break;
                case "StudentTermID":
                    studentTerms = studentTerms.OrderByDescending(st => st.StudentTermID);
                    break;
                case "Term":
                    studentTerms = studentTerms.OrderByDescending(st=>st.Term);
                    break;
                case "TermAbbrev":
                    studentTerms = studentTerms.OrderByDescending(st => st.TermAbbrev);
                    break;

                case "TermName":
                    studentTerms = studentTerms.OrderByDescending(st => st.TermName);
                    break;

            }
            return View(await studentTerms.AsNoTracking().ToListAsync());
        }

        // GET: StudentTerms/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentTerm = await _context.StudentTerms
                .FirstOrDefaultAsync(m => m.StudentTermID == id);
            if (studentTerm == null)
            {
                return NotFound();
            }

            return View(studentTerm);
        }

        // GET: StudentTerms/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: StudentTerms/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StudentTermID,DegreePlanId,Term,TermAbbrev,TermName")] StudentTerm studentTerm)
        {
            if (ModelState.IsValid)
            {
                _context.Add(studentTerm);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(studentTerm);
        }

        // GET: StudentTerms/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentTerm = await _context.StudentTerms.FindAsync(id);
            if (studentTerm == null)
            {
                return NotFound();
            }
            return View(studentTerm);
        }

        // POST: StudentTerms/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StudentTermID,DegreePlanId,Term,TermAbbrev,TermName")] StudentTerm studentTerm)
        {
            if (id != studentTerm.StudentTermID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(studentTerm);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentTermExists(studentTerm.StudentTermID))
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
            return View(studentTerm);
        }

        // GET: StudentTerms/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentTerm = await _context.StudentTerms
                .FirstOrDefaultAsync(m => m.StudentTermID == id);
            if (studentTerm == null)
            {
                return NotFound();
            }

            return View(studentTerm);
        }

        // POST: StudentTerms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var studentTerm = await _context.StudentTerms.FindAsync(id);
            _context.StudentTerms.Remove(studentTerm);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentTermExists(int id)
        {
            return _context.StudentTerms.Any(e => e.StudentTermID == id);
        }
    }
}
