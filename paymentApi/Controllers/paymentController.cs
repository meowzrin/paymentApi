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
        
        //[Route("ccn/{ccn}/cardHolder/{cardHolder}/expirationDate/{expirationDate}/amount/{amount}")]
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(PaymentResponse))]
        [ProducesResponseType(404)]
        public async Task<ActionResult<PaymentResponse>> ProcessPayment()
        {
            
            PaymentResponse paymentResponse = new PaymentResponse();
            PaymentData paymentData = new PaymentData
            {
                creditCardNumber = "7877845318451",
                cardHolder = "Tree",
                expirationDate = Convert.ToDateTime("24-07-2021"),
                amount=0
            };
            if (ModelState.IsValid)
            {
                paymentResponse = await _paymentBl.processData(paymentData);
            }
            else
            {
                paymentResponse.Status = "Invalid Data";
            }

                return paymentResponse;
        }

    }
}
