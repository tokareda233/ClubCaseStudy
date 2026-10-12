using ClubCaseStudy.Data;
using ClubCaseStudy.Models;
using ClubCaseStudy.Repo.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ClubCaseStudy.Repo.Implementations
{
    public class MemberShipRepo : GenericRepo<MemberShip>, IMemberShipRepo
    {
        private readonly AppDbContext _context;
        public MemberShipRepo(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<MemberShip>> GetActiveMemberShips()
        {
            return await _context.MemberShips.Where(x => x.Status == "Active").ToListAsync();
        }

        public async Task<MemberShip> PatchByEndDate(int id, DateTime endDate)
        {
            var mems= await _context.MemberShips.FirstOrDefaultAsync(c=>c.Id== id);
           return mems;

        }
    }
}
