using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using wandermate.backened.Models;
using Wandermate.Data;

namespace Wandermate.Controller
{
    [Route("Wandermate/travelPackage")]
    [ApiController]

    public class TravelPackageController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TravelPackageController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET api/hotel
        [HttpGet]
        public IActionResult GetAll(){
            var travelpackages = _context.TravelPackage.ToList();
            return Ok(travelpackages);
        }

        // GET api/hotel/id
        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute]int id){
            var travelpackage = _context.TravelPackage.Find(id);
            if(travelpackage == null){
                return NotFound();
            }
            return Ok(travelpackage);
        }

                [HttpPost ]
        public IActionResult Create([FromBody] TravelPackages travelPackages){
            _context.TravelPackage.Add(travelPackages);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetById), new {id = travelPackages.Id}, travelPackages);
        }

        
    }
}