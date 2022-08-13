using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;



namespace EmployeesAPI.Models
{


	public class TableDB : DbContext
	{
		public TableDB(DbContextOptions<TableDB> options) : base(options)
		{

		}


		public DbSet<Table> tables { get; set; }


		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.HasDefaultSchema("dbo");
			modelBuilder.Entity<Table>().ToTable("Table_1");
			modelBuilder.Entity<Table>().HasKey(p => p.ID);
			modelBuilder.Entity<Table>().Property(p => p.ID).IsRequired();
			modelBuilder.Entity<Table>().Property(p => p.Namex).HasColumnName("name");
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.LogTo(x => Console.WriteLine(x));
			base.OnConfiguring(optionsBuilder);
		}

	}
}
