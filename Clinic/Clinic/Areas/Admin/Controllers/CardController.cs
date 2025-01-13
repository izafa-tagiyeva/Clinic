using Clinic.DataAccessLayer;
using Clinic.FileExtension;
using Clinic.Models;
using Clinic.ViewModels.Card;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Clinic.Areas.Admin.Controllers
{
    [Area("Admin")]
    //[Authorize]
    public class CardController(ClininCDbContext _context, IWebHostEnvironment _env) : Controller
    {
       
        public async Task<IActionResult> Index()
        {

            return View(await _context.Doctors.Include(x => x.Department).ToListAsync());

        }


        public async Task<IActionResult> Create()
        {
            ViewBag.Departments = await _context.Departments.Where(x => !x.IsDeleted).ToListAsync(); /////////////////////////////
            return View();

        }


        [HttpPost]
        public async Task<IActionResult> Create(CardCreateVM vm)
        {
            if (!ModelState.IsValid) return  View(vm);
            string newFileName = await vm.CoverFile.UploadAsync("wwwroot", "imgs", "Cards");
            Doctors doctor = new Doctors 
            { 
                 Name = vm.Name,
                 Surname = vm.Surname,
                 DepartmentId = vm.DepartmentId,    
                 CoverImage = newFileName
            };

            await _context.Doctors.AddAsync(doctor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }


        [HttpPost]
        public async Task<IActionResult> Update (int id ,CardUpdateVM vm)
        {
            Doctors doctor = await _context.Doctors.FindAsync(id);
            if (doctor == null) return NotFound();
            string newFileName = await vm.CoverFile.UploadAsync(_env.WebRootPath, "imgs", "products");
             doctor.CoverImage = newFileName;
            if (!ModelState.IsValid) return View(vm);

            doctor.Name = vm.Name;  
            doctor.Surname = vm.Surname;
            doctor.DepartmentId = vm.DepartmentId;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }

        public async Task<IActionResult> Delete (int id)
        {

            Doctors doctor = await _context.Doctors.FindAsync(id);
            if (doctor is null) return NotFound();
              _context.Doctors.Remove(doctor);  
              await _context.SaveChangesAsync();

              return RedirectToAction(nameof(Index));

        }



    }
}
