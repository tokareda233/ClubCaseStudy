namespace ClubCaseStudy.Repo.Interfaces
{
    public interface IGenericRepo<TEntity > where TEntity : class
    {

        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        Task<TEntity> GetById(int id);
        Task<List<TEntity>> GetAll();
    }
}
