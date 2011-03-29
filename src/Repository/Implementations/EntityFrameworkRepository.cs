using System;
using System.Data.Objects;
using System.Linq;
using Armory.Interfaces;

namespace Armory.Repository.Implementations
{
    public class EntityFrameworkRepository : IRepository
    {
        private readonly ObjectContext _context;

        public EntityFrameworkRepository(ObjectContext context)
        {
            _context = context;
        }

        public IQueryable<T> AsQuearyable<T>() where T : class
        {
            return _context.CreateObjectSet<T>();
        }

        public void Save<T>(T item) where T : class
        {
            _context.CreateObjectSet<T>().AddObject(item);
        }

        public void Delete<T>(T item) where T : class
        {
            _context.CreateObjectSet<T>().DeleteObject(item);
        }

        public void Commit()
        {
            _context.SaveChanges(SaveOptions.AcceptAllChangesAfterSave);
        }
    }
}