using CrudApiService.Abstract.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CrudApiService.Repository.ModelConfiguration
{
    /// <summary>
    /// Конфигурация модели ProvidedProduct.
    /// </summary>
    public class ProvidedProductConfiguration : IEntityTypeConfiguration<ProvidedProduct>
    {
        /// <summary>
        /// Конфигурация.
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<ProvidedProduct> builder)
        {
            builder.HasKey(k => k.Id);
        }
    }
}
