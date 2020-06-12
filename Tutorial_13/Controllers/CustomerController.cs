using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tutorial_13.DTOs.Request;
using Tutorial_13.Exceptions;
using Tutorial_13.Models;
using Tutorial_13.Services;

namespace Tutorial_13.Controllers
{
    [Route("api/customer")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IOrderDbService _service;

        public CustomerController(IOrderDbService service)
        {
            _service = service;
        }


        [HttpGet("{id}/orders")]
        public IActionResult AddOrder(int id, AddOrderRequest request)
        {
            try
            {

                var res = _service.AddOrder(id, request);
                return Ok(res);
            }/*catch(NoSuchCustomerException | NoSuchConfectioneryException ex)
                {
                    return BadRequest(ex.Message);
                }*/         // tried to do like that(works in Java) but failed and didn't find solution :(
            catch (NoSuchCustomerException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (NoSuchConfectioneryException e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}