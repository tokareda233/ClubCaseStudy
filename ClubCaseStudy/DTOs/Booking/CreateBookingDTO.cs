using ClubCaseStudy.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ClubCaseStudy.DTOs.Booking
{
    public class CreateBookingDTO
    {
       
        [Required]
        public DateTime BookingDate { get; set; }
        [Required]

        public TimeSpan StartDate { get; set; }
        [Required]
        public TimeSpan EndDate { get; set; }
        [Required]
        [Range(1, 100)]
        public int GroupSize { get; set; }
        [Required]
        public string Status { get; set; }
        [Required]
       
        public int MemberId { get; set; }
      
        [Required]
       
        public int FacilityId { get; set; }
    }
}
