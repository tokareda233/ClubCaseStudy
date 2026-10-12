using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClubCaseStudy.Models
{
    public class MemberShip
    {
        public int Id { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
        [Required]
        [Range(100,1000)]
        public decimal Price { get; set; }
        [Required]
        public string Status { get; set; }
        [Required]
        [ForeignKey("Member")]
        public int MemberId {  get; set; }
        public Memberr ?Member { get; set; }
        public ICollection<Payment> ?Payments { get; set; }
    }
}
