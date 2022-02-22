using System.Linq;
using CrudApiService.Abstract.Interfaces;
using CrudApiService.Abstract.Model;

namespace CrudApiService.Repository.Repositories
{
    /// <summary>
    /// Репозиотрий актов продаж.
    /// </summary>
    public class SalesRepository : BaseRepository<Sale, DataBaseContext>, ISalesRepository
    {
        /// <inheritdoc />
        public SalesRepository(DataBaseContext context)
            : base(context)
        {
        }

        /// <inheritdoc />
        public int Create(Sale model)
        {
            return Create(model, v => v.Id);
        }
        
        /// <inheritdoc />
        public override void Update(Sale item)
        {
            var foundRecord = _dataContext.Sales.First(v => v.Id == item.Id);
            foundRecord.BuyerId = item.BuyerId ?? foundRecord.BuyerId;
            Save();
        }
    }
}
