using CrudApiService.Abstract.Model;

namespace CrudApiService.Repository.Repositories
{
    /// <summary>
    /// Репозиторий покупателей.
    /// </summary>
    public class BuyerRepository : BaseRepository<Buyer, DataBaseContext>
    {
        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="context"></param>
        public BuyerRepository(DataBaseContext context)
            : base(context)
        {
        }
    }
}
