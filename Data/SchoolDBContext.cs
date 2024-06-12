using Microsoft.EntityFrameworkCore;
using Escola.Data.Map;
using Escola.Models;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;

namespace Escola.Data
{
    public class SchoolDBContext : DbContext
    {

        public SchoolDBContext(DbContextOptions<SchoolDBContext> options)
            : base(options)
        {
            options.BuildOptionsFragment();
        }

        public DbSet<StudentModel> Students { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new StudentMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
