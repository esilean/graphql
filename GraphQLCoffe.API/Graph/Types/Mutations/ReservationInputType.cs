using GraphQL.Types;

namespace GraphQLCoffe.API.Graph.Types.Mutations
{
    public class ReservationInputType : InputObjectGraphType
    {
        public ReservationInputType()
        {
            Field<IntGraphType>("id");
            Field<StringGraphType>("name");
            Field<StringGraphType>("phone");
            Field<IntGraphType>("totalPeople");
            Field<StringGraphType>("email");
            Field<StringGraphType>("date");
            Field<StringGraphType>("time");
        }
    }
}
