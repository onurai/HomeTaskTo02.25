using HomeTaskTo02._25.Data.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace HomeTaskTo02._25.Data.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>(b =>
            {
                b.ToTable("BooksTable");
                b.HasKey(i=>i.BookId);
                b.Property(q => q.BookName).HasMaxLength(20);
                b.Property(l => l.BookName).HasColumnName("Name");
                b.HasIndex(i => i.BookId).IsUnique();
                b.HasOne(o => o.Author).WithMany(o => o.Books).HasForeignKey(x => x.AuthorId);

                b.Property(d => d.PurchasedDate).HasDefaultValue(DateTime.Now);
            });

            modelBuilder.Entity<Author>(b =>
            {
                b.ToTable("AuthorsTable");
                b.HasKey(i => i.AuthorId);
                b.Property(q => q.AuthorName).HasMaxLength(20);
                b.Property(l => l.AuthorName).HasColumnName("Name");
                b.HasIndex(i => i.AuthorId).IsUnique();
                b.HasMany(o => o.Books).WithOne(o => o.Author);
            });
        }
    }
}
