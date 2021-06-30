using GraphQLChocolate.API.Data;
using GraphQLChocolate.API.Graph.Mutations;
using GraphQLChocolate.API.Graph.Queries;
using GraphQLChocolate.API.Graph.Subscriptions;
using GraphQLChocolate.API.Graph.Types.Queries;
using GraphQLChocolate.API.Graph.Types.Subscriptions;
using GraphQLChocolate.API.Services;
using GraphQLChocolate.API.Services.Interfaces;
using HotChocolate;
using HotChocolate.AspNetCore;
using HotChocolate.AspNetCore.Playground;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace GraphQLChocolate.API
{
    public class Startup
    {
        private readonly string _allowedOrigin = "allowedOrigin";
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

            services.AddDbContext<ChocoDbContext>(opts =>
            {
                opts.UseSqlite(_configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddInMemorySubscriptions();
            services.AddScoped<MenuQuery>();
            services.AddScoped<MenuMutation>();
            services.AddScoped<MenuSubscription>();

            services.AddScoped<SubMenuQuery>();
            services.AddScoped<SubMenuMutation>();

            services.AddScoped<ReservationQuery>();
            services.AddScoped<ReservationMutation>();

            services.AddGraphQLServer()
                    .AddFiltering()
                    .AddSorting()
                    .AddProjections()
                    .AddQueryType(q => q.Name("Query"))
                    .AddType<MenuQueryTypeExtension>()
                    .AddType<SubMenuQueryTypeExtension>()
                    .AddType<ReservationQueryTypeExtension>()

                    .AddMutationType(q => q.Name("Mutation"))
                    .AddType<MenuMutationTypeExtension>()
                    .AddType<SubMenuMutationTypeExtension>()

                    .AddSubscriptionType(q => q.Name("Subscription"))
                    .AddType<MenuSubscriptionTypeExtension>();


            services.AddCors(option =>
            {
                option.AddPolicy(_allowedOrigin,
                                builder => builder
                                                .AllowAnyOrigin()
                                                .AllowAnyMethod()
                                                .AllowAnyHeader()
                    );
            });
        }

        public void Configure(IApplicationBuilder app,
                                IWebHostEnvironment env,
                                ChocoDbContext ctx)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UsePlayground(new PlaygroundOptions
                {
                    QueryPath = "/graphql",
                    Path = "/playground"
                });
            }

            app.UseCors(_allowedOrigin);
            app.UseWebSockets();
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGraphQL("/graphql");
            });

            ctx.Database.EnsureCreated();
        }
    }
}
