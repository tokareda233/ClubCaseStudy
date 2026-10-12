using System.ComponentModel.DataAnnotations;

namespace ClubCaseStudy.DTOs.Member
{
    public class CreateMemberDTO
    {
       
        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string FullName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Phone]
        [Required]
        public string Phone { get; set; }
        [Required]
        public DateTime DOB { get; set; }
    }
}
