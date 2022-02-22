using CrudApiService.Abstract.Interfaces;
using CrudApiService.Abstract.Model;
using Microsoft.AspNetCore.Mvc;

namespace CrudApiService.WebHosting.Controllers
{
    /// <summary>
    /// Контролер для работы с репозиторием данных о продаже.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class SaleDataController : BaseCrudController<ISalesDataRepository, SalesData>
    {
        /// <inheritdoc />
        public SaleDataController(ISalesDataRepository repository)
            : base(repository)
        {
        }
    }
}
