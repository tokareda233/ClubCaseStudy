using ClubCaseStudy.Models;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace ClubCaseStudy.Repo.Interfaces
{
    public interface IBookingRepo:IGenericRepo<Booking>
    {
        Task<List<Booking>> Pagnation ( string? Status, int? facilityId,int pagenumber=1, int pageSize=5 );

        Task<List<Booking>> BookingReport();

        Task<Booking> Patch(int id);
    }
}
