using TaxiManager9000.Domain.Entities;

namespace TaxiManager9000.DataAccess.Interfaces
{
    public interface IDb<T> where T : BaseEntity
    {
        bool Add(T entity);
        bool Update(T entity);
        bool RemoveById(int id);
        List<T> GetAll();
        T GetById(int id);
    }
}   
