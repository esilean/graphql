using GraphQLChocolate.API.Data;
using GraphQLChocolate.API.Filters;
using GraphQLChocolate.API.Graph.Mutations;
using GraphQLChocolate.API.Graph.Queries;
using GraphQLChocolate.API.Graph.Subscriptions;
using GraphQLChocolate.API.Graph.Types.Queries;
using GraphQLChocolate.API.Graph.Types.Subscriptions;
using GraphQLChocolate.API.Infra;
using GraphQLChocolate.API.Infra.Interfaces;
using GraphQLChocolate.API.Middlewares;
using GraphQLChocolate.API.Services;
using GraphQLChocolate.API.Services.Interfaces;
using GraphQLChocolate.API.Settings;
using HotChocolate;
using HotChocolate.AspNetCore;
using HotChocolate.AspNetCore.Playground;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Microsoft.IdentityModel.Tokens;
using System.Text;

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
            IdentityModelEventSource.ShowPII = true;

            AppSettings appSettings = new();
            _configuration.Bind(appSettings);
            services.AddSingleton(appSettings);

            services.AddScoped<IMenuService, MenuService>();
            services.AddScoped<ISubMenuService, SubMenuService>();
            services.AddScoped<IReservationService, ReservationService>();

            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IUserService, UserService>();

            services.AddScoped<IGenerateToken, GenerateToken>();

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

            services.AddScoped<UserMutation>();
            services.AddScoped<AuthMutation>();


            services.AddGraphQLServer()
                    .AddAuthorization()
                    .AddSocketSessionInterceptor<SubscriptionAuthMidd>()
                    .AddErrorFilter<ErrorFilter>()
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
                    .AddType<UserMutationTypeExtension>()
                    .AddType<LoginMutationTypeExtension>()

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

            var opts = new JwtBearerOptions
            {
                Authority = appSettings.TokenSettings.Authority,
                TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = appSettings.TokenSettings.Authority,
                    ValidateAudience = true,
                    ValidAudience = appSettings.TokenSettings.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(appSettings.TokenSettings.Key)),
                    ValidateIssuerSigningKey = true,
                    ValidateLifetime = true
                },
                RequireHttpsMetadata = false
            };
            services.AddSingleton(opts);
            services
                .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(options =>
                    {
                        options.Authority = opts.Authority;
                        options.TokenValidationParameters = opts.TokenValidationParameters;
                        options.RequireHttpsMetadata = opts.RequireHttpsMetadata;
                        options.Configuration = new OpenIdConnectConfiguration();
                    });
            services.AddAuthorization(options =>
            {
                options.AddPolicy("user-policy", policy =>
                {
                    policy.RequireRole(new[] { "user", "admin" });
                    //policy.RequireClaim("");
                });
            });
            services.AddHttpContextAccessor();
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

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGraphQL("/graphql");
            });

            ctx.Database.EnsureCreated();
        }
    }
}
