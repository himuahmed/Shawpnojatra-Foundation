using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shawpnojatra_Foundation.Models
{
	public class CoreModel
	{

		public int ID { get; set; }
		public int UserID { get; set; }

		public DateTime CD { get; set; } = DateTime.Now;
		public DateTime UD { get; set; } = DateTime.Now;

		public bool Active { get; set; } = true;
	}
}
