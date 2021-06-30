using GraphQLChocolate.API.Models;
using HotChocolate;
using HotChocolate.Subscriptions;
using HotChocolate.Types;
using Microsoft.AspNetCore.Http;
using System;

namespace GraphQLChocolate.API.Graph.Types.Subscriptions
{
    public class MenuSubscriptionTypeExtension : ObjectTypeExtension
    {
        protected override void Configure(IObjectTypeDescriptor descriptor)
        {
            descriptor.Name("Subscription");

            descriptor.Field("OnMenuCreate")
                        .Resolve(context => context.GetEventMessage<Menu>())
                        .Subscribe(async ctx =>
                        {
                            var hctx = ctx.Service<IHttpContextAccessor>();
                            var userId = hctx.HttpContext.Items["userId"] as string;
                            if (userId == null)
                                throw new Exception("Unauthorized");

                            var receiver = ctx.Service<ITopicEventReceiver>();
                            var stream = await receiver.SubscribeAsync<string, Menu>("MenuCreated");
                            return stream;
                        })
                        .Name("onMenuCreate");
        }
    }
}
