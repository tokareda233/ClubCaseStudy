using ClubCaseStudy.Data;
using ClubCaseStudy.Models;
using ClubCaseStudy.Repo.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ClubCaseStudy.Repo.Implementations
{
    public class BookingRepo : GenericRepo<Booking>, IBookingRepo
    {
        private readonly AppDbContext _context;
        public BookingRepo(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Booking>> BookingReport()
        {
            return await _context.Bookings.Include(x=>x.Member).Include(x=>x.Facility).ToListAsync();
        }

        public async Task<List<Booking>> Pagnation(string? Status, int? facilityId,int pagenumber=1, int pageSize=5)
        {
            return await _context.Bookings
                .Skip((pagenumber-1)*pageSize)
                .Take(pageSize)
                .Where(x => x.Status == Status&&x.FacilityId==facilityId)
                .ToListAsync();
        }

        public async Task<Booking> Patch(int id)
        {
           var book= await _context.Bookings.FirstOrDefaultAsync(c=>c.Id==id);
            return book;
        }
    }
}
