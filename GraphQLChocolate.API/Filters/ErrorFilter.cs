using HotChocolate;

namespace GraphQLChocolate.API.Filters
{
    public class ErrorFilter : IErrorFilter
    {
        public IError OnError(IError error)
        {
            return error;
        }
    }
}
