using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EmployeesAPI.Models;

namespace EmployeesAPI.Controllers
{
	[Route("[controller]")]
	[ApiController]
	public class EmployeesController : ControllerBase
	{
		private readonly Employees _context;

		public EmployeesController(Employees context)
		{
			_context = context;
		}

		// GET: /Employees
		[HttpGet]
		public async Task<ActionResult<IEnumerable<Employee>>> Getemployees()
		{
			return await _context.employees.OrderBy(d => d.dateOfBirth).OrderBy(s => s.surname).ToListAsync();
		}

		// GET: /Employees/5
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

		// PUT: /Employees/Update/5
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPut("/Update/{id}")]
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

		// POST: /Employees/Create
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPost("/Create")]
		public async Task<ActionResult<Employee>> PostEmployee(Employee employee)
		{
			_context.employees.Add(employee);
			await _context.SaveChangesAsync();

			return CreatedAtAction("GetEmployee", new { id = employee.id }, employee);
		}

		// DELETE: /Employees/Delete/5
		[HttpDelete("/Delete/{id}")]
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
