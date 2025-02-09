using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SaleSystem.Entity;

namespace SaleSystem.DAL.DBContext;

public partial class Dbsale0014Context : DbContext
{
    public Dbsale0014Context()
    {
    }

    public Dbsale0014Context(DbContextOptions<Dbsale0014Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Company> Companies { get; set; }

    public virtual DbSet<Configuration> Configurations { get; set; }

    public virtual DbSet<CorrelativeNumber> CorrelativeNumbers { get; set; }

    public virtual DbSet<Menu> Menus { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Rol> Rols { get; set; }

    public virtual DbSet<RolMenu> RolMenus { get; set; }

    public virtual DbSet<Sale> Sales { get; set; }

    public virtual DbSet<SaleDetail> SaleDetails { get; set; }

    public virtual DbSet<SaleDocType> SaleDocTypes { get; set; }

    public virtual DbSet<UserAccount> UserAccounts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.IdCategory).HasName("PK__Category__79D361B62867906D");

            entity.ToTable("Category");

            entity.Property(e => e.IdCategory).HasColumnName("idCategory");
            entity.Property(e => e.Description)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.IsActive).HasColumnName("isActive");
            entity.Property(e => e.RegisterDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("registerDate");
        });

        modelBuilder.Entity<Company>(entity =>
        {
            entity.HasKey(e => e.IdCompany).HasName("PK__Company__BBAEF00367AEE511");

            entity.ToTable("Company");

            entity.Property(e => e.IdCompany)
                .ValueGeneratedNever()
                .HasColumnName("idCompany");
            entity.Property(e => e.Address)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("address");
            entity.Property(e => e.CurrencySymbol)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("currencySymbol");
            entity.Property(e => e.DocName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("docName");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.LogoName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("logoName");
            entity.Property(e => e.LogoUrl)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("logoUrl");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Phone)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("phone");
            entity.Property(e => e.TaxPercentage)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("taxPercentage");
        });

        modelBuilder.Entity<Configuration>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Configuration");

            entity.Property(e => e.Property)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("property");
            entity.Property(e => e.Src)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("src");
            entity.Property(e => e.Val)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("val");
        });

        modelBuilder.Entity<CorrelativeNumber>(entity =>
        {
            entity.HasKey(e => e.IdCorrelativeNumber).HasName("PK__Correlat__C04AF647D6D5B269");

            entity.ToTable("CorrelativeNumber");

            entity.Property(e => e.IdCorrelativeNumber).HasColumnName("idCorrelativeNumber");
            entity.Property(e => e.LastNumber).HasColumnName("lastNumber");
            entity.Property(e => e.Management)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("management");
            entity.Property(e => e.NumOfDigits).HasColumnName("numOfDigits");
            entity.Property(e => e.UpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("updateDate");
        });

        modelBuilder.Entity<Menu>(entity =>
        {
            entity.HasKey(e => e.IdMenu).HasName("PK__Menu__C26AF4831DE09322");

            entity.ToTable("Menu");

            entity.Property(e => e.IdMenu).HasColumnName("idMenu");
            entity.Property(e => e.Controller)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("controller");
            entity.Property(e => e.Description)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.Icon)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("icon");
            entity.Property(e => e.IdMenuFather).HasColumnName("idMenuFather");
            entity.Property(e => e.IsActive).HasColumnName("isActive");
            entity.Property(e => e.PageAction)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("pageAction");
            entity.Property(e => e.RegisterDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("registerDate");

            entity.HasOne(d => d.IdMenuFatherNavigation).WithMany(p => p.InverseIdMenuFatherNavigation)
                .HasForeignKey(d => d.IdMenuFather)
                .HasConstraintName("FK__Menu__idMenuFath__49C3F6B7");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.IdProduct).HasName("PK__Product__5EEC79D10AD3F87A");

            entity.ToTable("Product");

            entity.Property(e => e.IdProduct).HasColumnName("idProduct");
            entity.Property(e => e.BarCode)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("barCode");
            entity.Property(e => e.Brand)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("brand");
            entity.Property(e => e.Description)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.IdCategory).HasColumnName("idCategory");
            entity.Property(e => e.ImgName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("imgName");
            entity.Property(e => e.ImgUrl)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("imgUrl");
            entity.Property(e => e.IsActive).HasColumnName("isActive");
            entity.Property(e => e.Price)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("price");
            entity.Property(e => e.RegisterDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("registerDate");
            entity.Property(e => e.Stock).HasColumnName("stock");

            entity.HasOne(d => d.IdCategoryNavigation).WithMany(p => p.Products)
                .HasForeignKey(d => d.IdCategory)
                .HasConstraintName("FK__Product__idCateg__5BE2A6F2");
        });

        modelBuilder.Entity<Rol>(entity =>
        {
            entity.HasKey(e => e.IdRol).HasName("PK__Rol__3C872F7667E888F1");

            entity.ToTable("Rol");

            entity.Property(e => e.IdRol).HasColumnName("idRol");
            entity.Property(e => e.Description)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.IsActive).HasColumnName("isActive");
            entity.Property(e => e.RegisterDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("registerDate");
        });

        modelBuilder.Entity<RolMenu>(entity =>
        {
            entity.HasKey(e => e.IdRolMenu).HasName("PK__RolMenu__CD2045D835642B94");

            entity.ToTable("RolMenu");

            entity.Property(e => e.IdRolMenu).HasColumnName("idRolMenu");
            entity.Property(e => e.IdMenu).HasColumnName("idMenu");
            entity.Property(e => e.IdRol).HasColumnName("idRol");
            entity.Property(e => e.IsActive).HasColumnName("isActive");
            entity.Property(e => e.RegisterDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("registerDate");

            entity.HasOne(d => d.IdMenuNavigation).WithMany(p => p.RolMenus)
                .HasForeignKey(d => d.IdMenu)
                .HasConstraintName("FK__RolMenu__idMenu__5165187F");

            entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.RolMenus)
                .HasForeignKey(d => d.IdRol)
                .HasConstraintName("FK__RolMenu__idRol__5070F446");
        });

        modelBuilder.Entity<Sale>(entity =>
        {
            entity.HasKey(e => e.IdSale).HasName("PK__Sale__C4AEB19898795C2D");

            entity.ToTable("Sale");

            entity.Property(e => e.IdSale).HasColumnName("idSale");
            entity.Property(e => e.ClientDoc)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("clientDoc");
            entity.Property(e => e.ClientName)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("clientName");
            entity.Property(e => e.IdSaleDocType).HasColumnName("idSaleDocType");
            entity.Property(e => e.IdUserAccount).HasColumnName("idUserAccount");
            entity.Property(e => e.RegisterDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("registerDate");
            entity.Property(e => e.SaleNumber)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("saleNumber");
            entity.Property(e => e.SubTotal)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("subTotal");
            entity.Property(e => e.Total)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("total");
            entity.Property(e => e.TotalTax)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("totalTax");

            entity.HasOne(d => d.IdSaleDocTypeNavigation).WithMany(p => p.Sales)
                .HasForeignKey(d => d.IdSaleDocType)
                .HasConstraintName("FK__Sale__idSaleDocT__6477ECF3");

            entity.HasOne(d => d.IdUserAccountNavigation).WithMany(p => p.Sales)
                .HasForeignKey(d => d.IdUserAccount)
                .HasConstraintName("FK__Sale__idUserAcco__656C112C");
        });

        modelBuilder.Entity<SaleDetail>(entity =>
        {
            entity.HasKey(e => e.IdSaleDetail).HasName("PK__SaleDeta__B23385CD4D727B5B");

            entity.ToTable("SaleDetail");

            entity.Property(e => e.IdSaleDetail).HasColumnName("idSaleDetail");
            entity.Property(e => e.IdProduct).HasColumnName("idProduct");
            entity.Property(e => e.IdSale).HasColumnName("idSale");
            entity.Property(e => e.Price)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("price");
            entity.Property(e => e.ProductBrand)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("productBrand");
            entity.Property(e => e.ProductCategory)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("productCategory");
            entity.Property(e => e.ProductDesc)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("productDesc");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
            entity.Property(e => e.Total)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("total");

            entity.HasOne(d => d.IdSaleNavigation).WithMany(p => p.SaleDetails)
                .HasForeignKey(d => d.IdSale)
                .HasConstraintName("FK__SaleDetai__idSal__693CA210");
        });

        modelBuilder.Entity<SaleDocType>(entity =>
        {
            entity.HasKey(e => e.IdSaleDocType).HasName("PK__SaleDocT__AC2D2FDE3EB70FBC");

            entity.ToTable("SaleDocType");

            entity.Property(e => e.IdSaleDocType).HasColumnName("idSaleDocType");
            entity.Property(e => e.Description)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.IsActive).HasColumnName("isActive");
            entity.Property(e => e.RegisterDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("registerDate");
        });

        modelBuilder.Entity<UserAccount>(entity =>
        {
            entity.HasKey(e => e.IdUserAccount).HasName("PK__UserAcco__37A2EB7372D22DFA");

            entity.ToTable("UserAccount");

            entity.Property(e => e.IdUserAccount).HasColumnName("idUserAccount");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.IdRol).HasColumnName("idRol");
            entity.Property(e => e.IsActive).HasColumnName("isActive");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Password)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("password");
            entity.Property(e => e.Phone)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("phone");
            entity.Property(e => e.PhotoName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("photoName");
            entity.Property(e => e.PhotoUrl)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("photoUrl");
            entity.Property(e => e.RegisterDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("registerDate");

            entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.UserAccounts)
                .HasForeignKey(d => d.IdRol)
                .HasConstraintName("FK__UserAccou__idRol__5535A963");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
