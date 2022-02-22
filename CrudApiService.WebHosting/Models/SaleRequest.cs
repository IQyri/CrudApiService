using System.Collections.Generic;

namespace CrudApiService.WebHosting.Models
{
    /// <summary>
    /// Запрос на создание акта продажи.
    /// </summary>
    public class SaleRequest
    {
        /// <summary>
        /// Идентификатор покупателя.
        /// </summary>
        public int? BuyerId { get; set; }

        /// <summary>
        /// Список с информацией о продаже.
        /// </summary>
        public ICollection<SaleInfo> SalesInfo { get; set; }
    }
}
