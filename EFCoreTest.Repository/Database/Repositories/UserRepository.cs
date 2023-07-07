using EFCoreTest.Domain;
using EFCoreTest.Repository.Database.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreTest.Repository.Database.Repositories
{
	public class UserRepository : BaseRepositoryDb<User>, IUserRepository
	{
		public UserRepository(DbContext context) : base(context)
		{
		}

		public async Task<List<User>> ListAll()
		{
			return await Set.Include(u => u.Addresses).ToListAsync();
		}

		public async Task<List<Address>> ListAllAddresses()
		{
			return await //Context.Set<Address>().ToListAsync();
				Set.SelectMany(u => u.Addresses).ToListAsync();
		}
	}
}
