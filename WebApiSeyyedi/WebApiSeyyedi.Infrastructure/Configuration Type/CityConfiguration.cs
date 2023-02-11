using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiSeyyedi.Data.Models;

namespace WebApiSeyyedi.Infrastructure.Configuration_Type
{
    public class CityConfiguration : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.ToTable("City");

            builder.HasKey(e => e.Id).HasName("PK__City__3214EC07F8E418B9");

            builder.Property(e => e.Name).HasMaxLength(150);


            builder.HasOne(d => d.Province).WithMany(p => p.Citys).HasForeignKey(d => d.ProvinceId).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("Province_Book_FK");
        }
    }
}
