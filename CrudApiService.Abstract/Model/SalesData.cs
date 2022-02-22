namespace CrudApiService.Abstract.Model
{
    /// <summary>
    /// Модель данных информации о продаже.
    /// </summary>
    public class SalesData
    {
        /// <summary>
        /// Идентификатор данных информации о продаже.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Идентификатор купленного продукта.
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// Навигационное свойство.
        /// </summary>
        public virtual Product Product { get; set; }

        /// <summary>
        /// Количество купленных продуктов с данным ProductId.
        /// </summary>
        public int ProductQuantity { get; set; }

        /// <summary>
        /// Общая стоимость купленного количества продуктов с данным ProductId.
        /// </summary>
        public int ProductAmount { get; set; }
    }
}
