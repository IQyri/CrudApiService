namespace CrudApiService.Abstract.Model
{
    /// <summary>
    /// Модель данных для доступных для продажи товаров
    /// </summary>
    /// ToDo: add SalesPointId
    public class ProvidedProduct
    {
        /// <summary>
        /// Идентификатор записи о доступных для продажи товаров
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Идентификатор продукта.
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// Навигационное свойство
        /// </summary>
        public virtual Product Product { get; set; }

        /// <summary>
        /// Количество продукта.
        /// </summary>
        public int ProductQuantity { get; set; }
    }
}
