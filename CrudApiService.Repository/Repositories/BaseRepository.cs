using System;
using System.Collections.Generic;
using System.Linq;
using CrudApiService.Abstract.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CrudApiService.Repository.Repositories
{
    /// <summary>
    /// Базовый репозиторий.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="C"></typeparam>
    public class BaseRepository<T, C> : IRepository<T>
        where T : class
        where C : DbContext
    {
        /// <summary>
        /// 
        /// </summary>
        protected readonly C _dataContext;

        private readonly DbSet<T> _dbSet;
        private bool _disposed;

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="context">Контекст БД.</param>
        protected BaseRepository(C context)
        {
            _dataContext = context;
            _dbSet = context.Set<T>();
        }

        /// <inheritdoc />
        public virtual IEnumerable<T> GetAll()
        {
            return _dbSet;
        }

        /// <inheritdoc />
        public virtual T GetItem(int id)
        {
            return _dbSet.Find(id);
        }

        /// <inheritdoc />
        public virtual ICollection<int> Create(IEnumerable<T> items, Func<T, int> getId)
        {
            _dbSet.AddRange(items);
            Save();
            return items.Select(v => getId(v)).ToArray();
        }
        
        /// <inheritdoc />
        public virtual int Create(T item, Func<T, int> getId)
        {
            var id = Create(new[] { item }, getId);
            Save();
            return id.Single();
        }

        /// <inheritdoc />
        public virtual void Update(T item)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public virtual void Delete(int id)
        {
            var item = GetItem(id);
            if (item != null)
                _dbSet.Remove(item);
            Save();
        }

        /// <inheritdoc />
        public virtual void Save()
        {
            _dataContext.SaveChanges();
        }

        /// <summary>
        /// Утилизация.
        /// </summary>
        /// <param name="disposing">Флаг утилизации.</param>
        private void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _dataContext.Dispose();
                }
            }

            this._disposed = true;
        }

        /// <summary>
        /// Утилизация.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
