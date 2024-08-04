using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using wandermate.backened.Models;
using Wandermate.Data;
using Wandermate.DTO;

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
        public async Task<ActionResult> Get()
        {
            var hotels = await _context.Hotel.ToListAsync();
            return Ok(hotels);
        }


        // GET api/hotel/id
        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var hotel = _context.Hotel.Find(id);
            if (hotel == null)
            {
                return NotFound();
            }
            return Ok(hotel);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] HotelDto hotelDto)
        { 
            try{
            var hotel = new Hotel
            {
                Name = hotelDto.Name,
                Description = hotelDto.Description,
                Price = hotelDto.Price,
                ImageUrl = hotelDto.ImageUrl
            };

            if (hotel == null)
            {
                return BadRequest();
            }

            await _context.Hotel.AddAsync(hotel);
            await _context.SaveChangesAsync();

            // return CreatedAtAction(nameof(GetById), new { id = hotel.Id }, hotel);
            return Ok(hotel);
            }
            catch (Exception ex)
            {
            return StatusCode(500, $"Internal server error: {ex.Message}");
            }
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
            updateData.ImageUrl = hotel.ImageUrl;

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
