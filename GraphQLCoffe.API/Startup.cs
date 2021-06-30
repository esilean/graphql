using GraphiQl;
using GraphQL.Server;
using GraphQL.Types;
using GraphQLCoffe.API.Data;
using GraphQLCoffe.API.Graph.Mutations;
using GraphQLCoffe.API.Graph.Queries;
using GraphQLCoffe.API.Graph.Schemas;
using GraphQLCoffe.API.Graph.Types.Mutations;
using GraphQLCoffe.API.Graph.Types.Queries;
using GraphQLCoffe.API.Services;
using GraphQLCoffe.API.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace GraphQLCoffe.API
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

            services.AddScoped<IMenuService, MenuService>();
            services.AddScoped<ISubMenuService, SubMenuService>();
            services.AddScoped<IReservationService, ReservationService>();

            services.AddDbContext<CoffeDbContext>(opts =>
            {
                opts.UseSqlite(_configuration.GetConnectionString("DefaultConnection"));
            });


            services.AddScoped<ISchema, RootSchema>();
            services.AddScoped<RootQuery>();
            services.AddScoped<RootMutation>();

            services.AddScoped<MenuType>();
            services.AddScoped<MenuQuery>();
            services.AddScoped<MenuInputType>();
            services.AddScoped<MenuMutation>();

            services.AddScoped<SubMenuType>();
            services.AddScoped<SubMenuQuery>();
            services.AddScoped<SubMenuInputType>();
            services.AddScoped<SubMenuMutation>();

            services.AddScoped<ReservationType>();
            services.AddScoped<ReservationQuery>();
            services.AddScoped<ReservationInputType>();
            services.AddScoped<ReservationMutation>();

            services.AddGraphQL(opts =>
            {
                opts.EnableMetrics = false;
            })
            .AddSystemTextJson();
        }

        public void Configure(IApplicationBuilder app,
                              IWebHostEnvironment env,
                              CoffeDbContext ctx)
        {
            if (env.IsDevelopment())

            {
                app.UseDeveloperExceptionPage();
            }

            app.UseGraphiQl("/graphql");
            app.UseGraphQL<ISchema>();

            ctx.Database.EnsureCreated();
        }
    }
}
