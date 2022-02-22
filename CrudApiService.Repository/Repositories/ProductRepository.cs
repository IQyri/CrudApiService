using System.Linq;
using CrudApiService.Abstract.Interfaces;
using CrudApiService.Abstract.Model;

namespace CrudApiService.Repository.Repositories
{
    /// <summary>
    /// Репозиотрий товаров.
    /// </summary>
    public class ProductRepository : BaseRepository<Product, DataBaseContext>, IProductRepository
    {
        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="context"></param>
        public ProductRepository(DataBaseContext context)
            : base(context)
        {
        }

        /// <inheritdoc />
        public int Create(Product model)
        {
            return Create(model, v => v.Id);
        }

        /// <inheritdoc />
        public override void Update(Product item)
        {
            var foundRecord = _dataContext.Products.First(v => v.Id == item.Id);
            foundRecord.Name = item.Name ?? foundRecord.Name;
            foundRecord.Price = item.Price;
            Save();
        }
    }
}
