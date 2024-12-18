using CinemaDB.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaDB.Data
{
    public class CinemaDBContext : DbContext
    {

        public CinemaDBContext()
        {

            Database.EnsureDeleted();
            Database.EnsureCreated();

        }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Director> Directors { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Country> Countries { get; set; } 
        public DbSet<Customer> Customers { get; set; } 
        public DbSet<Promo> Promos { get; set; }
        public DbSet<Session> Sessions { get; set; } 
        public DbSet<Hall> Halls { get; set; }
        public DbSet<Ticket> Tickets { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=CinemaDBTest2;");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // One-to-One
            modelBuilder.Entity<Actor>()
                .HasOne(a => a.Person)
                .WithOne(p => p.Actor)
                .HasForeignKey<Actor>(a => a.PersonId);

            modelBuilder.Entity<Director>()
                .HasOne(d => d.Person)
                .WithOne(p => p.Director)
                .HasForeignKey<Director>(d => d.PersonId);

            // Many-to-Many 
            modelBuilder.Entity<Actor>()
                .HasMany(a => a.Movies)
                .WithMany(m => m.Actors)
                .UsingEntity<Dictionary<string, object>>(
                    "ActorMovie",
                    j => j.HasOne<Movie>().WithMany().HasForeignKey("MovieId").OnDelete(DeleteBehavior.NoAction),
                    j => j.HasOne<Actor>().WithMany().HasForeignKey("ActorId").OnDelete(DeleteBehavior.NoAction)
                );

            modelBuilder.Entity<Genre>()
                .HasMany(g => g.Movies)
                .WithMany(m => m.Genres)
                .UsingEntity<Dictionary<string, object>>(
                    "GenreMovie",
                    j => j.HasOne<Movie>().WithMany().HasForeignKey("MovieId").OnDelete(DeleteBehavior.NoAction),
                    j => j.HasOne<Genre>().WithMany().HasForeignKey("GenreId").OnDelete(DeleteBehavior.NoAction)
                );

            modelBuilder.Entity<Country>()
                .HasMany(c => c.Movies)
                .WithMany(m => m.Countries)
                .UsingEntity<Dictionary<string, object>>(
                    "CountryMovie",
                    j => j.HasOne<Movie>().WithMany().HasForeignKey("MovieId").OnDelete(DeleteBehavior.NoAction),
                    j => j.HasOne<Country>().WithMany().HasForeignKey("CountryId").OnDelete(DeleteBehavior.NoAction)
                );

            modelBuilder.Entity<Promo>()
                .HasMany(p => p.Sessions)
                .WithMany(s => s.Promos)
                .UsingEntity<Dictionary<string, object>>(
                    "PromoSession",
                    j => j.HasOne<Session>().WithMany().HasForeignKey("SessionId").OnDelete(DeleteBehavior.NoAction),
                    j => j.HasOne<Promo>().WithMany().HasForeignKey("PromoId").OnDelete(DeleteBehavior.NoAction)
                );

            // One-to-Many
            modelBuilder.Entity<Company>()
                .HasMany(c => c.Movies)
                .WithOne(m => m.Company)
                .HasForeignKey(m => m.CompanyId);

            modelBuilder.Entity<Director>()
                .HasMany(d => d.Movies)
                .WithOne(m => m.Director)
                .HasForeignKey(m => m.DirectorId);

            modelBuilder.Entity<Session>()
                .HasMany(s => s.Tickets)
                .WithOne(t => t.Session)
                .HasForeignKey(t => t.SessionId);

            modelBuilder.Entity<Hall>()
                .HasMany(h => h.Sessions)
                .WithOne(s => s.Hall)
                .HasForeignKey(s => s.HallId);

            modelBuilder.Entity<Customer>()
                .HasMany(c => c.Promos)
                .WithOne(p => p.Customer)
                .HasForeignKey(p => p.CustomerId);

            base.OnModelCreating(modelBuilder);
        }

    }
}
