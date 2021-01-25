using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using paymentApi.domain;

namespace paymentApi.bl
{
   
    public interface IPaymentBl
    {
        Task<PaymentResponse> processData(PaymentData paymentInfo);
    }
}
