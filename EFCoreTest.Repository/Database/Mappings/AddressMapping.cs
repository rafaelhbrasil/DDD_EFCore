using EFCoreTest.Domain;
using EFCoreTest.Repository.Database.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreTest.Repository.Database.Mappings
{
	internal class AddressMapping : IEntityTypeConfiguration<Address>
	{
		public void Configure(EntityTypeBuilder<Address> builder)
		{
			//builder.ToTable("Address");
			//builder.HasKey(p => p.Id);

			builder.Property(p => p.Street)
				.HasMaxLength(200)
				.IsRequired();

			builder.Property(p => p.City)
				.HasMaxLength(80)
				.IsRequired();

			builder.Property(p => p.District)
				.HasMaxLength(80);

			builder.Property(p => p.State)
				.HasMaxLength(20)
				.IsRequired();

			builder.Property(p => p.State)
				.HasMaxLength(10)
				.IsRequired();

			//builder.HasOne<User>()
			//	.WithMany(p => p.Addresses)
			//	.HasForeignKey(p => p.UserId)
			//	.OnDelete(DeleteBehavior.Cascade);
		}
	}
}
