using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Services.Catalog.Api.Infrastructure
{
    public partial class MvcMusicStoreContext : DbContext
    {
        public MvcMusicStoreContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {

        }
        public virtual DbSet<Album> Album { get; set; }
        public virtual DbSet<Artist> Artist { get; set; }
        public virtual DbSet<Cart> Cart { get; set; }
        public virtual DbSet<Genre> Genre { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<OrderDetail> OrderDetail { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseSqlServer(@"Data Source=89--SF-C40\SQL2014;Initial Catalog=MvcMusicStore;user id=sa;password=sa123456;");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Album>(entity =>
            {
                entity.HasIndex(e => e.AlbumId)
                    .HasName("IPK_ProductItem");

                entity.HasIndex(e => e.ArtistId)
                    .HasName("IFK_Artist_Album");

                entity.Property(e => e.AlbumArtUrl)
                    .HasMaxLength(1024)
                    .HasDefaultValueSql("(N'/Content/Images/placeholder.gif')");

                entity.Property(e => e.Price).HasColumnType("numeric(10, 2)");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(160);

                entity.HasOne(d => d.Artist)
                    .WithMany(p => p.Album)
                    .HasForeignKey(d => d.ArtistId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Album__ArtistId__276EDEB3");

                entity.HasOne(d => d.Genre)
                    .WithMany(p => p.Album)
                    .HasForeignKey(d => d.GenreId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Album_Genre");
            });

            modelBuilder.Entity<Artist>(entity =>
            {
                entity.HasIndex(e => e.ArtistId)
                    .HasName("IPK_Artist");

                entity.Property(e => e.Name).HasMaxLength(120);
            });

            modelBuilder.Entity<Cart>(entity =>
            {
                entity.HasKey(e => e.RecordId);

                entity.Property(e => e.CartId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.HasOne(d => d.Album)
                    .WithMany(p => p.Cart)
                    .HasForeignKey(d => d.AlbumId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cart_Album");
            });

            modelBuilder.Entity<Genre>(entity =>
            {
                entity.HasIndex(e => e.GenreId)
                    .HasName("IPK_Genre");

                entity.Property(e => e.Description).HasMaxLength(4000);

                entity.Property(e => e.Name).HasMaxLength(120);
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasIndex(e => e.OrderId)
                    .HasName("IPK_Invoice");

                entity.Property(e => e.Address).HasMaxLength(70);

                entity.Property(e => e.City).HasMaxLength(40);

                entity.Property(e => e.Country).HasMaxLength(40);

                entity.Property(e => e.Email).HasMaxLength(160);

                entity.Property(e => e.FirstName).HasMaxLength(160);

                entity.Property(e => e.LastName).HasMaxLength(160);

                entity.Property(e => e.OrderDate).HasColumnType("datetime");

                entity.Property(e => e.Phone).HasMaxLength(24);

                entity.Property(e => e.PostalCode).HasMaxLength(10);

                entity.Property(e => e.State).HasMaxLength(40);

                entity.Property(e => e.Total).HasColumnType("numeric(10, 2)");

                entity.Property(e => e.Username).HasMaxLength(256);
            });

            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.HasIndex(e => e.OrderDetailId)
                    .HasName("IPK_InvoiceLine");

                entity.HasIndex(e => e.OrderId)
                    .HasName("IFK_Invoice_InvoiceLine");

                entity.Property(e => e.UnitPrice).HasColumnType("numeric(10, 2)");

                entity.HasOne(d => d.Album)
                    .WithMany(p => p.OrderDetail)
                    .HasForeignKey(d => d.AlbumId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_InvoiceLine_Album");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderDetail)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__InvoiceLi__Invoi__2F10007B");
            });
        }
    }
}
