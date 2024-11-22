using ST10291238_PROG6212_POE.Models;
using System.Text;

namespace ST10291238_PROG6212_POE.Services
{
    public class ReportService
    {
        public byte[] GenerateApprovedClaimsReport(List<ClaimsTable> claims)
        {
            var csv = new StringBuilder();
            csv.AppendLine("Claim ID,Lecturer Name,Programme,Claim Amount,Claim Date");

            foreach (var claim in claims)
            {
                csv.AppendLine($"{claim.ClaimId},{claim.LecturerName},{claim.Programme},{claim.ClaimAmount},{claim.ClaimDate:yyyy-MM-dd}");
            }

            return Encoding.UTF8.GetBytes(csv.ToString());
        }
    }
}
