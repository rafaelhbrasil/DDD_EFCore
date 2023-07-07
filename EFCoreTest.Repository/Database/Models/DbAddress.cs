using EFCoreTest.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreTest.Repository.Database.Models
{
	internal class DbAddress: Address
	{
        public DbAddress(string street, string city, string state, string zipCode, string? district, long userId): base(street, city, state, zipCode, district)
        {
            UserId = userId;
        }

        public long UserId { get; private set; }
	}
}
