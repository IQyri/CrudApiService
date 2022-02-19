namespace CrudApiService.Abstract.Model
{
    /// <summary>
    /// Модель данных товара.
    /// </summary>
    public class Product
    {
        /// <summary>
        /// Идентификатор товара.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Название товара.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Цена товара.
        /// </summary>
        public int Price { get; set; }
    }
}
