using System.ComponentModel.DataAnnotations;

namespace test_apps_3.Models.ViewModel
{
    public class AddStudentRequest
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string session { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        public IFormFile? ProfileImage { get; set; }
    }
}