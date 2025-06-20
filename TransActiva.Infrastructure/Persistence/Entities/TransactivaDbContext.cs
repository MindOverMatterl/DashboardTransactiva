using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace TransActiva.Infrastructure.Persistence.Entities;

public partial class TransactivaDbContext : DbContext
{
    public TransactivaDbContext()
    {
    }

    public TransactivaDbContext(DbContextOptions<TransactivaDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Boleta> Boleta { get; set; }

    public virtual DbSet<Envio> Envios { get; set; }

    public virtual DbSet<Pago> Pagos { get; set; }

    public virtual DbSet<Pedido> Pedidos { get; set; }

    public virtual DbSet<Pedidosproducto> Pedidosproductos { get; set; }

    public virtual DbSet<Preparacion> Preparacions { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Userprofile> Userprofiles { get; set; }

    public virtual DbSet<Usertype> Usertypes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        
    }
    
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
  //      => optionsBuilder.UseMySql("server=localhost;user=root;password=72882624V.;database=transactiva", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.42-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Boleta>(entity =>
        {
            entity.HasKey(e => e.IdBoleta).HasName("PRIMARY");

            entity
                .ToTable("boleta")
                .UseCollation("utf8mb4_general_ci");

            entity.Property(e => e.Ruta).HasMaxLength(255);
        });

        modelBuilder.Entity<Envio>(entity =>
        {
            entity.HasKey(e => e.IdEnvio).HasName("PRIMARY");

            entity
                .ToTable("envio")
                .UseCollation("utf8mb4_general_ci");

            entity.Property(e => e.Asesor).HasMaxLength(100);
            entity.Property(e => e.DireccionEnvio)
                .HasMaxLength(255)
                .HasColumnName("Direccion_Envio");
            entity.Property(e => e.DireccionRecojo)
                .HasMaxLength(255)
                .HasColumnName("Direccion_Recojo");
            entity.Property(e => e.Estado).HasMaxLength(50);
            entity.Property(e => e.FechaLlegada)
                .HasColumnType("datetime")
                .HasColumnName("Fecha_Llegada");
            entity.Property(e => e.NombreEmpresa)
                .HasMaxLength(100)
                .HasColumnName("Nombre_Empresa");
            entity.Property(e => e.NroGuia)
                .HasMaxLength(50)
                .HasColumnName("Nro_Guia");
            entity.Property(e => e.NumeroTelefonico)
                .HasMaxLength(20)
                .HasColumnName("Numero_Telefonico");
            entity.Property(e => e.RucEmpresa)
                .HasMaxLength(11)
                .HasColumnName("Ruc_Empresa");
        });

        modelBuilder.Entity<Pago>(entity =>
        {
            entity.HasKey(e => e.IdPago).HasName("PRIMARY");

            entity
                .ToTable("pagos")
                .UseCollation("utf8mb4_general_ci");

            entity.HasIndex(e => e.IdBoleta, "IdBoleta");

            entity.Property(e => e.Estado).HasMaxLength(50);
            entity.Property(e => e.Fecha).HasColumnType("datetime");
            entity.Property(e => e.FechaPago)
                .HasColumnType("datetime")
                .HasColumnName("Fecha_Pago");
            entity.Property(e => e.Monto).HasPrecision(10, 2);

            entity.HasOne(d => d.IdBoletaNavigation).WithMany(p => p.Pagos)
                .HasForeignKey(d => d.IdBoleta)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("pagos_ibfk_1");
        });

        modelBuilder.Entity<Pedido>(entity =>
        {
            entity.HasKey(e => e.IdPedido).HasName("PRIMARY");

            entity
                .ToTable("pedidos")
                .UseCollation("utf8mb4_general_ci");

            entity.HasIndex(e => e.IdComprador, "IdComprador");

            entity.HasIndex(e => e.IdPedidosProductos, "IdPedidosProductos");

            entity.HasIndex(e => e.IdProveedor, "IdProveedor");

            entity.Property(e => e.Estado).HasMaxLength(50);

            entity.HasOne(d => d.IdCompradorNavigation).WithMany(p => p.PedidoIdCompradorNavigations)
                .HasForeignKey(d => d.IdComprador)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("pedidos_ibfk_2");

            entity.HasOne(d => d.IdPedidosProductosNavigation).WithMany(p => p.Pedidos)
                .HasForeignKey(d => d.IdPedidosProductos)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("pedidos_ibfk_3");

            entity.HasOne(d => d.IdProveedorNavigation).WithMany(p => p.PedidoIdProveedorNavigations)
                .HasForeignKey(d => d.IdProveedor)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("pedidos_ibfk_1");
        });

