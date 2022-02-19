using System.ComponentModel.DataAnnotations;

namespace CrudApiService.Abstract.Model
{
    /// <summary>
    /// Модель данных информации о продаже.
    /// </summary>
    public class SalesData
    {
        /// <summary>
        /// Идентификатор купленного продукта.
        /// </summary>
        public int ProductId { get; set; }
        
        /// <summary>
        /// Навигационное свойство.
        /// </summary>
        public Product Product { get; set; }

        /// <summary>
        /// Количество купленных продуктов с данным ProductId.
        /// </summary>
        public int ProductQuantity { get; set; }

        /// <summary>
        /// Общая стоимость купленного количества продуктов с данным ProductId.
        /// </summary>
        public int ProductAmount
        {
            get => ProductQuantity * Product.Price;
            private set { }
        }
    }
}
