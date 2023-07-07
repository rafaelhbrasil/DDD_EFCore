using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreTest.Domain
{
	public class Address: Entity
	{
		public string Street { get; private set; }
		public string? District { get; private set; }
		public string City { get; private set; }
		public string State { get; private set; }
		public string ZipCode { get; private set; }

        0public long UserId { get; private set; }

        public Address(string street, string city, string state, string zipCode, string? district = null, long userId = 0)
		{
			Street = street;
			City = city;
			State = state;
			ZipCode = zipCode;
			District = district;
			UserId = userId;
		}
	}
}
