using System.Collections.Generic;

namespace CrudApiService.Abstract.Model
{
    /// <summary>
    /// Модель данных для точки продажи товара.
    /// </summary>
    public class SalesPoint
    {
        /// <summary>
        /// Идентификатор точки продажи.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Название точки продажи.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Список товаров доступных к продаже.
        /// </summary>
        public IList<ProvidedProduct> ProvidedProducts { get; set; }

    }
}
