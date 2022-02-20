using Microsoft.AspNetCore.Mvc;
using Shawpnojatra_Foundation.Models;
using Shawpnojatra_Foundation.Services;
using Shawpnojatra_Foundation.View_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shawpnojatra_Foundation.Controllers
{
	public class ActivityController : Controller
	{
		private readonly IActivityService _service;
		public ActivityController(IActivityService service)
		{
			_service = service;
		}
		[HttpGet]
		[Route("[action]")]
		[Route("api/Activity/GetPost")]
		public JsonResult GetPost()
		{
			var posts= _service.GetPost();
			return Json(posts);
		}
		[HttpGet]
		[Route("[action]")]
		[Route("api/Activity/GetPostByID")]
		public JsonResult GetPostByID(int ID)
		{
			var post = _service.GetPostsByID(ID);
			return Json(post);
		}

		[HttpPost]
		[Route("[action]")]
		[Route("api/Activity/AddPost")]

		public IActionResult AddPost(VMPost model)
		{
			var ID = _service.AddPost(model);
			if (ID > 0)
			{
				return Ok();
			}
			else
			{
				return BadRequest();
			}
		}
	}
}
