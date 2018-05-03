using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace SinjulMSBH_E11.Data
{
	public class SinjulMSBHDbContext: DbContext
	{
		public SinjulMSBHDbContext ( DbContextOptions<SinjulMSBHDbContext> options )
			: base( options )
		{
		}

		public DbSet<SinjulMSBH> SinjulMSBH { get; set; }
	}

	public class SinjulMSBH
	{
		public int Id { get; set; }

		public int Statistic { get; set; }
	}
}