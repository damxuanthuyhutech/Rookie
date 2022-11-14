using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API.Controllers;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol;


namespace UnitTest
{
    public class ProductControllerUnitTest : IDisposable
    {
        private readonly DbContextOptions<RookiesDbContext> _options;
        private readonly RookiesDbContext _context;
        private readonly List<Product> _products;

        public ProductControllerUnitTest()
        {
            _options = new DbContextOptionsBuilder<RookiesDbContext>().UseInMemoryDatabase("CategoryTestDB").Options;
            _context = new RookiesDbContext(_options);
            _products = new()
            {
                new Product(){Id=1, Name="Cat 1", Description="Product 1", Image = "1.jpg", Author = "product1", Price = 2, Quantity = 2, CreatedDate = DateTime.Now , UpdatedDate = DateTime.Now },
                new Product(){Id=2, Name="Cat 2", Description="Product 2", Image = "2.jpg", Author = "product2", Price = 2, Quantity = 2, CreatedDate = DateTime.Now , UpdatedDate = DateTime.Now },
                new Product(){Id=1, Name="Cat 3", Description="Product 3", Image = "3.jpg", Author = "product3", Price = 2, Quantity = 2, CreatedDate = DateTime.Now , UpdatedDate = DateTime.Now },
            };

            _context.Database.EnsureDeleted();
            _context.Products?.AddRange(_products);
            _context.SaveChanges();
        }

        //[Fact]
        //public void getAll()
        //{
        //    CategoryController categoryController = new(_context);

        //    List<Category> result = categoryController.getAll().Result;
        //    Assert.NotNull(result);
        //    Assert.Equivalent(_categories.ToJson(), result.ToJson());

        //}

        //[Theory]
        //[InlineData(1)]
        //[InlineData(2)]
        //[InlineData(3)]
        //public void getByIdNotNull(int id)
        //{

        //    CategoryController categoryController = new(_context);

        //    var objResult = categoryController.getById(id).Result.Result as ObjectResult ;

        //    Category? result = (Category?)objResult.Value;

        //    Assert.NotNull(result);
        //    Assert.Equivalent(_categories.FirstOrDefault(c => c.Id == id), result);


        //}

        //[Theory]
        //[InlineData("Cat 1", "Category 1")]
        //public void CreateNewCategories(string name, string description)
        //{
        //    CategoryCreateDto categoryDTO = new()
        //    {
        //       Name = name,
        //       Description = description
        //    };

        //    CategoryController categoryController = new(_context);
        //    var objResult = categoryController.CreateNewCategories(categoryDTO).Result.Result as ObjectResult;
        //    Category? result = (Category?)objResult?.Value;
        //    Assert.NotNull(result);
        //    Assert.Equivalent(_context.Categories?.LastOrDefault(), result);
        //}

        //[Theory]
        //[InlineData(1)]
        //public void Delete(int id)
        //{
        //    CategoryController categoryController = new(_context);
        //    var result = categoryController.Delete(id).Result;
        //    Assert.NotNull(result);
        //    Assert.IsType<OkResult>(result);
        //    Assert.Null(_context.Categories.FirstOrDefault(c => c.Id == id));

        //}

        public void Dispose()
        {
            _context.Database.EnsureDeleted();
            _context.Dispose();

        }
    }
}
