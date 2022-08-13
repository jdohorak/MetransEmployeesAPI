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
    /// <summary>Startup</summary>
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


        /// <summary>Configures the services.</summary>
        /// <param name="services">The services.</param>
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

        /// <summary>Configures the specified application.</summary>
        /// <param name="app">The application.</param>
        /// <param name="env">The env.</param>
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
