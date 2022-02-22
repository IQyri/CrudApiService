using System.Linq;
using CrudApiService.Abstract.Interfaces;
using CrudApiService.Abstract.Model;
using Microsoft.AspNetCore.Mvc;

namespace CrudApiService.WebHosting.Controllers
{
    /// <summary>
    /// Контролер для работы с репозиторием покупателей.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class BuyerController : BaseCrudController<IBuyerRepository, Buyer>
    {
        /// <inheritdoc />
        public BuyerController(IBuyerRepository repository)
            : base(repository)
        {
        }

        /// <inheritdoc />
        public override IActionResult Read()
        {
            return new JsonResult(_repository.GetAll().Select(v => new
            {
                Id =  v.Id,
                Name = v.Name,
                SalesId = v.SalesIds?.Select(t => t.Id)
            }));
        }
    }
}
