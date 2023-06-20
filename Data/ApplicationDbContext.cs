using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using TestyMatematyczne.Models;

namespace TestyMatematyczne.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public DbSet<Contest> Contest { get; set; }
        public DbSet<Solution> Solution { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Solution>().HasKey(x => new {x.ContestId, x.UserId, x.SolutionTime});

            builder.Entity<Solution>()
            .HasOne<Contest>(x => x.Contest)
            .WithMany(y => y.Solution)
            .HasForeignKey(y => y.ContestId).OnDelete(DeleteBehavior.ClientSetNull);

            builder.Entity<Solution>()
            .HasOne<User>(x => x.User)
            .WithMany(y => y.Solution)
            .HasForeignKey(y => y.UserId).OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}