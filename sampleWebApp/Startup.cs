using System.Data.SqlClient;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace sampleWebApp
{
    public class Startup
    {
        /*public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        private IConfiguration Configuration { get; }*/
        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
           /* services.AddDbContext<MoviesDbContext>();
            var con = new SqlConnection("Server=localhost; Initial Catalog=MoviesDb; Integrated Security=True"); 
            
            con.Open();
            services.AddDbContext<MoviesDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("ConnectionStrings")));
                */
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.Run(async (context) => { await context.Response.WriteAsync("Hello World!"); });
            app.UseMvc();
        }
    }
}