using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Lab_02.Models;

public partial class Lab01Context : DbContext
{
    public Lab01Context()
    {
    }

    public Lab01Context(DbContextOptions<Lab01Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Author> Authors { get; set; }

    public virtual DbSet<AuthorInfoView> AuthorInfoViews { get; set; }

    public virtual DbSet<Book> Books { get; set; }

    public virtual DbSet<BookAuthor> BookAuthors { get; set; }

    public virtual DbSet<Costumer> Costumers { get; set; }

    public virtual DbSet<CostumerPurchasesView> CostumerPurchasesViews { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderItem> OrderItems { get; set; }

    public virtual DbSet<Publisher> Publishers { get; set; }

    public virtual DbSet<StockStatus> StockStatuses { get; set; }

    public virtual DbSet<Store> Stores { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=localhost;Database=Lab_01;Integrated Security=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Author>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Authors__3214EC274A3321D9");

            entity.Property(e => e.Id).HasColumnName("ID");
        });

        modelBuilder.Entity<AuthorInfoView>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("AuthorInfoView");

            entity.Property(e => e.Age)
                .HasMaxLength(17)
                .IsUnicode(false);
            entity.Property(e => e.FullName).HasColumnName("Full Name");
            entity.Property(e => e.NumberOfTitles).HasColumnName("Number Of Titles");
            entity.Property(e => e.ValueOfStock).HasColumnName("Value of Stock");
        });

        modelBuilder.Entity<Book>(entity =>
        {
            entity.HasKey(e => e.Isbn).HasName("PK__Books__447D36EB9A512187");

            entity.Property(e => e.Isbn)
                .ValueGeneratedNever()
                .HasColumnName("ISBN");
            entity.Property(e => e.Language).HasDefaultValue("English");
            entity.Property(e => e.Price).HasDefaultValue(0.0);
            entity.Property(e => e.PublisherId).HasColumnName("PublisherID");

            entity.HasOne(d => d.Publisher).WithMany(p => p.Books)
                .HasForeignKey(d => d.PublisherId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PublisherID");
            entity.HasData(
                new Book { Isbn = 9780241714348, Title = "Alchemised", Language = "English", Price = 215, ReleaseDate = new DateOnly(2025,09,23), PublisherId = 6},
                new Book { Isbn = 9780349437057, Title = "Iron Flame", Language = "English", Price = 142, ReleaseDate = new DateOnly(2024, 11, 19), PublisherId = 4 },
                new Book { Isbn = 9780349437071, Title = "Onyx Storm", Language = "English", Price = 210, ReleaseDate = new DateOnly(2025, 01, 21), PublisherId = 4 },
                new Book { Isbn = 9781035414505, Title = "The Book of Azrael", Language = "English", Price = 147, ReleaseDate = new DateOnly(2024, 01, 18), PublisherId = 5 }
                );
        });

        modelBuilder.Entity<BookAuthor>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("BookAuthor");

            entity.Property(e => e.AuthorId).HasColumnName("AuthorID");
            entity.Property(e => e.Isbn).HasColumnName("ISBN");

            entity.HasOne(d => d.Author).WithMany()
                .HasForeignKey(d => d.AuthorId)
                .HasConstraintName("FK_AuthorID");

            entity.HasOne(d => d.IsbnNavigation).WithMany()
                .HasForeignKey(d => d.Isbn)
                .HasConstraintName("FK_ISBN");
        });

        modelBuilder.Entity<Costumer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Costumer__3214EC270DA0E6BC");

            entity.Property(e => e.Id).HasColumnName("ID");
        });

        modelBuilder.Entity<CostumerPurchasesView>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("CostumerPurchasesView");

            entity.Property(e => e.FullName).HasColumnName("Full Name");
            entity.Property(e => e.NumberOfPurchesedArticles).HasColumnName("Number of Purchesed articles");
            entity.Property(e => e.PurchasedTitles).HasColumnName("Purchased Titles");
            entity.Property(e => e.TotalSpent).HasColumnName("Total spent");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Employee__3214EC27D51EC65A");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Salary).HasDefaultValue(0.0);
            entity.Property(e => e.WorkPlaceId).HasColumnName("WorkPlaceID");

            entity.HasOne(d => d.WorkPlace).WithMany(p => p.Employees)
                .HasForeignKey(d => d.WorkPlaceId)
                .HasConstraintName("FK_WorkPlaceID");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrderNumber).HasName("PK__Orders__CAC5E742D485D3A0");

            entity.Property(e => e.CostumerId).HasColumnName("CostumerID");
            entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

            entity.HasOne(d => d.Costumer).WithMany(p => p.Orders)
                .HasForeignKey(d => d.CostumerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CostumerID");

            entity.HasOne(d => d.Employee).WithMany(p => p.Orders)
                .HasForeignKey(d => d.EmployeeId)
                .HasConstraintName("FK_EmployeeID");

            entity.HasOne(d => d.StoreCodeNavigation).WithMany(p => p.Orders)
                .HasForeignKey(d => d.StoreCode)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_StoreCode");
        });

        modelBuilder.Entity<OrderItem>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.Amount).HasDefaultValue(1);
            entity.Property(e => e.ItemIsbn).HasColumnName("ItemISBN");

            entity.HasOne(d => d.ItemIsbnNavigation).WithMany()
                .HasForeignKey(d => d.ItemIsbn)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ItemISBN");

            entity.HasOne(d => d.OrderNumberNavigation).WithMany()
                .HasForeignKey(d => d.OrderNumber)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrderNumber");
        });

        modelBuilder.Entity<Publisher>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Publishe__3214EC27E8DB943B");

            entity.Property(e => e.Id).HasColumnName("ID");
        });

        modelBuilder.Entity<StockStatus>(entity =>
        {
            entity.HasKey(e => new { e.StoreId, e.BookId });

            entity.ToTable("StockStatus");

            entity.Property(e => e.StoreId).HasColumnName("StoreID");
            entity.Property(e => e.BookId).HasColumnName("BookID");
            entity.Property(e => e.InStock).HasDefaultValue(0);

            entity.HasOne(d => d.Book).WithMany(p => p.StockStatuses)
                .HasForeignKey(d => d.BookId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BookID");

            entity.HasOne(d => d.Store).WithMany(p => p.StockStatuses)
                .HasForeignKey(d => d.StoreId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_StoreID");
            entity.HasData(
                new StockStatus() { StoreId = 1, BookId = 9780241714348, InStock = 3 },
                new StockStatus() { StoreId = 1, BookId = 9781035414505, InStock = 16 },
                new StockStatus() { StoreId = 1, BookId = 9781035437030, InStock = 2 },
                new StockStatus() { StoreId = 1, BookId = 9781408728512, InStock = 4 },
                new StockStatus() { StoreId = 1, BookId = 9781471415227, InStock = 15 },
                new StockStatus() { StoreId = 2, BookId = 9780349437071, InStock = 22 },
                new StockStatus() { StoreId = 2, BookId = 9781471407598, InStock = 2 },
                new StockStatus() { StoreId = 2, BookId = 9781471415227, InStock = 10 },
                new StockStatus() { StoreId = 3, BookId = 9780241714348, InStock = 1 },
                new StockStatus() { StoreId = 3, BookId = 9781035414505, InStock = 4 },
                new StockStatus() { StoreId = 3, BookId = 9781035437030, InStock = 6 },
                new StockStatus() { StoreId = 3, BookId = 9781471415227, InStock = 6 },
                new StockStatus() { StoreId = 3, BookId = 9781760630737, InStock = 11 }
                );
        });

        modelBuilder.Entity<Store>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Stores__3214EC270BBFD00D");

            entity.Property(e => e.Id).HasColumnName("ID");

            entity.HasData(
                new Store () { Id = 1, Name = "Göteborg Backaplan", Adress = "Krokegårdsgatan 5, Göteborg"},
                new Store() { Id = 2, Name = "Halmstad Hallarna", Adress = "Prästvägen 1, Halmstad" },
                new Store() { Id = 3, Name = "Karlskrona", Adress = "Hantverkaregatan 1, Karlskrona" }
                );
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
