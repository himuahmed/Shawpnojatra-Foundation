using Shawpnojatra_Foundation.Models;
using Shawpnojatra_Foundation.View_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shawpnojatra_Foundation.Services
{
	public interface IActivityService
	{
		IEnumerable<Post> GetPost();
		Post GetPostsByID(int ID);
		int AddPost(VMPost post);

		int UpdatePost(VMPost post);
		int DeletePost(int ID);
		int AddWeSite(VMWebLink model);
		IEnumerable<VMWebLink> GetWebSites();


	}
}
