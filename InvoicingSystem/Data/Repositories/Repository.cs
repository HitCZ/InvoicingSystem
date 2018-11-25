using InvoicingSystem.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace InvoicingSystem.Data.Repositories {
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class {
        protected readonly DbContext _context;
        protected readonly IEnumerable<TEntity> allEntities;

        public Repository(DbContext context) {
            _context = context;
            allEntities = _context.Set<TEntity>();
        }

        /// <summary>
        /// Returns the correct set of entities. 
        /// - IF reference equals null return full set.
        /// - ELSE return referenced set.
        /// Usage: further filtering of already filtered collections.
        /// </summary>
        /// <param name="filteredSet"></param>
        /// <returns></returns>
        protected IEnumerable<TEntity> GetCorrectSet(IEnumerable<TEntity> filteredSet) {
            return filteredSet ?? allEntities;
        }

        public TEntity Get(int id) {
            return _context.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> GetAll() {
            return _context.Set<TEntity>().ToList();
        }

        public IEnumerable<TEntity> Find(Func<TEntity, bool> predicate) {
            return _context.Set<TEntity>().Where(predicate);
        }

        public void Add(TEntity entity) {
            _context.Set<TEntity>().Add(entity);
        }

        public void AddRange(IEnumerable<TEntity> entities) {
            _context.Set<TEntity>().AddRange(entities);
        }

        public void Remove(TEntity entity) {
            _context.Set<TEntity>().Remove(entity);
        }

        public void RemoveRange(IEnumerable<TEntity> entities) {
            _context.Set<TEntity>().RemoveRange(entities);
        }
    }
}
