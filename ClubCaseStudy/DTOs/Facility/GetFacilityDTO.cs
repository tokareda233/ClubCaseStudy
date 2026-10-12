using System.ComponentModel.DataAnnotations;

namespace ClubCaseStudy.DTOs.Facility
{
    public class GetFacilityDTO
    {
        public int Id { get; set; }
       
        public string Name { get; set; }
        
        public int Capacity { get; set; }
        
        public decimal HourePrice { get; set; }
    }
}
