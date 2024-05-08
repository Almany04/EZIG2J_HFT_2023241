using EZIG2J_HFT_2023241.Logic;
using EZIG2J_HFT_2023241.Models;
using EZIG2J_HFT_2023241.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;

namespace EZIG2J_HFT_2023241.Endpoint
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<EmployeeDbContext>();

            services.AddTransient<IRepository<Employee>, EmployeeRepository>();
            services.AddTransient<IRepository<Department>, DepartmentRepository>();
            services.AddTransient<IRepository<ProjectAssignment>, ProjectAssignRepository>();
            services.AddTransient<IRepository<Project>, ProjectRepository>();

            services.AddTransient<IEmployeeLogic, EmployeeLogic>();
            services.AddTransient<IDepartmentLogic, DepartmentLogic>();
            services.AddTransient<IProjectAssignmentLogic, ProjectAssignmentLogic>();
            services.AddTransient<IProjectLogic, ProjectLogic>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });
            });
        }
    }
}
