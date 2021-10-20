using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Areas.Identity.Data;

namespace WebApplication.Models
{
	public class Tracking
	{
		public int Id { get; set; }
		public string UserId { get; set; }

		public DateTime Logged { get; set; }
	}
}
