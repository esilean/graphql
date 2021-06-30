using GraphQLChocolate.API.Models;
using HotChocolate;
using HotChocolate.Execution;
using HotChocolate.Subscriptions;
using HotChocolate.Types;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GraphQLChocolate.API.Graph.Subscriptions
{
    public class SubMenuSubscription
    {

        [SubscribeAndResolve]
        public async ValueTask<ISourceStream<IEnumerable<SubMenu>>> OnSubMenusGetByMenuId([Service] ITopicEventReceiver eventReceiver,
                                                                                          CancellationToken cancellationToken)
        {
            return await eventReceiver.SubscribeAsync<string, IEnumerable<SubMenu>>("ReturnedSubMenus", cancellationToken);
        }
    }
}
