﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GraphQLChocolate.API.Models
{
    public class Menu
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public ICollection<SubMenu> SubMenus { get; set; }
    }
}
