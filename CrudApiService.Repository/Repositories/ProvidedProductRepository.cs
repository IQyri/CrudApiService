using CrudApiService.Abstract.Model;

namespace CrudApiService.Repository.Repositories
{
    /// <summary>
    /// 
    /// </summary>
    public class ProvidedProductRepository : BaseRepository<ProvidedProduct, DataBaseContext>
    {
        private readonly DataBaseContext _context;

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="context">Контекст БД.</param>
        public ProvidedProductRepository(DataBaseContext context)
            : base(context)
        {
            _context = context;
        }
    }
}
