using System;
using System.Collections.Generic;
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
        private readonly C _dataContext;
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
        public virtual void Create(IEnumerable<T> items)
        {
            _dbSet.AddRange(items);
            Save();
        }

        /// <inheritdoc />
        public virtual void Update(T item)
        {
            _dataContext.Entry(item).State = EntityState.Modified;
            Save();
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
