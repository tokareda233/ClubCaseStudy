using ClubCaseStudy.Data;
using ClubCaseStudy.Models;
using ClubCaseStudy.Repo.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ClubCaseStudy.Repo.Implementations
{
    public class MemberRepo : GenericRepo<Memberr>, IMemberRepo
    {
        private readonly AppDbContext _context;
        public MemberRepo(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Memberr>> Pagnation(int pagenumber=1, int pagesize=5)
        {
           return await _context.Memberrs
                .Skip((pagenumber - 1) * pagesize)
                .Take(pagesize)
                .OrderBy(x=>x.DOB)
                .ToListAsync();
        }

        public async Task<List<Memberr>> SearchByName(string name)
        {
            return await _context.Memberrs.Where(x=>x.FullName.Contains(name)).ToListAsync();
        }

    }
}
