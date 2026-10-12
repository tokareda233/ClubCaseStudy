using ClubCaseStudy.Models;
using ClubCaseStudy.Repo.Interfaces;

namespace ClubCaseStudy.UnitOfWork
{
    public interface IUnitOfWork
    {
        IMemberRepo Members{ get; }
        IMemberShipRepo MemberShips { get; }
        IGenericRepo<Facility> Facilities { get; }
        IBookingRepo Bookings { get; }
        IPaymentRepo payments { get; }
        void Save();
        void SaveAsync();
    }
}
