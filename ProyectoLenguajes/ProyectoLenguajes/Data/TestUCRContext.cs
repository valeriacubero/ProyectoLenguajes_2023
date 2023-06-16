﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ProyectoLenguajes.Models;

namespace ProyectoLenguajes.Data;

public partial class TestUCRContext : DbContext
{
    public TestUCRContext()
    {
    }

    public TestUCRContext(DbContextOptions<TestUCRContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ACCOUNT> ACCOUNTs { get; set; }

    public virtual DbSet<ACTOR> ACTORs { get; set; }

    public virtual DbSet<AUDIT> AUDITs { get; set; }

    public virtual DbSet<ActorMovie> ActorMovies { get; set; }

    public virtual DbSet<ActorSerie> ActorSeries { get; set; }

    public virtual DbSet<AuditUser> AuditUsers { get; set; }

    public virtual DbSet<CHAPTER> CHAPTERs { get; set; }

    public virtual DbSet<GENDER> GENDERs { get; set; }

    public virtual DbSet<GenderMovie> GenderMovies { get; set; }

    public virtual DbSet<GenderSerie> GenderSeries { get; set; }

    public virtual DbSet<MOVIE> MOVIEs { get; set; }

    public virtual DbSet<SERIE> SERIEs { get; set; }

    public virtual DbSet<UserChapter> UserChapters { get; set; }

    public virtual DbSet<UserMovie> UserMovies { get; set; }
    public virtual DbSet<Errors> ERRORs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=163.178.173.130;Database=Lenguajes_Proyecto_VJE;TrustServerCertificate=True; User Id=basesdedatos; Password=rpbases.2022");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Errors>(entity =>
        {
            entity.HasNoKey();
            entity.Property(e => e.error);
                
        });

