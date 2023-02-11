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
    internal class LibraryConfigurationType : IEntityTypeConfiguration<Library>
    {
        public void Configure(EntityTypeBuilder<Library> builder)
        {
            builder.ToTable("Library");
            builder.HasKey(e => e.Id).HasName("PK__Library__3214EC07853ADEDD");
            builder.Property(e => e.Address).HasMaxLength(150);
            builder.Property(e => e.EmailAddress).HasMaxLength(100).IsUnicode(false);
            builder.Property(e => e.Name).HasMaxLength(100);
            builder.Property(e => e.PhoneNumber).HasMaxLength(20).IsUnicode(false);
        }
    }
}
