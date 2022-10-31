using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShareModel.DTO;
using ShareModel.DTO.Category;
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



        //[HttpPost]
        ////[Authorize]
        //public IActionResult CreateNew(CategoryCreateDto category)
        //{
        //    try
        //    {
        //        var ca = new Category
        //        {
        //            Active = category.Active,
        //            Title = category.Title,
        //            ParentID = category.ParentID,
        //            Href = category.Href,
        //        };
        //        _context.categories.Add(ca);
        //        _context.SaveChanges();
        //        return Ok(ca);
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest();
        //    }


        //}

        //[HttpPut("{id}")]
        //public IActionResult Update(int id, Category ca)
        //{
        //    try
        //    {
        //        var category = _context.Categories.SingleOrDefault(l => l.Id == id);
        //        if (category != null)
        //        {

        //            category.Active = ca.Active;
        //            category.Title = ca.Title;
        //            category.ParentID = ca.ParentID;
        //            category.Href = ca.Href;


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

        [HttpDelete("{id}")]
        public IActionResult Delete(int Id)
        {
            var category = _context.Categories.SingleOrDefault(l => l.Id == Id);
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

