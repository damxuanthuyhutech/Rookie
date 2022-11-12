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


        //[HttpPost]
        //public async Task<IActionResult> CreateNewAsync(OrderLinesCreateDTO orderLinesDTO)
        //{
        //    try
        //    {
        //        var order = await _context.Orders?.FirstOrDefaultAsync(o => o.Id == orderLinesDTO.Order);
        //        var product = await _context.Products?.FirstOrDefaultAsync(o => o.Id == orderLinesDTO.Product);

        //        var alreadyUserId = await _context.OrderLines?.FirstOrDefaultAsync(t => t.Product == product);
        //        var alreadyProductId = await _context.OrderLines?.FirstOrDefaultAsync(t => t.Order == order);

        //        OrderLine orderLines;
        //        if (alreadyUserId == null && alreadyProductId == null)
        //        {
        //            orderLines = new OrderLine
        //            {

        //                Quantity = orderLinesDTO.Quantity,
        //                Order = order,
        //                Product = product,
        //            };
        //            await _context.OrderLines.AddAsync(orderLines);
        //            await _context.SaveChangesAsync();
        //            return Ok(orderLines);

        //        }
        //        else
        //        {
        //            Console.WriteLine("ngu");
        //        }

        //        return Ok(orderLinesDTO);
               
        //    }
        //    catch
        //    {
        //        return BadRequest();
        //    }


        //}

        [HttpPost("[action]")]
        public async Task<ActionResult> OrderLineForm(OrderLinesFormDTO orderLinesFormDTO)
        {
            var alreadyUserId = await _context.OrderLines!
                .Include(c => c.Product)
                .Include(c => c.Order)
                .FirstOrDefaultAsync(t => t.Product.Id == orderLinesFormDTO.Product && t.Order.Id == orderLinesFormDTO.Order);

            //var alreadyProductId = await _context.OrderLines?.FirstOrDefaultAsync(t => t.Order == order);
            if (alreadyUserId != null)
            {           
                alreadyUserId.Quantity += orderLinesFormDTO.Quantity;
                _context.SaveChanges();
                return Ok();
            } 
            else
            {
                var product = await _context.Products!.FindAsync(orderLinesFormDTO.Product);
                var order = await _context.Orders!.FindAsync(orderLinesFormDTO.Order);

                if (product == null || order == null)
                {
                    return BadRequest();
                }

                var orderLine = new OrderLine
                {
                    Quantity = orderLinesFormDTO.Quantity,
                    Order = order,
                    Product = product
                };
                _context.OrderLines!.Add(orderLine);
                await _context.SaveChangesAsync();
                return Ok();
            }
    
        }

        [HttpGet("[action]/{id}")]
        public async Task<ActionResult<OrderLinesDTO>> AddQuantity(int id)
        {

            var orderLines = await _context.OrderLines!.Where(l => l.Id == id).FirstOrDefaultAsync();
            if (orderLines != null)
            {
                orderLines.Quantity = orderLines.Quantity + 1;
                _context.SaveChanges();
                return Ok(orderLines);
            }
            else
            {
                return NotFound();
            }


        }

        [HttpGet("[action]/{id}")]
        public async Task<ActionResult<OrderLinesDTO>> TruQuantity(int id)
        {

            var orderLines = await _context.OrderLines!.Where(l => l.Id == id).FirstOrDefaultAsync();
            if (orderLines != null)
            {
                orderLines.Quantity = orderLines.Quantity - 1;
                if (orderLines.Quantity == 0)
                {
                    _context.Remove(orderLines);
                    _context.SaveChanges();

                    return Ok();
                }
                _context.SaveChanges();
                return Ok(orderLines);
            }
            else
            {
                return NotFound();
            }


        }

        [HttpGet("[action]/{id}")]
        public async Task<ActionResult<OrderLinesDTO>> Delete(int id)
        {
            var orderLines = await _context.OrderLines!
                                    .Include(x => x.Product)
                                    .Include(x => x.Order)
                                    .FirstOrDefaultAsync(c => c.Id == id);
            if (orderLines != null)
            {

                _context.Remove(orderLines);
                _context.SaveChanges();

                return Ok();
            }
            else
            {
                return NotFound();
            }
        }


        [HttpGet("[action]")]
        public async Task<ActionResult<OrderLinesDTO>> GetAllOrther()
        {
            var prop =  await _context.OrderLines!
                           .Include(x => x.Product)
                           .Include(x => x.Order)                        
                           .Select(x => new OrderLinesDTO()
                           {
                               Id = x.Id,
                               Quantity = x.Quantity,
                               Order = x.Order.User.Id,
                               Product = x.Product.Name,

                           })
                           .ToListAsync();

            return Ok(prop);

        }

    }
}
