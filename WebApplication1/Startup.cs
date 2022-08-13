using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using EmployeesAPI.Models;
using System;
using Microsoft.Data.SqlClient;

namespace EmployeesAPI
{
	public class Startup
	{

		private string connectionString;

		public string ConnectionString
		{
			get
			{
				SqlConnectionStringBuilder connectionBuilder = new SqlConnectionStringBuilder();

				connectionBuilder.DataSource = "dohorak\\mssqlserver01";
				connectionBuilder.InitialCatalog = "dohorak";
				connectionBuilder.IntegratedSecurity = true;
				connectionString = connectionBuilder.ConnectionString;
				return connectionString;
			}
			set { connectionString = value; }
		}


		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddDbContext<Employees>(db => db.UseInMemoryDatabase("Employees"));
			SqlConnection conn = new SqlConnection();
			conn.ConnectionString = ConnectionString;

			conn.Open();


			conn.Close();
			//services.AddDbContext<TableDB>(db2 => db2.UseSqlServer($"Data Source=dohorak\\mssqlserver01;Initial Catalog=dohorak;Integrated Security=True"));
			services.AddDbContext<TableDB>(db2 => db2.UseSqlServer(ConnectionString));

			services.AddControllers();
			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebEmployeesAPI", Version = "v1" });
			});
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				app.UseSwagger();
				app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebEmployeesAPI v1"));
			}

			app.UseHttpsRedirection();

			app.UseRouting();

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}
