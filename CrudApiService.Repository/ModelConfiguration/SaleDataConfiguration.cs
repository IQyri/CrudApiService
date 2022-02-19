using CrudApiService.Abstract.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CrudApiService.Repository.ModelConfiguration
{
    /// <summary>
    /// Конфигурация модели SalesData.
    /// </summary>
    public class SaleDataConfiguration : IEntityTypeConfiguration<SalesData>
    {
        /// <summary>
        /// Конфигурация.
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<SalesData> builder)
        {
            builder.HasKey(k => k.ProductId);

            builder.Property(p => p.ProductAmount).ValueGeneratedOnAddOrUpdate();
        }
    }
}
