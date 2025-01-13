using Clinic.DataAccessLayer;
using Clinic.Models;
using Clinic.ViewModels.Department;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Clinic.Areas.Admin.Controllers
{
    [Area("Admin")]
    //[Authorize]
    public class DepartmentController(ClininCDbContext _context) : Controller
    {
        public async Task<IActionResult> Index()
        {
            return View(await _context.Departments.ToListAsync());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(DepartmentCreateVM vm) 
        {
            if (!ModelState.IsValid) return View();
            
              Department department = new Department
              {
                  DepartmentName= vm.DepartmentName,

              };
            await _context.AddAsync(department);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index)); 
        
        }



    }
}
