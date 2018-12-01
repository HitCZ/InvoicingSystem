using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using InvoicingSystem.Logic.Repositories.Interfaces;

namespace InvoicingSystem.Logic.Repositories {
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class {
        protected readonly DbContext Context;
        protected readonly IEnumerable<TEntity> AllEntities;

        public Repository(DbContext context) {
            Context = context;
            AllEntities = Context.Set<TEntity>();
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
            return filteredSet ?? AllEntities;
        }

        public TEntity Get(int id) {
            return Context.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> GetAll() {
            return Context.Set<TEntity>().ToList();
        }

        public IEnumerable<TEntity> Find(Func<TEntity, bool> predicate) {
            return Context.Set<TEntity>().Where(predicate);
        }

        public void Add(TEntity entity) {
            Context.Set<TEntity>().Add(entity);
        }

        public void AddRange(IEnumerable<TEntity> entities) {
            Context.Set<TEntity>().AddRange(entities);
        }

        public void Remove(TEntity entity) {
            Context.Set<TEntity>().Remove(entity);
        }

        public void RemoveRange(IEnumerable<TEntity> entities) {
            Context.Set<TEntity>().RemoveRange(entities);
        }
    }
}
