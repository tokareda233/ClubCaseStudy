using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ClubCaseStudy.DTOs.Payment
{
    public class GetPaymentDTO
    {
        public int Id { get; set; }
       
      
        public decimal Amount { get; set; }
      
        public DateTime PaymentDate { get; set; }
      
        public string PaymentMethod { get; set; }
       
    
        public int MembershipId { get; set; }
    }
}
