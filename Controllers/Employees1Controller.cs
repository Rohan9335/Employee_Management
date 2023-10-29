using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication3.Data;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class Employees1Controller : Controller
    {
        private readonly EmpContext _context;

        public Employees1Controller(EmpContext context)
        {
            _context = context;
        }

        // GET: Employees1
        public async Task<IActionResult> Index()
        {
              return _context.Employee1 != null ? 
                          View(await _context.Employee1.ToListAsync()) :
                          Problem("Entity set 'EmpContext.Employee1'  is null.");
        }

        // GET: Employees1/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Employee1 == null)
            {
                return NotFound();
            }

            var employee = await _context.Employee1
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // GET: Employees1/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Employees1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Email,Salary,DataOfBirth,Department")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(employee);
        }

        // GET: Employees1/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Employee1 == null)
            {
                return NotFound();
            }

            var employee = await _context.Employee1.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        // POST: Employees1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Email,Salary,DataOfBirth,Department")] Employee employee)
        {
            if (id != employee.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeExists(employee.Id))
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
            return View(employee);
        }

        // GET: Employees1/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Employee1 == null)
            {
                return NotFound();
            }

            var employee = await _context.Employee1
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // POST: Employees1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Employee1 == null)
            {
                return Problem("Entity set 'EmpContext.Employee1'  is null.");
            }
            var employee = await _context.Employee1.FindAsync(id);
            if (employee != null)
            {
                _context.Employee1.Remove(employee);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeExists(int id)
        {
          return (_context.Employee1?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
