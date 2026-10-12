using ClubCaseStudy.Data;
using ClubCaseStudy.Models;
using ClubCaseStudy.Repo.Interfaces;

namespace ClubCaseStudy.UnitOfWork
{
    public class UnitOfWorkk : IUnitOfWork
    {
        private readonly AppDbContext _context;
        public IMemberRepo Members { get; }

        public IMemberShipRepo MemberShips {  get; }

        public IGenericRepo<Facility> Facilities { get; }

        public IBookingRepo Bookings { get; }

        public IPaymentRepo payments { get; }

        public UnitOfWorkk(AppDbContext context, IMemberRepo member, IMemberShipRepo memberShips, IGenericRepo<Facility> facility, IBookingRepo bookings, IPaymentRepo payments)
        {
            _context = context;
            Members = member;
            MemberShips = memberShips;
            Facilities = facility;
            Bookings = bookings;
            this.payments = payments;
        }
        public void Save()
        {
            _context.SaveChanges();
        }

        public void SaveAsync()
        {
           _context.SaveChangesAsync();
        }
    }
}
