using System;
using System.Collections.Generic;
using System.Linq;
using CrudApiService.Abstract.Model;
using MoreLinq;

namespace CrudApiService.Repository
{
    /// <summary>
    /// Класс для генерации бд.
    /// </summary>
    public class DataGenerator
    {
        /// <summary>
        /// Инициализация контекста начальными данными.
        /// </summary>
        public static DataBaseContext Initialize()
        {
            var context = new DataBaseContext();

            context.Buyers.AddRange(
                    new Buyer() { Name = "Bob" },
                    new Buyer() { Name = "Alice" },
                    new Buyer() { Name = "Harry" },
                    new Buyer() { Name = "Hermiona" },
                    new Buyer() { Name = "Ron" },
                    new Buyer() { Name = "Albus" }
                );
            context.SaveChanges();

            context.Products.AddRange(
                new Product() {Name = "Milk", Price = 85},
                new Product() {Name = "Water", Price = 20},
                new Product() {Name = "Bread", Price = 15},
                new Product() {Name = "Cheese", Price = 180},
                new Product() {Name = "Apples", Price = 68},
                new Product() {Name = "Beans", Price = 113}
                );
            context.SaveChanges();

            context.Products.ForEach( 
                product =>
                {
                    context.ProvidedProducts
                        .Add(
                            new ProvidedProduct()
                            {
                                ProductId = product.Id,
                                ProductQuantity = new Random().Next(0, 500)
                            }
                        );
                    context.SaveChanges();
                }
            );

            context.SalesPoints.AddRange(
                new SalesPoint() {Name = "FixPrice", ProvidedProducts = context.ProvidedProducts.Take(3).ToList()},
                new SalesPoint() {Name = "Crossroad", ProvidedProducts = context.ProvidedProducts.Skip(2).ToList()},
                new SalesPoint() {Name = "Globus", ProvidedProducts = context.ProvidedProducts.Skip(3).ToList()}
            );
            context.SaveChanges();

            context.SalesData.Add(
                new SalesData()
                {
                    Product = context.Products.First(n => n.Name == "Cheese"),
                    ProductQuantity = 4,
                    ProductAmount = 720
                }
            );
            context.SaveChanges();

            context.Sales.Add(
                new Sale()
                {
                    Buyer = context.Buyers.First(v => v.Name == "Harry"),
                    Date = DateTime.Now.Date,
                    Time = DateTime.UtcNow.TimeOfDay,
                    SalesData = new List<SalesData>()
                    {
                        context.SalesData.First()
                    },
                    SalesPoint = context.SalesPoints.First(p => p.Name == "Crossroad")
                }
            );
            context.SaveChanges();
            return context;
        }


    }
}
