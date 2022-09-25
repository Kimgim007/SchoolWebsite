using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;

namespace Test2.Db
{
    public class Test2Context : DbContext
    {
        public DbSet<AlbumsDTO> Albums { get; set; }
        public DbSet<GenresDTO> Genres { get; set; }
        public DbSet<CountriesDTO> Countries { get; set; }
        public DbSet<ArtistsDTO> Artists { get; set; }
        public DbSet<SongsDTO> Songs { get; set; }
        public DbSet<PersonsDTO> Persons { get; set; }
        public DbSet<GroupsDTO> Groups { get; set; }
        public DbSet<Albums_SongsDTO> Albums_Songs { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
