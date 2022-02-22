using System;
using System.Collections.Generic;
using System.Linq;
using CrudApiService.Abstract.Model;
using CrudApiService.Repository;
using CrudApiService.Repository.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoreLinq;

namespace CrudApiService.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Test1()
        {
            using var db = new DataBaseContext();

            // Create
            Console.WriteLine("Inserting a new product");
            db.Products.Add(
                new Product()
                {
                    Name = "Milk",
                    Price = 70
                }
            );
            db.Products.Add(
                new Product()
                {
                    Name = "Water",
                    Price = 20
                }
            );
            db.Products.Add(
                new Product()
                {
                    Price = 15
                }
            );
            db.SaveChanges();

            // Read
            Console.WriteLine("Querying for a products");
            var products = db.Products
                .OrderBy(p => p.Price)
                .ToList();
            var nameless = db.Products.First(p => p.Name == null);

            // Update
            Console.WriteLine("Updating the product and providedProduct");
            nameless.Name = "Bread";
            db.Products.ForEach(
                p =>
                {
                    db.ProvidedProducts.Add(
                        new ProvidedProduct()
                        {
                            Product = p,
                            ProductQuantity = new Random().Next()
                        }
                    );
                    db.SaveChanges();
                }
            );
            db.SaveChanges();

            //Check reference
            db.ProvidedProducts.ForEach(v => Console.WriteLine($"Provided product: Id - {v.ProductId}, Quantity: {v.ProductQuantity}"));
        }

        [TestMethod]
        public void Test02()
        {
            using var context = DataGenerator.Initialize();
            context.Buyers
                .ForEach(p => Console.WriteLine($"Buyers Info: Id-{p.Id} Sales-{p.SalesIds != null}"));
            context.Sales
                .ForEach(
                    s =>
                        Console.WriteLine(
                            $"Sales: Buyer Id - {s.BuyerId} Date - {s.Date} Time - {s.Time} SalePoint - {s.SalesPoint.Name} SalesData - {string.Join(", ", s.SalesData.Select(v => v.Product.Name).ToList())} Amount - {s.TotalAmount}"
                        )
                );
        }

        [TestMethod]
        public void Test03()
        {
            using var context = DataGenerator.Initialize();
            var salesPointRepository = new SalesPointRepository(context);
            var productList = new List<(string, int)>()
            {
                ("Phone", 10)
            };

            //Логика когда один или несколько продуктов из списка не существует в бд - ?
            var point = salesPointRepository.ByFilter(productName: "Phone", quantity: 10);
            var suitableSalePoints = productList
                .Select(tuple => salesPointRepository.ByFilter(productName: tuple.Item1, quantity: tuple.Item2))
                .Where(p=> p != null)
                .ToList();
        }
    }
}
