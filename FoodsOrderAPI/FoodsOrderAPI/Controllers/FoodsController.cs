using FoodsOrderAPI.Data;
using FoodsOrderAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FoodsOrderAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class FoodsController : ControllerBase
    {
        DataContext _context;

        public FoodsController(DataContext context) 
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<FoodItem>>> Get()
        {
            var foods = await _context.FoodItems.ToListAsync();
            return Ok(foods);
            
        }


        [HttpPost]
        public async Task<ActionResult<FoodItem>> Post(FoodItem foodItems)
        {
            var foodItem = new FoodItem { 
                ImgSource = foodItems.ImgSource,   
                Description= foodItems.Description,
                Title= foodItems.Title
            };

            await _context.FoodItems.AddAsync(foodItem);
            await _context.SaveChangesAsync();
            return Ok(foodItems);

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<FoodItem>> Get(int id)
        { 
            var foodItem = await _context.FoodItems.FindAsync(id);
            if (foodItem == null)
            {
                return NotFound();
            }

            return Ok(foodItem);
        }


        [HttpPut("{id}")]

        public async Task<ActionResult<FoodItem>> Put(int id, FoodItem FoodItems)
        {
            var foodItem = await _context.FoodItems.FindAsync(id);
            if (foodItem == null)
            {
                return NotFound();
            }
            foodItem.Title = FoodItems.Title;
            foodItem.ImgSource = FoodItems.ImgSource;
            foodItem.Description = FoodItems.Description;

            await _context.SaveChangesAsync();
            return Ok(foodItem);

        }

        [HttpDelete("{id}")]

        public async Task<ActionResult<FoodItem>> Delete(int id)
        {
            var fooditem = await _context.FoodItems.FindAsync(id);
            if(fooditem == null) 
            {
                return NotFound(id);
            }
             _context.FoodItems.Remove(fooditem);
            await _context.SaveChangesAsync();
            return Ok(fooditem);
        }

            

    }
}
