using Microsoft.AspNetCore.Authorization;
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

		public IActionResult Index()
        {		
			var postList = _service.GetPost().OrderBy(x=>x.CD).ToList().Take(10);

			return View(postList);
        }

		public IActionResult PostDetails(int id=-1)
        {
			if (!string.IsNullOrWhiteSpace(id.ToString()) && id > -1)
            {
				Post post = _service.GetPostsByID(id);
				return View(post);
			}
            else
            {
				Post post = _service.GetPost().OrderBy(x => x.CD).FirstOrDefault();
				return View(post);
			}


			
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

		[Authorize(AuthenticationSchemes = "Bearer")]
		[HttpPost]
		[Route("[action]")]
		[Route("api/Activity/AddPost")]

		public IActionResult AddPost([FromForm]VMPost model)
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

		[Authorize(AuthenticationSchemes = "Bearer")]
		[HttpPost]
		[Route("[action]")]
		[Route("api/Activity/AddWebSite")]

		public IActionResult AddWebSite([FromForm] VMWebLink model)
		{
			var ID = _service.AddWeSite(model);
			if (ID > 0)
			{
				return Ok();
			}
			else
			{
				return BadRequest();
			}
		}

		[HttpGet]
		[Route("[action]")]
		[Route("api/Activity/GetWebSites")]
		public JsonResult GetWebSites()
		{
			var websites = _service.GetWebSites();
			return Json(websites);
		}

		public IActionResult WebSites()
		{
			return View();
		}

	}
}
