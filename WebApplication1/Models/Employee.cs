using System;

namespace EmployeesAPI.Models
{
	public class Employee
	{
		public int id { get; set; }
		public string name { get; set; }
		public string surname { get; set; }
		public DateTime dateOfBirth { get; set; }
	}
}
