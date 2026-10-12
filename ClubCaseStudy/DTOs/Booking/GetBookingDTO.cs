using ClubCaseStudy.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ClubCaseStudy.DTOs.Booking
{
    public class GetBookingDTO
    {
        public int Id { get; set; }
       
        public DateTime BookingDate { get; set; }
        

        public TimeSpan StartDate { get; set; }
      
        public TimeSpan EndDate { get; set; }
        
        public int GroupSize { get; set; }
        
        public string Status { get; set; }
      
        public int MemberId { get; set; }
     
       
        public int FacilityId { get; set; }
    }
}
