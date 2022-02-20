using System;
using System.Collections.Generic;

namespace CrudApiService.Abstract.Interfaces
{
    /// <summary>
    /// Интерфейс репозитория.
    /// </summary>
    public interface IRepository<T> : IDisposable
        where T : class
    {
        /// <summary>
        /// Прочитать все объекты типа T.
        /// </summary>
        /// <returns></returns>
        IEnumerable<T> GetAll();

        /// <summary>
        /// Прочитать данные объекта типа T с указанным Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        T GetItem(int id);

        /// <summary>
        /// Создать объект типа Т.
        /// </summary>
        /// <param name="items"></param>
        void Create(IEnumerable<T> items);

        /// <summary>
        /// Обновить данные объекта типа Т.
        /// </summary>
        /// <param name="item"></param>
        void Update(T item);

        /// <summary>
        /// Удалить объект типа Т с определенным id.
        /// </summary>
        /// <param name="id"></param>
        void Delete(int id);

        /// <summary>
        /// Сохранить изменения.
        /// </summary>
        void Save();
    }
}
