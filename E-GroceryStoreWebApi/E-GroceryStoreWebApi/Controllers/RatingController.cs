using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using E_GroceryStoreWebApi.DataAccess;
using E_GroceryStoreWebApi.Models;
using log4net;

namespace E_GroceryStoreWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RatingController : ControllerBase
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private readonly GroceryStoreDbContext _context;

        public RatingController(GroceryStoreDbContext context)
        {
            _context = context;
        }

        // GET: api/Rating
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RatingModel>>> GetratingModel()
        {
            return await _context.ratingModel.ToListAsync();
        }

        // GET: api/Rating/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RatingModel>> GetRatingModel(int id)
        {
            var ratingModel = await _context.ratingModel.FindAsync(id);

            if (ratingModel == null)
            {
                return NotFound();
            }

            return ratingModel;
        }

        // PUT: api/Rating/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRatingModel(int id, RatingModel ratingModel)
        {
            if (id != ratingModel.RatingId)
            {
                return BadRequest();
            }

            _context.Entry(ratingModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RatingModelExists(id))
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

        // POST: api/Rating
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<RatingModel>> PostRatingModel(RatingModel ratingModel)
        {
            _context.ratingModel.Add(ratingModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRatingModel", new { id = ratingModel.RatingId }, ratingModel);
        }

        // DELETE: api/Rating/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<RatingModel>> DeleteRatingModel(int id)
        {
            var ratingModel = await _context.ratingModel.FindAsync(id);
            if (ratingModel == null)
            {
                return NotFound();
            }

            _context.ratingModel.Remove(ratingModel);
            await _context.SaveChangesAsync();

            return ratingModel;
        }

        private bool RatingModelExists(int id)
        {
            return _context.ratingModel.Any(e => e.RatingId == id);
        }
    }
}
