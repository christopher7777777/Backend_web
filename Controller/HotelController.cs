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
        public IActionResult Create([
            FromBody] Hotel hotel){
            if(hotel ==null){
                return BadRequest();
            }
            
            _context.Hotel.Add(hotel);
            _context.SaveChanges();
            // return CreatedAtAction(nameof(GetById), new {id = hotel.Id}, hotel);
            return Ok (hotel);
        }
        [HttpPut("{id}")]

        public IActionResult Update([FromBody] Hotel hotel, int id)
        {
            var updateData = _context.Hotel.Find(id);
            if (updateData == null)
            {
                return NoContent();
            }
            
            updateData.Description = hotel.Description;
            updateData.Name = hotel.Name;
            updateData.Price = hotel.Price;
            updateData.Image = hotel.Image;

            _context.SaveChanges();
            return Ok(updateData);
            


        }
        [HttpDelete("{id}")]
        public IActionResult Delete([FromBody] Hotel hotel, int id)
        {
            var content = _context.Hotel.Find(id);
            if (content == null)
            {
                return NoContent();
            }

            _context.Hotel.Remove(content);
            _context.SaveChanges();
            return Ok();

        }


    }

    }
