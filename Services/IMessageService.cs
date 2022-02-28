
using Shawpnojatra_Foundation.Models;
using Shawpnojatra_Foundation.View_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shawpnojatra_Foundation.Services
{
	public interface IMessageService
	{
		IEnumerable<VMMessage> GetMessages();
		Message GetMessageByID(int ID);
		int AddMessage(Message message);

		int UpdateMessage(Message message);
		int DeleteMessage(int ID);
	}
}
