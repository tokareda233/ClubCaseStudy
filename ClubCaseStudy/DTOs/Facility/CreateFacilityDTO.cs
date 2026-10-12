using System.ComponentModel.DataAnnotations;

namespace ClubCaseStudy.DTOs.Facility
{
    public class CreateFacilityDTO
    {
       
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        [Range(1, 100)]
        public int Capacity { get; set; }
        [Required]
        [Range(50, 10000)]
        public decimal HourePrice { get; set; }
    }
}
