using System;
using System.Collections.Generic;
using System.Linq;

namespace CrudApiService.Abstract.Model
{
    /// <summary>
    /// Модель данных для акта продаж.
    /// </summary>
    public class Sale
    {
        /// <summary>
        /// Идентификатор акта продаж.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Дата осуществления продажи.
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Время осуществления продажи.
        /// </summary>
        public TimeSpan Time { get; set; }

        /// <summary>
        /// идентификатор точки продажи. Внешний ключ.
        /// </summary>
        public int SalesPointId { get; set; }

        /// <summary>
        /// Навигационное свойство.
        /// </summary>
        public SalesPoint SalesPoint { get; set; }

        /// <summary>
        /// Идентификатор покупателя. Внешний ключ.
        /// </summary>
        public int? BuyerId { get; set; }

        /// <summary>
        /// Навигационное свойство.
        /// </summary>
        public Buyer Buyer { get; set; }

        /// <summary>
        /// Список информации о покупках.
        /// </summary>
        public List<SalesData> SalesData { get; set; }

        /// <summary>
        /// Общая сумма всей покупки.
        /// </summary>
        public int TotalAmount {
            get
            {
                return SalesData.Select(p => p.ProductAmount).Sum();
            }
            private set { }
        }
    }
}
