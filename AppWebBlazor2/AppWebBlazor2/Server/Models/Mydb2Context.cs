using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace AppWebBlazor2.Server.Models;

public partial class Mydb2Context : DbContext
{
    public Mydb2Context()
    {
    }

    public Mydb2Context(DbContextOptions<Mydb2Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Cargo> Cargos { get; set; }

    public virtual DbSet<Empleado> Empleados { get; set; }

    public virtual DbSet<Pago> Pagos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cargo>(entity =>
        {
            entity.HasKey(e => e.Idcargo).HasName("PK__cargo__0515A5ADCADB0EE2");

            entity.ToTable("cargo");

            entity.Property(e => e.Idcargo).HasColumnName("idcargo");
            entity.Property(e => e.Desripcion)
                .HasMaxLength(500)
                .HasColumnName("desripcion");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Empleado>(entity =>
        {
            entity.HasKey(e => e.Idempleado).HasName("PK__empleado__EE7D5EF616EAFE11");

            entity.ToTable("empleado");

            entity.Property(e => e.Idempleado).HasColumnName("idempleado");
            entity.Property(e => e.Edad).HasColumnName("edad");
            entity.Property(e => e.Idcargo).HasColumnName("idcargo");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .HasColumnName("nombre");
            entity.Property(e => e.Salario)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("salario");

            entity.HasOne(d => d.IdcargoNavigation).WithMany(p => p.Empleados)
                .HasForeignKey(d => d.Idcargo)
                .HasConstraintName("FK__empleado__idcarg__267ABA7A");
        });

        modelBuilder.Entity<Pago>(entity =>
        {
            entity.HasKey(e => e.Idpago).HasName("PK__pago__55A035DE3F1F0779");

            entity.ToTable("pago");

            entity.Property(e => e.Idpago).HasColumnName("idpago");
            entity.Property(e => e.Fechapago)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("fechapago");
            entity.Property(e => e.Idempleado).HasColumnName("idempleado");
            entity.Property(e => e.Totalpago)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("totalpago");

            entity.HasOne(d => d.IdempleadoNavigation).WithMany(p => p.Pagos)
                .HasForeignKey(d => d.Idempleado)
                .HasConstraintName("FK__pago__idempleado__29572725");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
