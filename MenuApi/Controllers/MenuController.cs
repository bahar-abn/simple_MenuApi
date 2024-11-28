using MenuApi.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RestaurantMenuAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        private static List<MenuItem> _menuItems = new List<MenuItem>();

        [HttpPost]
        public IActionResult CreateMenuItem([FromBody] MenuItem menuItem)
        {
            if (menuItem == null)
            {
                return BadRequest("Menu item is null.");
            }
            menuItem.Id = Guid.NewGuid();
            _menuItems.Add(menuItem);
            return CreatedAtAction(nameof(GetMenuItem), new { id = menuItem.Id }, menuItem);
        }
        [HttpGet]
        public IActionResult GetAllMenuItems()
        {
            return Ok(_menuItems);
        }
        [HttpGet("{id}")]
        public IActionResult GetMenuItem(Guid id)
        {
            var menuItem = _menuItems.FirstOrDefault(m => m.Id == id);

            if (menuItem == null)
            {
                return NotFound("Menu item not found.");
            }
            return Ok(menuItem);
        }
        [HttpPut("{id}")]
        public IActionResult UpdateMenuItem(Guid id, [FromBody] MenuItem updatedMenuItem)
        {
            if (updatedMenuItem == null)
            {
                return BadRequest("Menu item is null.");
            }
            var existingMenuItem = _menuItems.FirstOrDefault(m => m.Id == id);

            if (existingMenuItem == null)
            {
                return NotFound("Menu item not found.");
            }
            existingMenuItem.Name = updatedMenuItem.Name;
            existingMenuItem.Description = updatedMenuItem.Description;
            existingMenuItem.Price = updatedMenuItem.Price;
            return NoContent(); 
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMenuItem(Guid id)
        {
            var menuItem = _menuItems.FirstOrDefault(m => m.Id == id);
            if (menuItem == null)
            {
                return NotFound("Menu item not found.");
            }
            _menuItems.Remove(menuItem);
            return NoContent();
        }
    }
}