using Microsoft.AspNetCore.Hosting;
using Shawpnojatra_Foundation.Models;
using Shawpnojatra_Foundation.View_Model;
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

		public IEnumerable<VMMessage> GetMessages()
		{
			List<VMMessage> vData = new List<VMMessage>();
			var vD= _db.Messages.ToList();
			foreach(var v in vD)
			{
				var d = new VMMessage
				{
					ID = v.ID,
					ContactNumber = v.ContactNumber != null ? v.ContactNumber : "No Contact Number",
					ContactPerson = v.ContactPerson != null ? v.ContactPerson : "Unknown",
					Text = v.Text,
					CDstring = v.CD.ToString("dd-MM-yyyy hh:mm:ss"),
				};
				vData.Add(d);
			}
			return vData;
		}

		public int UpdateMessage(Message message)
		{
			throw new NotImplementedException();
		}
	}
}
