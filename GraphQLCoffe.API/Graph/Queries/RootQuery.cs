using GraphQL.Types;

namespace GraphQLCoffe.API.Graph.Queries
{
    public class RootQuery : ObjectGraphType
    {
        public RootQuery()
        {
            Field<MenuQuery>("menuQuery", resolve: ctx => new { });
            Field<SubMenuQuery>("subMenuQuery", resolve: ctx => new { });
            Field<ReservationQuery>("reservationQuery", resolve: ctx => new { });
        }
    }
}
