using Microsoft.EntityFrameworkCore;
using Escola.Data.Map;
using Escola.Models;

namespace Escola.Data
{
    public class SchoolDBContext : DbContext
    {
        public SchoolDBContext(DbContextOptions<SchoolDBContext> options)
            : base(options)
        {
        }

        public DbSet<StudentModel> Students { get; set; }
        public DbSet<UserModel> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new StudentMap());
            modelBuilder.ApplyConfiguration(new UserMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
