using System.Linq;
using CrudApiService.Abstract.Interfaces;
using CrudApiService.Abstract.Model;

namespace CrudApiService.Repository.Repositories
{
    /// <summary>
    /// Репозиотрий доступных для продажи товаров.
    /// </summary>
    public class ProvidedProductRepository : BaseRepository<ProvidedProduct, DataBaseContext>, IProvidedProductRepository
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

        /// <inheritdoc />
        public int Create(ProvidedProduct model)
        {
            return Create(model, v => v.Id);
        }

        /// <inheritdoc />
        public override void Update(ProvidedProduct item)
        {
            var foundRecord = _dataContext.ProvidedProducts.First(v => v.Id == item.Id);
            foundRecord.ProductQuantity = item.ProductQuantity;
            Save();
        }
    }


    
}
