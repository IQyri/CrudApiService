namespace CrudApiService.WebHosting.Models
{
    /// <summary>
    /// Модель с информацией о продаже.
    /// </summary>
    public class SaleInfo
    {
        /// <summary>
        /// Наименование товара.
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        /// Количество товара.
        /// </summary>
        public int Quantity { get; set; }
    }
}
