﻿namespace GraphQL.API.Models
{
    public record Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
    }
}
