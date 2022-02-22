using System;
using System.Linq;
using CrudApiService.Abstract.Interfaces;
using CrudApiService.Abstract.Model;
using CrudApiService.WebHosting.Models;
using Microsoft.AspNetCore.Mvc;

namespace CrudApiService.WebHosting.Controllers
{
    /// <summary>
    /// Контролер для работы с репозиторием продаж.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class SalesController : BaseCrudController<ISalesRepository, Sale>
    {
        private readonly IProvidedProductRepository _providedProductRepository;
        private readonly ISalesPointRepository _salesPointRepository;
        private readonly IBuyerRepository _buyerRepository;
        private readonly ISalesDataRepository _salesDataRepository;
        private readonly ISalesRepository _salesRepository;
        private readonly IProductRepository _productRepository;

        /// <inheritdoc />
        public SalesController(
            IProvidedProductRepository providedProductRepository,
            ISalesPointRepository salesPointRepository,
            IBuyerRepository buyerRepository,
            ISalesDataRepository salesDataRepository,
            ISalesRepository salesRepository,
            IProductRepository productRepository
        )
            : base(salesRepository)
        {
            _providedProductRepository = providedProductRepository;
            _salesPointRepository = salesPointRepository;
            _buyerRepository = buyerRepository;
            _salesDataRepository = salesDataRepository;
            _salesRepository = salesRepository;
            _productRepository = productRepository;
        }

        /// <summary>
        /// Создать акт о продаже.
        /// </summary>
        /// <param name="request">Запрос на создание <see cref="SaleRequest"/>.</param>
        /// <returns></returns>
        [HttpPost(nameof(CreateSale))]
        public IActionResult CreateSale(SaleRequest request)
        {
            if (!ModelState.IsValid)
            {
                var errors = string.Join(
                    "\n",
                    ModelState
                        .SelectMany(v => v.Value.Errors)
                        .Select(v => v.ErrorMessage)
                        .ToArray()
                );
                return BadRequest(errors);
            }

            var suitableSalePoints = request.SalesInfo
                .Select(saleInfo => _salesPointRepository.ByFilter(productName: saleInfo.ProductName, quantity: saleInfo.Quantity))
                .Where(p => p != null)
                .ToList();

            if (suitableSalePoints.Count == 0)
            {
                return NotFound("Not found SalePoint which can provide requested product or quantity");
            }

            var saleAct = new Sale()
            {
                SalesPointId = suitableSalePoints.First().Id,
                BuyerId = request.BuyerId,
                Date = DateTime.Now.Date,
                Time = DateTime.Now.TimeOfDay,
                SalesData = request.SalesInfo
                    .Select(saleInfo => _salesDataRepository.CreateSalesData(saleInfo.ProductName, saleInfo.Quantity))
                    .ToList()
            };
            _salesRepository.Create(saleAct);

            return new JsonResult(
                new SuccessResponse
                {
                    BuyerId = saleAct.BuyerId,
                    SaleId = saleAct.Id
                }
            );
        }

        /// <inheritdoc />
        public override IActionResult Create(Sale model)
        {
            return CreateSale(
                new SaleRequest()
                {
                    BuyerId = model.BuyerId,
                    SalesInfo = model.SalesData.Select(v => new SaleInfo()
                    {
                        ProductName = _productRepository.GetItem(v.ProductId).Name,
                        Quantity = v.ProductQuantity
                    }).ToArray()
                }
            );
        }
        
        /// <inheritdoc />
        public override IActionResult Read()
        {
            return new JsonResult(_salesRepository.GetAll().Select(v => new
            {
                Id = v.Id,
                BuyerId = v.BuyerId,
                Date = v.Date.ToString("d.MM.yyyy"),
                Time = $"{v.Time.Hours}:{v.Time.Minutes}:{v.Time.Seconds}",
                SalePoint = _salesPointRepository.GetItem(v.Id).Name,
                TotalPrice = v.TotalAmount
            }));
        }
    }
}
