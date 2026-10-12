using ClubCaseStudy.Models;

namespace ClubCaseStudy.Repo.Interfaces
{
    public interface IMemberRepo:IGenericRepo<Memberr>
    {
        Task<List<Memberr>> Pagnation(int pagenumber, int pagesize);
        Task<List<Memberr>> SearchByName(string name);

    }
}