        modelBuilder.Entity<Pedidosproducto>(entity =>
        {
            entity.HasKey(e => e.IdPedidosProductos).HasName("PRIMARY");

            entity
                .ToTable("pedidosproductos")
                .UseCollation("utf8mb4_general_ci");

            entity.HasIndex(e => e.IdPago, "IdPago");

            entity.HasIndex(e => e.IdPreparacion, "IdPreparacion");

            entity.Property(e => e.Descripcion).HasColumnType("text");
            entity.Property(e => e.DireccionEntrega).HasMaxLength(255);
            entity.Property(e => e.FechaLlegadaAcordada)
                .HasColumnType("datetime")
                .HasColumnName("Fecha_Llegada_Acordada");
            entity.Property(e => e.FechaSolicitada)
                .HasColumnType("datetime")
                .HasColumnName("Fecha_Solicitada");
            entity.Property(e => e.NombreTransaccion)
                .HasMaxLength(255)
                .HasColumnName("Nombre_Transaccion");
            entity.Property(e => e.Producto).HasMaxLength(255);

            entity.HasOne(d => d.IdPagoNavigation).WithMany(p => p.Pedidosproductos)
                .HasForeignKey(d => d.IdPago)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("pedidosproductos_ibfk_1");

            entity.HasOne(d => d.IdPreparacionNavigation).WithMany(p => p.Pedidosproductos)
                .HasForeignKey(d => d.IdPreparacion)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("pedidosproductos_ibfk_2");
        });

        modelBuilder.Entity<Preparacion>(entity =>
        {
            entity.HasKey(e => e.IdPreparacion).HasName("PRIMARY");

            entity
                .ToTable("preparacion")
                .UseCollation("utf8mb4_general_ci");

            entity.HasIndex(e => e.IdEnvio, "IdEnvio");

            entity.Property(e => e.ComoEnvia)
                .HasMaxLength(255)
                .HasColumnName("Como_Envia");
            entity.Property(e => e.Detalles).HasColumnType("text");
            entity.Property(e => e.Estado).HasMaxLength(50);

            entity.HasOne(d => d.IdEnvioNavigation).WithMany(p => p.Preparacions)
                .HasForeignKey(d => d.IdEnvio)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("preparacion_ibfk_1");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PRIMARY");

            entity
                .ToTable("users")
                .UseCollation("utf8mb4_general_ci");

            entity.HasIndex(e => e.Email, "Email").IsUnique();

            entity.HasIndex(e => e.UserTypeId, "UserTypeId");

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp");
            entity.Property(e => e.Email).HasMaxLength(150);
            entity.Property(e => e.FailedLoginAttempts).HasDefaultValueSql("'0'");
            entity.Property(e => e.LockoutUntil).HasColumnType("datetime");
            entity.Property(e => e.Password).HasMaxLength(255);

            entity.HasOne(d => d.UserType).WithMany(p => p.Users)
                .HasForeignKey(d => d.UserTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("users_ibfk_1");
        });

        modelBuilder.Entity<Userprofile>(entity =>
        {
            entity.HasKey(e => e.UserProfileId).HasName("PRIMARY");

            entity
                .ToTable("userprofiles")
                .UseCollation("utf8mb4_general_ci");

            entity.HasIndex(e => e.ManagerEmail, "EmailManager").IsUnique();

            entity.HasIndex(e => e.ManagerDni, "ManagerDni").IsUnique();

            entity.HasIndex(e => e.Ruc, "Ruc").IsUnique();

            entity.HasIndex(e => e.UserId, "UserId").IsUnique();

            entity.Property(e => e.Address).HasMaxLength(255);
            entity.Property(e => e.ManagerDni).HasMaxLength(8);
            entity.Property(e => e.ManagerEmail).HasMaxLength(150);
            entity.Property(e => e.ManagerName).HasMaxLength(100);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Phone).HasMaxLength(20);
            entity.Property(e => e.Ruc).HasMaxLength(11);

            entity.HasOne(d => d.User).WithOne(p => p.Userprofile)
                .HasForeignKey<Userprofile>(d => d.UserId)
                .HasConstraintName("userprofiles_ibfk_1");
        });

        modelBuilder.Entity<Usertype>(entity =>
        {
            entity.HasKey(e => e.UserTypeId).HasName("PRIMARY");

            entity
                .ToTable("usertypes")
                .UseCollation("utf8mb4_general_ci");

            entity.HasIndex(e => e.Name, "Name").IsUnique();

            entity.Property(e => e.Name).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
