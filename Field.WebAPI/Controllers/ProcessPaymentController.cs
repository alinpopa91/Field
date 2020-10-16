using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Field.BLL.Models;
using Field.BLL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Field.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProcessPaymentController : ControllerBase
    {
        private readonly IProcessPaymentService _processPaymentService;

        public ProcessPaymentController(IProcessPaymentService paymentService)
        {
            _processPaymentService = paymentService;
        }

        [HttpPost]
        public ActionResult Post([FromBody] ProcessPaymentRequest request)
        {
            if (request == null)
                return StatusCode(StatusCodes.Status400BadRequest);

            var rsp = _processPaymentService.ProcessPayment(request);

            var result = JsonConvert.SerializeObject(rsp, Formatting.None);

            return new JsonResult(result, new JsonSerializerOptions
            {
                WriteIndented = true,
            });

            //if (rsp.Success)
            //{
            //    return StatusCode(StatusCodes.Status200OK);
            //}
            //else
            //{
            //    return StatusCode(StatusCodes.Status500InternalServerError);
            //}

            //return new JsonResult(new { id = rsp.Success, message = rsp.Message });
        }

    }
}