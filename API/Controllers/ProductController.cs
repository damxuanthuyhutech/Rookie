﻿using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ShareModel.DTO;
using ShareModel.DTO.Product;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly RookiesDbContext _context;


        public IList<Product> Products { get; set; } = default!;
       


        public ProductController(RookiesDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult getAll()
        {

            var pro = _context.products.ToList();
            return Ok(pro);
        }

        [HttpGet]
        [Route("get-all-products")]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> GetAllProducts()
        {
            return await _context.products!
                            .Include(x => x.Category)
                            .Take(9)
                            .Select(x => new ProductDTO()
                            {
                                Price = x.Price,
                                Content = x.Content,
                                Category = x.Category.Title ?? "", // Use ID not use name or title ?
                                Desciption = x.Desciption,
                                Detail = x.Detail,
                                Discount = x.Discount,
                                Id = x.Id,
                                NumberSold = x.NumberSold ,
                                Title = x.Title ?? ""
                            })
                            .ToListAsync();
        }



        [HttpGet("{id}")]
        public IActionResult getById(int id)
        {

            var loai = _context.products.FirstOrDefault(l => l.Id == id);
            if (loai != null)
            {
                return Ok(loai);
            }
            else
            {
                return NotFound();
            }


        }

        

        [HttpPost]
        //[Authorize]
        public IActionResult CreateNew(ProductCreateDto productDTO)
        {
            try
            {
                var product = new Product
                {
                   AverageRating  = productDTO.AverageRating,
                   CreatedDate = productDTO.CreatedDate,
                   Desciption = productDTO.Desciption,
                   Discount = productDTO.Discount,
                   MetaTitle  = productDTO.MetaTitle,
                   NumberRating = productDTO.NumberRating,
                   NumberSold = productDTO.NumberSold,
                   Price = productDTO.Price,
                   Quantity = productDTO.Quantity,
                   Title = productDTO.Title,
                   UpdatedDate = productDTO.UpdatedDate,
                   Content = productDTO.Content,
                   Detail = productDTO.Detail,
                   Active = productDTO.Active,
                   
                };
                _context.products.Add(product);
                _context.SaveChanges();
                return Ok(product);
            }
            catch
            {
                return BadRequest();
            }


        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, ProductDTO model)
        {
            try
            {
                var pro = _context.products.SingleOrDefault(l => l.Id == id);
                if (pro != null)
                {
                    pro.Desciption = model.Desciption;
                    pro.Discount = model.Discount;
                    pro.NumberSold = model.NumberSold;
                    pro.Price = model.Price;
                    pro.Title = model.Title;
                    pro.Content = model.Detail;
                    pro.Detail = model.Detail;


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

        [HttpDelete("{id}")]
        public IActionResult Delete(int Id)
        {
            var pro = _context.products.SingleOrDefault(l => l.Id == Id);
            if (pro != null)
            {

                _context.Remove(pro);
                _context.SaveChanges();

                return Ok();
            }
            else
            {
                return NotFound();
            }
        }
    }
}