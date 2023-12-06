﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace Topic2_WorkingEF.Models
{
    public partial class PE_PRN_Fall2023B1Context : DbContext
    {
        public PE_PRN_Fall2023B1Context()
        {
        }

        public PE_PRN_Fall2023B1Context(DbContextOptions<PE_PRN_Fall2023B1Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Director> Directors { get; set; }
        public virtual DbSet<Genre> Genres { get; set; }
        public virtual DbSet<Movie> Movies { get; set; }
        public virtual DbSet<MovieStar> MovieStars { get; set; }
        public virtual DbSet<Room> Rooms { get; set; }
        public virtual DbSet<Schedule> Schedules { get; set; }
        public virtual DbSet<Star> Stars { get; set; }
        public virtual DbSet<TimeSlot> TimeSlots { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder()
                                    .SetBasePath(Directory.GetCurrentDirectory())
                                    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            IConfigurationRoot root = builder.Build();
            optionsBuilder.UseSqlServer(root.GetConnectionString("PRN211"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Director>(entity =>
            {
                entity.Property(e => e.Dob).HasColumnType("date");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Nationality).HasMaxLength(255);
            });

            modelBuilder.Entity<Genre>(entity =>
            {
                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Movie>(entity =>
            {
                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.HasOne(d => d.Director)
                    .WithMany(p => p.Movies)
                    .HasForeignKey(d => d.DirectorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Movies__Director__398D8EEE");

                entity.HasMany(d => d.Genres)
                    .WithMany(p => p.Movies)
                    .UsingEntity<Dictionary<string, object>>(
                        "MovieGenre",
                        l => l.HasOne<Genre>().WithMany().HasForeignKey("GenreId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__Movie_Gen__Genre__44FF419A"),
                        r => r.HasOne<Movie>().WithMany().HasForeignKey("MovieId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__Movie_Gen__Movie__440B1D61"),
                        j =>
                        {
                            j.HasKey("MovieId", "GenreId").HasName("PK__Movie_Ge__BBEAC44DD044A312");

                            j.ToTable("Movie_Genre");
                        });
            });

            modelBuilder.Entity<MovieStar>(entity =>
            {
                entity.HasKey(e => new { e.MovieId, e.StarId })
                    .HasName("PK__Movie_St__2BB8287C8BC530EF");

                entity.ToTable("Movie_Star");

                entity.Property(e => e.Position).HasMaxLength(255);

                entity.HasOne(d => d.Movie)
                    .WithMany(p => p.MovieStars)
                    .HasForeignKey(d => d.MovieId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Movie_Sta__Movie__3E52440B");

                entity.HasOne(d => d.Star)
                    .WithMany(p => p.MovieStars)
                    .HasForeignKey(d => d.StarId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Movie_Sta__StarI__3F466844");
            });

            modelBuilder.Entity<Room>(entity =>
            {
                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Schedule>(entity =>
            {
                entity.Property(e => e.EndDate).HasColumnType("date");

                entity.Property(e => e.StartDate).HasColumnType("date");

                entity.HasOne(d => d.Movie)
                    .WithMany(p => p.Schedules)
                    .HasForeignKey(d => d.MovieId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Schedule__MovieI__5EBF139D");

                entity.HasOne(d => d.Room)
                    .WithMany(p => p.Schedules)
                    .HasForeignKey(d => d.RoomId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Schedule__RoomId__5CD6CB2B");

                entity.HasOne(d => d.TimeSlot)
                    .WithMany(p => p.Schedules)
                    .HasForeignKey(d => d.TimeSlotId)
                    .HasConstraintName("FK__Schedule__TimeSl__5DCAEF64");
            });

            modelBuilder.Entity<Star>(entity =>
            {
                entity.Property(e => e.Dob).HasColumnType("date");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Nationality).HasMaxLength(255);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
