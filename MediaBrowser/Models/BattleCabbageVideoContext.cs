using System;
using System.Collections.Generic;
using Azure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace MediaBrowser.Models;

public partial class BattleCabbageVideoContext : DbContext
{
    public BattleCabbageVideoContext()
    {
    }

    public BattleCabbageVideoContext(DbContextOptions<BattleCabbageVideoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Actor> Actors { get; set; }

    public virtual DbSet<Actorstomoviesjoin> Actorstomoviesjoins { get; set; }

    public virtual DbSet<Criticreview> Criticreviews { get; set; }

    public virtual DbSet<Datum> Data { get; set; }

    public virtual DbSet<Director> Directors { get; set; }

    public virtual DbSet<Directorstomoviesjoin> Directorstomoviesjoins { get; set; }

    public virtual DbSet<Genre> Genres { get; set; }

    public virtual DbSet<Kiosk> Kiosks { get; set; }

    public virtual DbSet<MediaBasic> MediaBasics { get; set; }

    public virtual DbSet<MediaRating> MediaRatings { get; set; }

    public virtual DbSet<Medium> Media { get; set; }

    public virtual DbSet<Movie> Movies { get; set; }

    public virtual DbSet<Rental> Rentals { get; set; }

    public virtual DbSet<StreamingEvent> StreamingEvents { get; set; }

    public virtual DbSet<UserAccount> UserAccounts { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Actor>(entity =>
        {
            entity.ToTable("actors");

            entity.Property(e => e.ActorId).HasColumnName("actor_id");
            entity.Property(e => e.Actor1)
                .HasMaxLength(500)
                .HasColumnName("actor");

            entity
            .HasMany(d => d.Movies)
            .WithMany(p => p.Actors)
            .UsingEntity<Actorstomoviesjoin>(
                l => l.HasOne<Movie>(e => e.Movie).WithMany(e => e.Actorstomoviesjoins).HasForeignKey(e => e.MovieId),
                r => r.HasOne<Actor>(e => e.Actor).WithMany(e => e.Actorstomoviesjoins).HasForeignKey(e => e.ActorId));
        });

        modelBuilder.Entity<Actorstomoviesjoin>(entity =>
        {
            entity.HasKey(e => new { e.ActorId, e.MovieId });

            entity.ToTable("actorstomoviesjoin");

            entity.Property("ActorId").HasColumnName("actor_id");
            entity.Property("MovieId").HasColumnName("movie_id");

            entity.HasOne(d => d.Actor)
                .WithMany()
                .HasForeignKey("actor_id")
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_actorstomoviesjoin_actors");

            entity.HasOne(d => d.Movie)
                .WithMany()
                .HasForeignKey("movie_id")
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_actorstomoviesjoin_movies");
        });

        modelBuilder.Entity<Criticreview>(entity =>
        {
            entity.ToTable("criticreviews");

            entity.Property(e => e.CriticReviewId).HasColumnName("critic_review_id");
            entity.Property(e => e.CriticReview1)
                .HasMaxLength(4000)
                .HasColumnName("critic_review");
            entity.Property(e => e.CriticScore).HasColumnName("critic_score");
            entity.Property(e => e.MovieId).HasColumnName("movie_id");

            entity.HasOne(d => d.Movie).WithMany(p => p.Criticreviews)
                .HasForeignKey(d => d.MovieId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_criticreviews_movies");
        });

        modelBuilder.Entity<Datum>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("data");

            entity.Property(e => e.EndYear)
                .HasMaxLength(50)
                .HasColumnName("endYear");
            entity.Property(e => e.Genres)
                .HasMaxLength(500)
                .HasColumnName("genres");
            entity.Property(e => e.IsAdult).HasColumnName("isAdult");
            entity.Property(e => e.OriginalTitle)
                .HasMaxLength(500)
                .HasColumnName("originalTitle");
            entity.Property(e => e.PrimaryTitle)
                .HasMaxLength(500)
                .HasColumnName("primaryTitle");
            entity.Property(e => e.RuntimeMinutes)
                .HasMaxLength(50)
                .HasColumnName("runtimeMinutes");
            entity.Property(e => e.StartYear)
                .HasMaxLength(50)
                .HasColumnName("startYear");
            entity.Property(e => e.Tconst)
                .HasMaxLength(15)
                .HasColumnName("tconst");
            entity.Property(e => e.TitleType)
                .HasMaxLength(12)
                .HasColumnName("titleType");
        });

        modelBuilder.Entity<Director>(entity =>
        {
            entity.ToTable("directors");

            entity.Property(e => e.DirectorId).HasColumnName("director_id");
            entity.Property(e => e.Director1)
                .HasMaxLength(500)
                .HasColumnName("director");

            entity
                .HasMany(d => d.Movies)
                .WithMany(p => p.Directors)
                .UsingEntity<Directorstomoviesjoin>(
                    l => l.HasOne<Movie>(e => e.Movie).WithMany(e => e.Directorstomoviesjoins).HasForeignKey(e => e.MovieId),
                    r => r.HasOne<Director>(e => e.Director).WithMany(e => e.Directorstomoviesjoins).HasForeignKey(e => e.DirectorId)
                );
        });

        modelBuilder.Entity<Directorstomoviesjoin>(entity =>
        {
            entity.HasKey(e => new { e.DirectorId, e.MovieId });

            entity.ToTable("directorstomoviesjoin");
            entity.Property(e => e.DirectorId).HasColumnName("director_id");
            entity.Property(e => e.MovieId).HasColumnName("movie_id");

            entity.HasOne(d => d.Director).WithMany(p => p.Directorstomoviesjoins)
                .HasForeignKey(d => d.DirectorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_directorstomoviesjoin_directors");

            entity.HasOne(d => d.Movie).WithMany(p => p.Directorstomoviesjoins)
                .HasForeignKey(d => d.MovieId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_directorstomoviesjoin_movies");
        });

        modelBuilder.Entity<Genre>(entity =>
        {
            entity.ToTable("genres");

            entity.Property(e => e.GenreId).HasColumnName("genre_id");
            entity.Property(e => e.Genre1)
                .HasMaxLength(100)
                .HasColumnName("genre");

            entity.HasMany(d => d.Movies)
                .WithOne(p => p.Genre)
                .HasForeignKey(d => d.GenreId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_movies_genres");
        });

        modelBuilder.Entity<Kiosk>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Kiosk");

            entity.Property(e => e.Address).HasMaxLength(250);
            entity.Property(e => e.State)
                .HasMaxLength(2)
                .IsFixedLength();
            entity.Property(e => e.ZipCode)
                .HasMaxLength(10)
                .IsFixedLength();
        });

        modelBuilder.Entity<MediaBasic>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.EndYear)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("endYear");
            entity.Property(e => e.Genres)
                .HasMaxLength(26)
                .IsUnicode(false)
                .HasColumnName("genres");
            entity.Property(e => e.IsAdult).HasColumnName("isAdult");
            entity.Property(e => e.OriginalTitle)
                .HasMaxLength(85)
                .IsUnicode(false)
                .HasColumnName("originalTitle");
            entity.Property(e => e.PrimaryTitle)
                .HasMaxLength(85)
                .IsUnicode(false)
                .HasColumnName("primaryTitle");
            entity.Property(e => e.RuntimeMinutes).HasColumnName("runtimeMinutes");
            entity.Property(e => e.StartYear).HasColumnName("startYear");
            entity.Property(e => e.Tconst)
                .HasMaxLength(9)
                .IsUnicode(false)
                .HasColumnName("tconst");
            entity.Property(e => e.TitleType)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("titleType");
        });

        modelBuilder.Entity<MediaRating>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.AverageRating).HasColumnName("averageRating");
            entity.Property(e => e.NumVotes).HasColumnName("numVotes");
            entity.Property(e => e.Tconst)
                .HasMaxLength(50)
                .HasColumnName("tconst");
        });

        modelBuilder.Entity<Medium>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.Title).HasMaxLength(200);
        });

        modelBuilder.Entity<Movie>(entity =>
        {
            entity.ToTable("movies");

            entity.Property(e => e.MovieId).HasColumnName("movie_id");
            entity.Property(e => e.Description)
                .HasMaxLength(2000)
                .HasColumnName("description");
            entity.Property(e => e.ExternalId)
                .HasMaxLength(30)
                .HasColumnName("external_id");
            entity.Property(e => e.GenreId).HasColumnName("genre_id");
            entity.Property(e => e.MpaaRating)
                .HasMaxLength(5)
                .HasColumnName("mpaa_rating");
            entity.Property(e => e.PopularityScore).HasColumnName("popularity_score");
            entity.Property(e => e.PosterUrl)
                .HasMaxLength(500)
                .HasColumnName("poster_url");
            entity.Property(e => e.ReleaseDate).HasColumnName("release_date");
            entity.Property(e => e.Tagline)
                .HasMaxLength(500)
                .HasColumnName("tagline");
            entity.Property(e => e.Title)
                .HasMaxLength(100)
                .HasColumnName("title");

            entity.HasOne(d => d.Genre).WithMany(p => p.Movies)
                .HasForeignKey(d => d.GenreId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_movies_genres");

            entity
            .HasMany(d => d.Actors)
            .WithMany(p => p.Movies)
            .UsingEntity<Actorstomoviesjoin>(
                r => r.HasOne<Actor>(e => e.Actor).WithMany(e => e.Actorstomoviesjoins).HasForeignKey(e => e.ActorId),
                l => l.HasOne<Movie>(e => e.Movie).WithMany(e => e.Actorstomoviesjoins).HasForeignKey(e => e.MovieId));

            entity
            .HasMany(d => d.Directors)
            .WithMany(p => p.Movies)
            .UsingEntity<Directorstomoviesjoin>(
                r => r.HasOne<Director>(e => e.Director).WithMany(e => e.Directorstomoviesjoins).HasForeignKey(e => e.DirectorId),
                l => l.HasOne<Movie>(e => e.Movie).WithMany(e => e.Directorstomoviesjoins).HasForeignKey(e => e.MovieId));
        });

        modelBuilder.Entity<Rental>(entity =>
        {
            entity.HasNoKey();
        });

        modelBuilder.Entity<StreamingEvent>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.EventType)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.PlatformName).HasMaxLength(50);
            entity.Property(e => e.PlatformType).HasMaxLength(50);
        });

        modelBuilder.Entity<UserAccount>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.Address).HasMaxLength(250);
            entity.Property(e => e.CreditCardNumber).HasMaxLength(30);
            entity.Property(e => e.Email).HasMaxLength(150);
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.LastName).HasMaxLength(50);
            entity.Property(e => e.PhoneNumber).HasMaxLength(15);
            entity.Property(e => e.State)
                .HasMaxLength(3)
                .IsFixedLength();
            entity.Property(e => e.ZipCode).HasMaxLength(10);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
