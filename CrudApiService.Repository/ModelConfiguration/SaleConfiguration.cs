using CrudApiService.Abstract.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CrudApiService.Repository.ModelConfiguration
{
    /// <summary>
    /// Конфигурация модели Sale.
    /// </summary>
    public class SaleConfiguration : IEntityTypeConfiguration<Sale>
    {
        /// <summary>
        /// Конфигурация.
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<Sale> builder)
        {
            builder.HasOne(p => p.Buyer)
                .WithMany(k => k.SaleIds)
                .HasForeignKey(p => p.Id);
        }
    }
}
