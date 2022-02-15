using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shawpnojatra_Foundation.Models
{
	public class Message:CoreModel
	{
		public string Text { get; set; }

		public string Image { get; set; }
		public string ContactPerson { get; set; }
		public string ContactNumber { get; set; }
		public int? TypeID { get; set; }
	}
}
