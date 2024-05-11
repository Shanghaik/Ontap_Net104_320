using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ontap_Net104_320.Models;

namespace Ontap_Net104_320.Configurations
{
    public class CartDetailsConfig : IEntityTypeConfiguration<CartDetails>
    {
        public void Configure(EntityTypeBuilder<CartDetails> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(p => p.Cart).WithMany(p => p.Details).
                HasForeignKey(p=>p.Username).HasConstraintName("FK_Cart_CartDetails");
        }
    }
}
