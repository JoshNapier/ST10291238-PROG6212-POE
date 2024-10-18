using Microsoft.EntityFrameworkCore;
using ST10291238_PROG6212_POE.Data;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;

namespace ST10291238_PROG6212_POE.Models
{
    public class ClaimsTable
    {
        [Key]
        public int ClaimId { get; set; }

        public string LecturerName { get; set; }

        public string LecturerSurname { get; set; }

        public string Programme { get; set; }

        public DateTime ClaimDate { get; set; }

        public double HourlyRate { get; set; }

        public int HoursWorked { get; set; }

        public double ClaimAmount { get; set; }

        public string Status { get; set; } = "Pending";

        public string Notes { get; set; }

        public string Documents { get; set; }

        public static async Task<List<ClaimsTable>> SelectClaims(ApplicationDbContext context)
        {
            List<ClaimsTable> claims = new List<ClaimsTable>();
            claims.AddRange(await context.Claims.ToListAsync());
            return claims;
        }
    }
}
