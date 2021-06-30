using GraphQLChocolate.API.Models;
using HotChocolate.Execution;
using HotChocolate.Subscriptions;
using HotChocolate.Types;
using System.Threading.Tasks;

namespace GraphQLChocolate.API.Graph.Subscriptions
{
    public class MenuSubscription
    {
        private readonly ITopicEventReceiver _eventReceiver;

        public MenuSubscription(ITopicEventReceiver eventReceiver)
        {
            _eventReceiver = eventReceiver;
        }

        [SubscribeAndResolve]
        public async ValueTask<ISourceStream<Menu>> OnMenuCreate()
        {
            return await _eventReceiver.SubscribeAsync<string, Menu>("MenuCreated");
        }

    }
}
