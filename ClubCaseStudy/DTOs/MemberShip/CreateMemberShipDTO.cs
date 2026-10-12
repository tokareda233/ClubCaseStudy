using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ClubCaseStudy.DTOs.MemberShip
{
    public class CreateMemberShipDTO
    {
       
        [Required]
        public string Type { get; set; }
        [Required]

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
        [Required]
        [Range(100, 1000)]
        public decimal Price { get; set; }
        [Required]
        public string Status { get; set; }
        [Required]
        
        public int MemberId { get; set; }
    }
}
