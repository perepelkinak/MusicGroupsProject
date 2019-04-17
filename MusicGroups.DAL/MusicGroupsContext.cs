using Microsoft.EntityFrameworkCore;
using MusicGroups.DAL.Entities;
using MusicGroups.Domain;

namespace MusicGroups.DAL
{
    public class MusicGroupsContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(
                    @"Server=KSENIA\\SQLEXPRESS01;Database=musicgroupsdb;Integrated Security=SSPI;MultipleActiveResultSets=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
        
        public DbSet<MemberEntity> Members { get; set; }
        public DbSet<GroupEntity> Groups { get; set; }
    }
}