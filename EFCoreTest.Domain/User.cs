using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreTest.Domain
{
	public class User : Entity
	{
		public string Name { get; private set; }
		public string Email { get; private set; }
		public string Password { get; private set; }

		//private List<Address> _addresses { get; } = new List<Address>();
		public virtual ICollection<Address>? Addresses { get; private set; }

		//protected User() : base() { }

		public User(string name, string email, string password) //: this()
		{
			Name = name;
			Email = email;
			ChangePassword(password);

		}

		public void ChangeName(string name)
		{
			Name = name;
		}

		public void ChangeEmail(string email)
		{
			Email = email;
		}

		public void ChangePassword(string password)
		{
			// hash password using SHA256 and store it in Password
			Password = password;
		}

		public void AddAddress(Address address)
		{
			if (Addresses == null)
				Addresses = new List<Address>();
			((List<Address>)Addresses).Add(address);

			//address.SetOwner(this);
		}

		public void RemoveAddress(int id)
		{
			var address = Addresses?.FirstOrDefault(x => x.Id == id);
			if (address != null)
			{
				((List<Address>)Addresses!).Remove(address);
			}
		}

	}
}
