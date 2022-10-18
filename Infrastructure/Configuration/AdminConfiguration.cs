using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 
using Core.Entities.UserEntity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration
{
    public class AdminConfiguration : IEntityTypeConfiguration<User>
    {
        private const string AdminId = "B22698B8-42A2-4115-9631-1C2D1E2AC5F7";
        public void Configure(EntityTypeBuilder<User> builder)
        {
            var admin = new User
            {
                Id = AdminId,
                UserName = "masteradmin",
                NormalizedUserName = "MASTERADMIN",
                Email = "Admin@Admin.com",
                NormalizedEmail = "ADMIN@ADMIN.COM",
                PhoneNumber = "XXXXXXXXXXXXX",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                SecurityStamp = new Guid().ToString("D"),
            };
            admin.PasswordHash = PassGenerate(admin);

            builder.HasData(admin);
        }
        public string PassGenerate(IdentityUser user)
        {
            var passHash = new PasswordHasher<IdentityUser>();
            return passHash.HashPassword(user, "1213SuperAdminPassword@#2fsSF_");
        }
    }
}
