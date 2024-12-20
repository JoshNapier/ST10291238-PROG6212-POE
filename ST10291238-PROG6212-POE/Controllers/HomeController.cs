using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ST10291238_PROG6212_POE.Data;
using ST10291238_PROG6212_POE.Models;
using ST10291238_PROG6212_POE.Services;
using System.Diagnostics;
using System.Security.Claims;

namespace ST10291238_PROG6212_POE.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;
        public ClaimsTable ClaimsTable { get; set; }

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

        public IActionResult MyClaims()
        {
            var claims = _context.Claims.ToList();
            ViewData["Claims"] = claims;
            return View();
        }

        public IActionResult Approvals()
        {
            var claims = _context.Claims.ToList();
            ViewData["Claims"] = claims;
            return View();
        }

        public IActionResult Admin()
        {
            return View();
        }

        public IActionResult Lecturers()
        {
            return View();
        }

        public IActionResult GenerateReport()
        {
            var claims = _context.Claims.Where(c => c.Status == "Approved").ToList();
            var reportService = new ReportService();
            var reportBytes = reportService.GenerateApprovedClaimsReport(claims);

            return File(reportBytes, "text/csv", "ApprovedClaimsReport.csv");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
