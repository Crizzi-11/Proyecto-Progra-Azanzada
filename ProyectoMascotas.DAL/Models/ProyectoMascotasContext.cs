using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ProyectoMascotas.DAL.Models;

public partial class ProyectoMascotasContext : DbContext
{
    public ProyectoMascotasContext()
    {
    }

    public ProyectoMascotasContext(DbContextOptions<ProyectoMascotasContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Administracion> Administracions { get; set; }

    public virtual DbSet<Cita> Citas { get; set; }

    public virtual DbSet<DesparasitacionesVacuna> DesparasitacionesVacunas { get; set; }

    public virtual DbSet<Dueno> Duenos { get; set; }

    public virtual DbSet<Mascota> Mascotas { get; set; }

    public virtual DbSet<Padecimiento> Padecimientos { get; set; }

    public virtual DbSet<Raza> Razas { get; set; }

    public virtual DbSet<TiposMascota> TiposMascota { get; set; }

    public virtual DbSet<VeterinarioS> Veterinarios { get; set; }

    public virtual DbSet<VeterinarioP> VeterinarioPs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=ProyectoMascotas;Integrated Security=True;Trusted_Connection=True;TrustServerCertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Administracion>(entity =>
        {
            entity.HasKey(e => e.IdAdm).HasName("PK__Administ__0E2BAC25E7CB19A9");

            entity.ToTable("Administracion");

            entity.Property(e => e.IdAdm).ValueGeneratedNever();
            entity.Property(e => e.Contrasena)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.EstadoUsuario)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.NombreAdm)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Rol)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.UltimaConexion).HasColumnType("datetime");
        });

        modelBuilder.Entity<Cita>(entity =>
        {
            entity.HasKey(e => e.CitaId).HasName("PK__Citas__F0E2D9F2E9F8811A");

            entity.Property(e => e.CitaId)
                .ValueGeneratedNever()
                .HasColumnName("CitaID");
            entity.Property(e => e.Detalle)
                .HasMaxLength(300)
                .IsUnicode(false);
            entity.Property(e => e.Diagnostico)
                .HasMaxLength(300)
                .IsUnicode(false);
            entity.Property(e => e.Estado)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.FechaHora).HasColumnType("datetime");
            entity.Property(e => e.ListaMedicamentos)
                .HasMaxLength(300)
                .IsUnicode(false);

            entity.HasOne(d => d.CodigoUsuarioNavigation).WithMany(p => p.Cita)
                .HasForeignKey(d => d.CodigoUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Citas__IdVeterin__5EBF139D");

            entity.HasOne(d => d.IdMascotaNavigation).WithMany(p => p.Cita)
                .HasForeignKey(d => d.IdMascota)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Citas__IdMascota__5FB337D6");

            entity.HasOne(d => d.IdVeterinarioPNavigation).WithMany(p => p.Cita)
                .HasForeignKey(d => d.IdVeterinarioP)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Citas__IdVeterin__60A75C0F");

            entity.HasOne(d => d.IdVeterinarioSNavigation).WithMany(p => p.Cita)
                .HasForeignKey(d => d.IdVeterinarioS)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Citas__IdVeterin__619B8048");
        });

        modelBuilder.Entity<DesparasitacionesVacuna>(entity =>
        {
            entity.HasKey(e => e.IdDesparacitacion).HasName("PK__Desparas__2AFDB7EF552C6DF6");

            entity.Property(e => e.IdDesparacitacion).ValueGeneratedNever();
            entity.Property(e => e.Producto)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Tipo)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.IdMascotaNavigation).WithMany(p => p.DesparasitacionesVacunas)
                .HasForeignKey(d => d.IdMascota)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Desparasi__IdMas__5812160E");
        });

        modelBuilder.Entity<Dueno>(entity =>
        {
            entity.HasKey(e => e.CodigoUsuario).HasName("PK__Dueno__F0C18F580D85BB12");

            entity.ToTable("Dueno");

            entity.Property(e => e.CodigoUsuario).ValueGeneratedNever();
            entity.Property(e => e.ListaCitas)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.NombreDueno)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.PrimApellido)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.SegApellido)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Telefono)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Mascota>(entity =>
        {
            entity.HasKey(e => e.IdMascota).HasName("PK__Mascotas__5C9C26F09A4D0ECB");

            entity.Property(e => e.IdMascota).ValueGeneratedNever();
            entity.Property(e => e.Genero)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Peso).HasColumnType("decimal(5, 2)");

            entity.HasOne(d => d.CodigoUsuarioNavigation).WithMany(p => p.Mascota)
                .HasForeignKey(d => d.CodigoUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Mascotas__Codigo__52593CB8");

            entity.HasOne(d => d.IdRazaNavigation).WithMany(p => p.Mascota)
                .HasForeignKey(d => d.IdRaza)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Mascotas__IdRaza__5165187F");

            entity.HasOne(d => d.IdTipoMascotaNavigation).WithMany(p => p.Mascota)
                .HasForeignKey(d => d.IdTipoMascota)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Mascotas__IdTipo__5070F446");
        });

        modelBuilder.Entity<Padecimiento>(entity =>
        {
            entity.HasKey(e => e.IdPadecimiento).HasName("PK__Padecimi__481F205AB8EBF140");

            entity.Property(e => e.IdPadecimiento).ValueGeneratedNever();
            entity.Property(e => e.Padecimiento1)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Padecimiento");

            entity.HasOne(d => d.IdMascotaNavigation).WithMany(p => p.Padecimientos)
                .HasForeignKey(d => d.IdMascota)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Padecimie__IdMas__5535A963");
        });

        modelBuilder.Entity<Raza>(entity =>
        {
            entity.HasKey(e => e.IdRaza).HasName("PK__Razas__8F06EB28C29CF3E3");

            entity.Property(e => e.IdRaza).ValueGeneratedNever();
            entity.Property(e => e.Raza1)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Raza");

            entity.HasOne(d => d.IdTipoMascotaNavigation).WithMany(p => p.Razas)
                .HasForeignKey(d => d.IdTipoMascota)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Razas__IdTipoMas__4BAC3F29");
        });

        modelBuilder.Entity<TiposMascota>(entity =>
        {
            entity.HasKey(e => e.IdTipoMascota).HasName("PK__TiposMas__B28651DA8D93E6FB");

            entity.Property(e => e.IdTipoMascota).ValueGeneratedNever();
            entity.Property(e => e.Tipo)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<VeterinarioS>(entity =>
        {
            entity.HasKey(e => e.IdVeterinarioS).HasName("PK__Veterina__4C2A66585789BFC2");

            entity.ToTable("VeterinarioS");

            entity.Property(e => e.IdVeterinarioS).ValueGeneratedNever();
            entity.Property(e => e.Correo)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.NombreVet)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.PrimApellido)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.SegApellido)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Telefono)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<VeterinarioP>(entity =>
        {
            entity.HasKey(e => e.IdVeterinarioP).HasName("PK__Veterina__4C2A665D54EF444B");

            entity.ToTable("VeterinarioP");

            entity.Property(e => e.IdVeterinarioP).ValueGeneratedNever();
            entity.Property(e => e.Correo)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.NombreVet)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.PrimApellido)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.SegApellido)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Telefono)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
