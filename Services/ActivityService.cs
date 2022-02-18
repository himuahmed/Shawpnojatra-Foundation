using Shawpnojatra_Foundation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shawpnojatra_Foundation.Services
{
	public class ActivityService
	{
		public ApplicationContext _db { get; set; }
		public ActivityService(ApplicationContext db)
		{
			_db = db;
		}
	}
}
