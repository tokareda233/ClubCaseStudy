using ClubCaseStudy.DTOs.Payment;
using ClubCaseStudy.Models;

namespace ClubCaseStudy.Repo.Interfaces
{
    public interface IPaymentRepo:IGenericRepo<Payment>
    {
        public  Task<GetStatisticsDTO> GetPaymentStatistics();
    }
}
