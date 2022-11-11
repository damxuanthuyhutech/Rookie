using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShareModel.DTO;
using ShareModel.DTO.Product;
using ShareModel.DTO.OrderLines;

using System.Data;
using System.Security.AccessControl;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderLinesController : ControllerBase
    {
        private readonly RookiesDbContext _context;


        //public IList<Product> Products { get; set; } = default!;



        public OrderLinesController(RookiesDbContext context)
        {
            _context = context;
        }


        [HttpGet("{id}")]
        //[Route("get-all-OrderLines")]
        public async Task<ActionResult<IEnumerable<OrderLinesDTO>>> GetAllOrderLines(int id)
        {
            return  await _context.OrderLines!
                                  .Include(x => x.Order)
                                  .Include(x => x.Product)
                                  .Where(x => x.Order.Id == id)
                                  .Select(x => new OrderLinesDTO()
                                  {
                                      Id = x.Id,
                                      Quantity = x.Quantity,
                                      Order = x.Order.User.Id,
                                      Product = x.Product.Name,
                                      PriceProduct = x.Product.Price,
                                  })
                                  .ToListAsync();


                                 
            //return await _context.OrderLines!
            //                .Include(x => x.Order)
            //                .Include(x => x.Product)

            //                .Select(x => new OrderLinesDTO()
            //                {
            //                    Id = x.Id,
            //                    Quantity = x.Quantity,
            //                    Order = x.Order.User.Id,
            //                    Product = x.Product.Name,
            //                    PriceProduct = x.Product.Price,



            //                })
            //                .ToListAsync();

        }


        [HttpPost]
        public async Task<IActionResult> CreateNewAsync(OrderLinesCreateDTO orderLinesDTO)
        {
            try
            {
                var order = await _context.Orders?.FirstOrDefaultAsync(o => o.Id == orderLinesDTO.Order);
                var product = await _context.Products?.FirstOrDefaultAsync(o => o.Id == orderLinesDTO.Product);

                var orderLines = new OrderLine
                {

                    Quantity = orderLinesDTO.Quantity,
                    Order = order,
                    Product = product,
                };
                await _context.OrderLines.AddAsync(orderLines);
                await _context.SaveChangesAsync();
                return Ok(orderLines);
            }
            catch
            {
                return BadRequest();
            }


        }

        [HttpPost("[action]")]
        public async Task<ActionResult<OrderLine>> OrderLineForm(OrderLinesFormDTO orderLinesFormDTO)
        {
            var product = await _context.Products!.FindAsync(orderLinesFormDTO.Product);
            //var user = await _context.Users!.FindAsync(orderLinesFormDTO.Order);
            var order = await _context.Orders?.FirstOrDefaultAsync(o => o.Id == orderLinesFormDTO.Order);

            if (order == null || product == null)
                return BadRequest();
            var orderLine = new OrderLine
            {
                Quantity = orderLinesFormDTO.Quantity,
                Order = order,
                Product = product,
                

            };
            _context.OrderLines!.Add(orderLine);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
