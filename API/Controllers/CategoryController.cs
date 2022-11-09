using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShareModel.DTO;
using ShareModel.DTO.Category;
using ShareModel.DTO.Product;
using System;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {

        private readonly RookiesDbContext _context;

        public CategoryController(RookiesDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult getAll()
        {

            var pro = _context.Categories.ToList();
            return Ok(pro);
        }

        [HttpGet("{id}")]
        public IActionResult getById(int id)
        {

            var loai = _context.Categories.Where(l => l.Id == id).ToList(); ;
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
        public IActionResult CreateNewCategories(CategoryCreateDto productDTO)
        {
            try
            {
                var category = new Category
                {
                    Name = productDTO.Name,
                    Description = productDTO.Description,
                


                };
                _context.Categories.Add(category);
                _context.SaveChanges();
                return Ok(category);
            }
            catch
            {
                return BadRequest();
            }

        }

        [HttpPut("{id}")]
        //[HttpGet("[action]/{id}")]
        public async Task<ActionResult<CategoryDTO>> Update(int id, CategoryDTO categoryDTO)
        {
            var category = await _context.Categories!.FirstOrDefaultAsync(Category => Category.Id == id);
                                    
                                    
            try
            {
                if (category != null)
                {
                    category.Name = categoryDTO.Name;
                    category.Description = category.Description;

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
        //[HttpGet("[action]/{id}")]
        public async Task<ActionResult<CategoryDTO>> Delete(int id)
        {
            var category = await _context.Categories!.FirstOrDefaultAsync(Category => Category.Id == id);


            if (category != null)
            {

                _context.Remove(category);
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

