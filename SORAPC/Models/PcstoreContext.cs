    using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SORAPC.Models;

public partial class PcstoreContext : DbContext
{
    public PcstoreContext()
    {
    }

    public PcstoreContext(DbContextOptions<PcstoreContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Catalogss> Catalogsses { get; set; }

    public virtual DbSet<Categoryss> Categorysses { get; set; }

    public virtual DbSet<Orderss> Ordersses { get; set; }

    public virtual DbSet<PosOrder> PosOrders { get; set; }

    public virtual DbSet<Statuss> Statusses { get; set; }

    public virtual DbSet<Userss> Usersses { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=ZESHALONDRAG\\SQLEXPRESS;Initial Catalog=PCstore;Integrated Security=True;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Catalogss>(entity =>
        {
            entity.HasKey(e => e.IdCatalogs).HasName("PK__Catalogs__E129E1E181D4790C");

            entity.ToTable("Catalogss");

            entity.Property(e => e.IdCatalogs).HasColumnName("ID_Catalogs");
            entity.Property(e => e.CategoryId).HasColumnName("Category_ID");
            entity.Property(e => e.Descriptions).HasColumnType("text");
            entity.Property(e => e.ImageUrl)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Image_url");
            entity.Property(e => e.Names)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.Category).WithMany(p => p.Catalogsses)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("FK__Catalogss__Categ__59FA5E80");
        });

        modelBuilder.Entity<Categoryss>(entity =>
        {
            entity.HasKey(e => e.IdCategorys).HasName("PK__Category__02A5B5FF7A857689");

            entity.ToTable("Categoryss");

            entity.Property(e => e.IdCategorys).HasColumnName("ID_Categorys");
            entity.Property(e => e.Names)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Orderss>(entity =>
        {
            entity.HasKey(e => e.IdOrders).HasName("PK__Orderss__20F81C1DC87EB57F");

            entity.ToTable("Orderss");

            entity.Property(e => e.IdOrders).HasColumnName("ID_Orders");
            entity.Property(e => e.Dates)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.StatusId).HasColumnName("Status_ID");
            entity.Property(e => e.TotalSum).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.UsersId).HasColumnName("Users_ID");

            entity.HasOne(d => d.Status).WithMany(p => p.Ordersses)
                .HasForeignKey(d => d.StatusId)
                .HasConstraintName("FK__Orderss__Status___5FB337D6");

            entity.HasOne(d => d.Users).WithMany(p => p.Ordersses)
                .HasForeignKey(d => d.UsersId)
                .HasConstraintName("FK__Orderss__Users_I__5EBF139D");
        });

        modelBuilder.Entity<PosOrder>(entity =>
        {
            entity.HasKey(e => e.IdPosOrders).HasName("PK__PosOrder__D41EBBEE4FB245C0");

            entity.Property(e => e.IdPosOrders).HasColumnName("ID_PosOrders");
            entity.Property(e => e.CatalogsId).HasColumnName("Catalogs_ID");
            entity.Property(e => e.OrdersId).HasColumnName("Orders_ID");
            entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.Catalogs).WithMany(p => p.PosOrders)
                .HasForeignKey(d => d.CatalogsId)
                .HasConstraintName("FK__PosOrders__Catal__6383C8BA");

            entity.HasOne(d => d.Orders).WithMany(p => p.PosOrders)
                .HasForeignKey(d => d.OrdersId)
                .HasConstraintName("FK__PosOrders__Order__628FA481");
        });

        modelBuilder.Entity<Statuss>(entity =>
        {
            entity.HasKey(e => e.IdStatus).HasName("PK__Statuss__5AC2A734EDD45E09");

            entity.ToTable("Statuss");

            entity.Property(e => e.IdStatus).HasColumnName("ID_Status");
            entity.Property(e => e.StatusName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Userss>(entity =>
        {
            entity.HasKey(e => e.IdUsers).HasName("PK__Userss__B97FFDA11E4156C6");

            entity.ToTable("Userss");

            entity.HasIndex(e => e.Email, "UQ__Userss__A9D105340C6D3405").IsUnique();

            entity.HasIndex(e => e.Logins, "UQ__Userss__D00D0632256474AC").IsUnique();

            entity.Property(e => e.IdUsers).HasColumnName("ID_Users");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Logins)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Passwords)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
