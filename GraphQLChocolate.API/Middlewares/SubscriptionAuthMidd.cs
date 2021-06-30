using GraphQLChocolate.API.Infra;
using HotChocolate.AspNetCore;
using HotChocolate.AspNetCore.Subscriptions;
using HotChocolate.AspNetCore.Subscriptions.Messages;
using HotChocolate.Execution;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

namespace GraphQLChocolate.API.Middlewares
{
    public class SubscriptionAuthMidd : ISocketSessionInterceptor
    {
        public ValueTask<ConnectionStatus> OnConnectAsync(ISocketConnection connection, InitializeConnectionMessage message, CancellationToken cancellationToken)
        {
            try
            {
                var tokenHeader = message.Payload["Authorization"] as string;
                if (string.IsNullOrEmpty(tokenHeader) || !tokenHeader.StartsWith("Bearer "))
                    return ValueTask.FromResult(ConnectionStatus.Reject("Unauthorized"));

                var token = tokenHeader.Replace("Bearer ", "");

                var opts = connection.HttpContext.RequestServices.GetRequiredService<JwtBearerOptions>();
                var backer = new JwtBearerBacker(opts);
                var claims = backer.IsJwtValid(token);
                if (claims == null)
                    return ValueTask.FromResult(ConnectionStatus.Reject("Unauthorized (invalid token)"));

                var userId = claims.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "";
                connection.HttpContext.Items["userId"] = userId;

                return ValueTask.FromResult(ConnectionStatus.Accept());

            }
            catch (Exception ex)
            {
                return ValueTask.FromResult(ConnectionStatus.Reject(ex.Message));
            }
        }

        public ValueTask OnCloseAsync(ISocketConnection connection, CancellationToken cancellationToken)
        {
            return ValueTask.CompletedTask;
        }
        public ValueTask OnRequestAsync(ISocketConnection connection, IQueryRequestBuilder requestBuilder, CancellationToken cancellationToken)
        {
            return ValueTask.CompletedTask;
        }
    }
}
