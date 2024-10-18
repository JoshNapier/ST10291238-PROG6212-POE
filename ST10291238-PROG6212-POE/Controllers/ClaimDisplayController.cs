using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ST10291238_PROG6212_POE.Data;
using ST10291238_PROG6212_POE.Models;
using System.Collections.Generic;

namespace ST10291238_PROG6212_POE.Controllers
{
    public class ClaimDisplayController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ClaimDisplayController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public static async Task<List<ClaimsTable>> SelectClaims(ApplicationDbContext context)
        {
            List<ClaimsTable> claims = new List<ClaimsTable>();
            claims.AddRange(await context.Claims.ToListAsync());
            return claims;
        }


        // Method to view a specific claim's details
        public async Task<IActionResult> ClaimDetails(int id)
        {
            var claim = await _context.Claims.FindAsync(id);

            if (claim == null)
            {
                return NotFound();
            }

            return View(claim);
        }
    }
}
