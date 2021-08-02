using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace WebAPI_News.Models
{
    public partial class newsDbContext : DbContext
    {
        public newsDbContext()
        {
        }

        public newsDbContext(DbContextOptions<newsDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<News> News { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Chinese_Taiwan_Stroke_CI_AS");

            modelBuilder.Entity<News>(entity =>
            {
                entity.ToTable("news");

                entity.Property(e => e.NewsId).HasColumnName("newsId");

                entity.Property(e => e.Title)
                    .HasMaxLength(50)
                    .HasColumnName("title");

                entity.Property(e => e.Ymd)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ymd")
                    .IsFixedLength(true);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
