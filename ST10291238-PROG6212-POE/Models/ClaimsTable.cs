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

        [Required]
        public string LecturerName { get; set; }

        [Required]
        public string LecturerSurname { get; set; }

        [Required]
        public string Programme { get; set; }

        [Required]
        public DateTime ClaimDate { get; set; }

        [Range(1, double.MaxValue, ErrorMessage = "Hourly rate must be greater than 0.")]
        public double HourlyRate { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Hours worked must be greater than 0.")]
        public int HoursWorked { get; set; }

        public double ClaimAmount { get; set; }

        [Required]
        public string Status { get; set; } = "Pending";

        public string Notes { get; set; }

        public string Documents { get; set; }

        public string RejectionReason { get; set; }

        public static async Task<List<ClaimsTable>> SelectClaims(ApplicationDbContext context)
        {
            List<ClaimsTable> claims = new List<ClaimsTable>();
            claims.AddRange(await context.Claims.ToListAsync());
            return claims;
        }
    }
}
