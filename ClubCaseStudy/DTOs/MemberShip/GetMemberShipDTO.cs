using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ClubCaseStudy.DTOs.MemberShip
{
    public class GetMemberShipDTO
    {
        public int Id { get; set; }
       
        public string Type { get; set; }
        

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
       
        public decimal Price { get; set; }
       
        public string Status { get; set; }
        
        public int MemberId { get; set; }
    }
}
