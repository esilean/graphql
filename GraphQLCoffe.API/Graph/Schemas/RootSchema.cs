using GraphQL.Types;
using GraphQLCoffe.API.Graph.Mutations;
using GraphQLCoffe.API.Graph.Queries;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace GraphQLCoffe.API.Graph.Schemas
{
    public class RootSchema : Schema
    {
        public RootSchema(IServiceProvider services) : base(services)
        {
            Query = services.GetRequiredService<RootQuery>();
            Mutation = services.GetRequiredService<RootMutation>();
        }
    }
}
