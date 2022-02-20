using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shawpnojatra_Foundation.View_Model
{
	public class VMPost
	{
		public int ID { get; set; }
		public string PostDetail { get; set; }

		public string Image { get; set; }

		public int TypeID { get; set; }
		public IFormFile ImageFile { get; set; }
		public string Title { get; set; }

	}
}
