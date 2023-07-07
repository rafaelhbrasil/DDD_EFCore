using EFCoreTest.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreTest.Repository.Database.Mappings
{
	internal class UserMapping : IEntityTypeConfiguration<User>
	{
		public void Configure(EntityTypeBuilder<User> builder)
		{
			//builder.ToTable("Users");
			//builder.HasKey(p => p.Id);

			builder.Property(p => p.Name)
				.HasMaxLength(200)
				.IsRequired();

			builder.Property(p => p.Email)
				.HasMaxLength(200)
				.IsRequired();

			builder.Property(p => p.Password)
				.HasMaxLength(255)
				.IsRequired();

			builder.HasIndex(p => p.Email);

			builder.HasMany(p => p.Addresses)
				.WithOne()
				//.HasForeignKey(builder => builder.UserId)
				.OnDelete(DeleteBehavior.Cascade);
		}
	}
}
