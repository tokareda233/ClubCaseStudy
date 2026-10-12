using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClubCaseStudy.Models
{
    public class Booking
    {
        public int Id { get; set; }
        [Required]
        public DateTime BookingDate { get; set; }
        [Required]

        public TimeSpan StartDate { get; set; }
        [Required]
        public TimeSpan EndDate { get; set; }
        [Required]
        [Range(1,100)]
        public int GroupSize { get; set; }
        [Required]
        public string Status { get; set; }
        [Required]
        [ForeignKey("Member")]
        public int MemberId { get; set; }
        public Memberr ?Member { get; set; }
        [Required]
        [ForeignKey("Facility")]
        public int FacilityId { get; set; }
        public Facility ?Facility { get; set; }

    }
}