        modelBuilder.Entity<ACCOUNT>(entity =>
        {
            entity.HasKey(e => e.idAccount).HasName("PK__ACCOUNT__DA18132CEC720622");

            entity.ToTable("ACCOUNT");

            entity.Property(e => e.email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.img)
                .HasMaxLength(2000)
                .IsUnicode(false)
                .HasDefaultValueSql("('https://png.pngtree.com/element_origin_min_pic/00/00/06/12575cb97a22f0f.jpg')");
            entity.Property(e => e.name)
                .HasMaxLength(70)
                .IsUnicode(false);
            entity.Property(e => e.password)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.roll)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasDefaultValueSql("('user')");
            entity.Property(e => e.userName)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ACTOR>(entity =>
        {
            entity.HasKey(e => e.idActor).HasName("PK__ACTOR__28CBA09390E8264C");

            entity.ToTable("ACTOR");

            entity.Property(e => e.birth).HasColumnType("date");
            entity.Property(e => e.img)
                .HasMaxLength(2000)
                .IsUnicode(false);
            entity.Property(e => e.lastName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.name)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<AUDIT>(entity =>
        {
            entity.HasKey(e => e.idAudit).HasName("PK__AUDIT__A0E9FA08FC86143C");

            entity.ToTable("AUDIT");

            entity.Property(e => e.action)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.date)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.description)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.nameOf)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.tableName)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ActorMovie>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("ActorMovie");

            entity.HasOne(d => d.idActorNavigation).WithMany()
                .HasForeignKey(d => d.idActor)
                .HasConstraintName("fk_idActorM");

            entity.HasOne(d => d.idMovieNavigation).WithMany()
                .HasForeignKey(d => d.idMovie)
                .HasConstraintName("fk_idMovieA");
        });

        modelBuilder.Entity<ActorSerie>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("ActorSerie");

            entity.HasOne(d => d.idActorNavigation).WithMany()
                .HasForeignKey(d => d.idActor)
                .HasConstraintName("fk_idActorS");

            entity.HasOne(d => d.idSerieNavigation).WithMany()
                .HasForeignKey(d => d.idSerie)
                .HasConstraintName("fk_idSerieA");
        });

        modelBuilder.Entity<AuditUser>(entity =>
        {
            entity.HasKey(e => e.idAuditUser).HasName("PK__AuditUse__CB5F1DCA69189EE5");

            entity.ToTable("AuditUser");

            entity.Property(e => e.action)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.date)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.description)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.nameOf)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.tableName)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<CHAPTER>(entity =>
        {
            entity.HasKey(e => e.idChapter).HasName("PK__CHAPTER__554042F1C7CA99D9");

            entity.ToTable("CHAPTER");

            entity.Property(e => e.description)
                .HasMaxLength(2000)
                .IsUnicode(false);
            entity.Property(e => e.duration)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.img)
                .HasMaxLength(2000)
                .IsUnicode(false);
            entity.Property(e => e.name)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.idSerieNavigation).WithMany(p => p.CHAPTERs)
                .HasForeignKey(d => d.idSerie)
                .HasConstraintName("fk_idSerie");
        });

        modelBuilder.Entity<GENDER>(entity =>
        {
            entity.HasKey(e => e.idGender).HasName("PK__GENDER__85D20780EC8B1E49");

            entity.ToTable("GENDER");

            entity.Property(e => e.typeG)
                .HasMaxLength(30)
                .IsUnicode(false);
        });

        modelBuilder.Entity<GenderMovie>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("GenderMovie");

            entity.HasOne(d => d.idGenderNavigation).WithMany()
                .HasForeignKey(d => d.idGender)
                .HasConstraintName("fk_idGenderM");

            entity.HasOne(d => d.idMovieNavigation).WithMany()
                .HasForeignKey(d => d.idMovie)
                .HasConstraintName("fk_idMovieG");
        });

        modelBuilder.Entity<GenderSerie>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("GenderSerie");

            entity.HasOne(d => d.idGenderNavigation).WithMany()
                .HasForeignKey(d => d.idGender)
                .HasConstraintName("fk_idGenderS");

            entity.HasOne(d => d.idSerieNavigation).WithMany()
                .HasForeignKey(d => d.idSerie)
                .HasConstraintName("fk_idSerieG");
        });

        modelBuilder.Entity<MOVIE>(entity =>
        {
            entity.HasKey(e => e.idMovie).HasName("PK__MOVIE__1A9A9792BB2E912E");

            entity.ToTable("MOVIE");

            entity.Property(e => e.description)
                .HasMaxLength(2000)
                .IsUnicode(false);
            entity.Property(e => e.director)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.distributor)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.duration)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.img)
                .HasMaxLength(2000)
                .IsUnicode(false);
            entity.Property(e => e.name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.trailer)
                .HasMaxLength(5000)
                .IsUnicode(false);
            entity.Property(e => e.year).HasColumnType("date");
        });

        modelBuilder.Entity<SERIE>(entity =>
        {
            entity.HasKey(e => e.idSerie).HasName("PK__SERIE__9E10C73D4A241779");

            entity.ToTable("SERIE");

            entity.Property(e => e.description)
                .HasMaxLength(2000)
                .IsUnicode(false);
            entity.Property(e => e.director)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.distributor)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.img)
                .HasMaxLength(2000)
                .IsUnicode(false);
            entity.Property(e => e.name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.trailer)
                .HasMaxLength(5000)
                .IsUnicode(false);
            entity.Property(e => e.year).HasColumnType("date");
        });

        modelBuilder.Entity<UserChapter>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("UserChapter");

            entity.Property(e => e.review)
                .HasMaxLength(8000)
                .IsUnicode(false);
            entity.Property(e => e.reviewTime).HasColumnType("datetime");
            entity.Property(e => e.stars).HasDefaultValueSql("((0))");

            entity.HasOne(d => d.idChapterNavigation).WithMany()
                .HasForeignKey(d => d.idChapter)
                .HasConstraintName("fk_idChapterU");

            entity.HasOne(d => d.idUserNavigation).WithMany()
                .HasForeignKey(d => d.idUser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_idUserC");
        });

        modelBuilder.Entity<UserMovie>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("UserMovie", tb => tb.HasTrigger("UserMovieRepit"));

            entity.Property(e => e.review)
                .HasMaxLength(8000)
                .IsUnicode(false);
            entity.Property(e => e.reviewTime).HasColumnType("datetime");
            entity.Property(e => e.stars).HasDefaultValueSql("((0))");

            entity.HasOne(d => d.idMovieNavigation).WithMany()
                .HasForeignKey(d => d.idMovie)
                .HasConstraintName("fk_idMovieU");

            entity.HasOne(d => d.idUserNavigation).WithMany()
                .HasForeignKey(d => d.idUser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_idUserM");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
