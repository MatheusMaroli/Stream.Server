using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stream.Server.Domain.Infra.Contexts
{
    public class DataContext : DbContext
    {

        public DbSet<Entities.Server> Servers { get; set; }
        public DbSet<Entities.Video> Videos { get; set; }
        public DbSet<Entities.Recycle> Recycles { get; set; }

        public DataContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Entities.Server>().ToTable("Servers");
            modelBuilder.Entity<Entities.Video>().ToTable("Videos");
            modelBuilder.Entity<Entities.Recycle>().ToTable("Recycles");
        }


    }
}
