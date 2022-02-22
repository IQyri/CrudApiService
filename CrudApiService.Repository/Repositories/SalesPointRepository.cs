using System;
using System.Linq;
using CrudApiService.Abstract.Interfaces;
using CrudApiService.Abstract.Model;

namespace CrudApiService.Repository.Repositories
{
    /// <summary>
    /// Репозиотрий точек продаж.
    /// </summary>
    public class SalesPointRepository : BaseRepository<SalesPoint, DataBaseContext>, ISalesPointRepository
    {
        /// <inheritdoc />
        public SalesPointRepository(DataBaseContext context)
            : base(context)
        {
        }

        /// <summary>
        /// Найти точку продажи, удовлетворяющую условия фильтра.
        /// </summary>
        /// <param name="pointName">Название точки продажи.</param>
        /// <param name="productName">Наименование товара.</param>
        /// <param name="quantity">Желаемое количестов товара.</param>
        /// <returns>Точку продажи.</returns>
        public SalesPoint ByFilter(string pointName = "", string productName = "", int quantity = 0)
        {
            var productId = productName == String.Empty ? null : _dataContext.Products.SingleOrDefault(v => v.Name.Equals(productName));
            if (productId == null)
            {
                return null;
            }
            return _dataContext.SalesPoints.FirstOrDefault(
                point => (pointName == String.Empty | point.Name.Equals(pointName)) &
                         point.ProvidedProducts.Any(
                             v => (v.ProductId == productId.Id) & v.ProductQuantity >= quantity
                         )
            );
        }

        /// <inheritdoc />
        public int Create(SalesPoint model)
        {
            return Create(model, v => v.Id);
        }

        /// <inheritdoc />
        public override void Update(SalesPoint item)
        {
            var foundRecord = _dataContext.SalesPoints.First(v => v.Id == item.Id);
            foundRecord.Name = item.Name ?? foundRecord.Name;
            Save();
        }
    }
}
