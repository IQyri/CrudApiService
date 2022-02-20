using CrudApiService.Abstract.Model;

namespace CrudApiService.Repository.Repositories
{
    /// <summary>
    /// 
    /// </summary>
    public class ProductRepository : BaseRepository<Product, DataBaseContext>
    {
        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="context"></param>
        public ProductRepository(DataBaseContext context)
            : base(context)
        {
        }
    }
}
