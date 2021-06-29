using GraphiQl;
using GraphQL.API.Data;
using GraphQL.API.Graph.Mutations;
using GraphQL.API.Graph.Queries;
using GraphQL.API.Graph.Schemas;
using GraphQL.API.Graph.Types;
using GraphQL.API.Interfaces;
using GraphQL.API.Services;
using GraphQL.Server;
using GraphQL.Types;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace GraphQL.API
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "GraphQL.API", Version = "v1" });
            });

            services.AddScoped<IProductService, ProductService>();

            services.AddScoped<ProductType>();
            services.AddScoped<ProductQuery>();
            services.AddScoped<ProductMutation>();
            services.AddScoped<ISchema, ProductSchema>();

            services.AddGraphQL(opts =>
            {
                opts.EnableMetrics = false;
            })
            .AddSystemTextJson();

            services.AddDbContext<DataDbContext>(opts =>
            {
                opts.UseSqlite(_configuration.GetConnectionString("DefaultConnection"));
            });
        }

        public void Configure(IApplicationBuilder app,
                              IWebHostEnvironment env,
                              DataDbContext ctx)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "GraphQL.API v1"));
            }

            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseGraphiQl("/graphql");
            app.UseGraphQL<ISchema>();

            ctx.Database.EnsureCreated();
        }
    }
}
