﻿using System;

namespace GraphQLChocolate.API.Models
{
    public class Reservation
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public int TotalPeople { get; set; }
        public string Email { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
    }
}
