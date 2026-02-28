using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SampleCrudMVC.Data;
using SampleCrudMVC.Models;

namespace SampleCrudMVC.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EmployeesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Employees
        public async Task<IActionResult> Index()
        {
            return View(await _context.Employees.ToListAsync());
        }

        // GET: Employees/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return View("NotFound");
            }

            var employee = await _context.Employees
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employee == null)
            {
                return View("NotFound");
            }

            return View(employee);
        }

        // GET: Employees/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,MiddleName,LastName,PhoneNumber,EmailAdress,Gender,Country,Position")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(employee);
        }

        // GET: Employees/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return View("NotFound");
            }

            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                return View("NotFound");
            }
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,MiddleName,LastName,PhoneNumber,EmailAdress,Gender,Country")] Employee employee)
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

        // GET: Employees/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee != null)
            {
                _context.Employees.Remove(employee);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeExists(int id)
        {
            return _context.Employees.Any(e => e.Id == id);
        }
        // GET: Показва празната страница за търсене
        public IActionResult Search()
        {
            var model = new EmployeeSearchVM()
            {
                Results = new List<Employee>()
            };
            return View(model);
        }

        // POST: Изпълнява търсенето
        [HttpPost]
        public async Task<IActionResult> Search(EmployeeSearchVM model)
        {
            var query = _context.Employees.AsQueryable();

            if (!string.IsNullOrEmpty(model.Name))
            {
                query = query.Where(e => e.FirstName.Contains(model.Name) || e.LastName.Contains(model.Name));
            }

           

            model.Results = await query.ToListAsync();
            return View(model);
        }


        public async Task<IActionResult> Statistics()
        {
            var employees = await _context.Employees.ToListAsync();

            var stats = new EmployeeStatisticsVM
            {
                TotalEmployees = employees.Count,
                MaleEmployees = employees.Count(e => e.Gender == "Male"),
                FemaleEmployees = employees.Count(e => e.Gender == "Female"),
                TopCountry = employees.GroupBy(e => e.Country)
                                      .OrderByDescending(g => g.Count())
                                      .Select(g => g.Key)
                                      .FirstOrDefault() ?? "N/A"
            };

            return View(stats);
        }
    }
}
