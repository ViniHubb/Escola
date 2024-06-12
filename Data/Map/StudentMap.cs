using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Escola.Models;


namespace Escola.Data.Map
{
    public class StudentMap : IEntityTypeConfiguration<StudentModel>
    {
        public void Configure(EntityTypeBuilder<StudentModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(127);
            builder.Property(x => x.Surname).IsRequired().HasMaxLength(127);
            builder.Property(x => x.DateOfBirth).IsRequired().HasMaxLength(31);
            builder.Property(x => x.Class).IsRequired().HasMaxLength(127);
            builder.Property(x => x.GPA).IsRequired().HasMaxLength(7);
        }
    }
}
