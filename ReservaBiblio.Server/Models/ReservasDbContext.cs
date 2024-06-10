using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ReservaBiblio.Server.Models;

public partial class ReservasDbContext : DbContext
{
    public ReservasDbContext()
    {
    }

    public ReservasDbContext(DbContextOptions<ReservasDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Espacios> Espacios { get; set; }

    public virtual DbSet<Material> Material { get; set; }

    public virtual DbSet<Profesores> Profesores { get; set; }

    public virtual DbSet<ReservasEspacios> ReservasEspacios { get; set; }

    public virtual DbSet<ReservasMaterial> ReservasMaterial { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Espacios>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Espacios__3213E83F7D3AC151");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Clave)
                .HasMaxLength(50)
                .HasColumnName("clave");
            entity.Property(e => e.Descripcion).HasColumnName("descripcion");
            entity.Property(e => e.Imagen)
                .HasMaxLength(50)
                .HasColumnName("imagen");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Material>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Material__3213E83F68779400");

            entity.ToTable("Material");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Clave)
                .HasMaxLength(50)
                .HasColumnName("clave");
            entity.Property(e => e.Descripcion).HasColumnName("descripcion");
            entity.Property(e => e.Imagen)
                .HasMaxLength(50)
                .HasColumnName("imagen");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Profesores>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Profesor__3213E83F643F5BDA");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Contrasena)
                .HasMaxLength(255)
                .HasColumnName("contrasena");
            entity.Property(e => e.Correo)
                .HasMaxLength(100)
                .HasColumnName("correo");
            entity.Property(e => e.Departamento)
                .HasMaxLength(100)
                .HasColumnName("departamento");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .HasColumnName("nombre");
            entity.Property(e => e.RangoAdministrador)
                .HasMaxLength(50)
                .HasColumnName("rango_administrador");
        });

        modelBuilder.Entity<ReservasEspacios>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Reservas__3213E83FA756B5E3");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Dia).HasColumnName("dia");
            entity.Property(e => e.EspacioId).HasColumnName("espacio_id");
            entity.Property(e => e.HoraFin).HasColumnName("hora_fin");
            entity.Property(e => e.HoraInicio).HasColumnName("hora_inicio");
            entity.Property(e => e.ProfesorId).HasColumnName("profesor_id");

            entity.HasOne(d => d.Profesor).WithMany(p => p.ReservasEspacios)
                .HasForeignKey(d => d.ProfesorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ReservasE__profe__5070F446");
        });

        modelBuilder.Entity<ReservasMaterial>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Reservas__3213E83F83DDCEE0");

            entity.ToTable("ReservasMaterial");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Dia).HasColumnName("dia");
            entity.Property(e => e.HoraFin).HasColumnName("hora_fin");
            entity.Property(e => e.HoraInicio).HasColumnName("hora_inicio");
            entity.Property(e => e.MaterialId).HasColumnName("material_id");
            entity.Property(e => e.ProfesorId).HasColumnName("profesor_id");

            entity.HasOne(d => d.Profesor).WithMany(p => p.ReservasMaterials)
                .HasForeignKey(d => d.ProfesorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ReservasM__profe__5441852A");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
