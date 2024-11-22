using Microsoft.AspNetCore.Mvc;
using ST10291238_PROG6212_POE.Data;
using ST10291238_PROG6212_POE.Models;

namespace ST10291238_PROG6212_POE.Controllers
{
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdminController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult ManageLecturers()
        {
            var lecturers = _context.Lecturers.ToList();
            return View(lecturers);
        }

        [HttpPost]
        public async Task<IActionResult> AddLecturer(Lecturer lecturer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lecturer);
                await _context.SaveChangesAsync();
                return RedirectToAction("ManageLecturers");
            }
            return View(lecturer);
        }
    }
}
