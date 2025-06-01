using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Presentation.Entities;

namespace Presentation.Contexts
{
    public class DataContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<ProfileEntity> ProfileEntities { get; set; }
        public DbSet<AddressEntity> AddressEntities { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }
}
