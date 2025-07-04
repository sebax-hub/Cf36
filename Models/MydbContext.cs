using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace Cf36.Models;

public partial class MydbContext : DbContext
{
    public MydbContext()
    {
    }

    public MydbContext(DbContextOptions<MydbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Tabla1> Tabla1s { get; set; }

    public virtual DbSet<Tabla2> Tabla2s { get; set; }

    public virtual DbSet<Table3> Table3s { get; set; }

    public virtual DbSet<Table4> Table4s { get; set; }

    public virtual DbSet<Table5> Table5s { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;port=3306;database=mydb;uid=root", Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.4.32-mariadb"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8_general_ci")
            .HasCharSet("utf8");

        modelBuilder.Entity<Tabla1>(entity =>
        {
            entity.HasKey(e => e.Idtabla1).HasName("PRIMARY");

            entity.ToTable("tabla1");

            entity.Property(e => e.Idtabla1)
                .ValueGeneratedNever()
                .HasColumnType("int(11)")
                .HasColumnName("idtabla1");
            entity.Property(e => e.Editar).HasMaxLength(80);
            entity.Property(e => e.ListarTabla1)
                .HasMaxLength(70)
                .HasColumnName("LIstar Tabla1");
            entity.Property(e => e.Regristrar).HasMaxLength(100);
        });

        modelBuilder.Entity<Tabla2>(entity =>
        {
            entity.HasKey(e => e.IdTabla2).HasName("PRIMARY");

            entity.ToTable("tabla2");

            entity.Property(e => e.IdTabla2)
                .ValueGeneratedNever()
                .HasColumnType("int(11)")
                .HasColumnName("idTabla2");
            entity.Property(e => e.Editar).HasMaxLength(100);
            entity.Property(e => e.ListarTabla2)
                .HasMaxLength(100)
                .HasColumnName("Listar Tabla2");
            entity.Property(e => e.Registrar).HasMaxLength(100);
        });

        modelBuilder.Entity<Table3>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("table3");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnType("int(11)");
            entity.Property(e => e.Color).HasMaxLength(45);
            entity.Property(e => e.Marca).HasMaxLength(45);
            entity.Property(e => e.Talla).HasMaxLength(45);
        });

        modelBuilder.Entity<Table4>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("table4");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnType("int(11)");
            entity.Property(e => e.Apellido).HasMaxLength(45);
            entity.Property(e => e.Correo).HasMaxLength(70);
            entity.Property(e => e.Nombre).HasMaxLength(45);
        });

        modelBuilder.Entity<Table5>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("table5");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnType("int(11)");
            entity.Property(e => e.Ciudad).HasMaxLength(45);
            entity.Property(e => e.Pais).HasMaxLength(45);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
