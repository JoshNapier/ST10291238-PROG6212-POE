using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ST10291238_PROG6212_POE.Data;
using ST10291238_PROG6212_POE.Models;
using System.Diagnostics;

namespace ST10291238_PROG6212_POE.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Submit()
        {
            return View();
        }

        //public async Task<IActionResult> Submit(ClaimsTable claim, IFormFile supportingDocuments)
        //{
        //    if (supportingDocuments != null && supportingDocuments.Length > 0)
        //    {
        //        var uploadsPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads");
        //        var fileName = Path.GetFileName(supportingDocuments.FileName);

        //        if (!Directory.Exists(uploadsPath))
        //        {
        //            Directory.CreateDirectory(uploadsPath);
        //        }

        //        var filePath = Path.Combine(uploadsPath, fileName);

        //        using (var stream = new FileStream(filePath, FileMode.Create))
        //        {
        //            await supportingDocuments.CopyToAsync(stream);
        //        }

        //        claim.Documents = "/uploads/" + fileName;
        //    }

        //    claim.Status = "Pending";
        //    _context.Claims.Add(claim);
        //    await _context.SaveChangesAsync();

        //    return RedirectToAction("MyClaims");
        //}

        public IActionResult MyClaims()
        {
            return View();
        }

        public IActionResult Approvals()
        {
            return View();
        }

        public IActionResult Admin()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
