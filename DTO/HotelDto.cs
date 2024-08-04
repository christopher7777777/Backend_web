using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wandermate.DTO
{
    public class HotelDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Description { get; set; }  = string.Empty;

        public string Address { get; set; } = string.Empty;

        public string Price { get; set; } = string.Empty;

        public string ImageUrl { get; set; } = string.Empty;
    }
}