using CrudApiService.Abstract.Model;

namespace CrudApiService.Abstract.Interfaces
{
    /// <summary>
    /// Интерфейс для репозитория покупателей.
    /// </summary>
    public interface IBuyerRepository : IRepository<Buyer>, ICreateEntity<Buyer>
    {
    }
}
