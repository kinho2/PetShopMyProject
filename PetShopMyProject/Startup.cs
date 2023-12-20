using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.IO;
using PetShopMyProject.Data;
using Microsoft.EntityFrameworkCore;
using PetShopMyProject.Interfaces.Repositories;
using PetShopMyProject.Data.Repositories;
using PetShopMyProject.Interfaces.Services;
using PetShopMyProject.ApplicationService;
using PetShopMyProject.Models;

namespace PetShopMyProject
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;

            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json").Build();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddDbContext<PetShopContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("PetShopMyProject")));
            services.AddScoped<DbContext, PetShopContext>();
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IPetClienteRepository, PetClienteRepository>();
            services.AddScoped<IClienteService, ClienteService>();
            services.AddScoped<IPetClienteService, PetClienteService>();
            services.AddScoped<IRepositoryBase<Cliente>, RepositoryBase<Cliente>>();
            services.AddScoped<IRepositoryBase<PetCliente>, RepositoryBase<PetCliente>>();
            services.AddMvc().AddRazorRuntimeCompilation();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
