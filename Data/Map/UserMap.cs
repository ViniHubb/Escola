using Microsoft.EntityFrameworkCore;
using Escola.Models;
using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Escola.Data.Map
{
    public class UserMap : IEntityTypeConfiguration<UserModel>
    {
        public void Configure(EntityTypeBuilder<UserModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.UserName).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Password).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Role).IsRequired().HasMaxLength(50);
        }
    }
}
