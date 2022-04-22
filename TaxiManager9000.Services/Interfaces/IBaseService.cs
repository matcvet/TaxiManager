using TaxiManager9000.Domain.Entities;

namespace TaxiManager9000.Services.Interfaces
{
    public interface IBaseService<T> where T : BaseEntity
    {
        bool Add(T entity);
        T GetById(int id);
        bool RemoveById(int id);
        bool Update(T entity);
        List<T> GetAll();
    }
}
