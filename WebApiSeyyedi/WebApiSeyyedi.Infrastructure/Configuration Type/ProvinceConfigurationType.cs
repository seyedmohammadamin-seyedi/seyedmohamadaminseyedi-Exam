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
    public class ProvinceConfigurationType : IEntityTypeConfiguration<Province>
    {
        public void Configure(EntityTypeBuilder<Province> builder)
        {
            builder.ToTable("Province");
            builder.HasKey(e => e.Id).HasName("PK__Province__3214EC07853ADEDD");
            builder.Property(e => e.Name).HasMaxLength(150);
        }
    }
}
