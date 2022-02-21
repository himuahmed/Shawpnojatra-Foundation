using Microsoft.AspNetCore.Mvc;
using Shawpnojatra_Foundation.Models;
using Shawpnojatra_Foundation.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shawpnojatra_Foundation.Controllers
{
	public class MessageController : Controller
	{
		private readonly IMessageService _service;
		public MessageController(IMessageService service)
		{
			_service = service;
		}
		public IActionResult Index()
		{
			return View();
		}
		[HttpGet]
		[Route("[action]")]
		[Route("api/Activity/GetMessages")]
		public JsonResult GetMessages()
		{
			var posts = _service.GetMessages();
			return Json(posts);
		}
		[HttpGet]
		[Route("[action]")]
		[Route("api/Activity/GetMessageByID")]
		public JsonResult GetMessageByID(int ID)
		{
			var message = _service.GetMessageByID(ID);
			return Json(message);
		}

		[HttpPost]
		[Route("[action]")]
		[Route("api/Activity/AddMessage")]

		public IActionResult AddMessage([FromForm] Message message)
		{
			var ID = _service.AddMessage(message);
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
