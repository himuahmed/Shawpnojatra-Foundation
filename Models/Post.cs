using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shawpnojatra_Foundation.Models
{
	public class Post :CoreModel
	{
		public string PostDetail { get; set; }

		public string Image { get; set; }

		public int TypeID { get; set; }
	}
}
