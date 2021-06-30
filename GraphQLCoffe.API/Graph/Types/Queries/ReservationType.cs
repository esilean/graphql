using GraphQL.Types;
using GraphQLCoffe.API.Models;

namespace GraphQLCoffe.API.Graph.Types.Queries
{
    public class ReservationType : ObjectGraphType<Reservation>
    {
        public ReservationType()
        {
            Field(x => x.Id);
            Field(x => x.Name);
            Field(x => x.Phone);
            Field(x => x.Time);
            Field(x => x.TotalPeople);
            Field(x => x.Email);
            Field(x => x.Date);
        }
    }
}
