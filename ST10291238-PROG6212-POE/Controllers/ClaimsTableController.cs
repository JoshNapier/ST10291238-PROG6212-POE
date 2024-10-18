using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ST10291238_PROG6212_POE.Data;
using ST10291238_PROG6212_POE.Models;
using System.Security.Claims;

namespace ST10291238_PROG6212_POE.Controllers
{
    public class ClaimsTableController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ClaimsTableController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Submit(ClaimsTable claim, IFormFile supportingDocuments)
        {
            if (supportingDocuments != null && supportingDocuments.Length > 0)
            {
                var uploadsPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads");
                var fileName = Path.GetFileName(supportingDocuments.FileName);

                if (!Directory.Exists(uploadsPath))
                {
                    Directory.CreateDirectory(uploadsPath);
                }

                var filePath = Path.Combine(uploadsPath, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await supportingDocuments.CopyToAsync(stream);
                }

                claim.Documents = "/uploads/" + fileName;

                claim.ClaimAmount = claim.HourlyRate * claim.HoursWorked;

                claim.Status = "Pending";
                _context.Claims.Add(claim);
                await _context.SaveChangesAsync();

                return RedirectToAction("MyClaims");
            }

            return View(claim);
        }
    }
}
