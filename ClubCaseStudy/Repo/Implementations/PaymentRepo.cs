using ClubCaseStudy.Data;
using ClubCaseStudy.DTOs.Payment;
using ClubCaseStudy.Models;
using ClubCaseStudy.Repo.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ClubCaseStudy.Repo.Implementations
{
    public class PaymentRepo : GenericRepo<Payment>, IPaymentRepo
    {
        private readonly AppDbContext _context;
        public PaymentRepo(AppDbContext context) : base(context)
        {
            _context = context;
        }

       
        public async Task<GetStatisticsDTO> GetPaymentStatistics()
        {
            var s = new GetStatisticsDTO()
            {
                TotalRevenue=_context.Payments.Sum(x=>x.Amount),
                TotalAvarage=_context.Payments.Average(x=>x.Amount),
                TotalCount=_context.Payments.Count(),
                HigherAmount=_context.Payments.Max(x=>x.Amount),
                LowerAmount=_context.Payments.Min(x=>x.Amount)

            };

            return s;
        }



    }
}
