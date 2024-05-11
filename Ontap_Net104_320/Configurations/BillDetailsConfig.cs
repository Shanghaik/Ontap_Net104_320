using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ontap_Net104_320.Models;

namespace Ontap_Net104_320.Configurations
{
    public class BillDetailsConfig : IEntityTypeConfiguration<BillDetails>
    {
        public void Configure(EntityTypeBuilder<BillDetails> builder)
        {
            builder.HasKey(p=>p.Id);
            builder.HasOne(p=>p.Bill).WithMany(p=>p.Details).
                HasForeignKey(p=>p.BillId);
        }
    }
}
