using GraphQL.Types;

namespace GraphQLCoffe.API.Graph.Mutations
{
    public class RootMutation : ObjectGraphType
    {
        public RootMutation()
        {
            Field<MenuMutation>("menuMutation", resolve: ctx => new { });
            Field<SubMenuMutation>("subMenuMutation", resolve: ctx => new { });
            Field<ReservationMutation>("reservationMutation", resolve: ctx => new { });
        }
    }
}
