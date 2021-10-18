using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Areas.Identity.Data;

namespace WebApplication.Models.ViewModels
{
	public class CreateMessageViewModel
	{
		public List<WebApplicationUser> Users { get; set; }
		public WebApplicationUser SendToUser { get; set; }
		public Message Message { get; set; }
	}
}
