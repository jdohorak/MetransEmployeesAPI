using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace EmployeesAPI.Models
{
	public class Employees : DbContext
	{
		public Employees(DbContextOptions<Employees> options) : base(options)
		{

		}

		public  DbSet<Employee> employees { get; set; }

		public List<Employee> GetEmployees()
		{
			return employees.ToList();
		}
	}
}
