using CrudApiService.Abstract.Model;

namespace CrudApiService.Abstract.Interfaces
{
    /// <summary>
    /// Интерфейс для репозитория точек продаж.
    /// </summary>
    public interface ISalesPointRepository : IRepository<SalesPoint>, ICreateEntity<SalesPoint>
    {
        /// <summary>
        /// Найти точку продажи по фильтру.
        /// </summary>
        /// <param name="pointName">Название точки продажи.</param>
        /// <param name="productName">Наименование товара.</param>
        /// <param name="quantity">Количество.</param>
        /// <returns></returns>
        SalesPoint ByFilter(string pointName = "", string productName = "", int quantity = 0);
    }
}
