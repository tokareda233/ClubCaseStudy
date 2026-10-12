using ClubCaseStudy.Models;

namespace ClubCaseStudy.Repo.Interfaces
{
    public interface IMemberShipRepo:IGenericRepo<MemberShip>
    {
        Task<List<MemberShip>> GetActiveMemberShips();
        Task<MemberShip> PatchByEndDate(int id, DateTime endDate);
    }
}
