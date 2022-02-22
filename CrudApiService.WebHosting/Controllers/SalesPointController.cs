using System.Linq;
using CrudApiService.Abstract.Interfaces;
using CrudApiService.Abstract.Model;
using Microsoft.AspNetCore.Mvc;

namespace CrudApiService.WebHosting.Controllers
{
    /// <summary>
    /// Контролер для работы с репозиторием точек продаж.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class SalesPointController : BaseCrudController<ISalesPointRepository, SalesPoint>
    {
        /// <inheritdoc />
        public SalesPointController(ISalesPointRepository repository)
            : base(repository)
        {
        }

        /// <inheritdoc />
        public override IActionResult Read()
        {
            return new JsonResult(_repository.GetAll().Select(v => new
            {
                Id = v.Id,
                Name = v.Name,
                ProvidedProduct = v.ProvidedProducts?.Select(t => t.Id)
            }));
        }
    }
}
