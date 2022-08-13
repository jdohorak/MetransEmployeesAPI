using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EmployeesAPI.Models;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace EmployeesAPI.Controllers
{
	[Route("[controller]")]
	[ApiController]
	public class TableDBController : ControllerBase
	{
		private TableDB _context;

		public TableDBController(TableDB context)
		{
			_context = context;
		}


		[HttpGet("TableDB")]
		public async Task<ActionResult<IEnumerable<Table>>> GetTable()
		{
			return await _context.tables.ToListAsync();
		}

		[HttpPost("Create")]
		public async Task<ActionResult<Table>> PostTable(Table table)
		{
			_context.tables.Add(table);
			await _context.SaveChangesAsync();
			return table;
		}
	}
}
