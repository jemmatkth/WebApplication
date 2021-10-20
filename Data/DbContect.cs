using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplication.Models;

public class DbContect : DbContext
{
	public DbContect(DbContextOptions<DbContect> options)
		: base(options)
	{
	}

	public DbSet<WebApplication.Models.Message> Message { get; set; }
	public DbSet<Tracking> Tracking { get; set; }
}
