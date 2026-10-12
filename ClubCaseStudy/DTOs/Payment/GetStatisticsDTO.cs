namespace ClubCaseStudy.DTOs.Payment
{
    public class GetStatisticsDTO
    {
        public decimal TotalRevenue { get; set; }
        public decimal TotalAvarage { get; set; }
        public decimal HigherAmount { get; set; }
        public decimal LowerAmount { get; set; }
        public decimal TotalCount { get; set; }

    }
}
