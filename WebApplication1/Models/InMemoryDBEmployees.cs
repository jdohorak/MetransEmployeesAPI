using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace EmployeesAPI.Models
{
    /// <summary>Employees db context</summary>
    public class Employees : DbContext
	{
        /// <summary>Initializes a new instance of the <see cref="Employees" /> class.</summary>
        /// <param name="options">The options.</param>
        public Employees(DbContextOptions<Employees> options) : base(options)
		{

		}

        /// <summary>Gets or sets the employees.</summary>
        /// <value>The employees db set.</value>
        public DbSet<Employee> employees { get; set; }

        /// <summary>Gets the employees.</summary>
        /// <returns>Employees list</returns>
        public List<Employee> GetEmployees()
		{
			return employees.ToList();
		}
	}
}
