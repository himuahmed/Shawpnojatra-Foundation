using Microsoft.AspNetCore.Hosting;
using Shawpnojatra_Foundation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shawpnojatra_Foundation.Services
{
	public class MessageService : IMessageService
	{
		public ApplicationContext _db { get; set; }
		private IWebHostEnvironment Environment;
		public MessageService(ApplicationContext db, IWebHostEnvironment _environment)
		{
			_db = db;
			Environment = _environment;
		}

		public int AddMessage(Message message)
		{
			int result = -1;
			_db.Add(message);
			if (_db.SaveChanges() > 0)
			{
				result = message.ID;
			}
			return result;
		}

		public int DeleteMessage(int ID)
		{
			int result = -1;
			var deleteEntity = _db.Messages.Find(ID);
			if (deleteEntity != null)
			{
				deleteEntity.Active = false;
			}
			if (_db.SaveChanges() > 0)
			{
				result = deleteEntity.ID;
			}
			return result;
		}

		public Message GetMessageByID(int ID)
		{
			
			var Entity = _db.Messages.Find(ID);
			return Entity;
		}

		public IEnumerable<Message> GetMessages()
		{
			return _db.Messages.ToList();
		}

		public int UpdateMessage(Message message)
		{
			throw new NotImplementedException();
		}
	}
}
