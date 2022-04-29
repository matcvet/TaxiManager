using TaxiManager9000.DataAccess;
using TaxiManager9000.Domain.Entities;
using TaxiManager9000.Services.Interfaces;

namespace TaxiManager9000.Services.Services
{
    public class BaseService<T> : IBaseService<T> where T : BaseEntity
    {
        protected LocalDb<T> ?Db { get; set; }

        public BaseService()
        {
            Db = new LocalDb<T>();
        }

        public bool Add(T entity)
        {
            try
            {
                Db.Add(entity);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public T GetById(int id)
        {
            return Db.GetById(id);
        }

        public List<T> GetAll()
        {
            return Db.GetAll();
        }

        public bool RemoveById(int id)
        {
            if (Db.RemoveById(id))
            {
                return true;
            }

            return false;
        }

        public bool Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
