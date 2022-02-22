using CrudApiService.Abstract.Model;

namespace CrudApiService.Abstract.Interfaces
{
    /// <summary>
    /// Интерфейс для репозитория данных о продаже товара.
    /// </summary>
    public interface ISalesDataRepository : IRepository<SalesData>, ICreateEntity<SalesData>
    {
        /// <summary>
        /// Создать данные о продаже товара.
        /// </summary>
        /// <param name="productName">Наименование товара.</param>
        /// <param name="productQuantity">Количество товара.</param>
        /// <returns></returns>
        SalesData CreateSalesData(string productName, int productQuantity);
    }
}
