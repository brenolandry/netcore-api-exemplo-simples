using ApiSimples.Application.Data.Mapping;
using ApiSimples.Application.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiSimples.Application.Data
{
    public class Context : DbContext
    {
        public DbSet<User> Users { get; set; }

        public Context(DbContextOptions<Context> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>(new UserMap().Configure);
        }
    }
}
