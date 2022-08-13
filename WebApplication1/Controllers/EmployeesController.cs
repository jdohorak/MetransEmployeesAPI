using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EmployeesAPI.Models;

namespace EmployeesAPI.Controllers
{
    /// <summary>Employees Controller</summary>
    [Route("[controller]")]
	[ApiController]
	public class EmployeesController : ControllerBase
	{
		private readonly Employees _context;

        /// <summary>Initializes a new instance of the <see cref="EmployeesController" /> class.</summary>
        /// <param name="context">The context.</param>
        public EmployeesController(Employees context)
		{
			_context = context;
		}

        /// <summary>GET: /Employees</summary>
        /// <returns>Employees lilst</returns>
        [HttpGet]
		public async Task<ActionResult<IEnumerable<Employee>>> Getemployees()
		{
			var result = await _context.employees.OrderBy(d => d.dateOfBirth).OrderBy(s => s.surname).ToListAsync();
			return result;
		}

        /// <summary>GET: /Employees/id</summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Employee</returns>
        [HttpGet("{id}")]
		public async Task<ActionResult<Employee>> GetEmployee(int id)
		{
			var employee = await _context.employees.FindAsync(id);

			if (employee == null)
			{
				return NotFound();
			}

			return employee;
		}

        /// <summary>PUT: /Employees/Update/id</summary>
        /// <param name="id">The identifier.</param>
        /// <param name="employee">The employee.</param>
        /// <returns>HTTPs result</returns>
        [HttpPut("Update/{id}")]
		public async Task<IActionResult> PutEmployee(int id, Employee employee)
		{
			if (id != employee.id)
			{
				return BadRequest();
			}

			_context.Entry(employee).State = EntityState.Modified;

			try
			{
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!EmployeeExists(id))
				{
					return NotFound();
				}
				else
				{
					throw;
				}
			}

			return NoContent();
		}

        /// <summary>POST: /Employees/Create</summary>
        /// <param name="employee">The employee.</param>
        /// <returns>HTTPs result</returns>
        [HttpPost("Create")]
		public async Task<ActionResult<Employee>> PostEmployee(Employee employee)
		{
			_context.employees.Add(employee);
			await _context.SaveChangesAsync();

			return CreatedAtAction("GetEmployee", new { id = employee.id }, employee);
		}

        /// <summary>//DELETE: //Employees/Delete/id</summary>
        /// <param name="id">The identifier.</param>
        /// <returns>HTTPs result</returns>
        [HttpDelete("Delete/{id}")]
		public async Task<IActionResult> DeleteEmployee(int id)
		{
			var employee = await _context.employees.FindAsync(id);
			if (employee == null)
			{
				return NotFound();
			}

			_context.employees.Remove(employee);
			await _context.SaveChangesAsync();

			return NoContent();
		}


		private bool EmployeeExists(int id)
		{
			return _context.employees.Any(e => e.id == id);
		}
	}
}
