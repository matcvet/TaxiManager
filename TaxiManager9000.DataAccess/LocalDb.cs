using TaxiManager9000.DataAccess.Interfaces;
using TaxiManager9000.Domain.Entities;
using TaxiManager9000.Services.Helpers;

namespace TaxiManager9000.DataAccess
{
    public class LocalDb<T> : IDb<T> where T : BaseEntity
    {
        public int Id { get; set; } = 1;
        protected List<T> Db;

        public LocalDb()
        {
            Db = new List<T>();
        }

        public bool Add(T entity)
        {
            try
            {
                entity.Id = Id++;
                Db.Add(entity);
                return true;
            }
            catch (Exception ex) 
            {
                StringFormatter.Colorize(ex.Message, ConsoleColor.Red);
                return false;
            }
        }

        public bool Update(T entity)
        {
            throw new NotImplementedException();
        }

        public List<T> GetAll()
        {
            return Db;
        }

        public T GetById(int id)
        {
            try
            {
                T entity = Db.Single(x => x.Id == id);
                return entity;
            }
            catch(Exception ex)
            {
                StringFormatter.Colorize(ex.Message, ConsoleColor.Red);
                return null;
            }
        }

        public bool RemoveById(int id)
        {
            try
            {
                Db.Remove(Db.Single(x => x.Id == id));
                Id--;
                return true;
            }
            catch(Exception e)
            {
                StringFormatter.Colorize(e.Message + ", user doesnt exist", ConsoleColor.Red);
                return false;
            }
        }
    }
}
