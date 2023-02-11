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
    public class BookDetailConfigurationType : IEntityTypeConfiguration<BookDetail>
    {
        public void Configure(EntityTypeBuilder<BookDetail> builder)
        {
            builder.ToTable("BookDetail");
            builder.HasKey(e => e.Id).HasName("PK__BookDeta__3214EC07EC11CE0C");
            builder.Property(e => e.Description).HasMaxLength(400);
            builder.Property(e => e.PublishDateTime).HasColumnType("datetime");
            builder.HasOne(d => d.Book).WithMany(p => p.BookDetails).HasForeignKey(d => d.BookId).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("Book_BookDetail_FK");
        }
    }
}
