using CrudApiService.Abstract.Model;

namespace CrudApiService.Abstract.Interfaces
{
    /// <summary>
    /// Интерфейс для репозитория доступных для продажи товаров.
    /// </summary>
    public interface IProvidedProductRepository : IRepository<ProvidedProduct>, ICreateEntity<ProvidedProduct>
    {
        
    }
}
