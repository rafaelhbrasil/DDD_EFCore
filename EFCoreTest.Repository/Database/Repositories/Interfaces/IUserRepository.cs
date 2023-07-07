using EFCoreTest.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreTest.Repository.Database.Repositories.Interfaces
{
	public interface IUserRepository : IRepository<User>
	{
		Task<List<User>> ListAll();

		Task<List<Address>> ListAllAddresses();
	}
}
