using paymentApi.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace paymentApi.dal.CheapPaymentGateway
{
    public class CheapPaymentGateway : ICheapPaymentGateway
    {
        //private readonly IHttpClientFactory _clientFactory;

        public CheapPaymentGateway(/*IHttpClientFactory clientFactory*/)
        {
            //_clientFactory = clientFactory;
        }
        

        public Task<PaymentResponse> processPayment(PaymentData paymentInfo)
        {
            throw new NotImplementedException();
        }
    }
}
