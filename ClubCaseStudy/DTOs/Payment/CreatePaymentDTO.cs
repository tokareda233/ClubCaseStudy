using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ClubCaseStudy.DTOs.Payment
{
    public class CreatePaymentDTO
    {
       
        [Required]
        [Range(100, 10000)]
        public decimal Amount { get; set; }
        [Required]
        public DateTime PaymentDate { get; set; }
        [Required]
        public string PaymentMethod { get; set; }
        [Required]
        
        public int MembershipId { get; set; }
    }
}
