using Microsoft.EntityFrameworkCore;
using PokemonReviewApp.Models;



namespace PokemonReviewApp.Data
{
    public class DataContext : DbContext
    {

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Country> Countries{ get; set; }
        public DbSet<Owner> Owner{ get; set; }
        public DbSet<Pokemon> Pokemon{ get; set; }
        public DbSet<PokemonCategory> PokemonCategories{ get; set; }
        public DbSet<PokemonOwner> PokemonOwners{ get; set; }
        public DbSet<Review> Reviews{ get; set; }
        public DbSet<Reviewer> Reviewers{ get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Setting up the the relationships between the tables - Many to Many - I assume, the reason for 2 modelBuilder.entity(one with id and "1" section for the hasOne withmany and so on) for the same relationsship is to serialize and avoid stackoverflow.
            modelBuilder.Entity<PokemonCategory>()
                .HasKey(pc => new { pc.PokemonId, pc.CategoryId });

            modelBuilder.Entity<PokemonCategory>()
                .HasOne(p => p.Pokemon)
                .WithMany(pc => pc.PokemonCategories)
                .HasForeignKey(p => p.PokemonId);
            modelBuilder.Entity<PokemonCategory>()
                .HasOne(pc => pc.Category)
                .WithMany(p => p.PokemonCategories)
                .HasForeignKey(c => c.CategoryId);

            ///

            modelBuilder.Entity<PokemonOwner>()
                .HasKey(pc => new { pc.PokemonId, pc.OwnerId });

            modelBuilder.Entity<PokemonOwner>()
                .HasOne(p => p.Pokemon)
                .WithMany(pc => pc.PokemonOwners)
                .HasForeignKey(p => p.PokemonId);
            modelBuilder.Entity<PokemonOwner>()
                .HasOne(po => po.Owner)
                .WithMany(p => p.PokemonOwners)
                .HasForeignKey(o => o.OwnerId);





        }

    }
}
