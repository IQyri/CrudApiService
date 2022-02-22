namespace CrudApiService.WebHosting.Models
{
    /// <summary>
    /// Модель ответа при успешном создании акта продажи.
    /// </summary>
    public class SuccessResponse
    {
        /// <summary>
        /// Идентификатор акта продаж.
        /// </summary>
        public int SaleId { get; set; }

        /// <summary>
        /// Идентификатор покупателя.
        /// </summary>
        public int? BuyerId { get; set; }


    }
}
