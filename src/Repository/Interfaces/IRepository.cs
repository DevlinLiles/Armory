using System.Linq;

namespace Armory.Interfaces
{
    public partial interface IRepository
    {
        IQueryable<T> AsQuearyable<T>() where T : class;
        void Save<T>(T item) where T : class;
        void Delete<T>(T item) where T : class ;
        void Commit();
    }
}