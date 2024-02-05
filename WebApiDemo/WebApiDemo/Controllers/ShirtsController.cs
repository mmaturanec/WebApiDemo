using Microsoft.AspNetCore.Mvc;
using WebApiDemo.Models;

namespace WebApiDemo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ShirtsController : ControllerBase
    {
        private List<Shirt> shirts = new List<Shirt>()
        { 
            new Shirt{ShirtId = 1, Brand = "My brand", Color = "Blue", Gender = "Men", Price = 30, Size = 10},
            new Shirt{ShirtId = 2, Brand = "My brand", Color = "Yellow", Gender = "Men", Price = 35, Size = 12},
            new Shirt{ShirtId = 3, Brand = "Your brand", Color = "Pink", Gender = "Women", Price = 28, Size = 8},
            new Shirt{ShirtId = 4, Brand = "Your brand", Color = "Purple", Gender = "Women", Price = 30, Size = 9}
        };

        [HttpGet]
        public IActionResult GetShirts()
        {
            return Ok("Reading all the shirts");
        }
        [HttpGet("{id}")]
        public IActionResult GetShirtById(int id)
        {
            if (id <= 0)
                return BadRequest();
            
            var shirt =  shirts.FirstOrDefault(x => x.ShirtId == id);
            if(shirt == null)
                return NotFound();
            
             return Ok(shirt);
            
        }
        [HttpPost] 
        public IActionResult CreateShirt([FromBody]Shirt shirt)
        {
            return Ok("Creating a shirt");
        }
        [HttpPut("{id}")]
        public IActionResult UpdateShirt(int id)
        {
            return Ok($"Updating a shirt: {id}");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteShirt(int id)
        {
            return Ok($"Deleting a shirt: {id}");
        }
    }
}
