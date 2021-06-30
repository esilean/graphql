using System;

namespace GraphQLChocolate.API.Models
{
    public class SubMenu
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public double Price { get; set; }
        public Guid MenuId { get; set; }
    }
}
