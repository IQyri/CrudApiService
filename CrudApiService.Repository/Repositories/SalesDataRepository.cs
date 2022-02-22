using System.Linq;
using CrudApiService.Abstract.Interfaces;
using CrudApiService.Abstract.Model;

namespace CrudApiService.Repository.Repositories
{
    /// <summary>
    /// Репозиотрий данных о продаже товара.
    /// </summary>
    public class SalesDataRepository : BaseRepository<SalesData, DataBaseContext>, ISalesDataRepository
    {
        /// <inheritdoc />
        public SalesDataRepository(DataBaseContext context)
            : base(context)
        {
        }

        /// <summary>
        /// Создать сущность данных о продаже товара
        /// </summary>
        /// <param name="productName">Наименование товара.</param>
        /// <param name="productQuantity">Количество товара для покупки.</param>
        /// <returns>Сущность данных о продаже.</returns>
        public SalesData CreateSalesData(string productName, int productQuantity)
        {
            var wishedProduct = _dataContext.Products.FirstOrDefault(v => v.Name.Equals(productName));
            if (wishedProduct == null)
            {
                return null;
            }

            var saleData = new SalesData()
            {
                Product = wishedProduct,
                ProductQuantity = productQuantity,
                ProductAmount = wishedProduct.Price * productQuantity

            };

            Create(saleData);
            return saleData;
        }


        /// <inheritdoc />
        public int Create(SalesData model)
        {
            var wishedProduct = _dataContext.Products.FirstOrDefault(v => v.Id.Equals(model.ProductId));
            if (wishedProduct == null)
            {
                return -1;
            }

            model.ProductAmount = wishedProduct.Price * model.ProductQuantity;
            return Create(model, v => v.Id);
        }

        /// <inheritdoc />
        public override void Update(SalesData item)
        {
            var foundRecord = _dataContext.SalesData.First(v => v.Id == item.Id);
            foundRecord.ProductQuantity = item.ProductQuantity;
            Save();
        }
    }
}
