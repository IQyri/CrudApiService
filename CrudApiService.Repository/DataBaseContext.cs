using CrudApiService.Abstract.Model;
using CrudApiService.Repository.ModelConfiguration;
using Microsoft.EntityFrameworkCore;

namespace CrudApiService.Repository
{
    /// <summary>
    /// Контекст базы данных.
    /// </summary>
    public sealed class DataBaseContext : DbContext
    {
        /// <summary>
        /// Коллекция продуктов.
        /// </summary>
        public DbSet<Product> Products { get; set; }

        /// <summary>
        /// Коллекция точек продаж.
        /// </summary>
        public DbSet<SalesPoint> SalesPoints { get; set; }

        /// <summary>
        /// Коллекция доступных для продажи товаров.
        /// </summary>
        public DbSet<ProvidedProduct> ProvidedProducts { get; set; }

        /// <summary>
        /// Коллекция покупателей.
        /// </summary>
        public DbSet<Buyer> Buyers { get; set; }

        /// <summary>
        /// Коллекция актов продаж
        /// </summary>
        public DbSet<Sale> Sales { get; set; }
        
        /// <summary>
        /// Коллекция данных о продаже.
        /// </summary>
        public DbSet<SalesData> SalesData { get; set; }

        /// <summary>
        /// Конструктор.
        /// </summary>
        public DataBaseContext()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }
        /// <summary>
        /// Конструктор с настройками.
        /// </summary>
        /// <param name="options"></param>
        public DataBaseContext(DbContextOptions<DataBaseContext> options)
            : base(options)
        {
        }

        /// <summary>
        /// Конфигурация контекста.
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseInMemoryDatabase("DbTest");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new SaleConfiguration());
            modelBuilder.ApplyConfiguration(new ProvidedProductConfiguration());
            modelBuilder.ApplyConfiguration(new SaleDataConfiguration());
        }
    }
}
