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
            var validationService = new ValidationService(_context);

            if (!validationService.ValidateClaim(claim, out string validationError))
            {
                ModelState.AddModelError(string.Empty, validationError);
                return View(claim);
            }

            if (supportingDocuments != null && supportingDocuments.Length > 0)
            {
                var uploadsPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads");
                if (!Directory.Exists(uploadsPath))
                {
                    Directory.CreateDirectory(uploadsPath);
                }

                var fileName = Path.GetFileName(supportingDocuments.FileName);
                var filePath = Path.Combine(uploadsPath, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await supportingDocuments.CopyToAsync(stream);
                }

                claim.Documents = "/uploads/" + fileName;

                //if (supportingDocuments != null && supportingDocuments.Length > 0)
                //{
                //    var uploadsPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads");
                //    var fileName = Path.GetFileName(supportingDocuments.FileName);

                //    if (!Directory.Exists(uploadsPath))
                //    {
                //        Directory.CreateDirectory(uploadsPath);
                //    }

                //    var filePath = Path.Combine(uploadsPath, fileName);

                //    using (var stream = new FileStream(filePath, FileMode.Create))
                //    {
                //        await supportingDocuments.CopyToAsync(stream);
                //    }

                //    claim.Documents = "/uploads/" + fileName;

                //    claim.ClaimAmount = claim.HourlyRate * claim.HoursWorked;

                //    claim.Status = "Pending";
                //    _context.Claims.Add(claim);
                //    await _context.SaveChangesAsync();

                //    return RedirectToAction("MyClaims");
                //}

                //return View(claim);
            }

            claim.ClaimAmount = claim.HourlyRate * claim.HoursWorked;
            claim.Status = "Pending";

            _context.Claims.Add(claim);
            await _context.SaveChangesAsync();

            return RedirectToAction("MyClaims");
        }

        [HttpPost]
        public async Task<IActionResult> ApproveClaim(int id)
        {
            var claim = await _context.Claims.FindAsync(id);
            if (claim == null)
            {
                return NotFound();
            }

            claim.Status = "Approved";
            await _context.SaveChangesAsync();

            return RedirectToAction("Approvals");
        }

        [HttpPost]
        public async Task<IActionResult> RejectClaim(int id, string rejectionReason)
        {
            var claim = await _context.Claims.FindAsync(id);
            if (claim == null) return NotFound();

            claim.Status = "Rejected";
            claim.RejectionReason = rejectionReason; // Store rejection reason
            await _context.SaveChangesAsync();

            return RedirectToAction("Approvals");
        }
    }
}
