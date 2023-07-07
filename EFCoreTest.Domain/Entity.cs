using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreTest.Domain
{
	public abstract class Entity
	{
		public long Id { get; private set; }

        protected Entity()
        {
            
        }
    }
}
