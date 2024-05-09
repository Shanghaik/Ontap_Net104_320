using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ontap_Net104_320.Models;

namespace Ontap_Net104_320.Configurations
{
    public class AccountConfig : IEntityTypeConfiguration<Account>
    {
        // FluentApi được sử dụng để dấu hình các bảng dựa trên các model và được ghi đè lên
        // các ràng buộc có sẵn hoặc DA
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            // Khóa chính
            builder.HasKey(p => p.Username);
            // Key có nhiều cột
            // builder.HasKey(p => new {p.Username, p.Password}); // key có 2 cột
            // builder.HasNoKey(); // Không có khóa
            // Cấu hình thuộc tính
            builder.Property(p => p.Password).HasColumnType("varchar(256)");
            builder.Property(p=>p.Address).IsUnicode(true).IsFixedLength(true).HasMaxLength(256);
            // .IsUnicode(true).IsFixedLength(true).HasMaxLength(256) tương đương với nvarchar(256)

        }
    }
}
