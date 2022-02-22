using CrudApiService.Abstract.Model;

namespace CrudApiService.Abstract.Interfaces
{
    /// <summary>
    /// Интерфейс для репозитория актов продаж.
    /// </summary>
    public interface ISalesRepository : IRepository<Sale>, ICreateEntity<Sale>
    {
    }
}
