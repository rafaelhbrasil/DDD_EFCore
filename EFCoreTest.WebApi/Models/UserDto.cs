using EFCoreTest.Domain;

namespace EFCoreTest.WebApi.Models
{
	public class UserDto : User
	{
		public UserDto(string name, string email, string password, ICollection<Address> addresses) 
			: base(name, email, password)
		{
			if (addresses != null)
				((List<Address>)Addresses).AddRange(addresses);
		}
	}
}
