using System.ComponentModel.DataAnnotations;

namespace ST10291238_PROG6212_POE.Models
{
    public class Lecturer
    {
        [Key]
        public int LecturerId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Surname { get; set; }

        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}
