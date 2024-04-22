using Microsoft.EntityFrameworkCore;
using QuoteAPI.Model;

namespace QuoteAPI.ApplicationDbContext
{
    public class QuoteDbContext : DbContext
    {
        public QuoteDbContext(DbContextOptions options) : base(options)
        {
                
        }

        public DbSet<Quote> Quote  { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Quote>(entity =>
            {
                entity.ToTable("Quotes"); // Define the table name

                // Define primary key
                entity.HasKey(q => q.Id);

                // Define properties
                entity.Property(q => q.Id).HasColumnName("QuoteId");
                entity.Property(q => q.QuoteName).HasColumnName("QuoteName").IsRequired(); // Assuming QuoteName is the quote text
                entity.Property(q => q.Author).HasColumnName("Author").IsRequired(false); // Allow null for Author
                entity.Property(q => q.Tags).HasColumnName("Tags").IsRequired(false); // Allow null for Tags

                // Configure Tags as a collection of strings
                entity.Property(q => q.Tags)
                    .HasConversion(
                        v => string.Join(',', v),
                        v => v.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList()
                    );

                // You may define other configurations or relationships here as needed.

            });

            base.OnModelCreating(modelBuilder);
        }

    }
}
