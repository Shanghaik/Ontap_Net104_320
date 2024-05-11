using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ontap_Net104_320.Models;

namespace Ontap_Net104_320.Configurations
{
    public class BillConfig : IEntityTypeConfiguration<Bill>
    {
        public void Configure(EntityTypeBuilder<Bill> builder)
        {
            builder.HasKey(p => p.Id);
            // Khóa ngoại
            builder.HasOne(p=>p.Account).WithMany(p=>p.Bills).
                HasForeignKey(p=>p.Username);
            // builder.HasAlternateKey(); // Set thuộc tính là Unique
        }
    }
}
