using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using paymentApi.bl;
using paymentApi.domain;
using System;
using System.Threading.Tasks;

namespace paymentApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class paymentController : ControllerBase
    {
        private readonly ILogger<paymentController> _logger;
        private readonly IPaymentBl _paymentBl;

        public paymentController(ILogger<paymentController> logger, IPaymentBl paymentBl)
        {
            _logger = logger;
            _paymentBl = paymentBl;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(PaymentResponse))]
        [ProducesResponseType(404)]
        public async Task<ActionResult<PaymentResponse>> ProcessPayment([FromQuery] PaymentData paymentData)
        {

            PaymentResponse paymentResponse = new PaymentResponse();

            paymentResponse = await _paymentBl.processData(paymentData);

            return Ok(paymentResponse);
        }

    }
}
