using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using wandermate.backened.Models;
using Wandermate.Data;

namespace Wandermate.Controller
{
    [Route("Wandermate/hotel")]
    [ApiController]

    public class HotelController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public HotelController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET api/hotel
        [HttpGet]
        public IActionResult GetAll(){
            var hotels = _context.Hotel.ToList();
            return Ok(hotels);
        }

        // GET api/hotel/id
        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute]int id){
            var hotel = _context.Hotel.Find(id);
            if(hotel == null){
                return NotFound();
            }
            return Ok(hotel);
        }
        [HttpPost ]
        public IActionResult Create([FromBody] Hotel hotel){
            _context.Hotel.Add(hotel);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetById), new {id = hotel.Id}, hotel);
        }
    }
}