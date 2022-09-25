using System.Data.Entity;
using Data.DTO;
using People.Data.DTO;

namespace People.EfStuff.Db
{
    public class DataContext : DbContext
    {
        public DataContext()
        {
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;          
        }
        public DbSet<StudentDTO> Students { get; set; }
        public DbSet<TeacherDTO> Teachers { get; set; }
        public DbSet<LectureDTO> Lectures { get; set; }
        public DbSet<GradeDTO> Grades { get; set; }
        public DbSet<ScientificWorkDTO> ScientificWorks { get; set; }
        public DbSet<SubjectDTO> Subjects { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);         
        }
    }

}

