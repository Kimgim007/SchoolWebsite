using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Text;
using Test1Context.DTO;

namespace Test1
{
    public class Test1ContextContext : DbContext
    {
        public Test1ContextContext()
        {
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;


        }
        public DbSet<GameDTO> Games { get; set; }

        public DbSet<TeamDTO> Teams { get; set; }
        public DbSet<UserDTO> Users { get; set; }
        public DbSet<GamesLibraryDTO> GamesLibrary { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<UserDTO>()
             .HasMany(c => c.Games).WithMany(i => i.Users)
             .Map(t => t.MapLeftKey("UserId")
             .MapRightKey("GameId")
             .ToTable("UserGame"));



        }
    }
}
