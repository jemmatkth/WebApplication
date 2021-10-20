using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Models.ViewModels
{
	public class HomeViewModel
	{
		public DateTime LastLoggedIn { get; set; }
		public int numberLoggedInLastMonth { get; set; }
	}
}
