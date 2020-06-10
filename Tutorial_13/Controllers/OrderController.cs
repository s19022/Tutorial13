using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tutorial_13.DTOs.Request;
using Tutorial_13.DTOs.Responce;
using Tutorial_13.Exceptions;
using Tutorial_13.Models;

namespace Tutorial_13.Controllers
{
    [Route("api/orders")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly OrderDbContext _context;

        public OrderController(OrderDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetListOfOrders(OrderRequest requets)
        {
            try
            {
                return Ok(_context.GetListOfOrders(requets))    ;
            }catch(NoCustomerWithNameException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}