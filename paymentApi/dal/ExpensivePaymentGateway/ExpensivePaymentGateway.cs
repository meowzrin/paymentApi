using paymentApi.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace paymentApi.dal.ExpensivePaymentGateway
{
    public class ExpensivePaymentGateway : IExpensivePaymentGateway
    {
        //private readonly IHttpClientFactory _clientFactory;

        public ExpensivePaymentGateway(/*IHttpClientFactory clientFactory*/)
        {
            //_clientFactory = clientFactory;
        }

        public PaymentResponse processPayment(PaymentData paymentInfo)
        {
            // Connect to external service to process payment
            PaymentResponse responseData = new PaymentResponse();
            responseData.Status = "Success";
            return responseData;
        }
    }
}
