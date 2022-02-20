namespace CrudApiService.Abstract.Model
{
    /// <summary>
    /// Модель данных для доступных для продажи товаров
    /// </summary>
    public class ProvidedProduct
    {
        /// <summary>
        /// Идентификатор продукта.
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// Навигационное свойство
        /// </summary>
        public Product Product { get; set; }

        /// <summary>
        /// Количество продукта.
        /// </summary>
        public int ProductQuantity { get; set; }
    }
}
