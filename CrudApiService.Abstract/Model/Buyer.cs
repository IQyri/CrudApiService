using System.Collections.Generic;

namespace CrudApiService.Abstract.Model
{
    /// <summary>
    /// Модель данных покупателя.
    /// </summary>
    public class Buyer
    {
        /// <summary>
        /// Идентификатор покупателя.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Имя покупателя.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Коллекция всех идентификаторов покупок.
        /// </summary>
        public virtual List<Sale> SalesIds { get; set; }
    }
}
