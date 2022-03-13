using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shawpnojatra_Foundation.Models
{
	public class ApplicationContext:IdentityDbContext
    {
		public ApplicationContext(DbContextOptions options) : base(options)
		{ 
		}

		public DbSet<Post> Posts { get; set; }
		public DbSet<Message> Messages { get; set; }
	}
}
