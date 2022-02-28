using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shawpnojatra_Foundation.View_Model
{
	public class VMMessage
	{
		public string Text { get; set; }
		public string Image { get; set; }
		public string ContactPerson { get; set; }
		public string ContactNumber { get; set; }
		public int? TypeID { get; set; }
		public int ID { get; set; }
		public int UserID { get; set; }

		public DateTime CD { get; set; } = DateTime.Now;
		public string CDstring { get; set; } 
		public DateTime UD { get; set; } = DateTime.Now;

		public bool Active { get; set; } = true;
	}
}
