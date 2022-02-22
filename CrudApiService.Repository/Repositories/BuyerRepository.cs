using System.Linq;
using CrudApiService.Abstract.Interfaces;
using CrudApiService.Abstract.Model;

namespace CrudApiService.Repository.Repositories
{
    /// <summary>
    /// Репозиторий покупателей.
    /// </summary>
    public class BuyerRepository : BaseRepository<Buyer, DataBaseContext>, IBuyerRepository
    {
        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="context"></param>
        public BuyerRepository(DataBaseContext context)
            : base(context)
        {
        }

        /// <inheritdoc />
        public int Create(Buyer model)
        {
            return Create(model, v => v.Id);
        }

        /// <inheritdoc />
        public override void Update(Buyer item)
        {
            var foundRecord = _dataContext.Buyers.First(v => v.Id == item.Id);
            foundRecord.Name = item.Name ?? foundRecord.Name;
            foundRecord.SalesIds = item.SalesIds ?? foundRecord.SalesIds;
            Save();
        }
    }
}
