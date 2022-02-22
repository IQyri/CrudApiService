using CrudApiService.Abstract.Interfaces;
using CrudApiService.Abstract.Model;
using Microsoft.AspNetCore.Mvc;

namespace CrudApiService.WebHosting.Controllers
{
    /// <summary>
    /// Контролер для работы с репозиторием продуктов.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : BaseCrudController<IProductRepository, Product>
    {
        /// <inheritdoc />
        public ProductController(IProductRepository repository)
            : base(repository)
        {
        }
    }
}
