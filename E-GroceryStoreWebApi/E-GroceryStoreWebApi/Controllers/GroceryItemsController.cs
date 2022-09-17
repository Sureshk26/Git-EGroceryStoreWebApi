using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using E_GroceryStoreWebApi.DataAccess;
using E_GroceryStoreWebApi.Models;

namespace E_GroceryStoreWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroceryItemsController : ControllerBase
    {
        private readonly GroceryStoreDbContext _context;

        public GroceryItemsController(GroceryStoreDbContext context)
        {
            _context = context;
        }

        // GET: api/GroceryItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GroceryItemsModel>>> GetgroceryItemModel()
        {
            return await _context.groceryItemModel.ToListAsync();
        }

        // GET: api/GroceryItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GroceryItemsModel>> GetGroceryItemsModel(int id)
        {
            var groceryItemsModel = await _context.groceryItemModel.FindAsync(id);

            if (groceryItemsModel == null)
            {
                return NotFound();
            }

            return groceryItemsModel;
        }

        // PUT: api/GroceryItems/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGroceryItemsModel(int id, GroceryItemsModel groceryItemsModel)
        {
            if (id != groceryItemsModel.ItemId)
            {
                return BadRequest();
            }

            _context.Entry(groceryItemsModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GroceryItemsModelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/GroceryItems
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<GroceryItemsModel>> PostGroceryItemsModel(GroceryItemsModel groceryItemsModel)
        {
            _context.groceryItemModel.Add(groceryItemsModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGroceryItemsModel", new { id = groceryItemsModel.ItemId }, groceryItemsModel);
        }

        // DELETE: api/GroceryItems/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<GroceryItemsModel>> DeleteGroceryItemsModel(int id)
        {
            var groceryItemsModel = await _context.groceryItemModel.FindAsync(id);
            if (groceryItemsModel == null)
            {
                return NotFound();
            }

            _context.groceryItemModel.Remove(groceryItemsModel);
            await _context.SaveChangesAsync();

            return groceryItemsModel;
        }

        private bool GroceryItemsModelExists(int id)
        {
            return _context.groceryItemModel.Any(e => e.ItemId == id);
        }
    }
}
