using ST10291238_PROG6212_POE.Data;

namespace ST10291238_PROG6212_POE.Models
{
    public class ValidationService
    {
        private readonly ApplicationDbContext _context;

        public ValidationService(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool ValidateClaim(ClaimsTable claim, out string validationError)
        {
            validationError = string.Empty;

            if (claim.HourlyRate < 50 || claim.HourlyRate > 500)
            {
                validationError = "Hourly rate must be between R50 and R500";
                return false;
            }

            if (claim.HoursWorked > 40)
            {
                validationError = "Hours worked must be less than 40";
                return false;
            }

            return true;
        }
    }
}
