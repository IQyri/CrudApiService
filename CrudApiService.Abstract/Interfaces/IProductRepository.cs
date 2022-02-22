using CrudApiService.Abstract.Model;

namespace CrudApiService.Abstract.Interfaces
{
    /// <summary>
    /// Интерфейс для репозитория товаров.
    /// </summary>
    public interface IProductRepository : IRepository<Product>, ICreateEntity<Product>
    {
    }
}
