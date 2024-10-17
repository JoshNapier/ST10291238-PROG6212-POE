using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ST10291238_PROG6212_POE.Models;

namespace ST10291238_PROG6212_POE.Controllers
{
    public class ClaimsTableController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Submit(ClaimsTable claim, IFormFileCollection supportingDocuments)
        {
            // Save claim to database
            _context.Claims.Add(claim);
            _context.SaveChanges();

            // Handle file upload
            if (supportingDocuments != null && supportingDocuments.Count > 0)
            {
                foreach (var document in supportingDocuments)
                {
                    if (document.Length > 0 &&
                        (Path.GetExtension(document.FileName) == ".pdf" ||
                         Path.GetExtension(document.FileName) == ".docx" ||
                         Path.GetExtension(document.FileName) == ".xlsx"))
                    {
                        var filePath = Path.Combine("Uploads", document.FileName);
                        using (var stream = System.IO.File.Create(filePath))
                        {
                            document.CopyTo(stream);
                        }
                        claim.Documents += filePath + ";";
                    }
                }
                _context.SaveChanges();
            }

            return RedirectToAction("MyClaims");
        }
    }
}
