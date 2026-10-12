using System.ComponentModel.DataAnnotations;

namespace ClubCaseStudy.Models
{
    public class Memberr
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100,MinimumLength =3)]
        public string FullName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Phone]
        [Required]
        public string Phone { get; set; }
        [Required]
        public DateTime DOB { get; set; }

        public MemberShip ?MemberShip { get; set; }
        public ICollection<Booking> ?Bookings { get; set; }
    }
}
