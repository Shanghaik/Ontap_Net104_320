using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ontap_Net104_320.Models;

namespace Ontap_Net104_320.Configurations
{
    public class CartConfig : IEntityTypeConfiguration<Cart>
    {
        public void Configure(EntityTypeBuilder<Cart> builder)
        {
            builder.HasKey(p => p.Username);
            // Cấu hình quan hệ 1-1
            builder.HasOne(p => p.Account).WithOne(p => p.Cart).
                HasForeignKey<Cart>(p => p.Username);
        }
    }
}
