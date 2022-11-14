using API.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.Data;
using Microsoft.AspNetCore.Razor.Language.Extensions;
using ShareModel.DTO.Rating;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RatingController : ControllerBase
    {
        private readonly RookiesDbContext _context;

        public RatingController(RookiesDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        public IActionResult getAll()
        {

            var pro = _context.Ratings!.ToList();
            return Ok(pro);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<RatingDTO>>> GetAllRatings(int id)
        {

            var result = await _context.Ratings!
                            .Include(x => x.Product)
                            .Include(x => x.User)
                            .Where(x => x.Product.Id == id)
                            .Select(x => new RatingDTO()
                            {
                                Title = x.Title,
                                Comment = x.Comment,
                                Star=x.Star,
                                UpdatedDate=x.UpdatedDate,
                                Reviewer = x.User.Name
                                
                            })
                            .ToListAsync();
            return result;
        }

        //[HttpPost("[action]")]
        [HttpPost]
        public async Task<ActionResult<Rating>> ReviewProduct(ReviewProductFormDTO reviewProductForm)
        {
            var product = await _context.Products!.FindAsync(reviewProductForm.ProductId);
            var user = await _context.Users!.FindAsync(reviewProductForm.UserId);
            if (user == null || product == null)
                return BadRequest();
            var rating = new Rating
            {
                Star = reviewProductForm.Star,
                Title = reviewProductForm.Title,
                Comment = reviewProductForm.Comment,
                UpdatedDate = new DateTime(),
                Product = product,
                User = user
            };
            _context.Ratings!.Add(rating);
            await _context.SaveChangesAsync();

            return Ok();
        }

        private static RatingDTO RatingDTO(Rating rating) =>
            new RatingDTO
            {
                Star = rating.Star,
                Title = rating.Title,
                Comment = rating.Comment,
                Reviewer = rating.User.Name,
                UpdatedDate = rating.UpdatedDate
            };


    }
}