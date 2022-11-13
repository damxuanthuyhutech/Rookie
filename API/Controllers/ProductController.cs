using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ShareModel.DTO;
using ShareModel.DTO.Product;
using System.Drawing;
using System.Linq;
using System.Xml.Linq;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ProductController : ControllerBase
    {
        private readonly RookiesDbContext _context;


        //public IList<Product> Products { get; set; } = default!;



        public ProductController(RookiesDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult getAll()
        {

            var pro = _context.Products.ToList();
            return Ok(pro);
        }

        [HttpGet]
        [Route("get-all-products")]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> GetAllProducts()
        {
            return await _context.Products!
                            .Include(x => x.Category)
                            .Include(x => x.Ratings)
                            .Take(9)
                            .Select(x => new ProductDTO()
                            {
                                Price = x.Price,
                                Description = x.Description,
                                Category = x.Category.Name ?? "",
                                Author = x.Author,
                                //Discount = x.Discount,
                                Id = x.Id,
                                Quantity = x.Quantity,
                                Name = x.Name

                            })
                            .ToListAsync();
         
        }

        [HttpGet("[action]")]
        public async Task<ActionResult<int>> GetProductCount()
        {
            var products = await _context.Products!
                                .ToListAsync();
            return products.Count;
              
        }

        [HttpGet]
        [Route("search")]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> Search([FromQuery] SearchProductDto input)
        {
            var query = _context.Products!
                            .Include(x => x.Category)
                            .Include(x => x.Ratings)
                            .AsQueryable();

            if (!string.IsNullOrWhiteSpace(input.Category))
            {
                query = query.Where(e => e.Category.Name == input.Category);
            }
            if (!string.IsNullOrWhiteSpace(input.Search))
            {
                query = query.Where(e => e.Name == input.Search);
            }

            return await query.Skip(input.Skip.Value).Take(input.MaxResponse.Value)
                .Select(x => new ProductDTO()
                {
                    Price = x.Price,
                    Description = x.Description,
                    Category = x.Category.Name ?? "",
                    Author = x.Author,
                    //Discount = x.Discount,
                    Id = x.Id,
                    Quantity = x.Quantity,
                    Name = x.Name

                }).ToListAsync();

        }



        //[HttpGet("{id}")]
        //public IActionResult getById(int id)
        //{

        //    var loai = _context.Products.FirstOrDefault(l => l.Id == id);
        //    if (loai != null)
        //    {
        //        return Ok(loai);
        //    }
        //    else
        //    {
        //        return NotFound();
        //    }


        //}



        [HttpPost]
        public IActionResult CreateNew(ProductCreateDto productDTO)
        {
            try
            {
                var product = new Product
                {
                    Name = productDTO.Name,
                    Description = productDTO.Description,
                    Image = productDTO.Image,
                    Author = productDTO.Author,
                    Price = productDTO.Price,
                    Quantity = productDTO.Quantity,
                    CreatedDate = productDTO.CreatedDate,
                    UpdatedDate = productDTO.UpdatedDate,


                };
                _context.Products.Add(product);
                _context.SaveChanges();
                return Ok(product);
            }
            catch
            {
                return BadRequest();
            }


        }

        //[HttpPut("{id}")]
        //public IActionResult Update(int id, ProductDTO model)
        //{
        //    try
        //    {
        //        var pro = _context.Products.SingleOrDefault(l => l.Id == id);
        //        if (pro != null)
        //        {
        //            pro.Desciption = model.Desciption;
        //            pro.Discount = model.Discount;
        //            pro.NumberSold = model.NumberSold;
        //            pro.Price = model.Price;
        //            pro.Title = model.Title;
        //            pro.Content = model.Detail;
        //            pro.Detail = model.Detail;


        //            _context.SaveChanges();
        //            return Ok();
        //        }
        //        else
        //        {
        //            return NotFound();
        //        }
        //    }
        //    catch
        //    {
        //        return BadRequest();
        //    }


        //}

        //[HttpDelete("{id}")]
        //public IActionResult Delete(int Id)
        //{
        //    var pro = _context.Products.SingleOrDefault(l => l.Id == Id);
        //    if (pro != null)
        //    {

        //        _context.Remove(pro);
        //        _context.SaveChanges();

        //        return Ok();
        //    }
        //    else
        //    {
        //        return NotFound();
        //    }


        //}
        //-------------------------------------------------------
        [HttpPut("{id}")]
        //[HttpGet("[action]/{id}")]
        public async Task<ActionResult<ProductDTO>> Update(int id, ProductDTO productDTO)
        {
            var product = await _context.Products!
                                    .Include(x => x.Category)
                                    .Include(x => x.Ratings)
                                    .FirstOrDefaultAsync(product => product.Id == id);
            try
            {
                if (product != null)
                {
                    product.Name = productDTO.Name;
                    product.Description = productDTO.Description;
                    product.Image = productDTO.Image;
                    product.Author = productDTO.Author;
                    product.Price = productDTO.Price;
                    product.Quantity = productDTO.Quantity;
                    product.CreatedDate = productDTO.CreatedDate;
                    product.UpdatedDate = productDTO.UpdatedDate;

                    _context.SaveChanges();
                    return Ok();


                }
                else
                {
                    return NotFound();
                }
            }
            catch 
            {
                return BadRequest();
            }
           
        }

        [HttpGet("[action]/{CurrentPage}")]
        //[Route("get-paging-products")]
        public async Task<ActionResult<ProductDTO>> Paging(int CurrentPage)
        {
            int SizePage = 9;                  
            var product = await _context.Products!
                  .Include(x => x.Category)
                            .Include(x => x.Ratings)                     
                            .Select(x => new ProductDTO()
                            {
                                Price = x.Price,
                                Description = x.Description,
                                Category = x.Category.Name ?? "",
                                Author = x.Author,
                                Image = x.Image,
                                Id = x.Id,
                                Quantity = x.Quantity,
                                Name = x.Name

                            })
                            .Skip((CurrentPage - 1) * SizePage).Take(9).ToListAsync();
            try
            {
                if (product != null)
                {

                    return Ok(product);


                }
                else
                {
                    return NotFound();
                }
            }
            catch
            {
                return BadRequest();
            }

        }

        [HttpDelete("{id}")]
        
        public async Task<ActionResult<ProductDTO>> Delete(int id)
        {
            var product = await _context.Products!
                                    .Include(x => x.Category)
                                    .Include(x => x.Ratings)
                                    .FirstOrDefaultAsync(product => product.Id == id);
            if (product != null)
            {

                _context.Remove(product);
                _context.SaveChanges();

                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet("{id}")]
        //[HttpGet("[action]/{id}")]
        public async Task<ActionResult<ProductDTO>> GetProductById(int id)
        {
            var product = await _context.Products!
                                    .Include(x => x.Category)
                                    .Include(x => x.Ratings)
                                    .FirstOrDefaultAsync(product => product.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            return ProductDTO(product);
        }

        //[HttpPost("[action]")]
        //public async Task<ActionResult<Product>> CreateProduct(Product product)
        //{
        //    _context.Products!.Add(product);
        //    await _context.SaveChangesAsync();

        //    return Ok();
        //}
        private static ProductDTO ProductDTO(Product product)
        {
            var numberOfRating = product.Ratings.Count;
            var avgRating = numberOfRating > 0 ? Convert.ToDecimal(product.Ratings.Aggregate(0, (sum, rating) => sum + rating.Star)) / numberOfRating : 0;
            ProductDTO dto =  new ProductDTO()
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Image = product.Image,
                Author = product.Author,
                Price = product.Price,
                Quantity = product.Quantity,
                CreatedDate = product.CreatedDate,
                UpdatedDate = product.UpdatedDate,
                Category = product.Category?.Name ,
                AverageRating = avgRating
            };
            return dto;
        }

    }
}