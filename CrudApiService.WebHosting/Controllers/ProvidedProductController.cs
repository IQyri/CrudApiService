using CrudApiService.Abstract.Interfaces;
using CrudApiService.Abstract.Model;
using Microsoft.AspNetCore.Mvc;

namespace CrudApiService.WebHosting.Controllers
{
    /// <summary>
    /// Контролер для работы с репозиторием доступных для продажи товаров.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ProvidedProductController : BaseCrudController<IProvidedProductRepository, ProvidedProduct>
    {
        /// <inheritdoc />
        public ProvidedProductController(IProvidedProductRepository repository)
            : base(repository)
        {
        }
    }
}
