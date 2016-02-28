using HRSystem.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;


namespace HRSystem.DAL
{
    public class HRContext : DbContext
    {
        public DbSet<City> Cities { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            //modelBuilder.Entity<Course>()
            //    .HasMany(c => c.Instructors).WithMany(i => i.Courses)
            //    .Map(t => t.MapLeftKey("CourseID")
            //        .MapRightKey("InstructorID")
            //        .ToTable("CourseInstructor"));

            //modelBuilder.Entity<Department>().MapToStoredProcedures();
        }

        public System.Data.Entity.DbSet<HRSystem.Models.RoleHierarchy> RoleHierarchies { get; set; }
    }
}