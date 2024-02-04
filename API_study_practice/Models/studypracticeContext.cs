using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace API_study_practice.Models
{
    public partial class studypracticeContext : DbContext
    {
        public studypracticeContext()
        {
        }

        public studypracticeContext(DbContextOptions<studypracticeContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Event> Events { get; set; } = null!;
        public virtual DbSet<Expense> Expenses { get; set; } = null!;
        public virtual DbSet<Photo> Photos { get; set; } = null!;
        public virtual DbSet<Review> Reviews { get; set; } = null!;
        public virtual DbSet<ToDoList> ToDoLists { get; set; } = null!;
        public virtual DbSet<ToDoListPlace> ToDoListPlaces { get; set; } = null!;
        public virtual DbSet<Trip> Trips { get; set; } = null!;
        public virtual DbSet<TripPlace> TripPlaces { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<UserTrip> UserTrips { get; set; } = null!;

        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Event>(entity =>
            {
                entity.ToTable("Event");

                entity.Property(e => e.EventId)
                    .ValueGeneratedNever()
                    .HasColumnName("event_id");

                entity.Property(e => e.Date)
                    .HasColumnType("date")
                    .HasColumnName("date");

                entity.Property(e => e.Description)
                    .IsUnicode(false)
                    .HasColumnName("description");

                entity.Property(e => e.EventName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("event_name")
                    .IsFixedLength();

                entity.Property(e => e.Place)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("place")
                    .IsFixedLength();

                entity.Property(e => e.Time).HasColumnName("time");
            });

            modelBuilder.Entity<Expense>(entity =>
            {
                entity.ToTable("Expense");

                entity.HasIndex(e => e.TripId, "IX_Relationship4");

                entity.Property(e => e.ExpenseId)
                    .ValueGeneratedNever()
                    .HasColumnName("expense_id");

                entity.Property(e => e.Currency)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("currency")
                    .IsFixedLength();

                entity.Property(e => e.Sum)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("sum");

                entity.Property(e => e.TripId).HasColumnName("trip_id");

                entity.HasOne(d => d.Trip)
                    .WithMany(p => p.Expenses)
                    .HasForeignKey(d => d.TripId)
                    .HasConstraintName("Relationship4");
            });

            modelBuilder.Entity<Photo>(entity =>
            {
                entity.ToTable("Photo");

                entity.HasIndex(e => e.UserId, "IX_Relationship14");

                entity.HasIndex(e => e.TripId, "IX_Relationship6");

                entity.Property(e => e.PhotoId)
                    .ValueGeneratedNever()
                    .HasColumnName("photo_id");

                entity.Property(e => e.DateOfCreating)
                    .HasColumnType("date")
                    .HasColumnName("date_of_creating");

                entity.Property(e => e.PhotoName)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("photo_name")
                    .IsFixedLength();

                entity.Property(e => e.TripId).HasColumnName("trip_id");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Trip)
                    .WithMany(p => p.Photos)
                    .HasForeignKey(d => d.TripId)
                    .HasConstraintName("Relationship6");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Photos)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("Relationship14");
            });

            modelBuilder.Entity<Review>(entity =>
            {
                entity.ToTable("Review");

                entity.HasIndex(e => e.UserId, "IX_Relationship11");

                entity.HasIndex(e => e.EventId, "IX_Relationship13");

                entity.Property(e => e.ReviewId)
                    .ValueGeneratedNever()
                    .HasColumnName("review_id");

                entity.Property(e => e.Estimation).HasColumnName("estimation");

                entity.Property(e => e.EventId).HasColumnName("event_id");

                entity.Property(e => e.ReviewText)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("review_text")
                    .IsFixedLength();

                entity.Property(e => e.TitleOfReview)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("title_of_review")
                    .IsFixedLength();

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Event)
                    .WithMany(p => p.Reviews)
                    .HasForeignKey(d => d.EventId)
                    .HasConstraintName("Relationship13");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Reviews)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("Relationship11");
            });

            modelBuilder.Entity<ToDoList>(entity =>
            {
                entity.HasKey(e => e.ToDoId)
                    .HasName("Unique_Identifier5");

                entity.ToTable("To-do list");

                entity.HasIndex(e => e.UserId, "IX_Relationship9");

                entity.Property(e => e.ToDoId)
                    .ValueGeneratedNever()
                    .HasColumnName("to_do_id");

                entity.Property(e => e.Description)
                    .IsUnicode(false)
                    .HasColumnName("description");

                entity.Property(e => e.NameOfTask)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("name_of_task")
                    .IsFixedLength();

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.ToDoLists)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("Relationship9");
            });

            modelBuilder.Entity<ToDoListPlace>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("To-do list_Place");

                entity.Property(e => e.EventId).HasColumnName("event_id");

                entity.Property(e => e.ToDoId).HasColumnName("to_do_id");
            });

            modelBuilder.Entity<Trip>(entity =>
            {
                entity.ToTable("Trip");

                entity.Property(e => e.TripId)
                    .ValueGeneratedNever()
                    .HasColumnName("trip_id");

                entity.Property(e => e.Description)
                    .IsUnicode(false)
                    .HasColumnName("description");

                entity.Property(e => e.DestinationPlace)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("destination_place")
                    .IsFixedLength();

                entity.Property(e => e.EndDate)
                    .HasColumnType("date")
                    .HasColumnName("end_date");

                entity.Property(e => e.StartDate)
                    .HasColumnType("date")
                    .HasColumnName("start_date");

                entity.Property(e => e.TripName)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("trip_name")
                    .IsFixedLength();
            });

            modelBuilder.Entity<TripPlace>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Trip_Place");

                entity.Property(e => e.EventId).HasColumnName("event_id");

                entity.Property(e => e.TripId).HasColumnName("trip_id");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.UserId)
                    .ValueGeneratedNever()
                    .HasColumnName("user_id");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("email")
                    .IsFixedLength();

                entity.Property(e => e.Password)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("password")
                    .IsFixedLength();

                entity.Property(e => e.UserName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("user_name")
                    .IsFixedLength();

                entity.Property(e => e.UserPatronymic)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("user_patronymic")
                    .IsFixedLength();

                entity.Property(e => e.UserSurname)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("user_surname")
                    .IsFixedLength();
            });

            modelBuilder.Entity<UserTrip>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("User_Trip");

                entity.Property(e => e.TripId).HasColumnName("trip_id");

                entity.Property(e => e.UserId).HasColumnName("user_id");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
