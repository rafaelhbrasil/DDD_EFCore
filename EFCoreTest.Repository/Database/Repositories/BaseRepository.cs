using EFCoreTest.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreTest.Repository.Database.Repositories
{
	public  abstract class BaseRepositoryDb<T> where T: Entity
	{
		protected readonly DbContext Context;
		protected virtual DbSet<T> Set { get { return Context.Set<T>(); } }

		protected BaseRepositoryDb(DbContext context)
		{
			Context = context;
		}
		public virtual void Add(T obj)
		{
			if (obj.Id == 0)
				Set.Add(obj);
		}

		public virtual void Update(T obj)
		{
			if (obj.Id != 0)
				Context.Entry(obj).State = EntityState.Modified;
		}

		public virtual Task<int> Commit()
		{
			return Context.SaveChangesAsync();
		}

		public virtual async Task Delete(long id)
		{
			var obj = await GetByIdAsync(id);
			if(obj != null)
				Delete(obj);
		}
		public virtual void Delete(T obj)
		{
			Set.Remove(obj);
		}

		public async virtual Task<T?> GetByIdAsync(long id)
		{
			return await Set.FindAsync(id);
		}

		public virtual void Dispose()
		{
			Context.Dispose();
		}
	}
}
