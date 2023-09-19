using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CalisanTakip.Models;

namespace CalisanTakip.Controllers
{
    public class WorkHoursController : Controller
    {
        private readonly CalisanTakipContext _context;

        public WorkHoursController(CalisanTakipContext context)
        {
            _context = context;
        }

        // GET: WorkHours
        public async Task<IActionResult> Index()
        {
            var calisanTakipContext = _context.WorkHours.Include(w => w.Employee);
            return View(await calisanTakipContext.ToListAsync());
        }

        // GET: WorkHours/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.WorkHours == null)
            {
                return NotFound();
            }

            var workHour = await _context.WorkHours
                .Include(w => w.Employee)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (workHour == null)
            {
                return NotFound();
            }

            return View(workHour);
        }

        // GET: WorkHours/Create
        public IActionResult Create()
        {
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "Id");
            return View();
        }

        // POST: WorkHours/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,EmployeeId,WorkDate,EntryTime,ExitTime")] WorkHour workHour)
        {
            if (ModelState.IsValid)
            {
                _context.Add(workHour);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "Id", workHour.EmployeeId);
            return View(workHour);
        }

        // GET: WorkHours/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.WorkHours == null)
            {
                return NotFound();
            }

            var workHour = await _context.WorkHours.FindAsync(id);
            if (workHour == null)
            {
                return NotFound();
            }
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "Id", workHour.EmployeeId);
            return View(workHour);
        }

        // POST: WorkHours/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,EmployeeId,WorkDate,EntryTime,ExitTime")] WorkHour workHour)
        {
            if (id != workHour.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(workHour);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WorkHourExists(workHour.Id))
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
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "Id", workHour.EmployeeId);
            return View(workHour);
        }

        // GET: WorkHours/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.WorkHours == null)
            {
                return NotFound();
            }

            var workHour = await _context.WorkHours
                .Include(w => w.Employee)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (workHour == null)
            {
                return NotFound();
            }

            return View(workHour);
        }

        // POST: WorkHours/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.WorkHours == null)
            {
                return Problem("Entity set 'CalisanTakipContext.WorkHours'  is null.");
            }
            var workHour = await _context.WorkHours.FindAsync(id);
            if (workHour != null)
            {
                _context.WorkHours.Remove(workHour);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WorkHourExists(int id)
        {
          return (_context.WorkHours?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
