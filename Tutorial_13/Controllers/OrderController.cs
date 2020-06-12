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
using Tutorial_13.Services;

namespace Tutorial_13.Controllers
{
    [Route("api/orders")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderDbService _service;

        public OrderController(IOrderDbService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetListOfOrders(GetOrdersRequest requets)
        {
            try
            {
                return Ok(_service.GetListOfOrders(requets))    ;
            }catch(NoSuchCustomerException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}